using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioArrayListProducto
{
    internal class Program
    {
        static void Main(string[] args)
        {
;
            Random random = new Random();

            int maxProductos = random.Next(1, 8);

            ArrayList listaProductos = new ArrayList();

            for (int i = 0; i < maxProductos; i++)
            {
                listaProductos.Add(new Producto(random.Next(1, 10), random.NextDouble() * 100));
            }

            foreach (Producto producto in listaProductos)
            {
                Console.WriteLine($"Cantidad: {producto.Cantidad}, Precio: {producto.Precio}, Precio Final: {producto.precioFinal()}");
            }
        }
    }
}
