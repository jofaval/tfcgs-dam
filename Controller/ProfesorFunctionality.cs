using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ProfesorFunctionality
    {
        public List<Horario> GetHorarios(Profesor profesor)
        {
            var horarios = StaticReferences.Context.HorarioDbSet;
            var horariosDelProfesor = horarios.Where(h => profesor.Impartimiento.Any(i => i.CodAsignatura.Equals(h.CodAsignatura)));

            return horariosDelProfesor.ToList();
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
                       alumno.Persona1.Nombre,
                       alumno.Persona1.Apellidos,
                       alumno.CursoNombre,
                       alumno.NumExpediente,
                       alumno.Persona1.Email,
                   };
        }
    }
}
