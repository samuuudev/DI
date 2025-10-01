using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosBasicos2Cadenas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string texto = "Hola Mundo";

            //convertir a mayusculas
            string textoMayusculas = texto.ToUpper();

            int longitud = texto.Length;

            bool contieneHola = texto.Contains("Hola");

            Console.WriteLine($"Original: {texto}");
            Console.WriteLine($"Mayusculas: {textoMayusculas}");
            Console.WriteLine($"Longitud: {longitud}");
            Console.WriteLine($"Contiene 'Hola' {contieneHola}");

            Console.ReadLine();
        }
    }
}
