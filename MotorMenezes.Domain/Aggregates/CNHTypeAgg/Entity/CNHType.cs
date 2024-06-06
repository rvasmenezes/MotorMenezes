using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity
{
    public class CNHType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string Description { get; set; }
    }
}
