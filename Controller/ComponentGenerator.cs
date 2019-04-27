using EntityFrameworkModel;
using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ComponentGenerator
    {
        public Alumno CreateAlumno(Persona Persona, string NumExpediente, Profesor Tutor)
        {
            return new Alumno()
            {
                Persona = Persona.Dni,
                NumExpediente = NumExpediente,
                Tutor = Tutor.Trabajador,
                FechaMatriculacion = DateTime.Now
            };
        }
    }
}
