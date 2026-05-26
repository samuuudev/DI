using aceptasreto.domain;
using aceptasreto.persistence;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace aceptasreto.view
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtUser.Text?.Trim() ?? "";
            string pass = txtPass.Password ?? "";

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass))
            {
                txtMensaje.Text = "Introduce username/correo y contraseña.";
                return;
            }

            UsuarioManage um = new UsuarioManage();
            List<object> fila = um.LoginPorUsernameOCorreo(login, pass);

            if (fila != null)
            {
                SesionActual.IdUsuario = Convert.ToInt32(fila[0]);
                SesionActual.Username = fila[1]?.ToString() ?? "";
                SesionActual.Rol = fila[2]?.ToString() ?? "";
                SesionActual.IdGrupo = string.IsNullOrEmpty(fila[3]?.ToString())
                    ? (int?)null
                    : Convert.ToInt32(fila[3]);
                var mw = new MainWindow();
                mw.Show();
                Close();
            }
            else
            {
                txtMensaje.Text = "Credenciales incorrectas.";
                txtMensaje.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void btnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }
    }
}