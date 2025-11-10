using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridConLinq
{
    internal class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }


        public Persona(string nombre, string apellido, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }
    }
}
