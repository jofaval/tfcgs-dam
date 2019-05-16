using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class PartialPersona : Persona
    {
        public override string ToString() => $"DNI: {Dni}, Nombre: {Nombre}, Apellidos: {Apellidos}";
    }
}
