using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model.DataStructure;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para ViewSelector.xaml
    /// </summary>
    public partial class ViewSelector : Window
    {
        public LogIn LogInInstance { get; set; }

        public ViewSelector()
        {
            InitializeComponent();

            //var viewEnum = (ViewsEnum[])Enum.GetValues(typeof(ViewsEnum));
            //foreach (var view in viewList)
            //{
            //    var comboBoxItem = new ComboBoxItem()
            //    {
            //        Content = view
            //    };

            //    items.Add(comboBoxItem);
            //}

            var screenHeight = SystemParameters.FullPrimaryScreenHeight;
            var screenWidth = SystemParameters.FullPrimaryScreenWidth;

            var newWidth = screenWidth * .20;
            Width = newWidth;
            MaxWidth = newWidth;
            var newHeight = screenHeight * .10;
            Height = newHeight;
            MaxHeight = Height;
        }

        public void FillViewsComboBox(List<ViewsEnum> possibleViews)
        {
            var items = ComboBoxViewSelector.Items;
            foreach (var view in possibleViews)
            {
                var comboBoxItem = new ComboBoxItem()
                {
                    Content = view
                };

                items.Add(comboBoxItem);
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ComboBoxViewSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox senderAsComboBox)
            {
                var content = (ViewsEnum)((ComboBoxItem)senderAsComboBox.SelectedItem).Content;
                XamlBridge.ViewEnum = content;
                LogInInstance.FinalizeLogIn();
                Close();
            }
        }
    }
}
