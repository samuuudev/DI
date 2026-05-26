
using PruebaExamen2_Estudiantes.persistence.manages.cursopersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaExamen2_Curso_JSON_DataGrid.persistence.manages.profesormanage;

namespace PruebaExamen2_Estudiantes.domain.curso
{
    internal class Curso
    {
        private int CursoID;
        private string nombreCurso;
        private int creditos;
        private List<Curso> listaCursos;
        public CursoPersistence pm;
        private int Id_;
        private string nombreProfesorJSON;
        private string especialidad;
        public Curso(string nombreCurso, int creditos)
        {
           this.nombreCurso = nombreCurso;
            this.creditos = creditos;
            pm = new CursoPersistence();
        
        }
        public Curso(int id, string nombreCurso, int creditos,string nombreProfesorJSON,string especialidad)
        {
            this.CursoID = id;
            this.nombreCurso = nombreCurso;
            this.creditos = creditos;
            this.especialidad = especialidad;   
            this.nombreProfesorJSON = nombreProfesorJSON;
            pm = new CursoPersistence();
         
        }
        public void AsignarProfesorDesdeJson()
        {
            profesorManage pmProfesor = new profesorManage();
            pmProfesor.readProfesor(); 
            var profesorCoincidente = pmProfesor.ListProfesor
                .FirstOrDefault(p => p.ID == this.Id);

            if (profesorCoincidente != null)
            {
                
                this.nombreProfesorJSON = profesorCoincidente.Nombre;
                //JSON PARA MODIFICAR ESTE CAMPOS (SE CAMBIA EN LA BASE DE DATOS)
                this.especialidad = profesorCoincidente.Especialidad;
            }
            else
            {
                this.nombreProfesorJSON = "General";
                this.especialidad = "General";
            }
        }
        public Curso()
        {
            pm = new CursoPersistence();
        }
        public Curso(int id)
        {
            pm = new CursoPersistence();
            Id_ = id;
        }
        public List<Curso> getListaCurso()
        {
            listaCursos = pm.LeerCursos();
            return listaCursos;
        }

        public int Id { get => CursoID; set => CursoID = value; }
        public string Nombre { get => nombreCurso; set => nombreCurso = value; }

        public int Creditos { get => creditos; set => creditos = value; }

        public string NombreProfesorJSON { get => nombreProfesorJSON; set => nombreProfesorJSON = value; }

        public string Especialidad { get => especialidad; set => especialidad = value; }

        public void insertar()
        {
            pm.InsertarCurso(this);
        }
        public void borrar()
        {
            pm.BorrarCurso(this);
        }
        public void modificar()
        {
            pm.ModificarCurso(this);
        }

    }
}

