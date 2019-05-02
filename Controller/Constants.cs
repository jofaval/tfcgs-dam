using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Constants
    {
        public static readonly string ApplicationTitle = "Gestión Académico-Administrativa Abastos";

        public static readonly string UrlHelper = "http://mestreacasa.gva.es/web/4602504000";

        public static readonly string UnsuccesfulLogIn = "No se ha podido acceder. ¡Lo sentimos!" +
                    "\nLa combinación usuario/contraseña no era la correcta.";

        public static readonly string UsernameFile = "user.sav";
        public static readonly string SettingsFile = "user.stgs";

        public static readonly string ConfigurationStyle = "SpecialTextControl";

        public static readonly string ResourceFontFamily = "StandardFontFamily";
        public static readonly string ResourceFontSize = "StandardFontSize";
        public static readonly string ResourceWindowWidth = "WindowWidth";
        public static readonly string ResourceWindowHeight = "WindowHeight";

        public static readonly string XmlFontFamily = "fontFamily";
        public static readonly string XmlFontSize = "fontSize";
        public static readonly string XmlWindowWidth = "windowWidth";
        public static readonly string XmlWindowHeight = "windowHeight";

        public static readonly double AspectRatio = 1920 / 1080;
    }
}
