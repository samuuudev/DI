using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioArrayListProducto
{
    internal class Producto
    {

        private int cantidad;
        private double precio;

        public Producto(int cantidad, double precio)
        {
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public int Cantidad { get => cantidad; }
        public double Precio { get => precio; }

        public double precioFinal()
        {
            return cantidad * precio;
        }
    }
}
