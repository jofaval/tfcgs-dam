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
using System.Windows.Threading;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public long DissappearAfter { get; set; }

        public string NotificationTitle { get; set; }
        public string NotificationContent { get; set; }

        public const int MARGIN = 25;

        public Notification()
        {
            DataContext = this;

            NotificationTitle = "Test";
            NotificationContent = "Increible, pues si que es";

            var screenHeight = SystemParameters.FullPrimaryScreenHeight;
            var screenWidth = SystemParameters.FullPrimaryScreenWidth;

            var newWidth = screenWidth * .20;
            Width = newWidth;
            MaxWidth = newWidth;
            var newHeight = screenHeight * .20;
            Height = newHeight;
            MaxHeight = Height;

            Top = screenHeight - Height;
            Left = screenWidth - Width;
        }

        private void StartTimer()
        {
            var timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, (int)DissappearAfter)
            };
            timer.Start();

            timer.Tick += (sender, args) =>
            {
                Close();
            };
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

        public static void CreateNotificaion(string msg, string title = "Notification", long dissappearAfter = 2000)
        {
            var notification = new Notification()
            {
                NotificationTitle = title,
                NotificationContent = msg,
                DissappearAfter = dissappearAfter,
                Visibility = Visibility.Visible,
        };
            notification.StartTimer();

            notification.InitializeComponent();
            Console.WriteLine(notification.NotificationContent);
        }
    }
}
