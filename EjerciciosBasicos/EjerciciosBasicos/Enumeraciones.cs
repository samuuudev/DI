using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosBasicos
{

    // Definicion de enumaracion sobre los dias de la semana
    public enum DiasSemana
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }


    internal class Enumeraciones
    {
        static void Main(string[] args)
        {
            DiasSemana dia = DiasSemana.Viernes;
            Console.WriteLine($"Mi dia favorito de la semana es {dia}");
            Console.ReadKey();
        }

    }
}
