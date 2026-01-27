using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoExamen2
{
    internal class Pacman
    {
        private int x;
        private int y;

        private char[,] map;


        private const char Wall = '#';
        private const char Path = '.';
        private const char PacmanChar = 'P';

        public Pacman(int x, int y)
        {
            this.map = new char[x, y];
        }

        public void PlacePacman(int startX, int startY)
        {
            x = startX;
            y = startY;
            map[y, x] = PacmanChar;
        }


        public void mostrarMapa()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void rellenarMapa()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1 || j == 0 || j == map.GetLength(1) - 1)
                    {
                        map[i, j] = Wall;
                    }
                    else
                    {
                        map[i, j] = Path;
                    }
                }
            }
        }

        public void generarMapaProcedural()
        {
            Random rand = new Random();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1 || j == 0 || j == map.GetLength(1) - 1)
                    {
                        map[i, j] = Wall;
                    }
                    else
                    {
                        map[i, j] = (rand.NextDouble() < 0.2) ? Wall : Path;
                    }
                }
            }
        }


        public void Mover(ConsoleKey direccion)
        {
            int newX = x;
            int newY = y;

            // Calcula la nueva posición según la tecla
            switch (direccion)
            {
                case ConsoleKey.UpArrow:
                    newY--;
                    break;
                case ConsoleKey.DownArrow:
                    newY++;
                    break;
                case ConsoleKey.LeftArrow:
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    newX++;
                    break;
                default:
                    return; // tecla no válida
            }

            // Comprobar límites y evitar muros
            if (newY < 0 || newY >= map.GetLength(0) ||
                newX < 0 || newX >= map.GetLength(1) ||
                map[newY, newX] == Wall)
                return; // Movimiento inválido

            // Limpia la posición previa (puede dejar Path u otro char)
            map[y, x] = Path;

            // Actualiza la posición
            x = newX;
            y = newY;
            map[y, x] = PacmanChar;
        }

        public void ColocarEnemigo()
        {
            Random rnd = new Random();
            int enemyX, enemyY;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '#')
                    {
                        
                    }
                }
            }
        }
    }
}
