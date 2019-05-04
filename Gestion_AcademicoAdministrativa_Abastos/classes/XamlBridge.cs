﻿using Model;
using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    public class XamlBridge
    {
        static public MainWindow MainWindowInstance { get; set; }
        static public Grid MainPanelInstance { get; set; }

        public static Grid BackUpLoginGridContent { get; set; }
        public static Grid BackgroundGrid { get; internal set; }
        static public Grid BackUpMainPanel { get; set; }

        public static Usuario CurrentUser { get; set; }
        public static WindowSizeEnum SizeEnum { get; set; }

        public static void CloseEverything()
        {
            MainPanelInstance = null;
            BackUpLoginGridContent = null;
            BackgroundGrid = null;
            BackUpMainPanel = null;
            CurrentUser = null;

            MainWindowInstance.CloseApp();
            MainWindowInstance = null;

            //new SplashScreen()
            //{
            //    Visibility = System.Windows.Visibility.Visible
            //};
        }
    }
}
