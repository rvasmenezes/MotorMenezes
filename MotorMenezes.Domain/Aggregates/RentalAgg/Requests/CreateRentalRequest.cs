using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;
using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.RentalAgg.Requests
{
    public class CreateRentalRequest
    {
        [Display(Name = "Plano")]
        [Range(1, int.MaxValue, ErrorMessage = "Plano é obrigatório")]
        public int PlanId { get; set; }

        [Display(Name = "Data final aluguél")]
        [Required(ErrorMessage = "Data final aluguél é obrigatória")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(2).Date;

        [Display(Name = "Data inicial aluguél")]
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(1).Date;

        public List<Plan> PlanList { get; set; } = new();
    }
}
