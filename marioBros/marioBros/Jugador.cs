using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marioBros
{
    internal class Jugador
    {
        public int PosI { get; private set; }
        public int PosJ { get; private set; }
        public string Simbolo { get; private set; }

        public double pocion { get; set; } = 0;
        public int vida { get; set; } = 3;


        public Jugador(int posI, int posJ, string simbolo)
        {
            PosI = posI;
            PosJ = posJ;
            Simbolo = simbolo;
        }

        public bool Mover(int dI, int dJ, Tablero tablero)
        {
            int nuevoI = PosI + dI;
            int nuevoJ = PosJ + dJ;

            if (!tablero.DentroMatriz(nuevoI, nuevoJ))
            {
                Console.WriteLine("No puedes salir del tablero");
                return false;
            }

            tablero.LimpiarCasilla(PosI, PosJ);
            PosI = nuevoI;
            PosJ = nuevoJ;
            tablero.ColocarJugador(this);

            return false;
        }
        public void MostrarEstado()
        {
            Console.WriteLine($"Vida: {vida}, Pocion: {pocion}");
        }
    }
}
