using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Curso : IEquatable<Curso>
    {
        public override string ToString() => $"Codigo: {Cod}, Nombre: {Nombre}";

        public bool Equals(Curso other) => Cod.Equals(other.Cod);
    }
}
