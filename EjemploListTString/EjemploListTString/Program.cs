using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploListTString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string>();

            lista.Add("Jose");
            lista.Add("Ana");
            lista.Add("Luis");
            lista.Add("Marta");
            lista.Add("Bea");
            lista.Add("Juan");

            foreach (string nombre in lista)
            {
                Console.WriteLine(nombre);
            }
        }
    }
}
