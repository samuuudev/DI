using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList lista = new ArrayList();

            lista.Add("Hola");
            lista.Add(123);
            lista.Add(45.67);

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}
