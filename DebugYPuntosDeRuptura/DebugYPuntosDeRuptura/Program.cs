using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugYPuntosDeRuptura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            double num1 = randomGenerator.NextDouble();
            double num2 = randomGenerator.NextDouble();
            Console.WriteLine("Número 1: " + num1);
            Console.WriteLine("Número 2: " + num2);
            
            CalcularOperaciones(num1, num2);
            Console.ReadLine();
        }

        static void CalcularOperaciones(double num1, double num2)
        {
            double resultadoSuma = SumarNumeros(num1, num2);
            double reusltadoDivision = DividirNumeros(num1, num2);
            MultiplicarNumeros();
        }

        static double SumarNumeros(double a, double b)
        {
            double resultado = a + b;
            Console.WriteLine("Resultado de la suma: " + resultado);
            return resultado;
        }

        static double DividirNumeros(double a, double b)
        {
            double resultado = a / b;
            Console.WriteLine("Resultado de la división: " + resultado);
            return resultado;
        }

        static void MultiplicarNumeros()
        {
            try
            {
                // Random randomGenerator = new Random();
                Random randomGenerator = null;
                double num1 = randomGenerator.NextDouble();
                double num2 = randomGenerator.NextDouble();
                double resultado = num1 * num2;

                Console.WriteLine("El resultado de la multiplicacion es : " + resultado);
            } catch
            {
                Console.WriteLine("Error de multiplicacion");
            }

        }
    }
}
