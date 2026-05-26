using aceptasreto.persistence;
using System.Collections.Generic;

namespace aceptasreto.domain
{
    internal class Reto
    {
        private int id;
        private string descripcion;

        private RetoManage rm;

        public Reto()
        {
            rm = new RetoManage();
        }

        public Reto(string descripcion)
        {
            this.descripcion = descripcion;
            rm = new RetoManage();
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Etiqueta { get => Id + " - " + (Descripcion ?? ""); }

        public List<Reto> getRetos(bool esAdmin, int? idGrupoSesion)
        {
            return rm.leerRetos(esAdmin, idGrupoSesion);
        }

        public void insertar()
        {
            rm.insertarReto(this);
        }

        public void delete()
        {
            rm.eliminarReto(this);
        }

        public void modificar()
        {
            rm.modificarReto(this);
        }
    }
}
