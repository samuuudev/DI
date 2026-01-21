using aceptasreto.Persistence;
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
using System.Windows.Shapes;

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUser.Text?.Trim() ?? string.Empty;
            string contraseña = txtPasswd.Text ?? string.Empty;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                ShowMessage("Introduce usuario y contraseña.", Colors.DarkRed);
                return;
            }

            try
            {
                // --- Construye aquí la consulta que desees usar contra la BBDD ---
                // Ejemplo (sustituye por tu tabla/columnas reales):
                string sql = $"SELECT id FROM aceptasreto.usuario WHERE usuario = '{Escape(usuario)}' AND contraseña = '{Escape(contraseña)}';";

                var filas = DBBroker.obtenerAgente().leer(sql);

                if (filas != null && filas.Count > 0)
                {
                    ShowMessage("Inicio de sesión correcto.", Colors.Green);
                    // Aquí puedes abrir MainWindow, guardar contexto de usuario, etc.
                    // Ejemplo: this.DialogResult = true; this.Close();
                }
                else
                {
                    ShowMessage("Usuario o contraseña incorrectos.", Colors.DarkRed);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error al conectar con la BBDD: " + ex.Message, Colors.DarkRed);
            }
        }
        private void ShowMessage(string text, Color color)
        {
            txtMensaje.Text = text;
            txtMensaje.Foreground = new SolidColorBrush(color);
        }
        private string Escape(string s) => s.Replace("'", "''");

    }
}