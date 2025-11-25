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

namespace Ejercicio1Examen
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



        private void btnIniciarJuego_Click(object sender, RoutedEventArgs e)
        {
            Generador gen = new Generador(contenedorTablero);
            gen.crearTablero(6, 6, 3, 3);
            gen.colocarParedes();
        }

        private void btn_AgregarDatos_Click(object sender, RoutedEventArgs e)
        {

            string fecha = datePickerFechaCRUD.SelectedDate.ToString();
            int nivel = cmbBoxCursoCRUD.SelectedIndex;

            Console.WriteLine(fecha);

            Jugador jugador = new Jugador(
                txtBoxNombreCRUD.Text,
                DateTime.Parse(fecha),
                cmbBoxCursoCRUD.SelectedIndex,
                int.Parse(txtBoxPuntuacionCRUD.Text));

            jugador.insertar();
            lstJugador.Add(jugador);
            dgJugador.Items.Refresh();
        }

        private void btn_ModificarDatos_Click(object sender, RoutedEventArgs e)
        {
            Jugador jugador = (Jugador)dgJugador.SelectedItem;
            jugador.modificar();
            dgJugador.Items.Refresh();
            
        }

        private void btn_EliminarDatos_Click(object sender, RoutedEventArgs e)
        {
            Jugador jugador = (Jugador)dgJugador.SelectedItem;
            jugador.delete();
            lstJugador.Remove(jugador);
        }
    }
}
