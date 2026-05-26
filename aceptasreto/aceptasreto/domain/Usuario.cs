using aceptasreto.persistence;
using System.Collections.Generic;

namespace aceptasreto.domain
{
    internal class Usuario
    {
        private int idUsuario;
        private string username;
        private string contraseña;
        private string nombre;
        private string apellido;
        private string correo;
        private string rol;
        private int activo;
        private int? idGrupo;

        private UsuarioManage um;

        public Usuario()
        {
            um = new UsuarioManage();
        }

        public Usuario(string username, string contraseña, string nombre, string apellido, string correo, string rol, int activo, int? idGrupo)
        {
            this.username = username;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.rol = rol;
            this.activo = activo;
            this.idGrupo = idGrupo;
            um = new UsuarioManage();
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Username { get => username; set => username = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Activo { get => activo; set => activo = value; }
        public int? IdGrupo { get => idGrupo; set => idGrupo = value; }

        public List<Usuario> getUsuarios() => um.leerUsuarios();
        public void insertar() => um.insertarUsuario(this);
        public void modificar() => um.modificarUsuario(this);
        public void delete() => um.eliminarUsuario(this);
    }
}