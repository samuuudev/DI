using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
{
    internal static class Utilidades
    {
        private static Random random = new Random(); // Se crea una sola vez

        public static int numAleatorio(int min, int max)
        {
            int numeroAleatorio = random.Next(min, max);
            return numeroAleatorio;
        }


        public static char caracterAleatorio(string caracteres)
        {
            int indice = random.Next(caracteres.Length);
            return caracteres[indice];
        }
    }   
}
