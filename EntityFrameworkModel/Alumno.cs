using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Alumno : IEquatable<Alumno>
    {
        public bool Equals(Alumno other) => Persona1.Equals(other.Persona1)
            && NumExpediente.Equals(other.NumExpediente);
    }
}
