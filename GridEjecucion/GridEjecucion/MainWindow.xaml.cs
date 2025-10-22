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

namespace GridEjecucion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    // Inicializamos el boton
                    Button btn = new Button();

                    btn.Width = 100;
                    btn.Height = 50;


                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.VerticalAlignment = VerticalAlignment.Top;

                    btn.Content = "Btn " + i + "." + j;

                    btn.Margin = new Thickness(20 + i * 110, 10 + j * 55, 0, 0);
                    contenedor.Children.Add(btn);
                }
            }
        }
    }
}
