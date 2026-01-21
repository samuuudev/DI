using System.Windows.Controls;
using StackNavigationWPF.Controllers;

namespace StackNavigationWPF.Views
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent(); // Inicializa los componentes XAML
        }

        // Evento del botón: cuando se pulsa, se llama al controller
        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Navegamos a CustomersPage
            NavigationController.Instance.GoCustomers();
        }
    }
}