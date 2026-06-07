using ExamenRecuperacionInformes.persistance.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRecuperacionInformes.domain
{
    internal class Huesped
    {
        private int idHuesped;
        private string nombre;
        private string dni;
        private int telefono;
        private int idTipoVehiculo;
        private string matricula;

        HuespedManage hm;

        public Huesped()
        {
            hm = new HuespedManage();
        }

        public Huesped(int id, string nombre, string dni, int telefono, int idTipoVehiculo, string matricula)
        {
            hm = new HuespedManage();

            this.idHuesped = id;
            this.nombre = nombre;
            this.dni = dni;
            this.telefono = telefono;
            this.idTipoVehiculo = idTipoVehiculo;
            this.matricula = matricula;
        }

        public Huesped(string nombre, string dni, int telefono, int idTipoVehiculo, string matricula)
        {
            hm = new HuespedManage();

            this.nombre = nombre;
            this.dni = dni;
            this.telefono = telefono;
            this.idTipoVehiculo = idTipoVehiculo;
            this.matricula = matricula;
        }


        public int IdHuesped { get => idHuesped; set => idHuesped = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public int IdTipoVehiculo { get => idTipoVehiculo; set => idTipoVehiculo = value; }
        public string Matricula { get => matricula; set => matricula = value; }


        public List<Huesped> getHuespedes()
        {
            return hm.leerHuespedes();
        }

        public void insertar()
        {
            hm.insertarHuesped(this);
        }

        public void modificar()
        {
            hm.modificarHuesped(this);
        }

        public void eliminar()
        {
            hm.eliminarHuesped(this);
        }
    }
}
