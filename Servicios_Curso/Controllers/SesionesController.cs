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
    public class SesionesController : ApiController
    {
        // GET api/<controller>
        public List<SESIon> Get()
        {
            clsSesion _sesion = new clsSesion();
            return _sesion.ConsultarSesiones();
        }
           
    }
}