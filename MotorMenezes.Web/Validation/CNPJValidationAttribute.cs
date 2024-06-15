using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Web.Validation
{
    public class CNPJValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cnpj = value as string;

            if (string.IsNullOrWhiteSpace(cnpj))
                return new ValidationResult("CNPJ é obrigatório!");

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (!IsCnpjValid(cnpj))
                return new ValidationResult("CNPJ inválido!");

            return ValidationResult.Success;
        }

        private static bool IsCnpjValid(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            // Verificação dos dígitos verificadores
            int[] multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            remainder = (remainder < 2) ? 0 : 11 - remainder;

            string digit1 = remainder.ToString();
            tempCnpj += digit1;

            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            remainder = (remainder < 2) ? 0 : 11 - remainder;

            string digit2 = remainder.ToString();
            tempCnpj += digit2;

            return cnpj.EndsWith(digit1 + digit2);
        }
    }
}
