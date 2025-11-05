using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1_Barcos
{
    internal class Barco
    {
        private int tamanio;
        private int maxTamanio;
        private bool horizontal;

        private int posI;
        private int posJ;
        public List<(int fila, int columna)> Posiciones;

        public static char simbolo = 'B';
        public Barco(int posI, int posJ) {

            this.posI = posI;
            this.posJ = posJ;
            Posiciones = new List<(int, int)>();

            this.maxTamanio = Tablero.tableroTamanio / 3;
            this.tamanio = Utilidades.numAleatorio(2, maxTamanio);
            this.horizontal = Utilidades.booleanoAleatorio();
        }

        public void MostrarDatos()
        {
            Console.WriteLine("El tamaño maximo es " + maxTamanio);
            Console.WriteLine("El tamaño del barco es " + tamanio);
            Console.WriteLine("El barco se posiciona horizontal " + horizontal);
            Console.WriteLine();
            Console.WriteLine("Posicion en i " + posI);
            Console.WriteLine("Posicion en j " + posJ);
            Console.WriteLine("////////////////////////////////////////////////");
        }

        public void colocar()
        {
            if (horizontal)
            {
                Posiciones.Add((posI * tamanio, posJ));
            }
            else
            {
                Posiciones.Add((posI, posJ * tamanio));
            }
        }


        public bool estaEnPosicion(int fila, int columna)
        {
            foreach (var pos in Posiciones)
                if (pos.fila == fila && pos.columna == columna)
                    return true;
            return false;
        }

        public bool getHorizontal()
        {
            return horizontal;
        }

        public int getTamanio()
        {
            return tamanio;
        }
    }
}
