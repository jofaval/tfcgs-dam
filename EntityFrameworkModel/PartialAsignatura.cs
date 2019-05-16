using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class PartialAsignatura : Asignatura
    {
        public override string ToString() => $"Cod: {Cod}, Nombre: {Nombre}";
    }
}
