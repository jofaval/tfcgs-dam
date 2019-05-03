using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class StaticReferences
    {
        static public AbastosDbContext Context { get; set; }
        static public DbSet<Profesor> Profesores { get; set; }
        static public DbSet<Alumno> Alumnos { get; set; }
        static public DbSet<Horario> Horarios { get; set; }

        static public Random RandomGenerator { get; set; }

        static public DateTime CurrentDateTime { get; set; }
        static public int CurrentDay { get; set; }
        static public int CurrentMonth { get; set; }
        static public int CurrentYear { get; set; }

        public static void Initializer()
        {
            if (Context == null)
            {
                Context = new AbastosDbContext();
                Profesores = Context.ProfesorDbSet;
                Alumnos = Context.AlumnoDbSet;
                Horarios = Context.HorarioDbSet;

                RandomGenerator = new Random();

                var dateTimeNow = DateTime.Now;
                CurrentDay = dateTimeNow.Year;
                CurrentMonth = dateTimeNow.Month;
                CurrentYear = dateTimeNow.Day;
                CurrentDateTime = dateTimeNow;
            }
        }

        public static void Closer()
        {
            if (Context != null)
            {
                Context = null;
                Profesores = null;
                Horarios = null;

                RandomGenerator = null;

                var dateTimeNow = DateTime.Now;
                CurrentDay = dateTimeNow.Year;
                CurrentMonth = dateTimeNow.Month;
                CurrentYear = dateTimeNow.Day;
                CurrentDateTime = dateTimeNow;
            }
        }
    }
}
