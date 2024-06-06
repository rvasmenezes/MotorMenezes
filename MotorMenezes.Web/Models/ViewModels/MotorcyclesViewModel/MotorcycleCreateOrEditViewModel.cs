using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel
{
    public class MotorcycleCreateOrEditViewModel
    {
        public int Id { get; set; }

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
        public string Plate { get; set; }
    }
}
