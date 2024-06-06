using Microsoft.Extensions.Configuration;
using MotorMenezes.Infra.Log.Entries;
using MotorMenezes.Infra.Log.Extensions;
using MotorMenezes.Infra.Log.Seedwork;

namespace MotorMenezes.Infra.Log.Providers
{
    public partial class LoggerProvider : ILogger
    {
        private readonly Serilog.ILogger _logger;
        private readonly Microsoft.Extensions.Logging.ILogger _nativeLogger;

        public LoggerProvider(IConfiguration configuration)
        {
            _logger = LoggerFactory.CreateLog(configuration);
            _nativeLogger = new Microsoft.Extensions.Logging.Logger<LoggerProvider>(Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance);
        }

        public async Task WriteAsync(LogEntry entry)
        {
            await Task.Run(() => _logger.Write(entry));
        }

        public async Task WriteHttpEntryAsync(LogHttpEntry entry)
        {
            await Task.Run(() => _logger.WriteHttpLog(entry));
        }

        public async Task WriteError(Exception ex, LogEntry entry)
        {
            entry.Level = Serilog.Events.LogEventLevel.Error;
            await Task.Run(() =>
               _logger.Write(entry)
            );
        }
    }
}
