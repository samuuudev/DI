using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1_Barcos
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Bienvenido al juego de los barcos");
            Console.WriteLine();
            Console.WriteLine("Introduce acontinuacion el tamaño del tablero: ");
            int tamanio = Console.Read();
            Console.WriteLine("Introduce la cantidad maxima de barcos que quieres en el tablero");
            int maxBarcos = Console.Read();


            Tablero tablero = new Tablero(tamanio, tamanio, maxBarcos);
        }
    }
}
