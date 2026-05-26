using aceptasreto.persistence;
using System.Collections.Generic;

namespace aceptasreto.domain
{
    internal class TalentLab
    {
        private int idTalentLab;
        private int? idReto1;
        private int? idReto2;
        private int? idReto3;
        private int? idGrupo;
        private string nombreGrupo;
        private string nombreReto1;
        private string nombreReto2;
        private string nombreReto3;

        private TalentLabManage tm;

        public TalentLab()
        {
            tm = new TalentLabManage();
        }

        public TalentLab(int? idReto1, int? idReto2, int? idReto3, int? idGrupo)
        {
            this.idReto1 = idReto1;
            this.idReto2 = idReto2;
            this.idReto3 = idReto3;
            this.idGrupo = idGrupo;
            tm = new TalentLabManage();
        }

        public int IdTalentLab { get => idTalentLab; set => idTalentLab = value; }
        public int? IdReto1 { get => idReto1; set => idReto1 = value; }
        public int? IdReto2 { get => idReto2; set => idReto2 = value; }
        public int? IdReto3 { get => idReto3; set => idReto3 = value; }
        public int? IdGrupo { get => idGrupo; set => idGrupo = value; }
        public string NombreGrupo { get => nombreGrupo; set => nombreGrupo = value; }
        public string NombreReto1 { get => nombreReto1; set => nombreReto1 = value; }
        public string NombreReto2 { get => nombreReto2; set => nombreReto2 = value; }
        public string NombreReto3 { get => nombreReto3; set => nombreReto3 = value; }

        public List<TalentLab> getTalentLabs(bool esAdmin, int? idGrupoSesion) => tm.leerTalentLabs(esAdmin, idGrupoSesion);
        public void insertar() => tm.insertarTalentLab(this);
        public void modificar() => tm.modificarTalentLab(this);
        public void delete() => tm.eliminarTalentLab(this);
    }
}