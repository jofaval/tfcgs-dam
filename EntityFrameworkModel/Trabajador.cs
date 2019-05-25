using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Trabajador
    {
        public string NombreCompleto()
        {
            return $"{Persona1.Nombre}, {Persona1.Apellidos}";
        }
    }
}
