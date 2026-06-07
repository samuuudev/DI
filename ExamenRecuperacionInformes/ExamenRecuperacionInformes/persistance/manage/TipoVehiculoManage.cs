using ExamenRecuperacionInformes.domain;
using ExamenRecuperacionInformes.persistance.dbbroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRecuperacionInformes.persistance.manage
{
    internal class TipoVehiculoManage
    {

        public List<TipoVehiculo> leerTiposVehiculo()
        {
            List<TipoVehiculo> tipos = new List<TipoVehiculo>();
            string sql = "SELECT idtipovehiculo, tipovehiculo FROM mancha.tipovehiculo;";
            var aux = DBBroker.obtenerAgente().leer(sql);
            foreach (List<object> c in aux)
            {
                TipoVehiculo tv = new TipoVehiculo(Convert.ToInt32(c[0]), c[1].ToString());
                tipos.Add(tv);
            }
            return tipos;
        }

        public void insertarTipoVehiculo(TipoVehiculo tv)
        {
            string sql = "INSERT INTO mancha.tipovehiculo (tipovehiculo) " +
                         "VALUES ('" + tv.TipoVehiculo1 + "');";
            DBBroker.obtenerAgente().modificar(sql);
        }
        public void modificarTipoVehiculo(TipoVehiculo tv)
        {
            string sql = "UPDATE mancha.tipovehiculo SET " +
                         "tipovehiculo='" + tv.TipoVehiculo1 + "' " +
                         "WHERE idtipovehiculo=" + tv.IdTipoVehiculo + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarTipoVehiculo(TipoVehiculo tv)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM mancha.tipovehiculo WHERE idtipovehiculo=" + tv.IdTipoVehiculo + ";");
        }
    }
}
