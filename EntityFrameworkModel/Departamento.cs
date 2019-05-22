using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Departamento : IEquatable<Departamento>
    {
        public bool Equals(Departamento other) => Cod.Equals(other.Cod);

        public override string ToString() => $"Codigo: {Cod}, Nombre: {Nombre}";
    }
}
