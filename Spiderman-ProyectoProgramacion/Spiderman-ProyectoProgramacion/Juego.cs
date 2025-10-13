using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
{
    internal class Juego
    {
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
                tablero.MostrarMatriz(jugador);

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
                case 'C':
                    jugador.civiles++;
                    Console.WriteLine("Has rescatado a un civil");
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'D':
                    Enemigo doctorOctopus = new Enemigo('D');
                    doctorOctopus.Atacar(jugador);
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'G': 
                    Enemigo duendeVerde = new Enemigo('G');
                    duendeVerde.Atacar(jugador);
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
                    break;
                case 'M': 
                    Enemigo mysterio = new Enemigo('M');
                    mysterio.Atacar(jugador);
                    tablero.LimpiarCasilla(jugador.PosI, jugador.PosJ);
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

            if (jugador.civiles >= 5 && tablero.getValorMatriz(jugador) == tablero.getUltimaPosicion())
            {
                Console.WriteLine("Has ganado");
                Environment.Exit(0);
            }
        }
    }
}
