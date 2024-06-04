using Servicios_Curso.Clases;
using Servicios_Curso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_Curso.Controllers
{
    [EnableCors(origins: "http://localhost:50247", headers: "*", methods: "*")]
    public class EstudiantesController : ApiController
    {
        // GET api/<controller>
        public List<ESTUdiante> Get()
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.ConsultarTodos();
        }

        // GET api/<controller>/5
        public ESTUdiante Get(string Documento)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.Consultar(Documento);
        }

        // POST api/<controller>
        public string Post([FromBody] ESTUdiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.Estudiante = estudiante;
            return _estudiante.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] ESTUdiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.Estudiante = estudiante;
            return _estudiante.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] ESTUdiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.Estudiante = estudiante;
            return _estudiante.Eliminar();

        }
    }
}