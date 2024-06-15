namespace MotorMenezes.Domain.Aggregates.MotorcycleAgg.Requests
{
    public class CreateOrEditMotorcycleRequest
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public string? Model { get; set; }
        public string? Plate { get; set; }
    }
}
