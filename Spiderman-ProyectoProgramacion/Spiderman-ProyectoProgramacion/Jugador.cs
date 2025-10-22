using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
{
    internal class Jugador
    {
        public int PosI { get; set; }
        public int PosJ { get; set; }
        public string Simbolo { get; private set; }

        public int civiles { get; set; } = 0;
        public int vida { get; set; } = 3;

        public bool TieneBonusSalto { get; set; } = false;


        public Jugador(int posI, int posJ, string simbolo)
        {
            PosI = posI;
            PosJ = posJ;
            Simbolo = simbolo;
        }


        /// <summary>
        /// Usamos los valores del jugador de posicion para moverlo por el tablero seleccionado
        /// </summary>
        /// <param name="dI"></param>
        /// <param name="dJ"></param>
        /// <param name="tablero"></param>
        /// <returns></returns>
        public bool Mover(int dI, int dJ, Tablero tablero)
        {

            int salto = TieneBonusSalto ? 2 : 1;
            int nuevoI = PosI + dI * salto;
            int nuevoJ = PosJ + dJ * salto;

            if (!tablero.DentroMatriz(nuevoI, nuevoJ))
            {
                Console.WriteLine("No puedes salir del tablero");
                return false;
            }

            tablero.LimpiarCasilla(PosI, PosJ);
            PosI = nuevoI;
            PosJ = nuevoJ;
            tablero.ColocarJugador(this);

            TieneBonusSalto = false; // Se consume el bonus

            return false;
        }

        /// <summary>
        /// Actualiza en tiempo de ejecucion la vida restante y civiles
        /// </summary>
        public void MostrarEstado()
        {
            Console.WriteLine($"Vida: {vida}, Civiles: {civiles}");
        }
    }
}
