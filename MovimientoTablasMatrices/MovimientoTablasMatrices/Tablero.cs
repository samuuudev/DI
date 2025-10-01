using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientoTablasMatrices
{
    internal class Tablero
    {
        // me creo una variable global tabla
        private char[,] tabla;
        private char vacio = '-';
        private char jugador = 'x';
        private int posX;
        private int posY;


        public Tablero(int x, int y)
        {
            // creo la tabla
            this.tabla = new char[x, y];

        }

        public void menu()
        {
            int option = 0;
            Console.WriteLine("Bienvenido al juego de mover al jugador por la tabla");
            Console.WriteLine("1. Derecha");
            Console.WriteLine("2. Izquierda");
            Console.WriteLine("3. Arriba");
            Console.WriteLine("4. Abajo");
            Console.WriteLine("================");


            option = int.Parse(Console.ReadLine());


            mover(option);
        }

        public void iniciar()
        {
            // posicion inicial del jugador
            posX = 0;
            posY = 0;
            // la inicializo y la relleno de guiones
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i, j] = '-';
                }
            }

            // muestro la tabla
            mostrarTabla();

            menu();

            // posiciono al jugador en el 0 ,0
            tabla[posX, posY] = jugador;
        }

        // Metodo para mover la tabla
        public void mover(int option)
        {

            // Compruebo si la tecla coincide con las flechas direccionales
            switch (option)
            {
                case 1:
                    if(posX < tabla.GetLength(0) - 1)
                    {
                        tabla[posX, posY] = vacio; // limpio la casilla actual
                        posX++;
                        tabla[posX, posY] = jugador; // pongo al jugador en la nueva
                    }
                    break;

                case 2:
                    if (posX < tabla.GetLength(0) - 1)
                    {
                        tabla[posX, posY] = vacio; // limpio la casilla actual
                        posX++;
                        tabla[posX, posY] = jugador; // pongo al jugador en la nueva
                    }
                    mostrarTabla();
                    break;

                case 3:
                    if (posX < tabla.GetLength(0) - 1)
                        posY--;
                    tabla[posX, posY + 1] = vacio;

                    mostrarTabla();
                    break;

                case 4:
                    if(posX < tabla.GetLength(0) - 1)
                    posY++;
                    tabla[posX, posY - 1] = vacio;
;
                    mostrarTabla();
                    break;

                default:
                    Console.WriteLine("Error, inténtalo de nuevo");
                    break;
            }

            tabla[posX, posY] = jugador;
        }



        // Metodo para mostrar la tabla
        public void mostrarTabla()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write(tabla[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
