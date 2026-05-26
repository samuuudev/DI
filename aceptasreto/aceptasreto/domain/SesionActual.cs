using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aceptasreto.domain
{
    internal static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string Username { get; set; } = string.Empty;
        public static string Rol { get; set; } = string.Empty;
        public static int? IdGrupo { get; set; }

        public static bool EsAdmin => (Rol ?? "").ToLower() == "admin";
        public static bool EsAlumno => (Rol ?? "").ToLower() == "alumno";

        public static void Limpiar()
        {
            IdUsuario = 0;
            Username = "";
            Rol = "";
            IdGrupo = null;
        }
    }
}
