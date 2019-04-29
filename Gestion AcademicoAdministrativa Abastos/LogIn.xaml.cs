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
using System.Net.Http;
using Controller;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
            //ControladorWPF.MaximizeNormalize(this, new Grid());
        }

        private void UrlLinker_Click(object sender, RoutedEventArgs e)
        {
            var RunningProcessPaths = ProcessFileNameFinderClass.GetAllRunningProcessFilePaths();

            string process = "";

            if (RunningProcessPaths.Contains("chrome.exe"))
            {
                //firefox is running
                Console.WriteLine("chrome is running");
                process = "chrome.exe";
            } else if (RunningProcessPaths.Contains("firefox.exe"))
            {
                //Google Chrome is running
                Console.WriteLine("firefox is running");
                process = "firefox.exe";
            }
            System.Diagnostics.Process.Start(process, "http://www.google.com");
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            /*if (UsernameField.Text == "usuario")
            {
                if (PasswordeField.Text == "1234")
                {
                    /*var mainWindow = new MainWindow()
                    {
                        Visibility = Visibility.Visible
                    };
                    new MainWindow().MainGridContent
                }
            }*/
            var username = UsernameField.Text;
            var password = PasswordeField.Password;
            //if (DataIntegrityChecker.CheckUsernamePassword(username, PasswordeField.Password))
            //{
            var user = DataRetriever.GetInstance().GetUser(username, password);
            if (user != null)
            {
                XamlBridge.CurrentUser = user;
                //var bgGrid = XamlBridge.BackgroundGrid;
                //bgGrid.Children.Remove(XamlBridge.BackUpLoginGridContent);
                //bgGrid.Children.Add(XamlBridge.MainPanelInstance);
                var instance = XamlBridge.MainWinowInstance;
                XamlFunctionality.ChangeWindowContent(XamlBridge.MainPanelInstance, new MainWindow());
                instance.AddButtonPanel();
                this.Close();
            }
            //}
        }
    }
}
