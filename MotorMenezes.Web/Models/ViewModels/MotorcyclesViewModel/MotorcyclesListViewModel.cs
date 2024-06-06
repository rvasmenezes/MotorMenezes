using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Dtos;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using System.Collections.Generic;

namespace MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel
{
    public class MotorcyclesListViewModel
    {
        public FilterMotorcycleDto FilterMotorcycleDto { get; set; }
        public List<Motorcycle> MotorcycleList { get; set; }
    }
}
