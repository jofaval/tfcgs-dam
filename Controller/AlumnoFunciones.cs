using EntityFrameworkModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class AlumnoFunctionality
    {
        public static object GetProfesores(string name, bool? ignoreMayus = true, bool? exactMatch = true)
        {
            name = name.ToLower();
            StaticReferences.Initializer();
            var profesores = StaticReferences.Profesores;

            //return profesores.AsEnumerable()
            //    .Where(p => DataIntegrityChecker.FullyCheckIfContainsString(p.Trabajador1.Persona1.Nombre, name, ignoreMayus, exactMatch))
            //    .ToList();

            return from prof in profesores.AsEnumerable()
                .Where(p => DataIntegrityChecker.FullyCheckIfContainsString(p.Trabajador1.Persona1.Nombre, name, ignoreMayus, exactMatch))
                .ToList()
                   select new
                   {
                       prof.Trabajador1.Persona1.Nombre,
                       prof.Trabajador1.Persona1.Apellidos,
                       prof.Departamento,
                       prof.Trabajador1.Especial?.Funcion,
                       prof.Trabajador1.Persona1.Email,
                       prof.Trabajador1.Sueldo,
                   };
        }
    }
}
