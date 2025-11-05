using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1_Barcos
{
    internal class Tablero
    {
        private char[,] matriz;
        public int Filas => matriz.GetLength(0);
        public int Columnas => matriz.GetLength(1);

        public static int tableroTamanio;

        public Barco[] barcos;
        private int nBarcos = 0;

        public Tablero(int filas, int columnas, int maxBarcos)
        {
            matriz = new char[filas, columnas];

            barcos = new Barco[maxBarcos];

            tableroTamanio = filas;

            Rellenar();

            while (nBarcos < maxBarcos)
            {
                colocarBarco();
                Console.WriteLine("Genero Barco");
            }

            MostrarTablero();
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
        /// Comprobamos que el jugador siempre este dentro de la matriz
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool DentroMatriz(int i, int j)
        {
            return i >= 0 && i < matriz.GetLength(0) && j >= 0 && j < matriz.GetLength(1);
        }


        public void colocarBarco()
        {

            int posicionInicialI = Utilidades.numAleatorio(0, tableroTamanio);
            int posicionInicialJ = Utilidades.numAleatorio(0, tableroTamanio);

            barcos[nBarcos] = new Barco(posicionInicialI, posicionInicialJ);
            barcos[nBarcos].MostrarDatos();

            matriz[posicionInicialI, posicionInicialJ] = Barco.simbolo;

            if (barcos[nBarcos].getHorizontal() && DentroMatriz(posicionInicialI + barcos[nBarcos].getTamanio(), posicionInicialJ))
            {
                for (int posI = 0; posI <= barcos[nBarcos].getTamanio(); posI++)
                { 
                    matriz[posicionInicialI + posI, posicionInicialJ] = Barco.simbolo;
                    barcos[nBarcos].colocar();
                }
            }
            else if (DentroMatriz(posicionInicialI, posicionInicialJ + barcos[nBarcos].getTamanio()))
            {
                for (int posj = 0; posj <= barcos[nBarcos].getTamanio(); posj++)
                {
                    matriz[posicionInicialI, posicionInicialJ + posj] = Barco.simbolo;
                    barcos[nBarcos].colocar();
                }
            }

            nBarcos++;
        }
    }
}
