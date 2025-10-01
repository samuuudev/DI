using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista de enteros y agregar los números 5, 10 y 15.
            List<int> numeros = new List<int>();

            // Agregar los números a la lista
            numeros.Add(5);
            numeros.Add(10);
            numeros.Add(15);

            // Mostrar los números en la consola
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }

            // Eliminar el número 10 de la lista
            numeros.Remove(10);
            Console.WriteLine("Después de eliminar el 10:");

            // Mostrar los números en la consola nuevamente
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }

            // Esperar a que el usuario presione una tecla antes de cerrar
            Console.ReadLine();
        }
    }
}
