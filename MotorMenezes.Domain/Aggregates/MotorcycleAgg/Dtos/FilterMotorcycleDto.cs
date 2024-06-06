namespace MotorMenezes.Domain.Aggregates.MotorcycleAgg.Dtos
{
    public class FilterMotorcycleDto
    {
        public string? Plate { get; set; }

        public string BtnSearchDisplay
        {
            get
            {

                if (!string.IsNullOrEmpty(Plate))
                    return "";

                return "display: none;";
            }
        }
    }
}
