using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploCoches
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Crear un array de coches
            ArrayList coches = new ArrayList();

            // Pedir datos al usuario y crear coches
            coches.Add(new Coche(0, "BMW", "M4", 1000, 120000));
            coches.Add(new Coche(1, "Mercedes", "GLA200", 25321, 80000));
            coches.Add(new Coche(2, "Seat", "Arona", 15000, 16560.56));
            coches.Add(new Coche(3, "Opel", "Corsa", 465079, 3251.13));

            // Mostrar los coches
            Console.Clear();
            Console.WriteLine("Coches introducidos:");
            foreach (Coche coche in coches)
            {
                Console.WriteLine(coche.ToString());
            }

            Console.WriteLine("Pulsa una tecla para continuar...");
            Console.ReadKey();

            int[,] tabla = new int[4, 4];

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i, j] = Utilidades.aleatorio(0, coches.Count);
                }
            }

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write(tabla[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(" ");

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write(tabla[i, j] + " ");
                    Coche coche = (Coche)coches[tabla[i, j]];
                    Console.WriteLine(coche.ToString());
                }
                Console.WriteLine();
            }
        }








        public void añadirCoche(ArrayList coches, int totalCoches, int id, string marca, string modelo, int km, double precio)
        {

            for (int i = 0; i < totalCoches; i++)
            {
                Console.Clear();
                Console.WriteLine("Introduce los datos del coche {0}:", i + 1);
                Console.Write("Marca: ");
                marca = Console.ReadLine();
                Console.Write("Modelo: ");
                modelo = Console.ReadLine();
                Console.Write("Kilómetros: ");
                km = int.Parse(Console.ReadLine());
                Console.Write("Precio: ");
                precio = double.Parse(Console.ReadLine());
                // Crear el coche y añadirlo al array
                Coche coche = new Coche(id, marca, modelo, km, precio);
                coches.Add(coche);
                id++;
            }
        }
    }
}
