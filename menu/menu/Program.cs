using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Variables
            string[,] tablero = new string[5, 5];
            int posI = 0, posJ = 0;
            bool salir = false;
            tablero[posI, posJ] = "O";
            #endregion


            Operaciones.rellenarMatriz(tablero, "x");

            while (!salir)
            {
                Operaciones.MostrarMenu();
                Operaciones.mostrarMatriz(tablero);
                Operaciones.entradaMenu(tablero, ref salir, ref posI, ref posJ);
            }
        }
    }
}
