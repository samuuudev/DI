using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas25_26.persistance;

namespace DataGridPersonas25_26.domain
{
    internal class Persona
    {
        private string nombre;
        private string apellido;
        private int edad;
        private List<Persona> listaPersonas;

        public Persona()
        {
            listaPersonas = new List<Persona>();
        }

        public Persona(string nombre, string apellido, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }

        // Nos devuelve la lista de personas de la base de datos (simulado)

        public List<Persona> getPersonas()
        {
            listaPersonas = PersonaPersistance.listaPersonas();
            return listaPersonas;


        }
    }
}
