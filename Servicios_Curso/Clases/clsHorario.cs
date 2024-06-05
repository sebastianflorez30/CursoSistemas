using Servicios_Curso.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_Curso.Clases
{
    public class clsHorario
    {
        private DBCursoEntities Curso = new DBCursoEntities();

        public HORArio Horario { get; set; }

        public string Insertar()
        {
            try
            {
                Curso.HORArios.Add(Horario);
                Curso.SaveChanges();
                return "Se grabo el horario: " + Horario.Codigo;

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
                Curso.HORArios.AddOrUpdate(Horario);
                Curso.SaveChanges();
                return "Se Actualizo el horario: " + Horario.Codigo;

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
                HORArio _horario = Consultar(Horario.Codigo);
                Curso.HORArios.Remove(_horario);
                Curso.SaveChanges();
                return "Se Eliminó el horario: " + Horario.Codigo;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public HORArio Consultar(int Codigo)
        {
            //Para retornar un empleado
            //Las instrucciones lambda, permiten que una variable tome las propiedades de un objeto al cual se refiere
            //El método FirstOrDefault, consulta el primer elemento que cumple con las condiciones que se le apliquen 
            //a la consulta, es el equivalente al WHERE
            //La variable "e =>", con la expresión =>, se convierte en una expresión lambda, que permite que esa variable
            //se vuelva un objeto de tipo empleado
            return Curso.HORArios.FirstOrDefault(h => h.Codigo == Codigo);
        }
        //Si quiero consultar todos los empleados, no les pongo ningún criterio, y retorno una lista de empleados
        public List<HORArio> ConsultarTodos()
        {
            //Para consultar un grupo de empleados, o de objetos de la base de datos, se debe retornar una lista
            //de esos objetos: List<Objeto>, y se termina la consulta con un .ToList()
            return Curso.HORArios.ToList();
        }
    }
}