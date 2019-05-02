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

        public static readonly string UrlHelper = "http://mestreacasa.gva.es/web/guest/inicio";

        public static readonly string UnsuccesfulLogIn = "No se ha podido acceder. ¡Lo sentimos!" +
                    "\nLa combinación usuario/contraseña no era la correcta.";

        public static readonly string UsernameFile = "user.sav";
        public static readonly string SettingsFile = ".settings";

        public static readonly string ConfigurationStyle = "SpecialTextControl";
    }
}
