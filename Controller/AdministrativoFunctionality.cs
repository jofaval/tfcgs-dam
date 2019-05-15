using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AdministrativoFunctionality
    {
        public static int GetAcademicYear(DateTime dateTime)
        {
            var year = dateTime.Year;
            var month = dateTime.Month;

            if (month < (byte)MonthEnum.AUGUST)
            {
                year--;
            }

            return year;
        }
    }
}
