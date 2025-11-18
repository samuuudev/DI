
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

        // Simulacion lectura base de datos
        //public static List<Persona> listaPersonas()
        //{
        //    List<Persona> lista = new List<Persona>();

        //    lista.Add(new Persona("Manuel", "Ruiz", 19));
        //    lista.Add(new Persona("Ismael", "Navarro", 20));
        //    lista.Add(new Persona("Ruben", "Rueda", 21));
        //    lista.Add(new Persona("Raul", "Guijon", 19));
        //    lista.Add(new Persona("Gabriel", "Hernandez", 21));
        //    lista.Add(new Persona("Asier", "Carretero", 21));
        //    lista.Add(new Persona("Adrian", "Luque", 21));
        //    lista.Add(new Persona("Manuel Alejandro", "Garcia", 21));

        //    return lista;
        //}

        public List<Persona> leerPersonas()
        {
            Persona persona = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.persona;");

            foreach (List<Object> c in aux)
            {
                persona = new Persona(Convert.ToInt32(c[0]), c[1].ToString(), c[2].ToString(), Convert.ToInt32(c[3]));

                listaPersonas.Add(persona);
            }

            return listaPersonas;
        }

        public void insertarPersona(Persona p)
        {
            String sql = "INSERT INTO mydb.persona (idpersona ,nombre, apellidos, edad) " +
                         "VALUES (" + p.Id + ", '" + p.Nombre + "', '" + p.Apellido + "', " + p.Edad + ");";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void lastIdPersona(Persona p)
        {
            List<Object> lPersona;
            lPersona = DBBroker.obtenerAgente().leer("SELECT MAX(idpersona) FROM mydb.persona;");

            foreach (List<Object> c in lPersona)
            {
                p.Id = Convert.ToInt32(c[0]) + 1;
            }
        }

        public void eliminarPersona(Persona p)
        {
            String sql = "DELETE FROM mydb.persona WHERE id = " + p.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarPersona(Persona p)
        {
            String sql = "UPDATE mydb.persona SET " +
                         "nombre = '" + p.Nombre + "', " +
                         "apellidos = '" + p.Apellido + "', " +
                         "edad = " + p.Edad + " " +
                         "WHERE id = " + p.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

    }
}
