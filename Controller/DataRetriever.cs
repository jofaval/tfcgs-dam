using EntityFrameworkModel;
using EntityFrameworkModel.Model;
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
            var usuarios = Context.UsuarioDbSet;
            var usuario = usuarios.Where((x) => x.Username == username && x.Contrasenya == password).FirstOrDefault();
            return usuario;
        }

        public static DataRetriever GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DataRetriever();
                Context = new AbastosDbContext();
            }

            return Instance;
        }

        public List<Horario> GetHorariosOfAlumno(Alumno alumno, int anyo = 2019)
        {
            var horarios = Context.HorarioDbSet;
            var horariosDelAlumno = horarios.Where(h => h.Anyo.Equals(anyo) && h.CursoCod.Equals(alumno.CursoCod));

            return horariosDelAlumno.ToList();
        }

        public List<Horario> GetHorariosOfProfesor(Profesor profesor)
        {
            var horarios = Context.HorarioDbSet;
            var horariosDelProfesor = horarios.Where(h => profesor.Impartimiento.Any(i => i.CodAsignatura.Equals(h.CodAsignatura)));

            return horariosDelProfesor.ToList();
        }
    }
}
