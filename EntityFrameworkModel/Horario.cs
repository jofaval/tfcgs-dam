using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Horario : IEquatable<Horario>, IComparable<Horario>
    {
        public bool Equals(Horario other)
        {
            try
            {
                return Curso.Equals(other.Curso)
                && Asignatura.Equals(other.Asignatura)
                && HoraFinal.Equals(other.HoraFinal)
                && HoraInicio.Equals(other.HoraInicio)
                && Dia.Equals(other.Dia)
                && Anyo.Equals(other.Anyo);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CompareTo(Horario other)
        {
            var outterDia = other.Dia;
            var innerHoraInicio = HoraInicio.Hour + HoraInicio.Minute;
            var outterHoraInicio = other.HoraInicio.Hour + other.HoraInicio.Minute;

            if (Dia.Equals(outterDia)
                && innerHoraInicio.Equals(outterHoraInicio))
            {
                return 0;
            }
            else if (Dia > outterDia || (Dia.Equals(outterDia)
                && innerHoraInicio > outterHoraInicio))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
