using aceptasreto.domain;
using aceptasreto.Persistence;
using System;
using System.Collections.Generic;

namespace aceptasreto.persistence
{
    internal class EmpresaManage
    {
        private string E(string s) => (s ?? "").Replace("'", "''");

        public List<Empresa> leerEmpresas()
        {
            var empresas = new List<Empresa>();
            string sql = "SELECT id_empresa, razon_social, ciudad, direccion, telefono_contacto, correo_contacto " +
                         "FROM aceptasreto.empresa;";
            var aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<object> c in aux)
            {
                Empresa e = new Empresa(c[1].ToString(), c[2].ToString(), c[3].ToString(), c[4].ToString(), c[5].ToString());
                e.IdEmpresa = Convert.ToInt32(c[0]);
                empresas.Add(e);
            }
            return empresas;
        }

        public void insertarEmpresa(Empresa e)
        {
            string sql = "INSERT INTO aceptasreto.empresa (razon_social, direccion, ciudad, telefono_contacto, correo_contacto, activo) " +
                         "VALUES ('" + E(e.RazonSocial) + "','" + E(e.Direccion) + "','" + E(e.Ciudad) + "','" + E(e.TelefonoContacto) + "','" + E(e.EmailContacto) + "',1);";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarEmpresa(Empresa e)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM aceptasreto.empresa WHERE id_empresa=" + e.IdEmpresa + ";");
        }

        public void modificarEmpresa(Empresa e)
        {
            string sql = "UPDATE aceptasreto.empresa SET " +
                         "razon_social='" + E(e.RazonSocial) + "', ciudad='" + E(e.Ciudad) + "', direccion='" + E(e.Direccion) + "', " +
                         "telefono_contacto='" + E(e.TelefonoContacto) + "', correo_contacto='" + E(e.EmailContacto) + "' " +
                         "WHERE id_empresa=" + e.IdEmpresa + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }
    }
}