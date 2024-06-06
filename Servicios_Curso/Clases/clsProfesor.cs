using Servicios_Curso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Curso.Clases
{
    public class clsProfesor
    {
        private DBCursoEntities Curso = new DBCursoEntities();

        public PROFesor Profesor { get; set; }

        public List<PROFesor> ConsultarProfesores()
        {
            return Curso.PROFesors
                          .OrderBy(p => p.Nombre)
                          .ToList();
        }
    }
}