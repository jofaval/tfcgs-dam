using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Persona : IEquatable<Persona>
    {
        public override string ToString() => $"DNI: {Dni}, Nombre: {Nombre}, Apellidos: {Apellidos}";

        public bool Equals(Persona other) => Dni.Equals(other.Dni)
            && Nif.Equals(other.Nif);
    }
}
