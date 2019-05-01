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
            InitializeComponent();

            var fontFamilies = Fonts.SystemFontFamilies;
            var comboBoxFontFamilyitems = ComboBoxFontFamily.Items;
            foreach (FontFamily fontFamily in fontFamilies)
            {
                comboBoxFontFamilyitems.Add(fontFamily);
            }
            UpdateConfiguration();
        }

        public void UpdateConfiguration()
        {
            var myStyle = (Style)Application.Current.Resources["SpecialTextControl"];
            var setters = myStyle.Setters;
            //setters.Add(new Setter(FontSizeProperty, 50));
            Application.Current.Resources["SpecialTextControl"] = myStyle;
            Application.Current.Resources["StandardFontSize"] = 40.0;
        }
    }
}
