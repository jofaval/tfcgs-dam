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

namespace Posibles_Interfaces_de_Usuario
{
    /// <summary>
    /// Lógica de interacción para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        static float totalTime = 1 * 1000;
        static float veces = 100;
        static float ratio = veces / totalTime;
        static float stopTime = totalTime / veces;
        static MainWindow mainWindow = new MainWindow();

        public float ProgressValue { get; set; }

        public SplashScreen()
        {
            ProgressValue = 0;
            InitializeComponent();
            this.WindowState = WindowState.Maximized;

            myTimer.Tick += new EventHandler(MyTimer_Tick);

            // Sets the timer interval to 5 seconds.
            var newRatio = (int)ratio;
            if (newRatio > 0)
            {
                myTimer.Interval = newRatio;
            }
            else
            {
                ratio *= 10;
                myTimer.Interval = 1;
            }
            myTimer.Start();
        }

        private void MyTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            /*var totalTime = 1 * 1000;
            var veces = 100;
            var stopTime = totalTime / veces;
            var ratio = totalTime / veces;

            float value = 0;
            for (int valueIterator = 0; valueIterator < veces; valueIterator++)
            {
                LoadingProgress.Value = value;
                value += ratio;
                Thread.Sleep((int)stopTime);
            }
            LoadingProgress.Value = 100;*/
            //LoadingProgress.Value += ratio;
            ProgressValue += ratio;
            LoadingProgress.Value = ProgressValue;
            //Console.WriteLine(LoadingProgress.Value);

            if (LoadingProgress.Value >= 100)
            {
                mainWindow.Visibility = Visibility.Visible;
                this.Close();
                myTimer.Stop();
            }
        }
    }
}
