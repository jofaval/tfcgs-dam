using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Estudio : IEquatable<Estudio>
    {
        public bool Equals(Estudio other) => Curso.Equals(other.Curso)
                && Alumno1.Equals(other.Alumno1)
                && Anyo.Equals(other.Anyo);
    }
}
