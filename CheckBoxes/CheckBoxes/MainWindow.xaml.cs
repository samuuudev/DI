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

namespace CheckBoxes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void chk_Si_Checked(object sender, RoutedEventArgs e)
        {
            lbMensaje.Content = "Has seleccionado SI";
            chk_No.IsChecked = false;
        }
        private void chk_No_Checked(object sender, RoutedEventArgs e)
        {
            lbMensaje.Content = "Has seleccionado NO";
            chk_Si.IsChecked = false;
        }
    }
}