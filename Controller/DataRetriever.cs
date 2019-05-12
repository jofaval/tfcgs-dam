﻿using Model;
using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DataRetriever
    {
        public static DataRetriever Instance { get; set; }

        public static AbastosDbContext Context { get; set; }

        public Usuario GetUser(string username, string password)
        {
            var usuarios = StaticReferences.Context.UsuarioDbSet;
            var usuario = usuarios
                .Where((x) => x.Username.Equals(username)
                && x.Contrasenya.Equals(password))
                .FirstOrDefault();
            return usuario;
        }

        public static DataRetriever GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DataRetriever();
                StaticReferences.Initializer();
            }

            return Instance;
        }

        public static List<ViewsEnum> PosibleViews(Usuario user)
        {
            var views = new List<ViewsEnum>();

            var userPersona = user.Persona1;
            if (userPersona.Alumno != null)
            {
                views.Add(ViewsEnum.ALUMNO);
            }

            var trabajador = userPersona.Trabajador;
            if (trabajador != null)
            {
                if (trabajador.Profesor != null)
                {
                    views.Add(ViewsEnum.PROFESOR);
                }
                else if (trabajador.Administrativo != null)
                {
                    views.Add(ViewsEnum.ADMINISTRATIVO);
                }
            }
            if (!views.Contains(ViewsEnum.ADMINISTRATIVO))
            {
                if (user.PermisoAdministrativo)
                {
                    views.Add(ViewsEnum.ADMINISTRATIVO);
                }
            }
            if (user.PermisoAdmin)
            {
                views.Add(ViewsEnum.ADMINISTRADOR);
            }

            return views;
        }

        public IEnumerable<dynamic> GetListByUser(ViewsEnum user, Profesor profesor = null)
        {
            var joiner = Constants.StringJoiner;

            switch (user)
            {
                case ViewsEnum.ALUMNO:
                    return AlumnoFunctionality.GetProfesores();
                case ViewsEnum.PROFESOR:
                    return ProfesorFunctionality.GetAlumnos(profesor);
                case ViewsEnum.ADMINISTRATIVO:
                case ViewsEnum.ADMINISTRADOR:
                default:
                    return StaticReferences.Context.PersonaDbSet
                    .Select(p => new
                    {
                        p.Dni,
                        p.Nif,
                        p.Nombre,
                        p.Apellidos,
                        Direccion = string.Concat(p.Calle, joiner, p.Patio, joiner, p.Piso, joiner, p.Puerta),
                    }).AsEnumerable();
            }
        }
    }
}
