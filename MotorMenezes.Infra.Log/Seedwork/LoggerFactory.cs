using Destructurama;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace MotorMenezes.Infra.Log.Seedwork
{
    public class LoggerFactory
    {
        public static ILogger CreateLog(IConfiguration configuration)
        {
            var section = configuration.GetSection("Log");

            var loggerConfiguration = new LoggerConfiguration()
                 .Enrich.WithProperty("Domain", section["Domain"])
                 .Enrich.WithProperty("Application", section["Application"])
                 .Enrich.WithProperty("ProductVersion", section["ProductVersion"])
                 .Enrich.WithProperty("MachineName", Environment.MachineName)
                 .Enrich.FromLogContext();

            if (!string.IsNullOrEmpty(section["SerilogSeqUri"]))
                loggerConfiguration
                    .WriteTo.Seq(serverUrl: section["SerilogSeqUri"]);

            loggerConfiguration.Destructure.JsonNetTypes();
            loggerConfiguration.Destructure.UsingAttributes();

            return loggerConfiguration.CreateLogger();
        }
    }
}
