using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            App.LoadSettings();
            var fontSize = (double)Application.Current.Resources[Constants.ResourceFontSize];
            var fontFamily = new FontFamily(Application.Current.Resources[Constants.ResourceFontFamily].ToString());
            var windowWidth = (double)Application.Current.Resources[Constants.ResourceWindowWidth];
            var windowHeight = (double)Application.Current.Resources[Constants.ResourceWindowHeight];
            InitializeComponent();
            LoadComboBoxWithFontFamilies();
            SliderFontSize.Value = fontSize;
            Application.Current.Resources[Constants.ResourceFontSize] = fontSize;
            Application.Current.Resources[Constants.ResourceFontFamily] = fontFamily;
            Application.Current.Resources[Constants.ResourceWindowWidth] = windowWidth;
            Application.Current.Resources[Constants.ResourceWindowHeight] = windowHeight;
            var mainWindow = XamlBridge.MainWindowInstance;
            SliderWidthSize.Value = mainWindow.Width;
            SliderHeightSize.Value = mainWindow.Height;
        }

        private void LoadComboBoxWithFontFamilies()
        {
            var fontFamilies = Fonts.SystemFontFamilies;
            var comboBoxFontFamilyitems = ComboBoxFontFamily.Items;
            foreach (FontFamily fontFamily in fontFamilies)
            {
                var fontFamilyName = fontFamily.ToString();

                var item = new ComboBoxItem
                {
                    Content = fontFamilyName,
                    FontFamily = new FontFamily(fontFamilyName)
                };

                comboBoxFontFamilyitems.Add(item);
            }
        }

        private void SliderFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Application.Current.Resources[Constants.ResourceFontSize] = (sender as Slider).Value;
            App.SaveNewSettings();
        }

        private void ComboBoxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox senderAsComboBox)
            {
                var fontFamilyName = ((ComboBoxItem)senderAsComboBox.SelectedItem).Content.ToString();
                Application.Current.Resources[Constants.ResourceFontFamily] = new FontFamily(fontFamilyName);
            }
            App.SaveNewSettings();
        }

        private void ScreenSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderWidthSize != null && SliderHeightSize != null)
            {
                if (sender == SliderWidthSize)
                {
                    SliderHeightSize.Value *= Constants.AspectRatio;
                }
                else
                {
                    SliderWidthSize.Value *= Constants.AspectRatio;
                }
                var mainWindow = XamlBridge.MainWindowInstance;

                var width = SliderWidthSize.Value;
                var height = SliderHeightSize.Value;
                mainWindow.SetSize(width, height);
            }
        }
    }
}
