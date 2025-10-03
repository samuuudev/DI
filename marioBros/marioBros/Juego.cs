using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marioBros
{
    internal class Juego
    {
        public void IniciarJuego()
        {
            Tablero tablero = new Tablero(8, 8);
            Jugador jugador = new Jugador(0, 0, "X");
            bool salir = false;

            tablero.ColocarJugador(jugador);

            Console.ReadLine();

            while (!salir)
            {
                Console.Clear();

                tablero.Mostrar();
                controlador(tablero, jugador);
                jugador.MostrarEstado();

                Console.WriteLine();
                tablero.MostrarMatriz();

                MostrarMenu();

                Console.WriteLine("");

                salir = ProcesarEntrada(tablero, jugador);

            }
        }

        public static void MostrarMenu()
        {
            Console.WriteLine("D. Derecha");
            Console.WriteLine("A. Izquierda");
            Console.WriteLine("W. Arriba");
            Console.WriteLine("S. Abajo");
            Console.WriteLine("Q. Salir");
        }

        private bool ProcesarEntrada(Tablero tablero, Jugador jugador)
        {
            char tecla = Console.ReadKey().KeyChar;
            switch (tecla)
            {
                case 'd':
                    return jugador.Mover(0, 1, tablero);
                case 'a': 
                    return jugador.Mover(0, -1, tablero);
                case 'w': 
                    return jugador.Mover(-1, 0, tablero);
                case 's': 
                    return jugador.Mover(1, 0, tablero);
                case 'q': 
                    return true;
                default:
                    Console.WriteLine("Opción no válida");
                    return false;
            }
        }


        // cambiar el nombre de este metodo no me gusta y no describe lo que hace
        private void controlador(Tablero tablero, Jugador jugador)
        {
            // logica del juego
            switch (tablero.getValorMatriz(jugador))
            {
                case 0:
                    Console.WriteLine("Has encontrado un enemigo");
                    jugador.vida--;
                    break;
                case 1:
                    Console.WriteLine("Has encontrado una vida");
                    jugador.vida++;
                    break;
                case 2:
                    Console.WriteLine("Has encontrado una pocion");
                    jugador.pocion++;
                    break;
                case 4:
                    Console.WriteLine("No hay nada");
                    break;
            }

            if (jugador.vida <= 0)
            {
                Console.WriteLine("Has perdido");
                Environment.Exit(0);
            }

            if (jugador.pocion >= 5 && tablero.getValorMatriz(jugador) == 9)
            {

            }
        }
    }
}
