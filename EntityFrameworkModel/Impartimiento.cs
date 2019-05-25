using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Impartimiento : IEquatable<Impartimiento>
    {
        public bool Equals(Impartimiento other) => Horario.Equals(other.Horario)
            && Profesor1.Equals(other.Profesor1)
            && Aula.Equals(Aula);
    }
}
