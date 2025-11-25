using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1Examen
{
    internal class Juego
    {

        /// <summary>
        /// Inicia el juego creando el tablero y jugador, llamando a todos los metodos necesarios
        /// </summary>
        public void IniciarJuego()
        {
            Tablero tablero = new Tablero(15, 15);
            Jugador jugador = new Jugador(0, 0, "S");
            bool salir = false;
            tablero.colocarJugador();
            tablero.colocarRatonesYParedes();


            while (!salir)
            {
                Console.Clear();

                tablero.MostrarTablero();
                controlador(tablero, jugador);
                
                jugador.MostrarEstado();

                Console.WriteLine();

                MostrarMenu();

                Console.WriteLine("");

                salir = ProcesarEntrada(tablero, jugador);
            }
        }


        /// <summary>
        /// Muestra el menu interactivo por consola, indicando con que teclas te mueves
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
        /// Lee la tecla presionada y en funcion de la direccion
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Obtenemos al jugador y al tablero y gestionamos toda la logica
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="jugador"></param>
        private void controlador(Tablero tablero, Jugador jugador)
        {
            // logica del juego
            switch (tablero.getValorMatriz(jugador))
            {
                case 'P':
                    Console.WriteLine("Te has encontrado una pared, movimiento invalido, repite");
                    break;
                case 'R':
                    Console.WriteLine("Te has comido un raton");
                    break;
                case 'X':
                    Console.WriteLine("Zona ya visitada, no pasa nada");
                    break;
                case 'S':
                    Console.WriteLine("Derrota: Has perdido, la serpiente cocho consigo misma");
                    Environment.Exit(0);
                    break;
            }

            if (jugador.ratones <= 0)
            {
                Console.WriteLine("Has ganado, no quedan mas ratones");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
