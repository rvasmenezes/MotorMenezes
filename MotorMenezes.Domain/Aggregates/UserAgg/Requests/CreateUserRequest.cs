using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.UserAgg.Requests
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "O Name é obrigatório")]
        public string? Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? PasswordConfirmation { get; set; }
    }
}
