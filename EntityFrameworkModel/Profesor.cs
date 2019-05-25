using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Profesor : IEquatable<Profesor>
    {
        public bool Equals(Profesor other) => Trabajador1.Persona1.Equals(other.Trabajador1.Persona1);

        public override string ToString()
        {
            var persona = Trabajador1.Persona1;
            return $"Nombre: {persona.Nombre}, Apellidos: {persona.Apellidos}, eMail: {persona.Email}";
        }
    }
}
