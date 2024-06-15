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

        public static List<int> GerarListaAnos(int quantidadeAnos)
        {
            int anoAtual = DateTime.Now.Year;
            List<int> listaAnos = new();

            for (int i = 0; i <= quantidadeAnos; i++)
                listaAnos.Add(anoAtual - i);

            return listaAnos;
        }
    }
}
