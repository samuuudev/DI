using Ejercicio2.persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.domain
{
    internal class Jugador
    {

        private int id;
        private string nickname;
        private DateTime fecha_juego;
        private int nivel;
        private int puntuacion; // no tengo pensado usar decimales para la puntuacion, por eso es tipo entero

        private JugadorPersistance pj;
        private List<Jugador> list;

        public Jugador()
        {
            pj = new JugadorPersistance();
        }

        public Jugador(string nickname, DateTime fecha, int  nivel, int puntuacion)
        {
            this.nickname = nickname;
            this.fecha_juego = fecha;
            this.nivel = nivel;
            this.puntuacion = puntuacion;

            pj = new JugadorPersistance();
        }

        public Jugador(int id, string nickname, DateTime fecha, int nivel, int puntuacion)
        {
            this.id = id;
            this.nickname = nickname;
            this.fecha_juego = fecha;
            this.nivel = nivel;
            this.puntuacion = puntuacion;

            pj = new JugadorPersistance();
        }

        // Me creo los getters y setter publicos
        public int Id { get => id; set => id = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public DateTime FechaJuego { get => fecha_juego; set => fecha_juego = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Puntuacion { get => puntuacion; set => puntuacion = value; }


        public List<Jugador> getJugadores()
        {
            list = pj.leerJugadores();

            return list;
        }
        public void insertar()
        {
            pj.insertarJugador(this);
        }

        public void delete()
        {
            pj.eliminarJugador(this);
        }

        public void modificar()
        {
            pj.modificarJugador(this);
        }

    }
}
