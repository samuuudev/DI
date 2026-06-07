using ExamenRecuperacionInformes.domain;
using ExamenRecuperacionInformes.persistance.dbbroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRecuperacionInformes.persistance.manage
{
    internal class ReservaManage
    {

        public List<Reserva> leerReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            string sql = "SELECT idreserva, idhuesped, idparcela, fechaentrada, fechasalida, costetotal, estado FROM mancha.reserva;";
            var aux = DBBroker.obtenerAgente().leer(sql);

            foreach (List<object> c in aux)
            {
                Reserva r = new Reserva(
                    Convert.ToInt32(c[1]),
                    Convert.ToInt32(c[2]),
                    Convert.ToDateTime(c[3]),
                    Convert.ToDateTime(c[4]),
                    Convert.ToDouble(c[5]),
                    c[6].ToString());

                r.IdReserva = Convert.ToInt32(c[0]);
                reservas.Add(r);
            }

            return reservas;
        }

        public void insertarReserva(Reserva r)
        {
            string sql = "INSERT INTO mancha.reserva (idhuesped, idparcela, fechaentrada, fechasalida, costetotal, estado) " +
                         "VALUES ('" + r.IdHuesped + "','" + r.IdParcela + "','" + r.FechaEntrada.ToString("yyyy-MM-dd") + "','" + r.FechaSalida.ToString("yyyy-MM-dd") + "','" + r.CosteTotal + "','" + r.Estado + "');";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarReserva(Reserva r)
        {
            string sql = "UPDATE mancha.reserva SET " +
                         "idhuesped='" + r.IdHuesped + "', idparcela='" + r.IdParcela + "', fechaentrada='" + r.FechaEntrada.ToString("yyyy-MM-dd") + "', fechasalida='" + r.FechaSalida.ToString("yyyy-MM-dd") + "', costetotal='" + r.CosteTotal + "', estado='" + r.Estado + "' " +
                         "WHERE idreserva=" + r.IdReserva + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarReserva(Reserva r)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM mancha.reserva WHERE idreserva=" + r.IdReserva + ";");
        }
    }
}
