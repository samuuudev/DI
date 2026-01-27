using System.Windows.Controls;
using StackNavigationWPF.Controllers;

namespace StackNavigationWPF.Views
{
    // Página que muestra los detalles de un pedido
    public partial class OrderDetailPage : Page
    {
        public OrderDetailPage()
        {
            InitializeComponent(); // Inicializa la interfaz definida en XAML
        }

        // Evento del botón: navega a la página de configuración (Settings)
        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Llama al controller para navegar a SettingsPage
            NavigationController.Instance.GoSettings();
        }
    }
}