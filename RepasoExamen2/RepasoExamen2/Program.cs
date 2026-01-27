using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoExamen2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pacman pacman = new Pacman(10, 10);

            while (true)
            {
                // Lee la tecla sin mostrarla
                var key = Console.ReadKey(true);
                Console.Clear();
                pacman.Mover(key.Key);
                pacman.mostrarMapa();

                if (key.Key == ConsoleKey.Escape)
                    break; // salir del bucle

                if (key.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    pacman.generarMapaProcedural();
                    pacman.PlacePacman(1, 1);
                    pacman.mostrarMapa();
                    Console.WriteLine("Pulsa [espacio] para regenerar el mapa o [Esc] para salir.");
                }
            }
        }
    }
}
