using Servicios_Curso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Curso.Clases
{
    public class clsSesion
    {
        private DBCursoEntities Curso = new DBCursoEntities();

        public SESIon Sesion { get; set; }

        public List<SESIon> ConsultarSesiones()
        {
            return Curso.SESIons
                          .OrderBy(s => s.FechaInicio)
                          .ToList();
        }



    }
}