using System.Text.RegularExpressions;

namespace MotorMenezes.Core.Helpers
{
    public static class Utilidades
    {
        public static DateTime TimeZoneBrasil(this DateTime date)
        {
            DateTime localDateTime = DateTime.Now;
            return localDateTime.ToUniversalTime();
        }

        public static bool ValidarPlaca(string placa)
        {
            // Padrão de placa brasileira: ABC1D23 (três letras, um número, três letras)
            string pattern = @"^[A-Z]{3}\d{1}[A-Z0-9]{1}\d{2}$";

            // Ignora case (maiusculas ou minusculas)
            Regex regex = new(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(placa);
        }
    }
}
