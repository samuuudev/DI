using System.Windows;
using StackNavigationWPF.Controllers;

namespace StackNavigationWPF.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Inicializa el controller pasándole el Frame donde navegará
            NavigationController.Initialize(MainFrame);

            // Comienza la navegación desde la HomePage
            NavigationController.Instance.GoHome();
        }
    }
}