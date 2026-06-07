using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenRecuperacionInformes.domain;
using ExamenRecuperacionInformes.persistance.dbbroker;
using System.Globalization;

namespace ExamenRecuperacionInformes.persistance.manage
{
    internal class ParcelaManage
    {

        public ParcelaManage() { }

        public List<Parcela> leerParcelas()
        {
            var parcelas = new List<Parcela>();
            string sql = "SELECT idparcela, tamanoparcela, luz, agua, precionoche FROM mancha.parcela;";
            var aux = DBBroker.obtenerAgente().leer(sql);
            foreach (List<object> c in aux)
            {
                // c elements vienen como string desde DBBroker.leer; parsear de forma segura
                int id = Convert.ToInt32(c[0]);
                int tam = Convert.ToInt32(c[1]);
                // leer luz/agua como entero (0/1) y convertir a bool
                bool luz = Convert.ToInt32(c[2]) == 1;
                bool agua = Convert.ToInt32(c[3]) == 1;
                double precio = Convert.ToDouble(c[4], CultureInfo.InvariantCulture);

                Parcela p = new Parcela(id, tam, luz, agua, precio);
                parcelas.Add(p);
            }
            return parcelas;
        }

        public void insertarParcela(Parcela p)
        {
            // Convertir booleanos a 0/1 y números con InvariantCulture; no usar comillas para valores numéricos
            string sql = "INSERT INTO mancha.parcela (tamanoparcela, luz, agua, precionoche) " +
                         "VALUES (" + p.TamanoParcela + ", " + (p.Luz ? 1 : 0) + ", " + (p.Agua ? 1 : 0) + ", " + p.Precio.ToString(CultureInfo.InvariantCulture) + ");";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarParcela(Parcela p)
        {
            string sql = "UPDATE mancha.parcela SET " +
                         "tamanoparcela=" + p.TamanoParcela + ", luz=" + (p.Luz ? 1 : 0) + ", agua=" + (p.Agua ? 1 : 0) + ", precionoche=" + p.Precio.ToString(CultureInfo.InvariantCulture) + " " +
                         "WHERE idparcela=" + p.IdParcela + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void eliminarParcela(Parcela p)
        {
            DBBroker.obtenerAgente().modificar("DELETE FROM mancha.parcela WHERE idparcela=" + p.IdParcela + ";");
        }

    }
}
