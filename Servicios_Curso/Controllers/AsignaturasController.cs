using Servicios_Curso.Clases;
using Servicios_Curso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGrease.Css.Visitor;

namespace Servicios_Curso.Controllers
{
    [EnableCors(origins: "http://localhost:50247", headers: "*", methods: "*")]
    public class AsignaturasController : ApiController
    {
        // GET api/<controller>
        /*
        public List<ASIGnatura> Get()
        {
            clsAsignatura _asignatura = new clsAsignatura();
            return _asignatura.ConsultarTodos();
        }*/

        public IQueryable Get()
        {
            clsAsignatura _asignatura = new clsAsignatura();
            return _asignatura.ListarAsignaturas();            
        }

        // GET api/<controller>/5
        public ASIGnatura Get(int Codigo)
        {
            clsAsignatura _asignatura = new clsAsignatura();
            return _asignatura.Consultar(Codigo);
        }

        // POST api/<controller>
        public string Post([FromBody] ASIGnatura asignatura)
        {
            clsAsignatura _asignatura = new clsAsignatura();
            _asignatura.Asignatura = asignatura;
            return _asignatura.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] ASIGnatura asignatura)
        {
            clsAsignatura _asignatura = new clsAsignatura();
            _asignatura.Asignatura = asignatura;
            return _asignatura.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] ASIGnatura asignatura)
        {
            clsAsignatura _asignatura = new clsAsignatura();
            _asignatura.Asignatura = asignatura;
            return _asignatura.Eliminar();

        }
    }
}