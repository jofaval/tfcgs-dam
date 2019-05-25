using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Telefono : IEquatable<Telefono>
    {
        public bool Equals(Telefono other) => Persona1.Equals(other.Persona1)
            && Telefono1.Equals(other.Telefono1);
    }
}
