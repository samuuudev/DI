
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2.domain;
using Ejercicio2.Persistence;

namespace Ejercicio2.persistance
{
    internal class JugadorPersistance
    {
        private DataTable table { get; set; }
        private List<Jugador> listaJugadores { get; set; }


        public JugadorPersistance()
        {
            table = new DataTable();
            listaJugadores = new List<Jugador>();
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

        public List<Jugador> leerJugadores()
        {
            Jugador jugador = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM jugador.jugador;");

            foreach (List<Object> c in aux)
            {
                jugador = new Jugador(Convert.ToInt32(c[0]), c[1].ToString(), DateTime.Parse(c[2].ToString()), Convert.ToInt32(c[3]), Convert.ToInt32(c[4]));

                listaJugadores.Add(jugador);
            }

            return listaJugadores;
        }

        public void insertarJugador(Jugador p)
        {

            string fecha = p.FechaJuego.ToString("yyyy-MM-dd");

            String sql = "INSERT INTO jugador.jugador (fecha_juego, nickname, nivel, puntuacion) " +
                         "VALUES ('" + fecha  + "', '" + p.Nickname + "', " + p.Nivel + ", " + p.Puntuacion + ");";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void lastIdJugador(Jugador p) // Este metodo no creo que sea necesario, lo dejo en el caso que me interese saber el id ultumo
        {
            List<Object> lJugador;
            lJugador = DBBroker.obtenerAgente().leer("SELECT MAX(idpersona) FROM jugador.jugador;");

            foreach (List<Object> c in lJugador)
            {
                p.Id = Convert.ToInt32(c[0]) + 1;
            }
        }

        public void eliminarJugador(Jugador p)
        {
            String sql = "DELETE FROM jugador.jugador WHERE id = " + p.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarJugador(Jugador p)
        {
            String sql = "UPDATE jugador.jugador SET " +
                         "nickname = '" + p.Nickname + "', " +
                         "fecha_juego = '" + p.FechaJuego + "', " +
                         "nivel = " + p.Nivel + " " +
                         "puntuacion = " + p.Puntuacion + " " +
                         "WHERE idjugador = " + p.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

    }
}
