using ExamenRecuperacionInformes.persistance.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRecuperacionInformes.domain
{
    internal class Parcela
    {
        private int idParcela;
        private int tamanoParcela;
        private bool luz;
        private bool agua;
        private double precio;

        ParcelaManage pm;

        public Parcela()
        {
            pm = new ParcelaManage();
        }

        public Parcela(int id, int tamanoParcela, bool luz, bool agua, double precio)
        {
            this.idParcela = id;
            this.tamanoParcela = tamanoParcela;
            this.luz = luz;
            this.agua = agua;
            this.precio = precio;
            // Inicializar el gestor para evitar NullReferenceException al llamar a métodos que usan pm
            pm = new ParcelaManage();
        }

        public Parcela(int tamanoParcela, bool luz, bool agua, double precio)
        {
            this.tamanoParcela = tamanoParcela;
            this.luz = luz;
            this.agua = agua;
            this.precio = precio;
            // Inicializar el gestor para evitar NullReferenceException al llamar a métodos que usan pm
            pm = new ParcelaManage();
        }

        public int IdParcela { get => idParcela; set => idParcela = value; }
        public int TamanoParcela { get => tamanoParcela; set => tamanoParcela = value; }
        public bool Luz { get => luz; set => luz = value; }
        public bool Agua { get => agua; set => agua = value; }
        public double Precio { get => precio; set => precio = value; }

        public List<Parcela> getParcelas()
        {
            return pm.leerParcelas();
        }

        public void insertar()
        {
            pm.insertarParcela(this);
        }

        public void modificar()
        {
            pm.modificarParcela(this);
        }

        public void eliminar()
        {
            pm.eliminarParcela(this);
        }

    }
}
