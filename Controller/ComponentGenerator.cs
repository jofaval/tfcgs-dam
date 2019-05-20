using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ComponentGenerator
    {
        private static ComponentGenerator Instance { get; set; }
        public string CreateAlumno(Persona Persona, string NumExpediente, string NIA, DateTime fechaMatriculacion)
        {
            var alumno = new Alumno()
            {
                Persona = Persona.Dni,
                NumExpediente = NumExpediente,
                FechaMatriculacion = fechaMatriculacion,
                Persona1 = Persona,
            };

            var context = StaticReferences.Context;
            var cursos = context.AlumnoDbSet;
            if (!context.AlumnoDbSet.Contains(alumno))
            {
                context.AlumnoDbSet.Add(alumno);
                context.SaveChanges();
                return Constants.SuccessCreatingEntity;
            }
            else
            {
                return Constants.FailureCreatingEntity;
            }
        }

        public static ComponentGenerator GetInstance()
        {
            if (Instance is null)
            {
                Instance = new ComponentGenerator();
            }

            return Instance;
        }

        public string CreateCurso(string cod, string nombre, DateTime? fechaMAtriculacion, bool turnoTarde)
        {
            var curso = new Curso()
            {
                Cod = cod,
                Nombre = nombre,
                FechaMatriculacion = fechaMAtriculacion,
                TurnoTarde = turnoTarde,
            };
            var context = StaticReferences.Context;
            var cursos = context.CursoDbSet;
            if (!cursos.Any(c => c.Cod.Equals(cod)))
            {
                cursos.Add(curso);
                context.SaveChanges();
                return Constants.SuccessCreatingEntity;
            }
            else
            {
                return Constants.FailureCreatingEntity;
            }
        }

        public string CreatePersona(string dni, string nif, string nombre, string apellidos, string email, string calle, string patio, string piso, string puerta, string codigoPostal, DateTime fechaNac, string telefono = "")
        {
            var persona = new Persona()
            {
                Dni = dni,
                Nif = nif,
                Nombre = nombre,
                Apellidos = apellidos,
                Email = email,
                Calle = calle,
                Patio = patio,
                Piso = piso,
                Puerta = puerta,
                CodigoPostal = codigoPostal,
                FechaNacimiento = fechaNac,
            };

            if (string.IsNullOrEmpty(telefono))
            {
                persona.Telefono = new List<Telefono>
                {
                    new Telefono()
                    {
                        Persona1 = persona,
                        Telefono1 = telefono,
                    }
                };
            }

            var context = StaticReferences.Context;
            var personas = context.PersonaDbSet.ToList();

            if (!personas.Contains(persona))
            {
                try
                {
                    context.PersonaDbSet.Add(persona);
                    context.SaveChanges();
                    return Constants.SuccessCreatingEntity;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return Constants.FailureCreatingEntity;
            }
        }

        public string CreateHorario(Curso curso, Asignatura asignatura, DateTime horaInicio, DateTime horaFinal)
        {
            StaticReferences.Initializer();
            var context = StaticReferences.Context;
            var horarios = context.HorarioDbSet.ToList();
            context.SaveChanges();
            var cursoCodText = curso.Cod;
            var cursoNombreText = curso.Nombre;

            var asignaturaCodText = asignatura.Cod;

            var horario = new Horario()
            {
                Anyo = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime),
                CursoCod = cursoCodText,
                CursoNombre = cursoNombreText,
                Curso = curso,
                CodAsignatura = asignaturaCodText,
                Asignatura = asignatura,
                HoraInicio = horaInicio,
                HoraFinal = horaFinal.Hour,
            };

            if (!horarios.Contains(horario))
            {
                context.HorarioDbSet.Add(horario);
                context.SaveChanges();
                return Constants.SuccessCreatingEntity;
            }
            else
            {
                return Constants.FailureCreatingEntity;
            }
        }

        public string CreateAsignatura(string cod, string nombre, string rama)
        {
            var asignatura = new Asignatura()
            {
                Cod = cod,
                Nombre = nombre,
                Rama = rama,
            };
            var context = StaticReferences.Context;
            var asignaturas = context.AsignaturaDbSet;
            if (!asignaturas.Any(c => c.Cod.Equals(cod)))
            {
                asignaturas.Add(asignatura);
                context.SaveChanges();
                return Constants.SuccessCreatingEntity;
            }
            else
            {
                return Constants.FailureCreatingEntity;
            }
        }
    }
}
