using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    static public class XamlBridge
    {
        static public Grid BackUpMainGridContent { get; set; }

        public static Grid BackUpLoginGridContent { get; set; }
        public static Grid BackgroundGrid { get; internal set; }

        public static Usuario CurrentUser { get; set; }
    }
}
