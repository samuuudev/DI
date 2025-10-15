using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
{
    internal class Enemigo
    {
        private char tipo;
        private string nombre;
        private int dano;

        public Enemigo(char tipo)
        {
            this.tipo = tipo;
            switch (tipo)
            {
                case 'D':
                    nombre = "Doctor Octopus";
                    dano = 1;
                    break;
                case 'G':
                    nombre = "Duende Verde";
                    dano = 1;
                    break;
                case 'M':
                    nombre = "Mysterio";
                    dano = 0;
                    break;
            }
        }

        /// <summary>
        /// Define el tipo de ataque y caracteristica
        /// </summary>
        /// <param name="jugador"></param>
        /// <param name="tablero"></param>
        public void Atacar(Jugador jugador, Tablero tablero)
        {
            if (tipo == 'M')
            {
                Random rnd = new Random();
                int nuevaFila, nuevaColumna;

                do
                {
                    nuevaFila = rnd.Next(0, tablero.Filas);
                    nuevaColumna = rnd.Next(0, tablero.Columnas);
                } while (!tablero.DentroMatriz(nuevaFila, nuevaColumna));

                jugador.PosI = nuevaFila;
                jugador.PosJ = nuevaColumna;

                Console.WriteLine($"Mysterio ha jugado contigo. Te ha teletransportado a ({nuevaFila}, {nuevaColumna}).");
                
            }
            else
            {
                jugador.vida -= dano;
                Console.WriteLine($"Has sido atacado por {nombre}. Has perdido {dano} vida.");
            }
        }


        // Getters
        public char Tipo { get { return tipo; } }
        public string Nombre { get { return nombre; } }
        public int Dano { get { return dano; } }
    }
}
