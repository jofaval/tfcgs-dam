using Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LoadSettings();
        }

        public static void LoadSettings()
        {
            if (!File.Exists(Constants.SettingsFile))
            {
                var xmlCreator = new XDocument(
                    new XElement("settings",
                        new XElement(Constants.XmlFontFamily, "Ubuntu"),
                        new XElement(Constants.XmlFontSize, "15"),
                        new XElement(Constants.XmlWindowWidth, "1920"),
                        new XElement(Constants.XmlWindowHeight, "1080")
                    )
                );

                xmlCreator.Save(Constants.SettingsFile);
            }

            var xmlReader = new XmlDocument();
            xmlReader.LoadXml(File.ReadAllText(Constants.SettingsFile));

            var fontSize = xmlReader.GetElementsByTagName(Constants.XmlFontSize)[0].InnerText;
            Current.Resources[Constants.ResourceFontSize] = double.Parse(fontSize);

            var fontFamily = xmlReader.GetElementsByTagName(Constants.XmlFontFamily)[0].InnerText;
            Current.Resources[Constants.ResourceFontFamily] = new FontFamily(fontFamily);

            var windowWidth = xmlReader.GetElementsByTagName(Constants.XmlWindowWidth)[0].InnerText;
            Current.Resources[Constants.ResourceWindowWidth] = double.Parse(windowWidth);

            var windowHeight = xmlReader.GetElementsByTagName(Constants.XmlWindowHeight)[0].InnerText;
            Current.Resources[Constants.ResourceWindowHeight] = double.Parse(windowHeight);
        }

        public static void SaveNewSettings()
        {
            var xmlReader = new XmlDocument();
            xmlReader.LoadXml(File.ReadAllText(Constants.SettingsFile));
            xmlReader.GetElementsByTagName(Constants.XmlFontSize)[0].InnerText = Current.Resources[Constants.ResourceFontSize].ToString();
            xmlReader.GetElementsByTagName(Constants.XmlFontFamily)[0].InnerText = ((FontFamily)Current.Resources[Constants.ResourceFontFamily]).ToString();
            xmlReader.GetElementsByTagName(Constants.XmlWindowWidth)[0].InnerText = Current.Resources[Constants.ResourceWindowWidth].ToString();
            xmlReader.GetElementsByTagName(Constants.XmlWindowHeight)[0].InnerText = Current.Resources[Constants.ResourceWindowHeight].ToString();
            xmlReader.Save(Constants.SettingsFile);
        }
    }
}
