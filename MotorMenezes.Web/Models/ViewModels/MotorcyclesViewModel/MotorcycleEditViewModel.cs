using MotorMenezes.Web.Validation;
using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel
{
    public class MotorcycleEditViewModel
    {
        [Required(ErrorMessage = "Id é obrigatório!")]
        public string Id { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Placa é obrigatória!")]
        [StringLength(100)]
        [PlateValidation]
        public string Plate { get; set; }
    }
}
