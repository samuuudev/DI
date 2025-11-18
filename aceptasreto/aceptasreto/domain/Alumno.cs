using aceptasreto.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aceptasreto.domain
{
    internal class Alumno
    {
        private int idAlumno;
        private string nombre;
        private string apellido;
        private int especialidad;
        private int grupo;

        public List<Alumno> listaAlumnos;
        public AlumnoManage am;

        public Alumno()
        {
            am = new AlumnoManage();
        }
        public Alumno(int id)
        {
            this.idAlumno = id;
            am = new AlumnoManage();
        }
        public Alumno(string nombre, string apellido, int especialidad)
        {
            am = new AlumnoManage();
            this.nombre = nombre;
            this.apellido = apellido;
            this.especialidad = especialidad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Especialidad { get => especialidad; set => especialidad = value; }
        public int Grupo { get => grupo; set => grupo = value; }
        public int Id { get => idAlumno; set => idAlumno = value; }

        // Nos devuelve la lista de personas de la base de datos (simulado)

        public List<Alumno> getAlumnos()
        {
            listaAlumnos = am.leerAlumnos();

            return listaAlumnos;
        }

        public void last()
        {
            am.lastIdAlumno(this);
        }

        public void insertar()
        {
            am.insertarAlumno(this);
        }

        public void delete()
        {
            am.eliminarAlumno(this);
        }

        public void modificar()
        {
            am.modificarAlumno(this);
        }
    }
}
