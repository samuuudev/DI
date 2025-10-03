using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marioBros
{
    internal class Tablero
    {
        private int[,] matriz;
        private string[,] matrizConsola;

        Jugador jugador;


        public Tablero(int filas, int columnas)
        {
            matriz = new int[filas, columnas];
            matrizConsola = new string[filas, columnas];
            
            Rellenar();
        }

        public void Rellenar()
        {
            for (int i = 0; i < matrizConsola.GetLength(0); i++)
            {
                for (int j = 0; j < matrizConsola.GetLength(1); j++)
                {
                    matrizConsola[i, j] = "*";
                }
            }

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = Utilidades.numAleatorio(0, 3);
                }
            }
            matriz[0, 0] = 4;
        }

        public bool DentroMatriz(int i, int j)
        {
            return i >= 0 && i < matriz.GetLength(0) && j >= 0 && j < matriz.GetLength(1);
        }

        public void ColocarJugador(Jugador jugador)
        {
            matrizConsola[jugador.PosI, jugador.PosJ] = jugador.Simbolo;
        }

        public void LimpiarCasilla(int i, int j)
        {
            matrizConsola[i, j] = ".";
            matriz[i, j] = 4;
        }

        public void Mostrar()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matrizConsola[i, j] + " ");

                }
                Console.WriteLine();
            }
        }

        public void MostrarMatriz()
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

        public int getValorMatriz(Jugador jugador)
        {

            int resultado = 0;
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
    }
}
