using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
{
    internal class Jugador
    {
        public int PosI { get; private set; }
        public int PosJ { get; private set; }
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
        public void MostrarEstado()
        {
            Console.WriteLine($"Vida: {vida}, Civiles: {civiles}");
        }
    }
}
