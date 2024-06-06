using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.RentalAgg.Requests
{
    public class CalculateRequest
    {
        [Required(ErrorMessage = "Plano é obrigatório")]
        public int PlanId { get; set; }

        public DateTime EndDate { get; set; }
    }
}
