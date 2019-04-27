using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AlumnoFunciones
    {
        public static List<Profesor> GetProfesores(string name, bool ignoreMayus = true)
        {
            name = name.ToLower();
            StaticReferences.Initializer();
            var profesores = StaticReferences.Profesores;
            
            return profesores.AsEnumerable()
                .Where(p => DataIntegrityChecker.FullyCheckIfContainsString(p.Trabajador1.Persona1.Nombre, name, ignoreMayus))
                .ToList();
        }
    }
}
