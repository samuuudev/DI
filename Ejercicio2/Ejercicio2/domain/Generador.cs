using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ejercicio2.domain
{
    internal class Generador
    {
        private Grid contenedorTablero;

        public Generador(Grid grid)
        {
            this.contenedorTablero = grid;
        }


        public void crearTablero(int i, int j, int numParedes, int numRatones)
        {

            Random random = new Random(3);

            for (int fila = 0; fila < i; fila++)
            {
                RowDefinition rowDef = new RowDefinition();
                contenedorTablero.RowDefinitions.Add(rowDef);
            }
            for (int columna = 0; columna < j; columna++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                contenedorTablero.ColumnDefinitions.Add(colDef);
            }
            for (int fila = 0; fila < i; fila++)
            {
                for (int columna = 0; columna < j; columna++)
                {
                    if (numParedes <= 0 && random.Next() % 2 == 0)
                    {
                        Label etiqueta = new Label();
                        etiqueta.HorizontalAlignment = HorizontalAlignment.Center;
                        etiqueta.VerticalAlignment = VerticalAlignment.Top;
                        etiqueta.Content = "P";
                        Grid.SetRow(etiqueta, fila);
                        Grid.SetColumn(etiqueta, columna);
                        contenedorTablero.Children.Add(etiqueta);
                        numParedes--;
                    }
                    else if (numRatones <= 0 && random.Next() % 2 == 0)
                    {
                        Label etiqueta = new Label();
                        etiqueta.HorizontalAlignment = HorizontalAlignment.Center;
                        etiqueta.VerticalAlignment = VerticalAlignment.Top;
                        etiqueta.Content = "R";
                        Grid.SetRow(etiqueta, fila);
                        Grid.SetColumn(etiqueta, columna);
                        contenedorTablero.Children.Add(etiqueta);
                        numRatones--;
                    }
                    else
                    {
                        Label etiqueta = new Label();
                        etiqueta.Margin = new Thickness(1);
                        etiqueta.HorizontalAlignment = HorizontalAlignment.Left;
                        etiqueta.VerticalAlignment = VerticalAlignment.Top;
                        etiqueta.Content = $"({fila},{columna})";
                        Grid.SetRow(etiqueta, fila);
                        Grid.SetColumn(etiqueta, columna);
                        contenedorTablero.Children.Add(etiqueta);
                    }
                }
            }
        }
               
            
  

        // A esta funcion la llamo desde el boton que me falta por implementar en el XAML
        public void colocarParedes()
        {
            int numParedes = 3;
            // int numParedes = Convert.ToInt32(txtbNumParedes.Text);
            for (int fila = 0; fila < contenedorTablero.RowDefinitions.Count; fila++)
            {
                for (int columna = 0; columna < contenedorTablero.ColumnDefinitions.Count; columna++)
                {
                    // coloco de forma aleatoria paredes en el tablero en base al numero aportado por el usuario en el textbox
                    Random rand = new Random();
                    int randomNum = rand.Next(0, contenedorTablero.RowDefinitions.Count * contenedorTablero.ColumnDefinitions.Count);

                    if (rand.Next(0, 3) == 0)
                    {
                        
                    }
                    
                }
            }
        }
    }
}
