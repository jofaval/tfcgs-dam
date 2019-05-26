using Model;
using Model.DataStructure;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ProfesorFunctionality
    {
        public static IEnumerable<object> GetHorarios(Profesor profesor)
        {
            var horarios = StaticReferences.Context.ImpartimientoDbSet;
            var horariosDelProfesor = horarios
                .Where(i => i.Profesor1.Equals(profesor))
                .AsEnumerable()
                .OrderBy(i => i.Horario)
                .Select(i => new
                {
                    Dia = (WeekEnum)i.Dia,
                    HoraInicio = AlumnoFunctionality.ExtractHour(i.HoraInicio),
                    HoraFinal = AlumnoFunctionality.ExtractHour(i.HoraFinal),
                    Aula = i.Aula.Codificate(),
                    Asignatura = i.Horario.Asignatura.Nombre,
                    Curso = i.CursoNombre,
                });

            return horariosDelProfesor;
        }

        public static IEnumerable<object> GetHorariosGuardia(DateTime currentDateTime)
        {
            var horarios = StaticReferences.Context.ImpartimientoDbSet;

            var currentHour = dateTimeNow.Hour;
            var currentMinute = dateTimeNow.Minute;

            var currentDay = dateTimeNow.DayOfWeek;
            currentDay = currentDay > 0 ? currentDay - 1 : currentDay + 6;

            var horariosDelProfesor = horarios
                .Where(i => i.Horario.Dia.Equals(currentDay)
                && (currentHour >= i.HoraInicio.Hour
                && currentHour <= i.HoraFinal.Hour)
                && (currentMinute >= i.HoraInicio.Minute
                && currentMinute <= i.HoraFinal.Minute))
                .AsEnumerable()
                .OrderBy(i => i.Horario)
                .Select(i => new
                {
                    Dia = (WeekEnum)i.Dia,
                    HoraInicio = AlumnoFunctionality.ExtractHour(i.HoraInicio),
                    HoraFinal = AlumnoFunctionality.ExtractHour(i.HoraFinal),
                    Aula = i.Aula.Codificate(),
                    Asignatura = i.Horario.Asignatura.Nombre,
                    Curso = i.CursoNombre,
                });

            return horariosDelProfesor;
        }

        public static IEnumerable<object> GetAlumnos(string name, Profesor profesor, bool? ignoreMayus = true, bool? exactMatch = true)
        {

            name = name.ToLower();
            var alumnos = StaticReferences.Alumnos
                .Where(a => profesor.Impartimiento
                .Where(i => i.CursoCod.Equals(a.CursoCod))
                .Any())
                .AsEnumerable();

            var resultList = name.Equals(string.Empty) ?
            alumnos.ToList() :
            alumnos
            .Where(a => DataIntegrityChecker.FullyCheckIfContainsString(a.Persona1.Nombre, name, ignoreMayus, exactMatch))?
            .ToList();

            return from alumno in resultList
                   select new
                   {
                       alumno.NumExpediente,
                       alumno.CursoNombre,
                       alumno.Persona1.Nombre,
                       alumno.Persona1.Apellidos,
                       alumno.Persona1.Email,
                   };
        }

        public static IEnumerable<dynamic> GetAlumnos(Profesor profesor)
        {
            var alumnos = StaticReferences.Alumnos
                   .Where(a => profesor.Impartimiento
                   .Where(i => i.CursoCod.Equals(a.CursoCod))
                   .Any())
                   .AsEnumerable();

            return alumnos
                .Select(alumno =>
                   new AlumnoViewModel
                   {
                       NumExpediente = alumno.NumExpediente,
                       CursoNombre = alumno.CursoNombre,
                       Nombre = alumno.Persona1.Nombre,
                       Apellidos = alumno.Persona1.Apellidos,
                       Email = alumno.Persona1.Email,
                   }).AsEnumerable();
        }
    }
}
