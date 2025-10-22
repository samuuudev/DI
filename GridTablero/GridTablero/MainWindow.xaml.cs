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

namespace GridTablero
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            crearTablero(15, 15);
        }


        public void crearTablero(int i, int j) {
            for (int fila = 0; fila < i; fila++)
            {
                RowDefinition rowDef = new RowDefinition();
                contenedor.RowDefinitions.Add(rowDef);
            }
            for (int columna = 0; columna < j; columna++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                contenedor.ColumnDefinitions.Add(colDef);
            }
            for (int fila = 0; fila < i; fila++)
            {
                for (int columna = 0; columna < j; columna++)
                {
                    
                    Label etiqueta = new Label();
                    etiqueta.Margin = new Thickness(1);
                    etiqueta.HorizontalAlignment = HorizontalAlignment.Center;
                    etiqueta.VerticalAlignment = VerticalAlignment.Center;
                    etiqueta.Content = $"({fila},{columna})";
                    Grid.SetRow(etiqueta, fila);
                    Grid.SetColumn(etiqueta, columna);
                    contenedor.Children.Add(etiqueta);
                }
            }
        }
    }
}
