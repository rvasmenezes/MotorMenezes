namespace MotorMenezes.Domain.Aggregates.RentalAgg.Response
{
    public class CalculateResponse
    {
        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal PercentageFine { get; set; }
        public int DaysRented { get; set; }
        public int DaysNotRented { get; set; }
        public decimal CostFine { get; set; }
        public int ExtraDaysRented { get; set; }
    }
}
