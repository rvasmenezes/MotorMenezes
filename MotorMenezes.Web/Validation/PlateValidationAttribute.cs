using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MotorMenezes.Web.Validation
{
    public class PlateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.Success;

            string placa = value.ToString();
            string pattern = @"^[A-Z]{3}\d{1}[A-Z0-9]{1}\d{2}$";
            Regex regex = new(pattern, RegexOptions.IgnoreCase);

            if (regex.IsMatch(placa))
                return ValidationResult.Success;
            else
                return new ValidationResult("Placa inválida! Use o formato ABC1D23.");
        }
    }
}
