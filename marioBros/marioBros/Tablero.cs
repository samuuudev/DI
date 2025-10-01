using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marioBros
{
    internal class Tablero
    {

        int[,] matriz;


        public Tablero(int ancho, int largo)
        {
            int[,] matriz = new int[ancho, largo];
            GenerarTablero();
        }


        /// <summary>
        /// Rellena la matriz con un valor
        /// </summary>
        /// <param name="matriz"></param>
        public void GenerarTablero()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = Utilidades.numAleatorio(0, 3);
                }
            }
        }
    }
}
