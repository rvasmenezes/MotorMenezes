using MotorMenezes.Infra.Log.Entries;

namespace MotorMenezes.Infra.Log.Providers
{
    public interface ILogger
    {
        Task WriteAsync(LogEntry entry);
        Task WriteHttpEntryAsync(LogHttpEntry entry);
    }
}
