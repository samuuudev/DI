using aceptasreto.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aceptasreto.domain
{
    internal class Empresa
    {
        private int idEmpresa;
        private string razonSocial;
        private string ciudad;
        private string direccion;
        private string telefonoContacto;
        private string emailContacto;

        public EmpresaManage em;

        public Empresa(string razonSocial, string ciudad, string direccion, string telefonoContacto, string emailContacto)
        {
            this.razonSocial = razonSocial;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.telefonoContacto = telefonoContacto;
            this.emailContacto = emailContacto;

            this.em = new EmpresaManage();
        }


        // Getters y setters para el crud
        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string EmailContacto { get => emailContacto; set => emailContacto = value; }
        public string TelefonoContacto { get => telefonoContacto; set => telefonoContacto = value; }

        public List<Empresa> getEmpresas()
        {
            return em.leerEmpresas();
        }

        public void insertar()
        {
            em.insertarEmpresa(this);
        }

        public void delete()
        {
            em.eliminarEmpresa(this);
        }

        public void modificar()
        {
            em.modificarEmpresa(this);
        }
    }
}
