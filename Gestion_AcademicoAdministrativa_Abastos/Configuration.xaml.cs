using Controller;
using Model.DataStructure;
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
            SliderWindowSize.Value = (byte)XamlBridge.SizeEnum;

            var screenWidth = SystemParameters.FullPrimaryScreenWidth;
            var screenHeight = SystemParameters.FullPrimaryScreenHeight;

            Width = screenWidth / 4;
            Height = screenHeight / 2;

            Resources[Constants.ResourceBackgroundColorfulGradientStart] = Application.Current.Resources[Constants.ResourceBackgroundColorfulGradientStart];
            Resources[Constants.ResourceBackgroundColorfulGradientEnd] = Application.Current.Resources[Constants.ResourceBackgroundColorfulGradientEnd];

            BackGroundFondoFirst.SelectedColor = (Color)Application.Current.Resources[Constants.ResourceBackgroundColorfulGradientStart];
            BackGroundFondoSecond.SelectedColor = (Color)Application.Current.Resources[Constants.ResourceBackgroundColorfulGradientEnd];
        }

        private void LoadComboBoxWithFontFamilies()
        {
            var fontFamilies = Fonts.SystemFontFamilies;
            var comboBoxFontFamilyitems = ComboBoxFontFamily.Items;
            var selectedFontFamilySource = ((FontFamily)Application.Current.Resources[Constants.ResourceFontFamily]).Source;
            foreach (FontFamily fontFamily in fontFamilies)
            {
                var fontFamilyName = fontFamily.Source;

                var item = new ComboBoxItem
                {
                    Content = fontFamilyName,
                    FontFamily = fontFamily
                };

                comboBoxFontFamilyitems.Add(item);

                if (selectedFontFamilySource.Equals(fontFamilyName))
                {
                    ComboBoxFontFamily.SelectedItem = item;
                }
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
            var mainWindow = XamlBridge.MainWindowInstance;
            var value = SliderWindowSize.Value;
            XamlBridge.SizeEnum = (WindowSizeEnum)value;
            var size = WindowSizeConversor.FromWindowSizeEnumToWindowSizeArray((WindowSizeEnum)value);
            mainWindow.SetSize(size);
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            XamlBridge.MainWindowInstance.MaximizeMinimize();
        }

        private void Window_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BackGroundFondoFirst_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var selectedColor = BackGroundFondoFirst.SelectedColor.Value;
            this.Resources[Constants.ResourceBackgroundColorfulGradientStart] = selectedColor;

            ChangeBackgroundColorfulGradient();
        }

        private void BackGroundFondoSecond_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var selectedColor = BackGroundFondoSecond.SelectedColor.Value;
            this.Resources[Constants.ResourceBackgroundColorfulGradientEnd] = selectedColor;

            ChangeBackgroundColorfulGradient();
        }

        public void ChangeBackgroundColorfulGradient()
        {
            Application.Current.Resources[Constants.ResourceBackgroundColorfulGradient] = new LinearGradientBrush(
               (Resources[Constants.ResourceBackgroundColorfulGradientEnd] as Color?).Value,
               (Resources[Constants.ResourceBackgroundColorfulGradientStart] as Color?).Value,
               new Point(0.5, 1),
               new Point(0.5, 0)
            );
            App.SaveNewSettings();
        }

        //private void MainColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        //{
        //    var selectedColor = MainColor.SelectedColor.Value;
        //    Resources["MainColor"] = selectedColor;
        //    Application.Current.Resources["MainColor"] = selectedColor;
        //    Resources["MainColorSolid"] = new SolidColorBrush(selectedColor);
        //    Application.Current.Resources["MainColorSolid"] = new SolidColorBrush(selectedColor);
        //}

        //private void StandOutColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        //{
        //    var selectedColor = StandOutColor.SelectedColor.Value;
        //    Resources["StandOutColor"] = selectedColor;
        //    Application.Current.Resources["StandOutColor"] = selectedColor;
        //    Resources["StandOutColorSolid"] = new SolidColorBrush(selectedColor);
        //    Application.Current.Resources["StandOutColorSolid"] = new SolidColorBrush(selectedColor);
        //}
    }
}
