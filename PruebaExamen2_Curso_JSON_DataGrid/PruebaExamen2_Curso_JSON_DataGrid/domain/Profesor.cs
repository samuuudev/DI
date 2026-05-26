using PruebaExamen2_Curso_JSON_DataGrid.persistence.manages.profesormanage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExamen2_Curso_JSON_DataGrid.domain.profesor
{
    internal class Profesor
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int Sueldo { get; set; }

        private profesorManage pm;

        public Profesor()
        {
            pm = new profesorManage();
        }
        public Profesor(int id) : this()
        {
            this.ID = id;
        }
        public List<Profesor> getListProfesor()
        {
            return pm.ListProfesor;
        }
        public Profesor(int id, string nombre, string apellido, string especialidad, DateTime fchaContratacion, int sueldo) : this()
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Especialidad = especialidad;
            FechaContratacion = fchaContratacion;
            Sueldo = sueldo;
        }
        public Profesor(string nombre, string apellido, string especialidad, DateTime fchaContratacion, int sueldo) : this()
        {
            Nombre = nombre;
            Apellido = apellido;
            Especialidad = especialidad;
            FechaContratacion = fchaContratacion;
            Sueldo = sueldo;
        }
        public void readP()
        {
            pm.readProfesor();
        }
        public void insert()
        {
            pm.insertarProfesor(this);
        }
        public void update()
        {
            pm.updateProfesor(this);
        }
    }
}

