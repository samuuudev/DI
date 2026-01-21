using System.Windows.Controls;
using StackNavigationWPF.Controllers;

namespace StackNavigationWPF.Views
{
    // Página que representa la sección de pedidos
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent(); // Inicializa la interfaz definida en XAML
        }

        // Evento del botón: navega a la página de detalle de un pedido
        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Llama al controller para navegar a OrderDetailPage
            NavigationController.Instance.GoOrderDetail();
        }
    }
}