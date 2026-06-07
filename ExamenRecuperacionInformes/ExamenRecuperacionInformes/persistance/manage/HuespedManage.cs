using System;
using System.Collections.Generic;
using ExamenRecuperacionInformes.domain;
using ExamenRecuperacionInformes.persistance.dbbroker;

namespace ExamenRecuperacionInformes.persistance.manage
{
    internal class HuespedManage
    {
        public HuespedManage()
        {   
        }

        public List<Huesped> leerHuespedes()
        {
            var huespedes = new List<Huesped>();
            string sql = "SELECT idhuesped, nombre, dni, telefono, idtipovehiculo, matricula FROM mancha.huesped;";
            var aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<object> c in aux)
            {
                Huesped h = new Huesped(
                    c[1].ToString(),
                    c[2].ToString(),
                    Convert.ToInt32(c[3]),
                    Convert.ToInt32(c[4]),
                    c[5].ToString());

                h.IdHuesped = Convert.ToInt32(c[0]);
                huespedes.Add(h);
            }

            return huespedes;
        }

        public void insertarHuesped(Huesped h)
        {
            string sql = "INSERT INTO mancha.huesped (nombre, dni, telefono, idtipovehiculo, matricula) " +
                         "VALUES ('" + h.Nombre + "','" + h.Dni + "','" + h.Telefono + "','" + h.IdTipoVehiculo + "','" + h.Matricula + "');";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarHuesped(Huesped h)
        {
            string sql = "UPDATE mancha.huesped SET " +
                         "nombre='" + h.Nombre + "', dni='" + h.Dni + "', telefono='" + h.Telefono + "', idtipovehiculo='" + h.IdTipoVehiculo + "', matricula='" + h.Matricula + "' " +
                         "WHERE idhuesped=" + h.IdHuesped + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarHuesped(Huesped h)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM mancha.huesped WHERE idhuesped=" + h.IdHuesped + ";");
        }
    }
}

