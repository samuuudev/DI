using System.Windows.Controls;
using StackNavigationWPF.Views;

namespace StackNavigationWPF.Controllers
{
    // Controller centralizado para la navegación
    // Se encarga de manejar el Frame y decidir qué página mostrar
    public class NavigationController
    {
        private static NavigationController instance; // Singleton
        private readonly Frame frame; // Frame de la ventana principal donde se muestran las páginas

        // Constructor privado: inicializa con un Frame
        private NavigationController(Frame frame)
        {
            this.frame = frame;
        }

        // Inicializa la instancia única del controller
        public static void Initialize(Frame frame)
        {
            instance = new NavigationController(frame);
        }

        // Acceso global a la instancia del controller
        public static NavigationController Instance => instance;

        // Métodos para navegar a cada página
        // Cada Navigate agrega una página a la pila de navegación interna de WPF
        public void GoHome() => frame.Navigate(new HomePage());
        public void GoCustomers() => frame.Navigate(new CustomersPage());
        public void GoOrders() => frame.Navigate(new OrdersPage());
        public void GoOrderDetail() => frame.Navigate(new OrderDetailPage());
        public void GoSettings() => frame.Navigate(new SettingsPage());
    }
}