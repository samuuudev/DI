using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1_Barcos
{
    internal static class Utilidades
    {
        private static Random random = new Random(); // Se crea una sola vez

        /// <summary>
        /// Devuelve un numero random entre los valores aportados min y max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int numAleatorio(int min, int max)
        {
            int numeroAleatorio = random.Next(min, max);
            return numeroAleatorio;
        }

        public static int numeAleatorio(int max)
        {
            return random.Next(max);
        }

        public static char caracterAleatorio(string caracteres)
        {
            int indice = random.Next(caracteres.Length);
            return caracteres[indice];
        }

        public static bool booleanoAleatorio()
        {
            if (random.Next(2) != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }   
}
