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

        public Tablero(int filas, int columnas)
        {
            matriz = new char[filas, columnas];
            
            Rellenar();
        }

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


        public bool DentroMatriz(int i, int j)
        {
            return i >= 0 && i < matriz.GetLength(0) && j >= 0 && j < matriz.GetLength(1);
        }

        public void ColocarJugador(Jugador jugador)
        {
            // Solo se muestra en consola, no se almacena permanentemente
            Mostrar(jugador);
        }

        public void LimpiarCasilla(int i, int j)
        {
            matriz[i, j] = 'X'; // Marca como visitada
        }


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

        public int getUltimaPosicion()
        {
            return matriz.GetLength(0) - 1 + matriz.GetLength(1) - 1;
        }

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
    }
}
