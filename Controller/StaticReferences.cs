using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class StaticReferences
    {
        static public AbastosDbContext Context { get; set; }
        static public DbSet<Profesor> Profesores { get; set; }
        static public DbSet<Horario> Horarios { get; set; }
        static public Random RandomGenerator { get; set; }

        public static void Initializer()
        {
            if (Context == null)
            {
                Context = new AbastosDbContext();
                RandomGenerator = new Random();
                Profesores = Context.ProfesorDbSet;
                Horarios = Context.HorarioDbSet;
            }
        }
    }
}
