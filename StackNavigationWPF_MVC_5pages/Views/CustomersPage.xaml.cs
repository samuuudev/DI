using System.Windows.Controls;
using StackNavigationWPF.Controllers;

namespace StackNavigationWPF.Views
{
    public partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Navega a OrdersPage
            NavigationController.Instance.GoOrders();
        }
    }
}