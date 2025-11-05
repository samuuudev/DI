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
            // Descargamos los datos de la base de datos (simulado)


            // Paso 1: Instanciamos la clase persona y la inicializamos usando el constructor vacio
            persona = new Persona();
            // Llamamos al metodo getPersonas para obtener la lista de personas
            lstPersonas = persona.getPersonas();
            // Sincronizamos el DataGrid con la lista de personas
            dgv_Personas.ItemsSource = lstPersonas;
        }

        public void start()
        {
            txtBox_DatosNombre.Text = "";
            txtBox_DatosApellido.Text = "";
            txtBox_DatosEdad.Text = "";
        }

        private void dgv_Personas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // txtBox_DatosNombre.Text = "Ha cambiado la seleccion";
        }

        private void btn_EliminarDatos_Click(object sender, RoutedEventArgs e)
        {
            lstPersonas.Remove((Persona)dgv_Personas.SelectedItem);
            dgv_Personas.Items.Refresh();
            start();
        }

        private void btn_ModificarDatos_Click(object sender, RoutedEventArgs e)
        {
            // Creamos una nueva persona con los datos modificados
            Persona persona = new Persona(txtBox_DatosNombre.Text, txtBox_DatosApellido.Text, int.Parse(txtBox_DatosEdad.Text));
            // Reemplazamos la persona seleccionada en la lista por la nueva persona
            lstPersonas[dgv_Personas.SelectedIndex] = persona;
            dgv_Personas.Items.Refresh();

            start();
        }

        private void btn_AgregarDatos_Click(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona(txtBox_DatosNombre.Text, txtBox_DatosApellido.Text, int.Parse(txtBox_DatosEdad.Text));
            lstPersonas.Add(persona);
            dgv_Personas.Items.Refresh();

            start();
        }
    }
}
