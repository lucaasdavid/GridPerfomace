using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Grid_Perfomace.Services.Util
{
    public static class RandomExtensions
    {
        #region Gerar String Aleatoria
        
         public static string GerarStringAleatoria(this Random rnd, int min, int max, string sequencialString)
        {
            int numeroDeCaracteres = rnd.Next(min, max);
            return GerarDadosAleatorio(numeroDeCaracteres, sequencialString);
        }        

        private static string GerarDadosAleatorio(int numeroDeCaracteres, string sequencialString)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            string resultado = "";
            for (int i = 0; i < numeroDeCaracteres; i++)
            {
                int caracterRandom = rnd.Next(sequencialString.Length - 1);
                resultado += sequencialString[caracterRandom];
            }
            return resultado;
        }

        #endregion

        #region Gerar Inteiro Aleatorio

        public static int GerarInteiroAleatorio(this Random rnd, int resultado)
        {
            for(int i = 0; i <= 10; i++)
            {
                resultado = new Random(Guid.NewGuid().GetHashCode()).Next(100, 10000);
            }
            return resultado;
        }

        #endregion

        #region Gerar Double Aleatorio

        public static double GerarDoubleAleatorio(this Random rnd)
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
            double resultado;

            resultado = rnd.NextDouble() * 4000;
            return resultado;
        }

        #endregion

        #region Gerar Bool Aleatorio

        public static bool GerarBoolAleatorio(this Random rnd)
        {
            int resultado = new Random(Guid.NewGuid().GetHashCode()).Next(1, 100);
            return resultado > 50;
        }

        #endregion

        #region Gerar Data Aleatoria

        public static DateTime GerarDataAleatoria(this Random rnd)
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }

        #endregion

        #region Gerar String Cor Aleatoria

        public static Brush GerarStringCorAleatoria(this Random rnd)
        {
            int r, g, b;
            rnd = new Random(Guid.NewGuid().GetHashCode());
            r = rnd.Next(255);
            g = rnd.Next(255);
            b = rnd.Next(255);

            Color randomColor = Color.FromRgb((byte)r, (byte)g, (byte)b);
            return new SolidColorBrush(randomColor);
        }  

        #endregion
    }
}
