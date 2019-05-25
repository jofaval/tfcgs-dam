using Model;
using Model.DataStructure;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Controller
{
    public class AlumnoFunctionality
    {
        public static IEnumerable<dynamic> GetProfesores()
        {
            var profesores = StaticReferences.Profesores.AsEnumerable();
            return profesores
                   .Select(profesor =>
                   new ProfesorViewModel
                   {
                       Nombre = profesor.Trabajador1?.Persona1?.Nombre,
                       Apellidos = profesor.Trabajador1?.Persona1?.Apellidos,
                       Departamento = profesor.Departamento1.Nombre,
                       Funcion = profesor.Trabajador1?.Especial?.Funcion,
                       Email = profesor.Trabajador1?.Persona1?.Email,
                   }).AsEnumerable();
        }

        public static IEnumerable<dynamic> GetProfesores(string name, bool? ignoreMayus = true, bool? exactMatch = true)
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
            var cursoCod = alumno.CursoCod;
            var horarios = StaticReferences.Horarios.AsEnumerable();
            var currentYear = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime);

            return StaticReferences.Context.HorarioDbSet
                .Where(h => h.CursoCod.Equals(cursoCod) && h.Anyo.Equals(currentYear))
                .AsEnumerable()
                .OrderBy(h => h)
                .Select(h => new
                {
                    Dia = (WeekEnum)h.Dia,
                    HoraInicio = ExtractHour(h.HoraInicio),
                    HoraFinal = ExtractHour(h.HoraFinal),
                    Asignatura = h.Asignatura.Nombre,
                });
        }

        public static string ExtractHour(DateTime dateTime)
        {
            return string.Concat(dateTime.Hour.ToString("D2"), ':', dateTime.Minute.ToString("D2"));
        }

        public static List<Horario> GetHorariosOfAlumno(Alumno alumno, int anyo = 2019)
        {
            var horarios = StaticReferences.Context.HorarioDbSet;
            var horariosDelAlumno = horarios.Where(h => h.Anyo.Equals(anyo) && h.CursoCod.Equals(alumno.CursoCod));

            return horariosDelAlumno.ToList();
        }
    }
}
