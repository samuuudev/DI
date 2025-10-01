using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploCoches
{
    internal class Coche
    {
        // Atributos
        private int _id;
        private string _marca;
        private string _modelo;
        private int _km;
        private double _precio;

        // Constructores
        public Coche(int id, string marca, string modelo, int km, double precio)
        {
            _id = id;
            _marca = marca;
            _modelo = modelo;
            _km = km;
            _precio = precio;
        }


        // Getters y Setters
        public int id { get => _id; set => _id = value; }
        public string marca { get => _marca; set => _marca = value; }
        public string modelo { get => _modelo; set => _modelo = value; }
        public int km { get => _km; set => _km = value; }
        public double precio { get => _precio; set => _precio = value; }

        public override string ToString()
        {
            return $"Marca: {_marca} con un precio de: {_precio}";
        }
    }
}
