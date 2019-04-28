using EntityFrameworkModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class AlumnoFunciones
    {
        public static List<Profesor> GetProfesores(string name, bool? ignoreMayus = true, bool? exactMatch = true)
        {
            name = name.ToLower();
            StaticReferences.Initializer();
            var profesores = StaticReferences.Profesores;
            
            return profesores.AsEnumerable()
                .Where(p => DataIntegrityChecker.FullyCheckIfContainsString(p.Trabajador1.Persona1.Nombre, name, ignoreMayus, exactMatch))
                .ToList();
        }
    }
}
