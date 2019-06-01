using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gestion_AcademicoAdministrativa_Abastos.Classes
{
    public static class Restrictions
    {
        public static void AlphaNumericText(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(x => char.IsLetterOrDigit(x) || x.Equals(' '));
        }
    }
}
