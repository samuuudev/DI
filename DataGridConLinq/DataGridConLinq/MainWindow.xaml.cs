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

namespace DataGridConLinq
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // ============ DEFINICION DE VARIABLES ============ //
        private List<Persona> listaPersonas;



        public MainWindow()
        {
            InitializeComponent();
            listaPersonas = new List<Persona>()
            {
                new Persona("Juan","Pérez",28),
                new Persona("María","Gómez",34),
                new Persona("Luis","Rodríguez",22),
                new Persona("Ana","López",19),
                new Persona("Carlos","Hernández",45),
                new Persona("Sofía","Martínez",31),
                new Persona("Miguel","Sánchez",16),
                new Persona("Laura","Díaz",27),
                new Persona("Javier","Fernández",14),
                new Persona("Elena","García",17)
            };

            dgvPersonas.ItemsSource = listaPersonas;
        }

        private void Filtrar_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(txtEdadMinima.Text, out int edadMinima))
            {
                var personasFiltradas = listaPersonas.Where(p => p.edad >= edadMinima);
                dgvPersonas.ItemsSource = personasFiltradas.ToList();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una edad mínima válida.");
            }
        }

        private void MostrarTodos_Click(object sender, RoutedEventArgs e)
        {
            dgvPersonas.ItemsSource = listaPersonas;
        }
    }
}
