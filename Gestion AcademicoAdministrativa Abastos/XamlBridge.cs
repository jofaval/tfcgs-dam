using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Posibles_Interfaces_de_Usuario
{
    static public class XamlBridge
    {
        static public Grid BackUpMainGridContent { get; set; }

        public static Grid BackUpLoginGridContent { get; set; }
        public static Grid BackgroundGrid { get; internal set; }
    }
}
