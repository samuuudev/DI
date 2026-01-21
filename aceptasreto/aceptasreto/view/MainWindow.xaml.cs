using aceptasreto.domain;
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

namespace aceptasreto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Alumno alumno;
        private List<Alumno> listaAlumnos;

        public MainWindow()
        {
            InitializeComponent();
            listaAlumnos = new List<Alumno>();
            alumno = new Alumno();

            listaAlumnos = alumno.getAlumnos();

            dgAlumnos.ItemsSource = listaAlumnos;

        }

        // Alumno CRUD botones
        private void btn_AgregarDatosA_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = new Alumno(txtBoxNombreCRUD.Text, txtBoxApellidoCRUD.Text);
            // alumno.last();
            alumno.insertar();
            dgAlumnos.Items.Refresh();
        }

        private void btn_ModificarDatosA_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = (Alumno)dgAlumnos.SelectedItem;
            alumno.modificar();
            dgAlumnos.Items.Refresh();
        }

        private void btn_EliminarDatosA_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = (Alumno)dgAlumnos.SelectedItem;
            alumno.delete();
            dgAlumnos.Items.Refresh();
        }

        // Empresa CRUD botones
        private void btn_AgregarDatosE_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = new Empresa(
                txtBoxRazonSocialE.Text, 
                txtBoxCiudadE.Text, 
                txtBoxDireccionE.Text, 
                txtBoxTelefonoContactoE.Text, 
                txtBoxCorreoContactoE.Text
                
            );

            empresa.insertar();
            dgAlumnos.Items.Refresh();
        }

        private void btn_ModificarDatosE_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = (Empresa)dgAlumnos.SelectedItem;
            empresa.modificar();
            dgAlumnos.Items.Refresh();
        }

        private void btn_EliminarDatosE_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = (Empresa)dgAlumnos.SelectedItem;
            empresa.delete();
            dgAlumnos.Items.Refresh();
        }

    }
}
