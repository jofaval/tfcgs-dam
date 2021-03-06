﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Asignatura : IEquatable<Asignatura>
    {
        public override string ToString() => $"Codigo: {Cod}, Nombre: {Nombre}";

        public bool Equals(Asignatura other) => Cod.Equals(other.Cod);
    }
}
