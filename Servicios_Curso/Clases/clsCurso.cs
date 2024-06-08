using Servicios_Curso.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_Curso.Clases
{
    public class clsCurso
    {
        private DBCursoEntities dbCurso = new DBCursoEntities();

        public CURSo Curso { get; set; }

        public string Insertar()
        {
            try
            {
                dbCurso.CURSoes.Add(Curso);
                dbCurso.SaveChanges();
                return "Se grabo el curso: " + Curso.Nombre;

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
                dbCurso.CURSoes.AddOrUpdate(Curso);
                dbCurso.SaveChanges();
                return "Se Actualizo el curso: " + Curso.Nombre;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public CURSo Consultar(int Codigo)
        {
            //Para retornar un empleado
            //Las instrucciones lambda, permiten que una variable tome las propiedades de un objeto al cual se refiere
            //El método FirstOrDefault, consulta el primer elemento que cumple con las condiciones que se le apliquen 
            //a la consulta, es el equivalente al WHERE
            //La variable "e =>", con la expresión =>, se convierte en una expresión lambda, que permite que esa variable
            //se vuelva un objeto de tipo empleado
            return dbCurso.CURSoes.FirstOrDefault(c => c.Codigo == Codigo);
        }
        public IQueryable ListarTodosConProfesor()
        {
            return from P in dbCurso.Set<PROFesor>()
                   join C in dbCurso.Set<CURSo>()               
                   on P.Documento equals C.DocumentoProfesor
                   join A in dbCurso.Set<ASIGnatura>()
                   on C.CodigoAsignatura equals A.Codigo
                   orderby P.Nombre, C.Nombre, A.NombreAsignatura
                   select new
                   {
                       Codigo = C.Codigo,
                       Nombre = C.Nombre,
                       Descripcion = C.Descripcion,
                       Duracion = C.Duracion,
                       Nivel = C.Nivel,
                       CodigoAsignatura = A.Codigo,
                       DocumentoProfesor = P.Documento
                   };
        }

        //Si quiero consultar todos los empleados, no les pongo ningún criterio, y retorno una lista de empleados
        public string Eliminar()
        {
            try
            {
                //se debe consultar el empleado
                //se creaun objeto de empleado, y se asigna la consulta de la info
                //Curso _estudiante = Curso.Estudiantes.FirstOrDefault(Curso.Estudiantes.FirstOrDefault(c => c.Id_Estudiante == Estudiante.Id_Estudiante);
                //se remueve el estudiante que se consulta en el paso anterior
                CURSo _curso = Consultar(Curso.Codigo);
                dbCurso.CURSoes.Remove(_curso);
                dbCurso.SaveChanges();
                return "Se Eliminó el curso: " + Curso.Codigo;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<CURSo> ConsultarTodos()
        {
            //Para consultar un grupo de empleados, o de objetos de la base de datos, se debe retornar una lista
            //de esos objetos: List<Objeto>, y se termina la consulta con un .ToList()
            return dbCurso.CURSoes.ToList();
        }
    }
}