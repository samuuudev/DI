using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu
{
    internal class Operaciones
    {

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
            Console.WriteLine("1. Derecha");
            Console.WriteLine("2. Izquierda");
            Console.WriteLine("3. Arriba");
            Console.WriteLine("4. Abajo");
            Console.WriteLine("5. Salir");
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
                int opcion = 0;

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            if (dentroMatriz(posI, posJ + 1, tablero))
                            {
                                tablero[posI, posJ] = "*";
                                posJ++;
                                tablero[posI, posJ] = "O";
                            }
                            break;
                        case 2:
                            if (dentroMatriz(posI, posJ - 1, tablero))
                            {
                                tablero[posI, posJ] = "*";
                                posJ--;
                                tablero[posI, posJ] = "O";
                            }
                            break;
                        case 3:
                            if (dentroMatriz(posI - 1, posJ, tablero))
                            {
                                tablero[posI, posJ] = "*";
                                posI--;
                                tablero[posI, posJ] = "O";
                            }
                            break;
                        case 4:
                            if (dentroMatriz(posI + 1, posJ, tablero))
                            {
                                tablero[posI, posJ] = "*";
                                posI++;
                                tablero[posI, posJ] = "O";
                            }
                            break;
                        case 5:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida");
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
