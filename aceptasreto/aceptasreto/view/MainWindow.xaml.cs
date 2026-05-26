using aceptasreto.domain;
using aceptasreto.persistence;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace aceptasreto
{
    public partial class MainWindow : Window
    {
        private List<Alumno> listaAlumnos;
        private List<Empresa> listaEmpresas;
        private List<Reto> listaRetos;
        private List<Grupo> listaGrupos;
        private List<Usuario> listaUsuarios;
        private List<TalentLab> listaTL;
        private List<Reto> retosDisponiblesTL;
        private List<Reto> retosSeleccionadosTL;

        // Para la gestión de grupos
        private List<Alumno> lstAlumnosNoAsignados;
        private List<Alumno> lstAlumnosSeleccionados;
        private Grupo grupoSeleccionado;

        public MainWindow()
        {
            InitializeComponent();
            MainTabControl.SelectedIndex = 0;
            CargarDatos();
            AplicarPermisos();
        }

        private int? ParseNullableInt(string txt)
        {
            if (string.IsNullOrWhiteSpace(txt)) return null;
            int v;
            return int.TryParse(txt, out v) ? (int?)v : null;
        }

        private void CargarDatos()
        {
            RecargarAlumnos();
            RecargarEmpresas();
            RecargarRetos();
            RecargarGrupos();
            RecargarTalentLab();
            RecargarUsuarios();
        }

        private void RecargarAlumnos()
        {
            listaAlumnos = new Alumno().getAlumnos();
            dgAlumnos.ItemsSource = listaAlumnos;
        }

        private void RecargarEmpresas()
        {
            listaEmpresas = new Empresa("", "", "", "", "").getEmpresas();
            dgEmpresas.ItemsSource = listaEmpresas;
        }

        private void RecargarRetos()
        {
            listaRetos = new Reto().getRetos(SesionActual.EsAdmin, SesionActual.IdGrupo);
            dgRetos.ItemsSource = listaRetos;
        }

        private void RecargarGrupos()
        {
            listaGrupos = new Grupo().getGrupos(SesionActual.EsAdmin, SesionActual.IdGrupo);
            CargarDatosGrupos(); // Carga también las listas de alumnos
        }

        private void RecargarTalentLab()
        {
            listaTL = new TalentLab().getTalentLabs(SesionActual.EsAdmin, SesionActual.IdGrupo);
            dgTalentLab.ItemsSource = listaTL;
            InicializarEditorTalentLab();
        }

        private void RecargarUsuarios()
        {
            listaUsuarios = new Usuario().getUsuarios();
            dgUsuarios.ItemsSource = listaUsuarios;
        }

        private void AplicarPermisos()
        {
            if (SesionActual.EsAdmin) return;

            btn_AgregarDatosA.IsEnabled = false;
            btn_ModificarDatosA.IsEnabled = false;
            btn_EliminarDatosA.IsEnabled = false;

            btn_AgregarDatosE.IsEnabled = false;
            btn_ModificarDatosE.IsEnabled = false;
            btn_EliminarDatosE.IsEnabled = false;

            btn_AgregarDatosR.IsEnabled = false;
            btn_ModificarDatosR.IsEnabled = false;
            btn_EliminarDatosR.IsEnabled = false;

            BtnAñadirModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;

            btn_AgregarTL.IsEnabled = false;
            btn_ModificarTL.IsEnabled = false;
            btn_EliminarTL.IsEnabled = false;

            btn_AgregarUsuario.IsEnabled = false;
            btn_ModificarUsuario.IsEnabled = false;
            btn_EliminarUsuario.IsEnabled = false;

            dgAlumnos.IsReadOnly = true;
            dgEmpresas.IsReadOnly = true;
            dgRetos.IsReadOnly = true;
            dgTalentLab.IsReadOnly = true;
            dgUsuarios.IsReadOnly = true;
        }

        // ===== Métodos de navegación =====
        private void NavAlumnado_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
        }

        private void NavGrupos_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void NavEmpresas_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        private void NavRetos_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 3;
        }

        private void NavTalent_Lab_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 4;
        }

        private void NavUsuarios_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 5;
        }

        // ===== Buscador Alumnado =====
        private void txtBoxBuscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded || dgAlumnos == null || listaAlumnos == null)
                return;

            string q = (txtBoxBuscador.Text ?? "").Trim().ToLower();

            if (string.IsNullOrWhiteSpace(q) || q == "Buscar alumnado")
            {
                dgAlumnos.ItemsSource = listaAlumnos;
                return;
            }

            var filtrada = listaAlumnos.FindAll(a =>
                (a.Nombre ?? "").ToLower().Contains(q) ||
                (a.Apellido ?? "").ToLower().Contains(q) ||
                a.Grupo.ToString().Contains(q) ||
                a.Id.ToString().Contains(q)
            );

            dgAlumnos.ItemsSource = filtrada;
        }

        // ===== Alumnado =====
        private void btn_AgregarDatosA_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alta alumnado pendiente (usuario + alumnado).");
        }

        private void btn_ModificarDatosA_Click(object sender, RoutedEventArgs e)
        {
            Alumno a = dgAlumnos.SelectedItem as Alumno;
            if (a == null) return;

            a.Nombre = txtBoxNombreCRUD.Text;
            a.Apellido = txtBoxApellidoCRUD.Text;
            a.modificar();
            RecargarAlumnos();
        }

        private void btn_EliminarDatosA_Click(object sender, RoutedEventArgs e)
        {
            Alumno a = dgAlumnos.SelectedItem as Alumno;
            if (a == null) return;

            a.delete();
            RecargarAlumnos();
        }

        // ===== Métodos vacíos de SelectionChanged =====
        private void dgAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Alumno a = dgAlumnos.SelectedItem as Alumno;
            if (a != null)
            {
                txtBoxNombreCRUD.Text = a.Nombre;
                txtBoxApellidoCRUD.Text = a.Apellido;
            }
        }

        private void dgGrupos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grupo g = ListGroupMembers.SelectedItem as Grupo;
            if (g != null)
            {
                GroupNameTextBox.Text = g.Descripcion;
            }
        }

        private void dgEmpresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Empresa empresa = dgEmpresas.SelectedItem as Empresa;
            if (empresa != null)
            {
                txtBoxRazonSocialE.Text = empresa.RazonSocial;
                txtBoxCiudadE.Text = empresa.Ciudad;
                txtBoxDireccionE.Text = empresa.Direccion;
                txtBoxTelefonoContactoE.Text = empresa.TelefonoContacto;
                txtBoxCorreoContactoE.Text = empresa.EmailContacto;
            }
        }

        private void dgRetos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reto r = dgRetos.SelectedItem as Reto;
            if (r == null) return;

            txtBoxIdReto.Text = r.Id.ToString();
            txtBoxDescripcionR.Text = r.Descripcion;
        }

        private void dgTalentLab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TalentLab tl = dgTalentLab.SelectedItem as TalentLab;
            if (tl == null)
            {
                InicializarEditorTalentLab();
                return;
            }

            CargarTalentLabParaEditar(tl);
        }

        private void dgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Usuario u = dgUsuarios.SelectedItem as Usuario;
            if (u != null)
            {
                txtUUsername.Text = u.Username;
                txtUPass.Text = u.Contraseña;
                txtUNombre.Text = u.Nombre;
                txtUApellido.Text = u.Apellido;
                txtUCorreo.Text = u.Correo;
                txtURol.Text = u.Rol;
                txtUActivo.Text = u.Activo.ToString();
                txtUGrupo.Text = u.IdGrupo?.ToString() ?? "";
            }
        }

        // ===== Empresas =====
        private void btn_AgregarDatosE_Click(object sender, RoutedEventArgs e)
        {
            Empresa e1 = new Empresa(
                txtBoxRazonSocialE.Text,
                txtBoxCiudadE.Text,
                txtBoxDireccionE.Text,
                txtBoxTelefonoContactoE.Text,
                txtBoxCorreoContactoE.Text
            );

            e1.insertar();
            RecargarEmpresas();
            LimpiarCamposEmpresa();
        }

        private void btn_ModificarDatosE_Click(object sender, RoutedEventArgs e)
        {
            Empresa e1 = dgEmpresas.SelectedItem as Empresa;
            if (e1 == null) return;

            e1.RazonSocial = txtBoxRazonSocialE.Text;
            e1.Ciudad = txtBoxCiudadE.Text;
            e1.Direccion = txtBoxDireccionE.Text;
            e1.TelefonoContacto = txtBoxTelefonoContactoE.Text;
            e1.EmailContacto = txtBoxCorreoContactoE.Text;

            e1.modificar();
            RecargarEmpresas();
            LimpiarCamposEmpresa();
        }

        private void btn_EliminarDatosE_Click(object sender, RoutedEventArgs e)
        {
            Empresa e1 = dgEmpresas.SelectedItem as Empresa;
            if (e1 == null) return;

            e1.delete();
            RecargarEmpresas();
            LimpiarCamposEmpresa();
        }

        private void LimpiarCamposEmpresa()
        {
            txtBoxRazonSocialE.Text = "";
            txtBoxCiudadE.Text = "";
            txtBoxDireccionE.Text = "";
            txtBoxTelefonoContactoE.Text = "";
            txtBoxCorreoContactoE.Text = "";
        }

        // ===== Retos =====
        private void btn_AgregarDatosR_Click(object sender, RoutedEventArgs e)
        {
            string descripcion = (txtBoxDescripcionR.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Introduce una descripción para el reto.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Reto reto = new Reto(descripcion);
            reto.insertar();
            RecargarRetos();
            LimpiarCamposReto();
        }

        private void btn_ModificarDatosR_Click(object sender, RoutedEventArgs e)
        {
            Reto reto = dgRetos.SelectedItem as Reto;
            if (reto == null)
            {
                MessageBox.Show("Selecciona un reto para modificar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string descripcion = (txtBoxDescripcionR.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            reto.Descripcion = descripcion;
            reto.modificar();
            RecargarRetos();
            LimpiarCamposReto();
        }

        private void btn_EliminarDatosR_Click(object sender, RoutedEventArgs e)
        {
            Reto reto = dgRetos.SelectedItem as Reto;
            if (reto == null)
            {
                MessageBox.Show("Selecciona un reto para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show(
                $"¿Eliminar el reto con id {reto.Id}?",
                "Confirmar eliminación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes) return;

            reto.delete();
            RecargarRetos();
            LimpiarCamposReto();
        }

        private void BuscarReto_Click(object sender, RoutedEventArgs e)
        {
            if (listaRetos == null)
            {
                RecargarRetos();
            }

            string q = (txtBoxBuscadorReto.Text ?? "").Trim().ToLower();
            if (string.IsNullOrWhiteSpace(q) || q == "buscar reto")
            {
                dgRetos.ItemsSource = listaRetos;
                return;
            }

            var filtrada = listaRetos.FindAll(r =>
                r.Id.ToString().Contains(q) ||
                (r.Descripcion ?? "").ToLower().Contains(q));

            dgRetos.ItemsSource = filtrada;
        }

        private void LimpiarCamposReto()
        {
            txtBoxIdReto.Text = "";
            txtBoxDescripcionR.Text = "";
        }

        // ===== CRUD de GRUPOS simple =====
        private void btn_AgregarGrupo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GroupNameTextBox.Text))
            {
                MessageBox.Show("Introduce una descripción para el grupo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Grupo g = new Grupo(GroupNameTextBox.Text);
            g.insertar();
            RecargarGrupos();
            GroupNameTextBox.Text = "";
        }

        private void btn_ModificarGrupo_Click(object sender, RoutedEventArgs e)
        {
            Grupo g = grupoSeleccionado ?? (ListGroupMembers.SelectedItem as Grupo);
            if (g == null) return;

            g.Descripcion = GroupNameTextBox.Text;
            g.modificar();
            RecargarGrupos();
        }

        private void btn_EliminarGrupo_Click(object sender, RoutedEventArgs e)
        {
            Grupo g = grupoSeleccionado ?? (ListGroupMembers.SelectedItem as Grupo);
            if (g == null) return;

            g.delete();
            RecargarGrupos();
        }

        // ===== GESTIÓN AVANZADA DE GRUPOS (con asignación de alumnos) =====

        /// <summary>
        /// Carga los datos iniciales para la gestión de grupos
        /// </summary>
        private void CargarDatosGrupos()
        {
            // Carga alumnos no asignados
            Alumno alumnoTemp = new Alumno();
            lstAlumnosNoAsignados = alumnoTemp.am.LeerAlumnosSinGrupo();
            ListUnassigned.ItemsSource = lstAlumnosNoAsignados;
            ListUnassigned.DisplayMemberPath = "NombreCompleto";

            // Inicializa lista de seleccionados
            lstAlumnosSeleccionados = new List<Alumno>();
            ListSelected.ItemsSource = lstAlumnosSeleccionados;
            ListSelected.DisplayMemberPath = "NombreCompleto";

            // Carga grupos en la lista inferior
            ListGroupMembers.ItemsSource = listaGrupos;
            ListGroupMembers.DisplayMemberPath = "Nombre";

            // Limpia campos
            GroupNameTextBox.Text = "";
            grupoSeleccionado = null;
        }

        /// <summary>
        /// Mueve alumnos seleccionados de "no asignados" a "seleccionados"
        /// </summary>
        private void BtnMoverDerecha_Click(object sender, RoutedEventArgs e)
        {
            if (ListUnassigned.SelectedItems.Count > 0)
            {
                List<Alumno> alumnosAMover = new List<Alumno>();
                foreach (Alumno alumno in ListUnassigned.SelectedItems)
                {
                    alumnosAMover.Add(alumno);
                }

                foreach (Alumno alumno in alumnosAMover)
                {
                    lstAlumnosNoAsignados.Remove(alumno);
                    lstAlumnosSeleccionados.Add(alumno);
                }

                ListUnassigned.Items.Refresh();
                ListSelected.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Selecciona al menos un alumno para mover", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Mueve alumnos seleccionados de "seleccionados" a "no asignados"
        /// </summary>
        private void BtnMoverIzquierda_Click(object sender, RoutedEventArgs e)
        {
            if (ListSelected.SelectedItems.Count > 0)
            {
                List<Alumno> alumnosAMover = new List<Alumno>();
                foreach (Alumno alumno in ListSelected.SelectedItems)
                {
                    alumnosAMover.Add(alumno);
                }

                foreach (Alumno alumno in alumnosAMover)
                {
                    lstAlumnosSeleccionados.Remove(alumno);
                    lstAlumnosNoAsignados.Add(alumno);
                }

                ListUnassigned.Items.Refresh();
                ListSelected.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Selecciona al menos un alumno para mover", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Guarda o modifica un grupo con los alumnos seleccionados
        /// </summary>
        private void BtnAñadirModificar_Click(object sender, RoutedEventArgs e)
        {
            string nombreGrupo = GroupNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(nombreGrupo))
            {
                MessageBox.Show("Introduce un nombre para el grupo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                int idGrupoActual;

                if (grupoSeleccionado == null)
                {
                    // Crear nuevo grupo
                    Grupo nuevoGrupo = new Grupo(nombreGrupo);
                    nuevoGrupo.insertar();
                    idGrupoActual = nuevoGrupo.gm.ObtenerUltimoId();
                }
                else
                {
                    // Modificar grupo existente
                    grupoSeleccionado.Descripcion = nombreGrupo;
                    grupoSeleccionado.modificar();
                    idGrupoActual = grupoSeleccionado.IdGrupo;

                    // Desasignar alumnos anteriores
                    Alumno alumnoTemp = new Alumno();
                    List<Alumno> alumnosAntiguos = alumnoTemp.am.LeerAlumnosPorGrupo(idGrupoActual);
                    foreach (Alumno a in alumnosAntiguos)
                    {
                        a.DesasignarGrupo();
                    }
                }

                // Asignar alumnos seleccionados al grupo
                foreach (Alumno alumno in lstAlumnosSeleccionados)
                {
                    alumno.AsignarGrupo(idGrupoActual);
                }

                MessageBox.Show($"Grupo '{nombreGrupo}' guardado correctamente con {lstAlumnosSeleccionados.Count} alumno(s)",
                               "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                RecargarGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el grupo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Elimina el grupo seleccionado
        /// </summary>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un grupo de la lista inferior para eliminarlo.",
                               "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show(
                $"¿Estás seguro de eliminar el grupo '{grupoSeleccionado.Nombre}'?\n\nLos alumnos volverán a la lista de no asignados.",
                "Confirmar eliminación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Desasignar todos los alumnos del grupo
                    Alumno alumnoTemp = new Alumno();
                    List<Alumno> alumnosGrupo = alumnoTemp.am.LeerAlumnosPorGrupo(grupoSeleccionado.IdGrupo);
                    foreach (Alumno a in alumnosGrupo)
                    {
                        a.DesasignarGrupo();
                    }

                    grupoSeleccionado.delete();
                    MessageBox.Show("Grupo eliminado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    RecargarGrupos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el grupo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona un grupo de la lista inferior
        /// </summary>
        private void ListGroupMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListGroupMembers.SelectedItem != null)
            {
                Grupo grupoSelec = (Grupo)ListGroupMembers.SelectedItem;
                CargarGrupoParaEditar(grupoSelec);
            }
        }

        /// <summary>
        /// Carga un grupo para editarlo: muestra sus alumnos y los que no tiene
        /// </summary>
        private void CargarGrupoParaEditar(Grupo grupo)
        {
            grupoSeleccionado = grupo;
            GroupNameTextBox.Text = grupo.Nombre;

            lstAlumnosSeleccionados.Clear();
            lstAlumnosNoAsignados.Clear();

            // Carga alumnos del grupo
            Alumno alumno = new Alumno();
            lstAlumnosSeleccionados = alumno.am.LeerAlumnosPorGrupo(grupo.IdGrupo);
            ListSelected.ItemsSource = lstAlumnosSeleccionados;
            ListSelected.Items.Refresh();

            // Carga alumnos sin grupo
            lstAlumnosNoAsignados = alumno.am.LeerAlumnosSinGrupo();
            ListUnassigned.ItemsSource = lstAlumnosNoAsignados;
            ListUnassigned.Items.Refresh();
        }

        // ===== Talent Lab =====
        private void InicializarEditorTalentLab()
        {
            if (listaRetos == null) listaRetos = new Reto().getRetos(SesionActual.EsAdmin, SesionActual.IdGrupo);
            if (listaGrupos == null) listaGrupos = new Grupo().getGrupos(SesionActual.EsAdmin, SesionActual.IdGrupo);

            retosDisponiblesTL = new List<Reto>(listaRetos ?? new List<Reto>());
            retosSeleccionadosTL = new List<Reto>();

            cmbTLGrupo.ItemsSource = listaGrupos;
            cmbTLGrupo.SelectedItem = null;

            RefrescarListasRetosTalentLab();
            ActualizarCamposRetosTalentLab();
        }

        private void CargarTalentLabParaEditar(TalentLab tl)
        {
            if (listaRetos == null) listaRetos = new Reto().getRetos(SesionActual.EsAdmin, SesionActual.IdGrupo);
            if (listaGrupos == null) listaGrupos = new Grupo().getGrupos(SesionActual.EsAdmin, SesionActual.IdGrupo);

            retosSeleccionadosTL = new List<Reto>();

            if (tl.IdReto1.HasValue)
            {
                Reto r1 = listaRetos.Find(r => r.Id == tl.IdReto1.Value);
                if (r1 != null) retosSeleccionadosTL.Add(r1);
            }

            if (tl.IdReto2.HasValue)
            {
                Reto r2 = listaRetos.Find(r => r.Id == tl.IdReto2.Value);
                if (r2 != null && !retosSeleccionadosTL.Exists(r => r.Id == r2.Id)) retosSeleccionadosTL.Add(r2);
            }

            if (tl.IdReto3.HasValue)
            {
                Reto r3 = listaRetos.Find(r => r.Id == tl.IdReto3.Value);
                if (r3 != null && !retosSeleccionadosTL.Exists(r => r.Id == r3.Id)) retosSeleccionadosTL.Add(r3);
            }

            retosDisponiblesTL = new List<Reto>(listaRetos.FindAll(r => !retosSeleccionadosTL.Exists(s => s.Id == r.Id)));

            cmbTLGrupo.ItemsSource = listaGrupos;
            cmbTLGrupo.SelectedValue = tl.IdGrupo;

            RefrescarListasRetosTalentLab();
            ActualizarCamposRetosTalentLab();
        }

        private void RefrescarListasRetosTalentLab()
        {
            ListRetosDisponibles.ItemsSource = null;
            ListRetosDisponibles.ItemsSource = retosDisponiblesTL;

            ListRetosSeleccionados.ItemsSource = null;
            ListRetosSeleccionados.ItemsSource = retosSeleccionadosTL;
        }

        private void BtnTLMoverDerecha_Click(object sender, RoutedEventArgs e)
        {
            if (ListRetosDisponibles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un reto para mover", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<Reto> retosAMover = new List<Reto>();
            foreach (var item in ListRetosDisponibles.SelectedItems)
            {
                Reto reto = item as Reto;
                if (reto != null) retosAMover.Add(reto);
            }

            foreach (Reto reto in retosAMover)
            {
                if (retosSeleccionadosTL.Count >= 3) break;

                retosDisponiblesTL.Remove(reto);
                if (!retosSeleccionadosTL.Exists(r => r.Id == reto.Id))
                {
                    retosSeleccionadosTL.Add(reto);
                }
            }

            if (retosSeleccionadosTL.Count >= 3)
            {
                MessageBox.Show("Solo se pueden seleccionar 3 retos como máximo.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            RefrescarListasRetosTalentLab();
            ActualizarCamposRetosTalentLab();
        }

        private void BtnTLMoverIzquierda_Click(object sender, RoutedEventArgs e)
        {
            if (ListRetosSeleccionados.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un reto para devolver", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<Reto> retosADevolver = new List<Reto>();
            foreach (var item in ListRetosSeleccionados.SelectedItems)
            {
                Reto reto = item as Reto;
                if (reto != null) retosADevolver.Add(reto);
            }

            foreach (Reto reto in retosADevolver)
            {
                retosSeleccionadosTL.Remove(reto);
                if (!retosDisponiblesTL.Exists(r => r.Id == reto.Id))
                {
                    retosDisponiblesTL.Add(reto);
                }
            }

            RefrescarListasRetosTalentLab();
            ActualizarCamposRetosTalentLab();
        }

        private void ActualizarCamposRetosTalentLab()
        {
            txtTLR1.Text = "";
            txtTLR2.Text = "";
            txtTLR3.Text = "";

            int index = 0;
            foreach (Reto reto in retosSeleccionadosTL)
            {
                if (index == 0) txtTLR1.Text = reto.Id.ToString();
                else if (index == 1) txtTLR2.Text = reto.Id.ToString();
                else if (index == 2) txtTLR3.Text = reto.Id.ToString();

                index++;
                if (index >= 3) break;
            }
        }

        private void btn_AgregarTL_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTLGrupo.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un grupo.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (retosSeleccionadosTL == null || retosSeleccionadosTL.Count < 1)
            {
                MessageBox.Show("Debes seleccionar al menos 1 reto obligatorio.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            TalentLab t = new TalentLab(
                retosSeleccionadosTL.Count > 0 ? (int?)retosSeleccionadosTL[0].Id : null,
                retosSeleccionadosTL.Count > 1 ? (int?)retosSeleccionadosTL[1].Id : null,
                retosSeleccionadosTL.Count > 2 ? (int?)retosSeleccionadosTL[2].Id : null,
                (int?)cmbTLGrupo.SelectedValue
            );

            t.insertar();
            RecargarTalentLab();
            LimpiarCamposTalentLab();
        }

        private void btn_ModificarTL_Click(object sender, RoutedEventArgs e)
        {
            TalentLab t = dgTalentLab.SelectedItem as TalentLab;
            if (t == null) return;

            if (cmbTLGrupo.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un grupo.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (retosSeleccionadosTL == null || retosSeleccionadosTL.Count < 1)
            {
                MessageBox.Show("Debes seleccionar al menos 1 reto obligatorio.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            t.IdReto1 = retosSeleccionadosTL.Count > 0 ? (int?)retosSeleccionadosTL[0].Id : null;
            t.IdReto2 = retosSeleccionadosTL.Count > 1 ? (int?)retosSeleccionadosTL[1].Id : null;
            t.IdReto3 = retosSeleccionadosTL.Count > 2 ? (int?)retosSeleccionadosTL[2].Id : null;
            t.IdGrupo = (int?)cmbTLGrupo.SelectedValue;

            t.modificar();
            RecargarTalentLab();
        }

        private void btn_EliminarTL_Click(object sender, RoutedEventArgs e)
        {
            TalentLab t = dgTalentLab.SelectedItem as TalentLab;
            if (t == null) return;

            t.delete();
            RecargarTalentLab();
        }

        private void LimpiarCamposTalentLab()
        {
            txtTLR1.Text = "";
            txtTLR2.Text = "";
            txtTLR3.Text = "";
            cmbTLGrupo.SelectedItem = null;

            if (listaRetos == null) listaRetos = new Reto().getRetos(SesionActual.EsAdmin, SesionActual.IdGrupo);
            retosDisponiblesTL = new List<Reto>(listaRetos ?? new List<Reto>());
            retosSeleccionadosTL = new List<Reto>();
            RefrescarListasRetosTalentLab();
        }

        // ===== Usuarios =====
        private void btn_AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario(
                txtUUsername.Text,
                txtUPass.Text,
                txtUNombre.Text,
                txtUApellido.Text,
                txtUCorreo.Text,
                txtURol.Text,
                ParseNullableInt(txtUActivo.Text) ?? 1,
                ParseNullableInt(txtUGrupo.Text)
            );

            u.insertar();
            RecargarUsuarios();
            LimpiarCamposUsuario();
        }

        private void btn_ModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = dgUsuarios.SelectedItem as Usuario;
            if (u == null) return;

            u.Username = txtUUsername.Text;
            u.Contraseña = txtUPass.Text;
            u.Nombre = txtUNombre.Text;
            u.Apellido = txtUApellido.Text;
            u.Correo = txtUCorreo.Text;
            u.Rol = txtURol.Text;
            u.Activo = ParseNullableInt(txtUActivo.Text) ?? 1;
            u.IdGrupo = ParseNullableInt(txtUGrupo.Text);

            u.modificar();
            RecargarUsuarios();
        }

        private void btn_EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = dgUsuarios.SelectedItem as Usuario;
            if (u == null) return;

            u.delete();
            RecargarUsuarios();
            LimpiarCamposUsuario();
        }

        private void LimpiarCamposUsuario()
        {
            txtUUsername.Text = "";
            txtUPass.Text = "";
            txtUNombre.Text = "";
            txtUApellido.Text = "";
            txtUCorreo.Text = "";
            txtURol.Text = "";
            txtUActivo.Text = "";
            txtUGrupo.Text = "";
        }
    }
}