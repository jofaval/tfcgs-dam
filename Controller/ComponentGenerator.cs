﻿using Model;
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
