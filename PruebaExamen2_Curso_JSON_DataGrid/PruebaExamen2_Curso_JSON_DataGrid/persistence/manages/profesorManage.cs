using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaExamen2_Curso_JSON_DataGrid.domain.profesor;
using System.IO;
using Newtonsoft.Json;

namespace PruebaExamen2_Curso_JSON_DataGrid.persistence.manages.profesormanage
{
    internal class profesorManage
    {
        public List<Profesor> ListProfesor { get; set; }


        private string ruta = "profesor.json";

        public profesorManage()
        {
            ListProfesor = new List<Profesor>();
        }


        public void readProfesor()
        {
            if (File.Exists(ruta))
            {
                string contenido = File.ReadAllText(ruta);
                var listObject = JsonConvert.DeserializeObject<dynamic>(contenido);
                this.ListProfesor = listObject.profesor.ToObject<List<Profesor>>();
            }
        }
        public bool updateProfesor(Profesor p)
        {
            if (ListProfesor == null || ListProfesor.Count == 0)
            {
                readProfesor();
            }

            var profesorExistente = ListProfesor.FirstOrDefault(profe => profe.ID == p.ID);

            if (profesorExistente != null)
            {
                profesorExistente.Especialidad = p.Especialidad;

                RootObject datosParaGuardar = new RootObject { profesor = this.ListProfesor };

                string json = JsonConvert.SerializeObject(datosParaGuardar, Formatting.Indented);
                File.WriteAllText(ruta, json); 

                return true;
            }

            return false;
        }
        public bool removeById(Profesor p)
        {
            foreach (Profesor profesor in ListProfesor)
            {
                if (profesor.ID == p.ID)
                {
                    ListProfesor.Remove(profesor);
                    return true;
                }
            }
            return false;
        }
        public void insertarProfesor(Profesor p)
        {
            p.ID = ListProfesor.Count > 0 ? ListProfesor.Max(persona => persona.ID) + 1 : 1;
            ListProfesor.Add(p);
            RootObject datosParaGuardar = new RootObject { profesor = this.ListProfesor };
            datosParaGuardar.profesor = ListProfesor;
            string json = JsonConvert.SerializeObject(datosParaGuardar, Formatting.Indented);
            File.WriteAllText(ruta, json);

        }
        public class RootObject
        {
            public List<Profesor> profesor { get; set; }
        }
    }
}
