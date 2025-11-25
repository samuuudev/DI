using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1Examen
{
    internal class Jugador
    {
        public int PosI { get; set; }
        public int PosJ { get; set; }
        public string Simbolo { get; private set; }

        public int ratones { get; set; } = 3;


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

            int nuevoI = PosI + dI;
            int nuevoJ = PosJ + dJ;

            if (!tablero.DentroMatriz(nuevoI, nuevoJ))
            {
                Console.WriteLine("No puedes salir del tablero");
                return false;
            }

            PosI = nuevoI;
            PosJ = nuevoJ;

            return false;
        }

        /// <summary>
        /// Actualiza en tiempo de ejecucion la vida restante y civiles
        /// </summary>
        public void MostrarEstado()
        {
            Console.WriteLine($"Ratones: {ratones}");
        }
    }
}
