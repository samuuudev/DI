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
        private int id;
        private string nombre;
        private string apellido;
        private int edad;
        private List<Persona> listaPersonas;

        public PersonaPersistance pm;

        public Persona()
        {
            pm = new PersonaPersistance();
        }
        public Persona(int id)
        {
            pm = new PersonaPersistance();
            this.id = id;
        }

        public Persona(string nombre, string apellido, int edad)
        {
            pm = new PersonaPersistance();
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }
        public Persona(int id, string nombre, string apellido, int edad)
        {
            pm = new PersonaPersistance();
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Id { get => id; set => id = value; }

        // Nos devuelve la lista de personas de la base de datos (simulado)

        public List<Persona> getPersonas()
        {
            listaPersonas = pm.leerPersonas();

            return listaPersonas;
        }

        public void last()
        {
            pm.lastIdPersona(this);
        }

        public void insertar()
        {
            pm.insertarPersona(this);
        }

        public void delete()
        {
            pm.eliminarPersona(this);
        }   

        public void modificar()
        {
            pm.modificarPersona(this);
        }
    }
}
