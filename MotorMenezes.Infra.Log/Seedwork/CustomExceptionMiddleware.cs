using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.IO;
using MotorMenezes.Infra.Log.Entries;
using MotorMenezes.Infra.Log.Filters;
using MotorMenezes.Infra.Log.Providers;
using Newtonsoft.Json;
using System.Net;

namespace MotorMenezes.Infra.Log.Seedwork
{
    public class CustomExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        public readonly IConfiguration _configuration;

        public CustomExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, ILogger logger)
        {
            var idRequest = Guid.NewGuid().ToString();

            try
            {
                await LogRequest(context, logger);
                await _next(context);
            }
            catch (Exception ex)
            {
                var entry = new LogEntry(
                    $"Internal Server Error",
                    context.Request.Path.Value.Split("/").Last(),
                    null,
                    Serilog.Events.LogEventLevel.Error,
                    ex,
                    idRequest
                );

                await logger.WriteAsync(entry);

                context.Response.Redirect("/Erro/InternalError");
            }
        }

        private async Task LogRequest(HttpContext context, ILogger logger)
        {
            using (var requestStream = _recyclableMemoryStreamManager.GetStream())
            {
                var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
                var attributeOvershadowFieldsLog = endpoint?.Metadata.GetMetadata<OvershadowFieldsLog>();

                context.Request.EnableBuffering();
                await context.Request.Body.CopyToAsync(requestStream);

                var details = context.Request.Path.Value.Split("/");
                var method = context.Request.Method;

                if (details.Count() >= 3 && method != "GET" && method != "OPTIONS")
                {
                    var section = _configuration.GetSection("Log");

                    var log = new LogHttpEntry(
                        $"[{section["Domain"]}][{details[1]}][{details.Last()}]",
                        ReadStreamInChunks(requestStream, attributeOvershadowFieldsLog),
                        Serilog.Events.LogEventLevel.Information,
                        method,
                        "", //IP
                        details.Last(),
                        details[1],
                        context.Request.QueryString.ToString(),
                        context.Request.Scheme + "://" + context.Request.Host,
                        context.Request.Host.ToString()
                    );

                    if (log?.Content?.ToString()?.Length > 262144) log.Content = "CONTENT TO LARGE";

                    await logger.WriteHttpEntryAsync(log!);
                }

                context.Request.Body.Position = 0;
            }
        }

        private static string ReadStreamInChunks(Stream stream, OvershadowFieldsLog? overshadowFieldsLog)
        {
            try
            {
                const int readChunkBufferLength = 4096;

                stream.Seek(0, SeekOrigin.Begin);

                using (var textWriter = new StringWriter())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var readChunk = new char[readChunkBufferLength];
                        int readChunkLength;
                        do
                        {
                            readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                            textWriter.Write(readChunk, 0, readChunkLength);
                        } while (readChunkLength > 0);

                        var textReturn = textWriter.ToString();

                        if (overshadowFieldsLog != null)
                        {
                            var fields = overshadowFieldsLog.Fields.Split(",");

                            var jsonRequest = textReturn.ToString().Split("&");

                            textReturn = "";

                            for (int i = 0; i < jsonRequest.Length; i++)
                            {

                                var exist = false;

                                foreach (var f in fields)
                                {
                                    if (jsonRequest.Length > i && jsonRequest[i].ToUpper().Contains(f.ToUpper().Trim()))
                                    {
                                        exist = true;
                                        var field = jsonRequest[i].ToString().Split("=");
                                        textReturn += field[0] + @"= ""XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX""";
                                    }
                                }

                                if (!exist)
                                    textReturn += jsonRequest[i];
                            }

                            textReturn += "\r\n}";
                        }

                        return textReturn;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static async Task HandleErrorAsync(HttpContext context, LogEntry logEntry)
        {
            var errorResponse = new CustomErroResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = logEntry.Exception!.Message,
                StackTrace = string.IsNullOrEmpty(logEntry.Exception.StackTrace) ? "" : logEntry.Exception.StackTrace
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
