using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
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

            tablero.ColocarJugador(jugador);

            while (!salir)
            {
                Console.Clear();

                tablero.Mostrar(jugador);
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
                case 'C':
                    jugador.civiles++;
                    Console.WriteLine("Has rescatado a un civil");
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'D':
                    Enemigo doctorOctopus = new Enemigo('D');
                    doctorOctopus.Atacar(jugador, tablero);
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'G': 
                    Enemigo duendeVerde = new Enemigo('G');
                    duendeVerde.Atacar(jugador, tablero);
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'M': 
                    Enemigo mysterio = new Enemigo('M');
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    mysterio.Atacar(jugador, tablero);
                    break;
                case 'N':
                    Console.WriteLine("Has caido en una zona neutra, no pasa nada");
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'X':
                    Console.WriteLine("Zona ya visitada, no pasa nada");
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'B':
                    Console.WriteLine("Has obtenido un bonus de salto. Podras moverte 2 casillas");
                    jugador.TieneBonusSalto = true;
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
            }

            if (jugador.vida <= 0)
            {
                Console.WriteLine("Has perdido");
                Environment.Exit(0);
            }

            if (jugador.civiles >= 5 && tablero.getPosicionAbsoluta(jugador) == tablero.getUltimaPosicion())
            {
                Console.WriteLine("Has ganado");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
