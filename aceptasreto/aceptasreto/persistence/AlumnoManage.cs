using aceptasreto.domain;
using aceptasreto.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aceptasreto.persistence
{
    internal class AlumnoManage
    {
        private DataTable table { get; set; }
        private List<Alumno> listaAlumnos { get; set; }


        public AlumnoManage()
        {
            table = new DataTable();
            listaAlumnos = new List<Alumno>();
        }

        public List<Alumno> leerAlumnos()
        {
            Alumno alumno = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT nombre, apellidos, especialidad FROM aceptasreto.alumnado;");

            foreach (List<Object> c in aux)
            {
                alumno = new Alumno(c[0].ToString(), c[1].ToString(), Convert.ToInt32(c[2])); // Convert.ToInt32(c[0]), c[1].ToString(), c[2].ToString(), Convert.ToInt32(c[3])

                listaAlumnos.Add(alumno);
            }

            return listaAlumnos;
        }

        public void insertarAlumno(Alumno a)
        {
            String sql = "INSERT INTO aceptasreto.alumnado (nombre, apellidos, especialidad)" +
                         "VALUES ('" + a.Nombre + "', '" + a.Apellido + "', '" + a.Especialidad +");";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void lastIdAlumno(Alumno a)
        {
            List<Object> lAlumno;
            lAlumno = DBBroker.obtenerAgente().leer("SELECT MAX(idAlumnado) FROM aceptasreto.alumnado;");

            foreach (List<Object> c in lAlumno)
            {
                a.Id = Convert.ToInt32(c[0]) + 1;
            }
        }

        public void eliminarAlumno(Alumno a)
        {
            String sql = "DELETE FROM aceptasreto.alumnado WHERE id = " + a.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void modificarAlumno(Alumno a)
        {
            String sql = "UPDATE aceptasreto.alumnado SET " +
                         "nombre = '" + a.Nombre + "', " +
                         "apellidos = '" + a.Apellido + "', " +
                         "especialidad = '" + a.Especialidad + "' " +
                         "WHERE id = " + a.Id + ";";
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void añadirGrupo(Alumno a) {
            // TODO: Añadir el grupo al alumno pasado por parametro
        }
    }
}
