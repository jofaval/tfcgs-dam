using Model;
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
            StaticReferences.Initializer();
            var usuarios = StaticReferences.Context.UsuarioDbSet;
            var usuario = usuarios.Where((x) => x.Username == username && x.Contrasenya == password).FirstOrDefault();
            return usuario;
        }

        public static DataRetriever GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DataRetriever();
                //Context = new AbastosDbContext();
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
                else if (user.PermisoAdmin)
                {
                    views.Add(ViewsEnum.ADMINISTRADOR);
                }
                else if (trabajador.Administrativo != null)
                {
                    views.Add(ViewsEnum.ADMINISTRATIVO);
                }
            }

            return views;
        }
    }
}
