using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mariposa
{
    /// <summary>
    /// Lógica de interacción para tablero.xaml
    /// </summary>
    public partial class tablero : Page
    {
        public tablero()
        {
            InitializeComponent();
            crearTablero(8, 8);
        }

        public void crearTablero(int filas, int columnas)
        {
            Grid tableroGrid = new Grid();
            for (int i = 0; i < filas; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                tableroGrid.RowDefinitions.Add(rowDef);
            }
            for (int j = 0; j < columnas; j++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                tableroGrid.ColumnDefinitions.Add(colDef);
            }
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Border cellBorder = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1)
                    };
                    Grid.SetRow(cellBorder, i);
                    Grid.SetColumn(cellBorder, j);
                    tableroGrid.Children.Add(cellBorder);
                }
            }

            // Mover el Frame del XAML dentro del nuevo grid
            gridTablero.Children.Clear(); // lo sacamos de su contenedor anterior
            tableroGrid.Children.Add(mariposaTablero);
            Grid.SetRow(mariposaTablero, 0);
            Grid.SetColumn(mariposaTablero, 0);

            // Insertar todo en el contenedor original
            gridTablero.Children.Add(tableroGrid);
        }
    }
}
