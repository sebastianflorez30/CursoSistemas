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
    public class HorariosController : ApiController
    {
        // GET api/<controller>/5
        public HORArio Get(int Codigo)
        {
            clsHorario _horario = new clsHorario();
            return _horario.Consultar(Codigo);
        }


        // POST api/<controller>
        public string Post([FromBody] HORArio horario)
        {
            clsHorario _horario = new clsHorario();
            _horario.Horario = horario;
            return _horario.Insertar();
        }


        // PUT api/<controller>/5
        public string Put([FromBody] HORArio horario)
        {
            clsHorario _horario = new clsHorario();
            _horario.Horario = horario;
            return _horario.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] HORArio horario)
        {
            clsHorario _horario = new clsHorario();
            _horario.Horario = horario;
            return _horario.Eliminar();
        }
    }
}