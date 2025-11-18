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

using DataGridPersonas25_26.domain;

namespace DataGridPersonas25_26
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Persona persona;
        private List<Persona> lstPersonas;
        public MainWindow()
        {
            InitializeComponent();
            lstPersonas = new List<Persona>();
            // Paso 1: Instanciamos la clase persona y la inicializamos usando el constructor vacio
            persona = new Persona();
            // Llamamos al metodo getPersonas para obtener la lista de personas
            lstPersonas = persona.getPersonas();
            // Sincronizamos el DataGrid con la lista de personas
            dgv_Personas.ItemsSource = lstPersonas;
            start();
        }

        public void start()
        {
            // Limpiamos los TextBox
            txtBox_DatosNombre.Text = "";
            txtBox_DatosApellido.Text = "";
            txtBox_DatosEdad.Text = "";
        }

        private void dgv_Personas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtenemos la persona seleccionada en el DataGrid
            Persona personaSeleccionada = (Persona)dgv_Personas.SelectedItem;

            // Mostramos los datos de la persona seleccionada en los TextBox
            if (personaSeleccionada != null) // La condicion evita el error cuando no hay ningun elemento seleccionado
            {
                txtBox_DatosNombre.Text = personaSeleccionada.Nombre;
                txtBox_DatosApellido.Text = personaSeleccionada.Apellido;
                txtBox_DatosEdad.Text = personaSeleccionada.Edad.ToString();
            }

        }

        private void btn_EliminarDatos_Click(object sender, RoutedEventArgs e)
        {
            Persona personaEliminar = (Persona)dgv_Personas.SelectedItem;
            personaEliminar.delete();
            // Borramos la persona seleccionada en el DataGrid de la lista de personas
            lstPersonas.Remove((Persona)dgv_Personas.SelectedItem);
            dgv_Personas.Items.Refresh();
            start();
        }

        private void btn_ModificarDatos_Click(object sender, RoutedEventArgs e)
        {
            // Creamos una nueva persona con los datos modificados
            Persona persona = (Persona)dgv_Personas.SelectedItem;

            persona.modificar();
            dgv_Personas.Items.Refresh();

            start();
        }

        private void btn_AgregarDatos_Click(object sender, RoutedEventArgs e)
        {

            // Creamos una nueva persona con los datos ingresados
            Persona persona = new Persona(txtBox_DatosNombre.Text, txtBox_DatosApellido.Text, int.Parse(txtBox_DatosEdad.Text));
            persona.last();
            persona.insertar();


            lstPersonas.Add(persona);
            dgv_Personas.Items.Refresh();

            start();
        }
    }
}
