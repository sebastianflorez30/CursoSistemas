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
    public class CursosController : ApiController
    {
        /*// GET api/<controller>
        public List<CURSo> Get()
        {
            clsCurso _curso = new clsCurso();
            return _curso.ConsultarTodos();
        }
        */
        // GET api/<controller>/5
        public CURSo Get(int Codigo)
        {
            clsCurso _curso = new clsCurso();
            return _curso.Consultar(Codigo);
        }

        // POST api/<controller>
        public string Post([FromBody] CURSo curso)
        {
            clsCurso _curso = new clsCurso();
            _curso.Curso = curso;
            return _curso.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] CURSo curso)
        {
            clsCurso _curso = new clsCurso();
            _curso.Curso = curso;
            return _curso.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] CURSo curso)
        {
            clsCurso _curso = new clsCurso();
            _curso.Curso = curso;
            return _curso.Eliminar();

        }
    }
}