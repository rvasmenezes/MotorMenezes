using System;
using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Web.Validation
{
    public class AgeRestrictionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                var age = CalculateAge(birthDate);
                if (age < 18)
                    return new ValidationResult("Você deve ter mais de 18 anos para se cadastrar.");
            }

            // Data de nascimento válida
            return ValidationResult.Success;
        }

        private static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
