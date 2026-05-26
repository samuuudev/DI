using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Net;
using System.IO;
using aceptasreto.Persistence;

namespace repartoCrystalReports
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DataSet1 _dataSet;

        public Window1()
        {
            InitializeComponent();
            reportViewer.Owner = this;
            _dataSet = new DataSet1();
            CargarDatosDesdeMySQL();
            CargarEntrenadores();
        }

        private void CargarDatosDesdeMySQL()
        {
            try
            {
                DBBroker broker = DBBroker.obtenerAgente();

                _dataSet.Entrenador.Clear();
                broker.llenarDataTable(_dataSet.Entrenador, "SELECT ID_ENTRENADOR, NOMBRE, ESPECIALIDAD FROM entrenador");

                CrystalReport1 reporte = new CrystalReport1();
                reporte.SetDataSource(_dataSet);
                reportViewer.ViewerCore.ReportSource = reporte;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarEntrenadores()
        {
            try
            {
                DBBroker broker = DBBroker.obtenerAgente();
                _dataSet.Entrenador.Clear();
                broker.llenarDataTable(_dataSet.Entrenador, "SELECT ID_ENTRENADOR, NOMBRE, ESPECIALIDAD FROM entrenador");
                dgEntrenadores.ItemsSource = _dataSet.Entrenador.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tabla: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnApiRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "https://api.chucknorris.io/jokes/random";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    txtApiResult.Text = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la petición API: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCargar_Click(object sender, RoutedEventArgs e)
        {
            CargarEntrenadores();
            CargarDatosDesdeMySQL();
        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEntrenador.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("ID y NOMBRE son obligatorios.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                DBBroker broker = DBBroker.obtenerAgente();
                string id = EscapeSql(txtIdEntrenador.Text.Trim());
                string nombre = EscapeSql(txtNombre.Text.Trim());
                string especialidad = EscapeSql(txtEspecialidad.Text.Trim());

                string sql = "INSERT INTO entrenador (ID_ENTRENADOR, NOMBRE, ESPECIALIDAD) VALUES ('" + id + "', '" + nombre + "', '" + especialidad + "')";
                broker.modificar(sql);
                CargarEntrenadores();
                CargarDatosDesdeMySQL();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEntrenador.Text))
            {
                MessageBox.Show("Selecciona o escribe un ID_ENTRENADOR.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                DBBroker broker = DBBroker.obtenerAgente();
                string id = EscapeSql(txtIdEntrenador.Text.Trim());
                string nombre = EscapeSql(txtNombre.Text.Trim());
                string especialidad = EscapeSql(txtEspecialidad.Text.Trim());

                string sql = "UPDATE entrenador SET NOMBRE = '" + nombre + "', ESPECIALIDAD = '" + especialidad + "' WHERE ID_ENTRENADOR = '" + id + "'";
                broker.modificar(sql);
                CargarEntrenadores();
                CargarDatosDesdeMySQL();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEntrenador.Text))
            {
                MessageBox.Show("Selecciona o escribe un ID_ENTRENADOR.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                DBBroker broker = DBBroker.obtenerAgente();
                string id = EscapeSql(txtIdEntrenador.Text.Trim());
                string sql = "DELETE FROM entrenador WHERE ID_ENTRENADOR = '" + id + "'";
                broker.modificar(sql);
                CargarEntrenadores();
                CargarDatosDesdeMySQL();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DgEntrenadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView fila = dgEntrenadores.SelectedItem as DataRowView;
            if (fila == null)
            {
                return;
            }

            txtIdEntrenador.Text = fila["ID_ENTRENADOR"].ToString();
            txtNombre.Text = fila["NOMBRE"].ToString();
            txtEspecialidad.Text = fila["ESPECIALIDAD"].ToString();
        }

        private void LimpiarFormulario()
        {
            txtIdEntrenador.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;
        }

        private string EscapeSql(string valor)
        {
            return valor.Replace("'", "''");
        }
    }
}
