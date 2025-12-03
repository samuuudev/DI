using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                int[] numeros = new int[4] { 10, 20, 30, 40 };

                Console.WriteLine("Ingresa el primer numero:");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa el segundo numero:");
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa el indice a buscar:");
                int numArray = int.Parse(Console.ReadLine());


                Console.WriteLine("Resultado de la división: " + (num1 / num2));
                Console.WriteLine("Número en la posición indicada: " + numeros[numArray]);

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: La posición ingresada está fuera del rango del array.");
                Console.WriteLine(ex.Message);
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine("Error: Formato invalido, no se aceptan numeros negativos.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error inesperado.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Ejecución finalizada.");
            }
        }
    }
}
