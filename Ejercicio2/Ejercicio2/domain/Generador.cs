using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ejercicio2.domain
{
    internal class Generador
    {
        private Grid contenedorTablero;
        private char[,] modelo; // Modelo del tablero
        private int filas;
        private int columnas;
        private static readonly char PARED = 'P';
        private static readonly char RATON = 'R';
        private static readonly char LIBRE = ' ';

        public Generador(Grid grid)
        {
            this.contenedorTablero = grid;
        }

        /// <summary>
        /// Genera el tablero de tamaño i x j, colocando el número justo de paredes y ratones, y rellena el resto con huecos libres.
        /// </summary>
        public void crearTablero(int i, int j, int numParedes, int numRatones)
        {
            // PREPARA EL MODELO DE DATOS
            filas = i;
            columnas = j;
            modelo = new char[filas, columnas];

            // 1. Inicializa todas las posiciones como LIBRE
            for (int f = 0; f < filas; f++)
                for (int c = 0; c < columnas; c++)
                    modelo[f, c] = LIBRE;

            // 2. Genera una lista con todas las posiciones disponibles
            var rnd = new Random();
            var posicionesDisponibles = new List<(int, int)>();
            for (int f = 0; f < filas; f++)
                for (int c = 0; c < columnas; c++)
                    posicionesDisponibles.Add((f, c));

            // 3. Coloca paredes sin repetir posiciones
            for (int n = 0; n < numParedes && posicionesDisponibles.Count > 0; n++)
            {
                int idx = rnd.Next(posicionesDisponibles.Count);
                var pos = posicionesDisponibles[idx];
                modelo[pos.Item1, pos.Item2] = PARED;
                posicionesDisponibles.RemoveAt(idx);
            }
            // 4. Coloca ratones sin repetir posiciones
            for (int n = 0; n < numRatones && posicionesDisponibles.Count > 0; n++)
            {
                int idx = rnd.Next(posicionesDisponibles.Count);
                var pos = posicionesDisponibles[idx];
                modelo[pos.Item1, pos.Item2] = RATON;
                posicionesDisponibles.RemoveAt(idx);
            }

            // 5. Borra el grid visual antes de añadir labels nuevos
            contenedorTablero.Children.Clear();
            contenedorTablero.RowDefinitions.Clear();
            contenedorTablero.ColumnDefinitions.Clear();

            for (int f = 0; f < filas; f++)
                contenedorTablero.RowDefinitions.Add(new RowDefinition());
            for (int c = 0; c < columnas; c++)
                contenedorTablero.ColumnDefinitions.Add(new ColumnDefinition());

            // 6. Pinta la matriz sobre el Grid
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    Label label = new Label
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontWeight = FontWeights.Bold,
                        FontSize = 18
                    };
                    switch (modelo[f, c])
                    {
                        case 'P':
                            label.Content = "🟥"; // Pared
                            break;
                        case 'R':
                            label.Content = "🐭"; // Ratón
                            break;
                        default:
                            label.Content = ""; // Libre
                            break;
                    }
                    Grid.SetRow(label, f);
                    Grid.SetColumn(label, c);
                    contenedorTablero.Children.Add(label);
                }
            }
        }

        /// <summary>
        /// Devuelve el modelo actual del tablero (por si quieres gestionarlo) 
        /// </summary>
        public char[,] GetModelo() => modelo;
    }
}