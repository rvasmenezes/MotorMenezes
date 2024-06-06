using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;
using MotorMenezes.Domain.Aggregates.RentalAgg.Entities;
using System.Collections.Generic;

namespace MotorMenezes.Web.Models.ViewModels.RentalViewModel
{
    public class RentalListViewModel
    {
        public List<Rental> RentalList { get; set; }
        public List<Plan> PlanList { get; set; }
    }
}
