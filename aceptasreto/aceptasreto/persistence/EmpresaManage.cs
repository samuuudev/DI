using aceptasreto.domain;
using aceptasreto.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aceptasreto.persistence
{
    internal class EmpresaManage
    {
        private List<Empresa> empresas;


        public EmpresaManage() {
            this.empresas = new List<Empresa>();
        }

        public List<Empresa> leerEmpresas()
        {
            Empresa empresa = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT razon_social, ciudad, direccion, teelefono_contacto, correo_contacto FROM aceptasreto.empresa;");

            foreach (List<Object> c in aux)
            {
                empresa = new Empresa(c[0].ToString(), c[1].ToString(), c[2].ToString(), c[3].ToString(), c[4].ToString()); // Convert.ToInt32(c[0]), c[1].ToString(), c[2].ToString(), Convert.ToInt32(c[3])

                empresas.Add(empresa);
            }

            return empresas;
        }

        public void insertarEmpresa(Empresa e)
        {
            String sql = "INSERT INTO aceptasreto.empresa (razon_social, direccion, ciudad, telefono_contacto, correo_contacto)" +
                         "VALUES ('" 
                         + e.RazonSocial + "', '" 
                         + e.Direccion + "', '" 
                         + e.Ciudad + ", "
                         + e.TelefonoContacto + ", " 
                         + e.EmailContacto + ");";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarEmpresa(Empresa e)
        {
            String sql = "DELETE FROM aceptasreto.empresa WHERE id = " + e.IdEmpresa + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarEmpresa(Empresa e)
        {
            String sql = "UPDATE aceptasreto.empresa SET " +
                         "razon_social = '" + e.RazonSocial + "', " +
                         "ciudad = '" + e.Ciudad + "', " +
                         "direccion = '" + e.Direccion+ "', " +
                         "telefono_contacto = '" + e.TelefonoContacto + "', " +
                         "correo_contacto = '" + e.EmailContacto + "', " +
                         "WHERE id = " + e.IdEmpresa + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }
    }
}
