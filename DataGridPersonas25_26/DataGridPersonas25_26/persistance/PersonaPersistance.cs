
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas25_26.domain;

namespace DataGridPersonas25_26.persistance
{
    internal class PersonaPersistance
    {
        private DataTable table { get; set; }
        public PersonaPersistance()
        {
            table = new DataTable();

        }

        // Simulacion lectura base de datos
        public static List<Persona> listaPersonas()
        {
            List<Persona> lista = new List<Persona>();

            lista.Add(new Persona("Manuel", "Ruiz", 19));
            lista.Add(new Persona("Ismael", "Navarro", 20));
            lista.Add(new Persona("Ruben", "Rueda", 21));
            lista.Add(new Persona("Raul", "Guijon", 19));
            lista.Add(new Persona("Gabriel", "Hernandez", 21));
            lista.Add(new Persona("Asier", "Carretero", 21));
            lista.Add(new Persona("Adrian", "Luque", 21));
            lista.Add(new Persona("Manuel Alejandro", "Garcia", 21));

            return lista;
        }

    }
}
