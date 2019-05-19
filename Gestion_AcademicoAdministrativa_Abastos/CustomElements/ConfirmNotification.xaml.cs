using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gestion_AcademicoAdministrativa_Abastos.CustomElements
{
    /// <summary>
    /// Lógica de interacción para ConfirmNotification.xaml
    /// </summary>
    public partial class ConfirmNotification : Window
    {
        public bool OKClicked { get; set; }

        public string NotificationTitle { get; set; }

        public const int MARGIN = 25;

        public ConfirmNotification()
        {
            DataContext = this;

            var screenHeight = SystemParameters.FullPrimaryScreenHeight;
            var screenWidth = SystemParameters.FullPrimaryScreenWidth;

            var newWidth = screenWidth * .5;
            Width = newWidth;
            MaxWidth = newWidth;
            var newHeight = screenHeight * .5;
            Height = newHeight;
            MaxHeight = Height;

            Top = screenHeight - Height;
            Left = screenWidth - Width;
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

        public static ConfirmNotification CreateNotificaion(string title = "Confirmas la acción")
        {
            if (XamlFunctionality.IsWindowOpen<ConfirmNotification>())
            {
                XamlFunctionality.CloseWindowInstancesOf<ConfirmNotification>();
            }
            var notification = new ConfirmNotification()
            {
                NotificationTitle = title,
                Visibility = Visibility.Visible,
            };

            notification.InitializeComponent();
            return notification;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            CloseWindow();
        }

        private void CloseWindow()
        {
            var anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(0.25 * 1000));
            anim.Completed += (s, _) => Close();
            BeginAnimation(OpacityProperty, anim);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Window_Loaded;
            Opacity = 0;
            var anim = new DoubleAnimation(1, TimeSpan.FromMilliseconds(0.25 * 1000));
            BeginAnimation(OpacityProperty, anim);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DoWhenFinished();
        }

        private void DoWhenFinished()
        {
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
