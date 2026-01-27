using System;

class ProceduralPacmanMap
{
    // Constantes que representan el tamaño del mapa
    const int width = 21;
    const int height = 19;
    static char[,] map = new char[height, width];

    static Random rnd = new Random();

    static void Main()
    {
        GenerateMap();
        PrintMap();
    }

    // Generación procedural simple para el mapa estilo Pac-Man
    static void GenerateMap()
    {
        // 1. Rellenar el mapa de muros ('#')
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                map[y, x] = '#';

        // 2. Crear pasillos centrales horizontales
        for (int y = 1; y < height - 1; y += 2)
            for (int x = 1; x < width - 1; x++)
                map[y, x] = '.';

        // 3. Crear algunos pasillos verticales aleatorios, asegurando simetría
        for (int x = 1; x < width / 2; x += 2)
        {
            for (int y = 1; y < height - 1; y++)
            {
                if (rnd.NextDouble() > 0.3)
                {
                    map[y, x] = '.';
                    map[y, width - 1 - x] = '.'; // Simetría horizontal
                }
            }
        }

        // 4. Crear una zona en el centro para los fantasmas
        int ghostX = width / 2;
        int ghostY = height / 2;
        map[ghostY, ghostX] = 'G';
        map[ghostY, ghostX - 1] = ' ';
        map[ghostY, ghostX + 1] = ' ';
        map[ghostY - 1, ghostX] = ' ';
        map[ghostY + 1, ghostX] = ' ';

        // 5. Posicionar a Pac-Man de inicio
        map[height - 2, 1] = 'P';

        // 6. Asegurar que los bordes son muros (opcional: puedes agregar túneles a los lados)
        // (ya están puestos arriba)
    }

    // Dibujar el mapa en consola
    static void PrintMap()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
                Console.Write(map[y, x]);
            Console.WriteLine();
        }
    }
}
