using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosBasicosMatrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz = new int[2, 3]
            {
                 { 1,2,3 },
                { 4,5,6}
            };
            int[,] matriz2 = new int[2, 3]
            {
                 { 1,2,3 },
                { 4,5,6}
            };

            int[,] resultado = new int[2, 3];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    resultado[i, j] = matriz[i, j] + matriz2[i, j];
                    Console.Write(resultado[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            pintarEscalera(5);

            Console.WriteLine();
            pintarEscaleraInvertida(5);

            Console.WriteLine();
            pintarEscaleraFlip(5);

            Console.WriteLine();
            pintarTriangulo(5);


        }

        public static void pintarEscalera(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void pintarEscaleraInvertida(int n)
        {
            
        }


        public static void pintarTriangulo(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
