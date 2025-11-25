using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1Examen
{
    internal class Tablero
    {
        private char[,] matriz;
        public int Filas => matriz.GetLength(0);
        public int Columnas => matriz.GetLength(1);

        public Tablero(int filas, int columnas)
        {
            matriz = new char[filas, columnas];
            
            Rellenar();
        }

        /// <summary>
        /// Comprobamos que el jugador siempre este dentro de la matriz
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool DentroMatriz(int i, int j)
        {
            return i >= 0 && i < matriz.GetLength(0) && j >= 0 && j < matriz.GetLength(1);
        }


        /// <summary>
        /// Con esto relllenamos la tabla con valores aleatorios 
        /// </summary>
        public void Rellenar()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    this.matriz[i, j] = '.';
                }
            }
        }

        public void colocarRatonesYParedes()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (Utilidades.numAleatorio(1,4) % 2 == 0)
                    {
                        matriz[i, j] = Utilidades.caracterAleatorio("RP");
                    }
                }
            }
        }

        /// <summary>
        /// Este metodo muestra en la consola el tablero
        /// </summary>
        public void MostrarTablero()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Obtiene el valor de la matriz en la que esta el jugador
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public char getValorMatriz(Jugador jugador)
        {

            char resultado = ' ';
            int posI = jugador.PosI;    
            int posJ = jugador.PosJ;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    resultado = matriz[posI, posJ];
                }
            }
            return resultado;
        }

        public void colocarJugador()
        {
            int posicionInicialI = Utilidades.numAleatorio(0, matriz.GetLength(0));
            int posicionInicialJ = Utilidades.numAleatorio(0, matriz.GetLength(0));

            matriz[posicionInicialI, posicionInicialJ] = 'S';

            if (DentroMatriz(posicionInicialI + 4, posicionInicialJ))
            {
                for (int posI = 0; posI <= 4; posI++)
                {
                    matriz[posicionInicialI + posI, posicionInicialJ] = 's';
                }
            }
        }

        /// <summary>
        /// Devuelve la posicion actual del jugador
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public int getPosicionAbsoluta(Jugador jugador)
        {
            int columnas = matriz.GetLength(1);
            return jugador.PosI * columnas + jugador.PosJ;
        }

    }
}
