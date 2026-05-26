using aceptasreto.domain;
using aceptasreto.Persistence;
using System;
using System.Collections.Generic;

namespace aceptasreto.persistence
{
    internal class RetoManage
    {
        private string E(string s) => (s ?? "").Replace("'", "''");

        public List<Reto> leerRetos(bool esAdmin, int? idGrupo)
        {
            var lista = new List<Reto>();
            string sql;

            if (esAdmin)
            {
                sql = "SELECT id_reto, descripcion FROM aceptasreto.reto;";
            }
            else
            {
                // Si no es admin y no tiene grupo, devolvemos lista vacía (SQL válida)
                if (!idGrupo.HasValue)
                {
                    sql = "SELECT id_reto, descripcion FROM aceptasreto.reto WHERE 1 = 0;";
                }
                else
                {
                    sql = "SELECT DISTINCT r.id_reto, r.descripcion " +
                          "FROM aceptasreto.reto r " +
                          "INNER JOIN aceptasreto.talent_lab t " +
                          "ON (r.id_reto = t.id_reto1 OR r.id_reto = t.id_reto2 OR r.id_reto = t.id_reto3) " +
                          "WHERE t.id_grupo = " + idGrupo.Value + ";";
                }
            }

            var aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<object> c in aux)
            {
                var r = new Reto();
                r.Id = Convert.ToInt32(c[0]);
                r.Descripcion = c[1]?.ToString() ?? "";
                lista.Add(r);
            }

            return lista;
        }

        public void insertarReto(Reto r)
        {
            int nuevoId = ObtenerUltimoId() + 1;
            r.Id = nuevoId;
            string sql = "INSERT INTO aceptasreto.reto (id_reto, descripcion) VALUES (" + nuevoId + ", '" + E(r.Descripcion) + "');";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarReto(Reto r)
        {
            string sql = "UPDATE aceptasreto.reto SET descripcion='" + E(r.Descripcion) + "' WHERE id_reto=" + r.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarReto(Reto r)
        {
            DBBroker.obtenerAgente().modificar("UPDATE aceptasreto.talent_lab SET id_reto1=NULL WHERE id_reto1=" + r.Id + ";");
            DBBroker.obtenerAgente().modificar("UPDATE aceptasreto.talent_lab SET id_reto2=NULL WHERE id_reto2=" + r.Id + ";");
            DBBroker.obtenerAgente().modificar("UPDATE aceptasreto.talent_lab SET id_reto3=NULL WHERE id_reto3=" + r.Id + ";");
            string sql = "DELETE FROM aceptasreto.reto WHERE id_reto=" + r.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public int ObtenerUltimoId()
        {
            var resultado = DBBroker.obtenerAgente().leer("SELECT IFNULL(MAX(id_reto),0) FROM aceptasreto.reto;");
            if (resultado.Count > 0)
            {
                var fila = (List<object>)resultado[0];
                if (fila.Count > 0 && int.TryParse(fila[0].ToString(), out int id))
                {
                    return id;
                }
            }
            return 0;
        }
    }
}