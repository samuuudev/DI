using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosBasicosBuclesControlFlujo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // bucle for
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Numero: {i}");
            }

            // Bucle foreach
            string[] frutas = { "manzanas", "platanos", "cerezas" };

            foreach (string fruta in frutas)
            {
                Console.WriteLine($"Fruta: {fruta}");
            }

            // if-else
            int numero = 10;
            if (numero % 2 == 0)
            {
                Console.WriteLine("El numero es par");
            }
            else
            {
                Console.WriteLine("El numero es impar");
            }
        }
    }
}
