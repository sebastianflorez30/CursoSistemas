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
    public class ProfesoresController : ApiController
    {
        // GET api/<controller>
        public List<PROFesor> Get()
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.ConsultarProfesores();
        }
    }
}