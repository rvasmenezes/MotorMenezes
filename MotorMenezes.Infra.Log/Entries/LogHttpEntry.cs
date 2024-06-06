using Serilog.Events;

namespace MotorMenezes.Infra.Log.Entries
{
    public class LogHttpEntry : LogEntry
    {
        public string? Method { get; set; }
        public string? IpAddress { get; set; }
        public string? Query { get; set; }
        public string? Url { get; set; }
        public string? Controller { get; set; }

        public LogHttpEntry(
                string title,
                object? content = null,
                LogEventLevel? lvl = null,
                string? method = null,
                string? ipAddress = null,
                string? action = null,
                string? controller = null,
                string? query = null,
                string? uri = null,
                string? requestKey = null
            ) : base(title, action, content, lvl, null, requestKey)
        {
            Method = method;
            IpAddress = ipAddress;
            Action = action;
            Query = query;
            Url = uri;
            Controller = controller;
        }
    }

}
