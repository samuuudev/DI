using aceptasreto.persistence;
using System.Collections.Generic;

namespace aceptasreto.domain
{
    internal class Grupo
    {
        private int idGrupo;
        private string descripcion;
        private string nombre;
        public GrupoManage gm;

        public Grupo()
        {
            gm = new GrupoManage();
        }

        public Grupo(string descripcion)
        {
            this.descripcion = descripcion;
            gm = new GrupoManage();
        }

        public int Id { get => idGrupo; set => idGrupo = value; }
        public int IdGrupo { get => idGrupo; set => idGrupo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Nombre { get => nombre ?? descripcion; set => nombre = value; }

        public List<Grupo> getGrupos(bool esAdmin, int? idGrupoSesion)
        {
            return gm.leerGrupos(esAdmin, idGrupoSesion);
        }

        public void insertar() => gm.insertarGrupo(this);
        public void modificar() => gm.modificarGrupo(this);
        public void delete() => gm.eliminarGrupo(this);
    }
}
