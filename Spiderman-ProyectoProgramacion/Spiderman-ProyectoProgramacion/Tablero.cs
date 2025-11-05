using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
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
        /// Con esto relllenamos la tabla con valores aleatorios 
        /// </summary>
        public void Rellenar()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = Utilidades.caracterAleatorio("CCCCNNNNNNNNNNDDGGMMBB"); // 4C, 10N, 2D, 2G, 4M, 2B Total/24
                }
            }
            matriz[0, 0] = 'X'; // posición inicial visitada
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
        /// Instanciamos al jugador en la matriz
        /// </summary>
        /// <param name="jugador"></param>
        public void ColocarJugador(Jugador jugador)
        {
            // Solo se muestra en consola, no se almacena permanentemente
            Mostrar(jugador);
        }
        /// <summary>
        /// Limpiamos la casilla en la que el jugador ha estado
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void LimpiarCasilla(int i, int j)
        {
            matriz[i, j] = 'X'; // Marca como visitada
        }

        /// <summary>
        /// Muestra el tablero completo
        /// </summary>
        /// <param name="jugador"></param>
        public void Mostrar(Jugador jugador)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (i == jugador.PosI && j == jugador.PosJ)
                        Console.Write(jugador.Simbolo + " "); // Jugador
                    else if (matriz[i, j] == 'X')
                        Console.Write(". "); // Visitada
                    else
                        Console.Write("* "); // No visitada (oculta el tipo real)
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Metodo debug para comprobar donde estan los enemigos
        /// </summary>
        /// <param name="jugador"></param>
        public void MostrarMatriz(Jugador jugador)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (i == jugador.PosI && j == jugador.PosJ)
                        Console.Write(jugador.Simbolo + " "); // Jugador
                    else if (matriz[i, j] == 'X')
                        Console.Write(". "); // Visitada
                    else if (matriz[i, j] == 'D' || matriz[i, j] == 'G' || matriz[i, j] == 'M')
                        Console.Write("+ ");
                    else
                        Console.Write("* "); // No visitada (oculta el tipo real)

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

        /// <summary>
        /// Obtiene la ultima posicion de la matriz
        /// </summary>
        /// <returns></returns>
        public int getUltimaPosicion()
        {
            return matriz.GetLength(0) * matriz.GetLength(1) - 1;
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
