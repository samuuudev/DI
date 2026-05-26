using aceptasreto.domain;
using aceptasreto.Persistence;
using System;
using System.Collections.Generic;

namespace aceptasreto.persistence
{
    internal class UsuarioManage
    {
        private string E(string s) => (s ?? "").Replace("'", "''");

        public List<Usuario> leerUsuarios()
        {
            var lista = new List<Usuario>();
            string sql = "SELECT id_usuario, username, contraseña, nombre, apellido, correo, rol, activo, id_grupo " +
                         "FROM aceptasreto.usuario;";
            var aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<object> c in aux)
            {
                Usuario u = new Usuario();
                u.IdUsuario = Convert.ToInt32(c[0]);
                u.Username = c[1]?.ToString();
                u.Contraseña = c[2]?.ToString();
                u.Nombre = c[3]?.ToString();
                u.Apellido = c[4]?.ToString();
                u.Correo = c[5]?.ToString();
                u.Rol = c[6]?.ToString();
                u.Activo = (c[7] == null || c[7].ToString() == "") ? 0 : Convert.ToInt32(c[7]);
                u.IdGrupo = (c[8] == null || c[8].ToString() == "") ? (int?)null : Convert.ToInt32(c[8]);
                lista.Add(u);
            }

            return lista;
        }

        public void insertarUsuario(Usuario u)
        {
            string idGrupoSql = u.IdGrupo.HasValue ? u.IdGrupo.Value.ToString() : "NULL";

            string sql = "INSERT INTO aceptasreto.usuario " +
                         "(username, contraseña, nombre, rol, activo, apellido, correo, id_grupo) VALUES (" +
                         "'" + E(u.Username) + "'," +
                         "'" + E(u.Contraseña) + "'," +
                         "'" + E(u.Nombre) + "'," +
                         "'" + E(u.Rol) + "'," +
                         u.Activo + "," +
                         "'" + E(u.Apellido) + "'," +
                         "'" + E(u.Correo) + "'," +
                         idGrupoSql + ");";

            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarUsuario(Usuario u)
        {
            string idGrupoSql = u.IdGrupo.HasValue ? u.IdGrupo.Value.ToString() : "NULL";

            string sql = "UPDATE aceptasreto.usuario SET " +
                         "username='" + E(u.Username) + "', " +
                         "contraseña='" + E(u.Contraseña) + "', " +
                         "nombre='" + E(u.Nombre) + "', " +
                         "apellido='" + E(u.Apellido) + "', " +
                         "correo='" + E(u.Correo) + "', " +
                         "rol='" + E(u.Rol) + "', " +
                         "activo=" + u.Activo + ", " +
                         "id_grupo=" + idGrupoSql + " " +
                         "WHERE id_usuario=" + u.IdUsuario + ";";

            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarUsuario(Usuario u)
        {
            string sql = "DELETE FROM aceptasreto.usuario WHERE id_usuario=" + u.IdUsuario + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public List<object> LoginPorUsernameOCorreo(string login, string pass)
        {
            string sql = "SELECT id_usuario, username, rol, id_grupo " +
                         "FROM aceptasreto.usuario " +
                         "WHERE (username='" + E(login) + "' OR correo='" + E(login) + "') " +
                         "AND contraseña='" + E(pass) + "' AND (activo=1 OR activo IS NULL) LIMIT 1;";

            var r = DBBroker.obtenerAgente().leer(sql);
            return (r != null && r.Count > 0) ? (List<object>)r[0] : null;
        }
    }
}