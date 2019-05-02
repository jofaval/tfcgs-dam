using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class AlumnoFunctionality
    {
        public static IEnumerable<object> GetProfesores(string name, bool? ignoreMayus = true, bool? exactMatch = true)
        {
            name = name.ToLower();
            StaticReferences.Initializer();
            var profesores = StaticReferences.Profesores.AsEnumerable();

            //return profesores.AsEnumerable()
            //    .Where(p => DataIntegrityChecker.FullyCheckIfContainsString(p.Trabajador1.Persona1.Nombre, name, ignoreMayus, exactMatch))
            //    .ToList();

            List<Profesor> resultList;
                resultList = name.Equals(string.Empty) ?
                profesores.ToList() :
                profesores
                .Where(p => DataIntegrityChecker.FullyCheckIfContainsString(p.Trabajador1.Persona1.Nombre, name, ignoreMayus, exactMatch))?
                .ToList();

            return from profesor in resultList
                   select new
                   {
                       profesor.Trabajador1.Persona1.Nombre,
                       profesor.Trabajador1.Persona1.Apellidos,
                       profesor.Departamento,
                       profesor.Trabajador1.Especial?.Funcion,
                       profesor.Trabajador1.Persona1.Email,
                   };
        }

        public static IEnumerable<object> GetHorarios(Usuario currentUser)
        {
            var alumno = currentUser.Persona1.Alumno;
            var curso = alumno.CursoCod;
            StaticReferences.Initializer();
            var horarios = StaticReferences.Horarios.AsEnumerable();
            var currentYear = DateTime.Now.Year;

            return from horario in horarios
                   .Where(h => h.CursoCod == curso && h.Anyo == currentYear)
                   .ToList()
                   select new
                   {
                       horario.Dia,
                       horario.HoraInicio,
                       horario.HoraFinal,
                       horario.Asignatura
                   };
        }
    }
}
