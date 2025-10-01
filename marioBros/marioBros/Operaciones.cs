using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace marioBros
{
    internal class Operaciones
    {
        /// <summary>
        /// Metodo que inicia el juego
        /// </summary>
        public static void iniciarJuego()
        {
            string[,] tableroVisual = new string[8, 8];
            bool salir = false;
            int posI = 0;
            int posJ = 0;
            rellenarMatriz(tableroVisual, "*");
                
            tableroVisual[posI, posJ] = "X";
            while (!salir)
            {
                mostrarMatriz(tableroVisual);
                MostrarMenu();
                entradaMenu(tableroVisual, ref salir, ref posI, ref posJ);
            }
        }



        /// <summary>
        /// Rellena la matriz con un valor
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="cadena"></param>
        public static void rellenarMatriz(string[,] matriz, string cadena)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = cadena;
                }
            }
        }

        /// <summary>
        /// Devuelve falso si la posición está fuera de la matriz
        /// </summary>
        /// <param name="posI"></param>
        /// <param name="posJ"></param>
        /// <param name="matriz"></param>
        /// <returns></returns>
        public static bool dentroMatriz(int posI, int posJ, string[,] matriz)
        {

            if (posI >= 0 && posI < matriz.GetLength(0) && posJ >= 0 && posJ < matriz.GetLength(1))
            {
                return true;
            } else
            {
                Console.WriteLine("Posición fuera de la matriz. No puedes salir del tablero");
                return false;
            }
        }

        /// <summary>
        /// Muestra el menu de opciones
        /// </summary>
        public static void MostrarMenu()
        {
            Console.WriteLine("D. Derecha");
            Console.WriteLine("A. Izquierda");
            Console.WriteLine("W. Arriba");
            Console.WriteLine("S. Abajo");
            Console.WriteLine("Q. Salir");
        }


        /// <summary>
        /// Comprueba la entrada del usuario y mueve la "O" en la dirección indicada
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="salir"></param>
        /// <param name="posI"></param>
        /// <param name="posJ"></param>
        public static void entradaMenu(string[,] tablero, ref bool salir, ref int posI, ref int posJ)
        {
            try
            {
                char tecla = Console.ReadKey().KeyChar;
                switch (tecla)
                    {
                        case 'd':
                            if (dentroMatriz(posI, posJ + 1, tablero))
                            {
                            tablero[posI, posJ] = "*";
                                posJ++;
                                tablero[posI, posJ] = "X";
                            }
                            break;
                        case 'a':
                            if (dentroMatriz(posI, posJ - 1, tablero))
                            {
                                tablero[posI, posJ] = "*";
                                posJ--;
                                tablero[posI, posJ] = "X";
                            }
                            break;
                        case 'w':
                            if (dentroMatriz(posI - 1, posJ, tablero))
                            {
                                tablero[posI, posJ] = "*";
                                posI--;
                                tablero[posI, posJ] = "X";
                            }
                            break;
                        case 's':
                            if (dentroMatriz(posI + 1, posJ, tablero))
                            {
                                tablero[posI, posJ] = "*";
                                posI++;
                                tablero[posI, posJ] = "X";
                            }
                            break;
                        case 'q':
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido una excepcion " + ex.ToString());
            }
        }


        /// <summary>
        /// Muestra la matriz por consola
        /// </summary>
        /// <param name="matriz"></param>
        public static void mostrarMatriz(string[,] matriz)
        {
            Console.Clear();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
