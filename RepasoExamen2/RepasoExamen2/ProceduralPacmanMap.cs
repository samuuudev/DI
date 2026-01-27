using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoExamen2
{
    internal class ProceduralPacmanMap
    {
        public const int Width = 28;
        public const int Height = 31;
        private char[,] map;
        public ProceduralPacmanMap()
        {
            map = new char[Height, Width];
            GenerateMap();
        }
        private void GenerateMap()
        {
            Random rand = new Random();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Simple procedural generation logic
                    if (y == 0 || y == Height - 1 || x == 0 || x == Width - 1)
                    {
                        map[y, x] = '#'; // Wall
                    }
                    else
                    {
                        map[y, x] = (rand.NextDouble() < 0.2) ? '#' : '.'; // Wall or Path
                    }
                }
            }
        }
        public void PrintMap()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
