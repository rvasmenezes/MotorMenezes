using Serilog.Events;

namespace MotorMenezes.Infra.Log.Entries
{
    public class LogEntry
    {
        public string? Action { get; set; }
        public string Title { get; set; }
        public object? Content { get; set; }
        public string? RequestKey { get; set; }
        public LogEventLevel Level { get; set; }
        public Exception? Exception { get; set; }

        public LogEntry(
            string title,
            string? action,
            object? content = null,
            LogEventLevel? lvl = null,
            Exception? exception = null,
            string? requestKey = null)
        {
            Title = title;
            Action = action;
            Content = content;
            Level = lvl ?? LogEventLevel.Information;
            RequestKey = requestKey;
            Exception = exception;
        }

    }
}
