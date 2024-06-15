using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;
using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.RentalAgg.Entities
{
    public class Rental
    {
        [Key]
        [StringLength(255)]
        public string Id { get; set; }

        [StringLength(255)]
        public string UserId { get; set; }
        public User? User { get; set; }

        public int PlanId { get; set; }
        public Plan? Plan { get; set; }

        public DateTime RegiterDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Rental(string userId, int planId, DateTime endDate)
        {
            Id = Guid.NewGuid().ToString();
            UserId = userId;
            PlanId = planId;
            RegiterDate = DateTime.Now.ToUniversalTime();
            StartDate = DateTime.Now.ToUniversalTime().AddDays(1);
            EndDate = endDate.ToUniversalTime();
        }
    }
}
