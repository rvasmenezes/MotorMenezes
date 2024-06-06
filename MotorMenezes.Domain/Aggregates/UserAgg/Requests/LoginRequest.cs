﻿using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.UserAgg.Requests
{
    public class LoginRequest
    {

        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
