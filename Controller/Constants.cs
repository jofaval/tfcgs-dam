﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Controller
{
    public class Constants
    {
        public static readonly string ApplicationTitle = "Gestión Académico-Administrativa Abastos";

        public static readonly string UrlHelper = "http://mestreacasa.gva.es/web/4602504000";

        public static readonly string UnsuccesfulLogIn = "No se ha podido acceder. ¡Lo sentimos!" +
                    "\nLa combinación usuario/contraseña no era la correcta.";
        public static readonly string StringJoiner = ", ";

        public static readonly string UsernameFile = "user.sav";
        public static readonly string SettingsFile = "user.stgs";

        public static readonly string ConfigurationStyle = "SpecialTextControl";

        public static readonly string ResourceFontFamily = "StandardFontFamily";
        public static readonly string ResourceFontSize = "StandardFontSize";
        public static readonly string ResourceWindowWidth = "WindowWidth";
        public static readonly string ResourceWindowHeight = "WindowHeight";
        public static readonly string ResourceBackgroundColorfulGradientStart = "BackgroundColorfulGradientStart";
        public static readonly string ResourceBackgroundColorfulGradientEnd = "BackgroundColorfulGradientEnd";
        public static readonly string ResourceBackgroundColorfulGradient = "BackgroundColorfulGradient";

        public static readonly string XmlFontFamily = "fontFamily";
        public static readonly string XmlFontSize = "fontSize";
        public static readonly string XmlWindowWidth = "windowWidth";
        public static readonly string XmlWindowHeight = "windowHeight";
        public static readonly string XmlBackgroundStart = "backgroundStart";
        public static readonly string XmlBackgroundEnd = "backgroundEnd";

        public static readonly string SuccessCreatingEntity = "Se ha creado con éxito";
        public static readonly string FailureCreatingEntity = "Ya existe en el sistema o no se ha podido añadir";

        public static readonly string SuccessRemovingEntity = "Se ha eliminado con éxito";
        public static readonly string FailureRemovingEntity = "No se ha podido eliminar o no se ha encontrado.";

        public static readonly string NoResults = "No hemos podido encontrar resultados";

        public static readonly double AspectRatio = 1920 / 1080;
        public static readonly Regex RegexOnlyNumber = new Regex("[^0-9]+");
        public static readonly Regex RegexAlphaNumeric = new Regex(@"[^\w]+");
        public const double TopBarHeight = 25;
        public const int MainWindowThickness = 5;

        public static readonly string EncryptationKey = "F8f3faTqmQSFMAR8RfDNdmEVtymZLA2J";
        public static readonly string LocalMachineKey = NetworkInterface.GetAllNetworkInterfaces().First().GetPhysicalAddress().ToString();
        public const int SleepTimeProfesorGuardiaRoboto = 55 * 60 * 1000;

        public static readonly string BackgroundColorfulGradientStartCode = "#FF69E655";
        public static readonly string BackgroundColorfulGradientEndCode = "#FF006CC5";
    }
}
