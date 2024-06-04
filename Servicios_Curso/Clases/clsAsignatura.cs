using Servicios_Curso.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_Curso.Clases
{
    public class clsAsignatura
    {
        private DBCursoEntities Curso = new DBCursoEntities();

        public ASIGnatura Asignatura { get; set; }

        public string Insertar()
        {
            try
            {
                Curso.ASIGnaturas.Add(Asignatura);
                Curso.SaveChanges();
                return "Se grabo la asignatura: " + Asignatura.NombreAsignatura;

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {   //Para actualizar  un objeto, a partir de Vs 2022, Existe el metodo AddOrUpdate(), que permmite la actualizacion
                //de un objeto, si ya existe en al bd, si no existe lo inserta, y si existe lo modifica
                // la otra opcion  es recibir el objeto, consultar la informacion pro clave primaria y cambiar solo el o los datos que van a cambiar
                Curso.ASIGnaturas.AddOrUpdate(Asignatura);
                Curso.SaveChanges();
                return "Se Actualizo la asignatura: " + Asignatura.NombreAsignatura;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                //se debe consultar el empleado
                //se creaun objeto de empleado, y se asigna la consulta de la info
                //Curso _estudiante = Curso.Estudiantes.FirstOrDefault(Curso.Estudiantes.FirstOrDefault(c => c.Id_Estudiante == Estudiante.Id_Estudiante);
                //se remueve el estudiante que se consulta en el paso anterior
                ASIGnatura _asignatura = Consultar(Asignatura.Codigo);
                Curso.ASIGnaturas.Remove(_asignatura);
                Curso.SaveChanges();
                return "Se Eliminó la asignatura: " + Asignatura.Codigo;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ASIGnatura Consultar(int Codigo)
        {
            //Para retornar un empleado
            //Las instrucciones lambda, permiten que una variable tome las propiedades de un objeto al cual se refiere
            //El método FirstOrDefault, consulta el primer elemento que cumple con las condiciones que se le apliquen 
            //a la consulta, es el equivalente al WHERE
            //La variable "e =>", con la expresión =>, se convierte en una expresión lambda, que permite que esa variable
            //se vuelva un objeto de tipo empleado
            return Curso.ASIGnaturas.FirstOrDefault(e => e.Codigo == Codigo);
        }
        //Si quiero consultar todos los empleados, no les pongo ningún criterio, y retorno una lista de empleados
        public List<ASIGnatura> ConsultarTodos()
        {
            //Para consultar un grupo de empleados, o de objetos de la base de datos, se debe retornar una lista
            //de esos objetos: List<Objeto>, y se termina la consulta con un .ToList()
            return Curso.ASIGnaturas.ToList();
        }
    }
}