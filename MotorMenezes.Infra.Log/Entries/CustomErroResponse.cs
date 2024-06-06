namespace MotorMenezes.Infra.Log.Entries
{
    public class CustomErroResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
