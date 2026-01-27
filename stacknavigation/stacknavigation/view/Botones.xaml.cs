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

namespace stacknavigation.view
{
    /// <summary>
    /// Lógica de interacción para Botones.xaml
    /// </summary>
    public partial class Botones : Page
    {
        List<Page> paginas = new List<Page>();
        int paginaActual = 0;
        public Botones()
        {
            InitializeComponent();
            cargarPaginas();

        }

        private void cargarPaginas()
        {
            paginas.Add(new MainPage());
            paginas.Add(new DetailPage());
            paginas.Add(new PaginaEjemplo1());
            paginas.Add(new PaginaEjemplo2());
            paginaActual = 0;
            // paginas.Add();
        }

        private void btn_Siguiente(object sender, RoutedEventArgs e)
        {
            paginaActual++;

            if (paginaActual < paginas.Count)
                this.NavigationService.Navigate(paginas[paginaActual]);
        }

        private void btn_Atras(object sender, RoutedEventArgs e)
        {
            paginaActual--;

            if (paginaActual < paginas.Count)
            {
                this.NavigationService.Navigate(paginas[paginaActual]);
            }
            else {
                Label error = new Label();
                error.Content = "No hay más páginas atrás";
            }
        }
    }
}
