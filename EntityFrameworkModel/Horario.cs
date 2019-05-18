using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Horario
    {
        public bool Equals(Horario other) => Curso.Equals(other.Curso)
            && Asignatura.Equals(other.Asignatura)
            && HoraFinal.Equals(other.HoraFinal)
            && HoraInicio.Equals(other.HoraInicio)
            && Dia.Equals(other.Dia);
    }
}
