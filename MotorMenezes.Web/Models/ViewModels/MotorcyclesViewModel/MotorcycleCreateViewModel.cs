using MotorMenezes.Web.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel
{
    public class MotorcycleCreateViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Ano")]
        [Required(ErrorMessage = "Ano é obrigatório!")]
        public int Year { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Modelo é obrigatório!")]
        [StringLength(100)]
        public string Model { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Placa é obrigatória!")]
        [StringLength(100)]
        [PlateValidation]
        public string Plate { get; set; }

        public List<int> YearList { get; set; }
    }
}
