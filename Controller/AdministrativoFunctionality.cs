using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AdministrativoFunctionality
    {
        public int GetAcademicYear(DateTime dateTime)
        {
            var year = dateTime.Year;
            var month = dateTime.Month;

            if (month < 8)
            {
                year--;
            }

            return year;
        }
    }
}
