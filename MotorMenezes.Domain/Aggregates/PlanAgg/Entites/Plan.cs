using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.PlanAgg.Entites
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }

        public int Day { get; set; }

        public decimal CostPerDay { get; set; }

        public decimal PercentageFine { get; set; }

        public Plan(int day, decimal costPerDay, decimal percentageFine)
        {
            Day = day;
            CostPerDay = costPerDay;
            PercentageFine = percentageFine;
        }
    }
}
