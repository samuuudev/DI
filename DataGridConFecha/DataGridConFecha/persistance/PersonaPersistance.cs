
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas25_26.domain;
using ExampleMVCnoDatabase.Persistence;

namespace DataGridPersonas25_26.persistance
{
    internal class PersonaPersistance
    {
        private DataTable table { get; set; }
        private List<Persona> listaPersonas { get; set; }


        public PersonaPersistance()
        {
            table = new DataTable();
            listaPersonas = new List<Persona>();
        }

        public List<Persona> leerPersonas()
        {
            Persona persona = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM persona.persona;");

            foreach (List<Object> c in aux)
            {
                persona = new Persona(Convert.ToInt32(c[0]),
                    c[1].ToString(),
                    c[2].ToString(),
                    Convert.ToInt32(c[3]),
                    DateTime.Parse((string)c[4]));

                listaPersonas.Add(persona);
            }

            return listaPersonas;
        }

        public void insertarPersona(Persona p)
        {
            int id = p.Id;
            string nombre = p.Nombre;
            string apellido = p.Apellido;
            int edad = p.Edad;
            string fechaIncorporacion = p.Fecha.ToString("dd-MM-yyyy");



            String sql = "INSERT INTO persona.persona (idpersona ,nombre, apellido, edad, fecha_incorporacion) " +
                         "VALUES (" + id + ", '" + nombre + "', '" + apellido + "', " + edad + ", '" + fechaIncorporacion + "');";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void lastIdPersona(Persona p)
        {
            List<Object> lPersona;
            lPersona = DBBroker.obtenerAgente().leer("SELECT MAX(idpersona) FROM persona.persona;");

            foreach (List<Object> c in lPersona)
            {
                p.Id = Convert.ToInt32(c[0]) + 1;
            }
        }

        public void eliminarPersona(Persona p)
        {
            String sql = "DELETE FROM persona.persona WHERE id = " + p.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarPersona(Persona p)
        {
            String sql = "UPDATE persona.persona SET " +
                         "nombre = '" + p.Nombre + "', " +
                         "apellidos = '" + p.Apellido + "', " +
                         "edad = " + p.Edad + " " +
                         "WHERE id = " + p.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

    }
}
