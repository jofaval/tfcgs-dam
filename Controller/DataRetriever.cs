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
    public class DataRetriever
    {
        public static DataRetriever Instance { get; set; }

        public static AbastosDbContext Context { get; set; }

        public Usuario GetUser(string username, string password)
        {
            //password = Cryptography.Encrypt(password, username);
            var usuarios = StaticReferences.Context.UsuarioDbSet;
            var usuario = usuarios
                .AsEnumerable()
                .FirstOrDefault((x) => x.Username.Equals(username)
                && Cryptography.Decrypt(x.Contrasenya, username).Equals(password));
            //Console.WriteLine(password);
            //Console.WriteLine(usuarios
            //    .FirstOrDefault((x) => x.Username.Equals(username)) is null);
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

            if (user != null)
            {
                var userPersona = user.Persona1;
                if (userPersona.Alumno != null)
                {
                    views.Add(ViewsEnum.Alumno);
                }

                var trabajador = userPersona.Trabajador;
                if (trabajador != null)
                {
                    if (trabajador.Profesor != null)
                    {
                        views.Add(ViewsEnum.Profesor);
                    }
                    else if (trabajador.Administrativo != null)
                    {
                        views.Add(ViewsEnum.Administrativo);
                    }
                }
                if (!views.Contains(ViewsEnum.Administrativo))
                {
                    if (user.PermisosUsuario.PermisoAdministrativo)
                    {
                        views.Add(ViewsEnum.Administrativo);
                    }
                }
                if (user.PermisosUsuario.PermisoAdmin)
                {
                    views.Add(ViewsEnum.Administrador);
                }
            }

            return views;
        }

        public IEnumerable<dynamic> GetListByUser(ViewsEnum user, Profesor profesor = null)
        {
            var joiner = Constants.StringJoiner;

            switch (user)
            {
                case ViewsEnum.Alumno:
                    return AlumnoFunctionality.GetProfesores();
                case ViewsEnum.Profesor:
                    return ProfesorFunctionality.GetAlumnos(profesor);
                case ViewsEnum.Administrativo:
                case ViewsEnum.Administrador:
                default:
                    return StaticReferences.Context.PersonaDbSet
                    .Select(p => new PersonaViewModel
                    {
                        Dni = p.Dni,
                        Nif = p.Nif,
                        Nombre = p.Nombre,
                        Apellidos = p.Apellidos,
                        Direccion = string.Concat(p.Calle, joiner, p.Patio, joiner, p.Piso, joiner, p.Puerta),
                    }).AsEnumerable();
            }
        }

        public Usuario GetUserByPerson(Persona persona)
        {
            return persona.Usuario.FirstOrDefault();
        }

        public Usuario GetUserByPerson(string DNI)
        {
            return GetPersona(DNI)?
                .Usuario.FirstOrDefault();
        }

        public Persona GetPersona(string DNI)
        {
            return StaticReferences.Context.PersonaDbSet
                .SingleOrDefault(p => p.Dni.Equals(DNI));
        }
    }
}
