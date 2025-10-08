using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman_ProyectoProgramacion
{
    internal class Enemigo
    {
        private char tipo;
        private string habilidad;
        private int dano;

        public Enemigo(char tipo)
        {
            this.tipo = tipo;
            switch (tipo)
            {
                case 'D':
                    habilidad = "Golpe";
                    dano = 1;
                    break;
                case 'G':
                    habilidad = "Golpe";
                    dano = 1;
                    break;
                case 'M':
                    habilidad = "Aleatorio";
                    dano = 0;
                    break;
            }
        }
        public void Atacar(Jugador jugador)
        {
            jugador.vida -= dano;
            Console.WriteLine($"Has sido atacado por {habilidad}. Has perdido {dano} vida.");
        }


        // Getters
        public char Tipo { get { return tipo; } }
        public string Habilidad { get { return habilidad; } }
        public int Dano { get { return dano; } }
    }
}
