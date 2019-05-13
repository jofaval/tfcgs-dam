using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class AlumnoFunctionality
    {
        public static IEnumerable<object> GetProfesores()
        {
            return StaticReferences.Profesores
                   .Select(profesor =>
                   new
                   {
                       profesor.Trabajador1.Persona1.Nombre,
                       profesor.Trabajador1.Persona1.Apellidos,
                       profesor.Departamento,
                       profesor.Trabajador1.Especial.Funcion,
                       profesor.Trabajador1.Persona1.Email,
                   }).AsEnumerable();
        }

        public static IEnumerable<object> GetProfesores(string name, bool? ignoreMayus = true, bool? exactMatch = true)
        {
            name = name.ToLower();
            StaticReferences.Initializer();
            var profesores = StaticReferences.Profesores.AsEnumerable();

            var resultList = name.Equals(string.Empty) ?
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
            var horarios = StaticReferences.Horarios.AsEnumerable();
            var currentYear = DateTime.Now.Year;

            return from horario in horarios
                   .Where(h => h.CursoCod.Equals(curso) && h.Anyo.Equals(currentYear))
                   .ToList()
                   select new
                   {
                       horario.Dia,
                       horario.HoraInicio,
                       horario.HoraFinal,
                       horario.Asignatura
                   };
        }

        public static List<Horario> GetHorariosOfAlumno(Alumno alumno, int anyo = 2019)
        {
            var horarios = StaticReferences.Context.HorarioDbSet;
            var horariosDelAlumno = horarios.Where(h => h.Anyo.Equals(anyo) && h.CursoCod.Equals(alumno.CursoCod));

            return horariosDelAlumno.ToList();
        }
    }   
}
