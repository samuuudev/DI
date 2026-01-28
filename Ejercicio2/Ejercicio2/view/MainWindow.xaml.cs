using Ejercicio2.domain;
using Org.BouncyCastle.Utilities;
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

namespace Ejercicio2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Jugador jugador;
        private List<Jugador> lstJugador;

        private Generador gen;

        public MainWindow()
        {
            InitializeComponent();

            lstJugador = new List<Jugador>();
            // Paso 1: Instanciamos la clase persona y la inicializamos usando el constructor vacio
            jugador = new Jugador();
            // Llamamos al metodo getPersonas para obtener la lista de personas
            lstJugador = jugador.getJugadores();
            // Sincronizamos el DataGrid con la lista de personas
            dgJugador.ItemsSource = lstJugador;

            
        }

        private void RefrescarJugadores()
        {
            lstJugador = jugador.getJugadores();
            dgJugador.ItemsSource = null; // Truco para forzar refresco del grid
            dgJugador.ItemsSource = lstJugador;
        }

        private void btnIniciarJuego_Click(object sender, RoutedEventArgs e)
        {
            Generador gen = new Generador(contenedorTablero);
            gen.crearTablero(6, 6, 3, 3);
        }



        private void btn_AgregarDatos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBoxNombreCRUD.Text) ||
                    !datePickerFechaCRUD.SelectedDate.HasValue ||
                    string.IsNullOrWhiteSpace(txtBoxPuntuacionCRUD.Text))
                {
                    MessageBox.Show("Complete todos los campos.");
                    return;
                }

                int nivel = cmbBoxCursoCRUD.SelectedIndex;
                int puntuacion;
                if (!int.TryParse(txtBoxPuntuacionCRUD.Text, out puntuacion))
                {
                    MessageBox.Show("Puntuación no válida.");
                    return;
                }

                Jugador nuevoJugador = new Jugador(
                    txtBoxNombreCRUD.Text,
                    datePickerFechaCRUD.SelectedDate.Value,
                    nivel,
                    puntuacion);

                nuevoJugador.insertar(); // Esto guardará en BBDD y debe actualizar el id localmente (ver más abajo)

                RefrescarJugadores();

                // Limpia los campos
                txtBoxNombreCRUD.Clear();
                txtBoxPuntuacionCRUD.Clear();
                cmbBoxCursoCRUD.SelectedIndex = 0;
                datePickerFechaCRUD.SelectedDate = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar jugador: " + ex.Message);
            }
        }

        private void btn_ModificarDatos_Click(object sender, RoutedEventArgs e)
        {
            if (dgJugador.SelectedItem is Jugador jugadorSeleccionado)
            {
                try
                {
                    // Actualizar objetos con los datos de los campos (puedes hacer doble click en el grid para rellenar los TextBox)
                    jugadorSeleccionado.Nickname = txtBoxNombreCRUD.Text;
                    jugadorSeleccionado.Puntuacion = int.Parse(txtBoxPuntuacionCRUD.Text);
                    jugadorSeleccionado.Nivel = cmbBoxCursoCRUD.SelectedIndex;
                    jugadorSeleccionado.FechaJuego = datePickerFechaCRUD.SelectedDate.Value;

                    jugadorSeleccionado.modificar();
                    RefrescarJugadores();

                    // Limpia los campos
                    txtBoxNombreCRUD.Clear();
                    txtBoxPuntuacionCRUD.Clear();
                    cmbBoxCursoCRUD.SelectedIndex = 0;
                    datePickerFechaCRUD.SelectedDate = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar jugador: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un jugador antes de modificar.");
            }
        }
            
        private void btn_EliminarDatos_Click(object sender, RoutedEventArgs e)
        {
            Jugador jugador = (Jugador)dgJugador.SelectedItem;
            jugador.delete();
            lstJugador.Remove(jugador);
        }
    }
}
