using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosBasicos
{

    // Definicion de enumaracion para las operaciones



    internal class Program
    {
        static void Main(string[] args)
        {

        }


        void calculadora()
        {
            int num1 = 0; int num2 = 0;

            // mostramos un mensaje en pantalla
            Console.WriteLine("Calculadora en c# \r");
            Console.WriteLine("----------------\n");

            // Pedimos el primer numero
            Console.WriteLine("Escribe un numero y pulsa Enter");
            num1 = Convert.ToInt32(Console.ReadLine());

            // Pedimos el segundo numero
            Console.WriteLine("Escribe otro numero y pulsa Enter");
            num2 = Convert.ToInt32(Console.ReadLine());

            // Pedimos por consola la operacion
            Console.WriteLine("Elige una operacion de la lista:");
            Console.WriteLine("\ta : Suma");
            Console.WriteLine("\tb : Resta");
            Console.WriteLine("\tc : Multiplicacion");
            Console.WriteLine("\td : Division");

            switch (Console.ReadLine())
            {
                case "a":

                    Console.WriteLine($"Tu resultado: {num1} + {num2} = " + (num1 + num2));
                    break;
                case "b":
                    Console.WriteLine($"Tu resultado: {num1} - {num2} = " + (num1 - num2));
                    break;
                case "c":
                    Console.WriteLine($"Tu resultado: {num1} * {num2} = " + (num1 * num2));
                    break;
                case "d":
                    Console.WriteLine($"Tu resultado: {num1} / {num2} = " + (num1 / num2));
                    break;
                default:
                    Console.WriteLine("Operacion no valida");
                    break;
            }

            // Esperamos a que el usuario pulse una tecla para finalizar
            Console.WriteLine("Pulsa una tecla para cerrar la calculadora");
            Console.ReadLine();
        }
    }
}
