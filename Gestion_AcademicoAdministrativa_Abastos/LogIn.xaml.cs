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
using System.Threading;

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
            XamlFunctionality.ReadSavedUsernamePassword(this);
        }

        private void UrlLinker_Click(object sender, RoutedEventArgs e)
        {
            var RunningProcessPaths = ProcessFileNameFinderClass.GetAllRunningProcessFilePaths();

            string process = "";

            var workingMsg = " está en funcionamiento,\nenseguida se abrirá.";
            if (RunningProcessPaths.Contains("chrome.exe"))
            {
                //firefox is running
                Notification.CreateNotificaion(string.Concat("chrome", workingMsg));
                process = "chrome.exe";
            }
            else if (RunningProcessPaths.Contains("firefox.exe"))
            {
                //Google Chrome is running
                Notification.CreateNotificaion(string.Concat("firefox", workingMsg));
                process = "firefox.exe";
            }
            else if (RunningProcessPaths.Contains("opera.exe"))
            {
                //Google Chrome is running
                Notification.CreateNotificaion(string.Concat("opera", workingMsg));
                process = "opera.exe";
            }
            System.Diagnostics.Process.Start(process, Constants.UrlHelper);
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameField.Text;
            var password = PasswordeField.Password;

            var user = DataRetriever.GetInstance().GetUser(username, password);
            if (user != null)
            {
                XamlBridge.CurrentUser = user;

                var viewSelector = new ViewSelector()
                {
                    Visibility = Visibility.Visible,
                    LogInInstance = this,
                };
            }
            else
            {
                Notification.CreateNotificaion(Constants.UnsuccesfulLogIn);
            }
        }

        public void FinalizeLogIn()
        {
            var instance = XamlBridge.MainWindowInstance;

            var backUpMainPanel = XamlBridge.BackUpMainPanel;
            XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

            XamlBridge.MainPanelInstance = backUpMainPanel;

            if (CheckSaveInformation.IsChecked.Value)
            {
                XamlFunctionality.WriteSaveUsernamePassword(this);
            }

            instance.AddButtonPanel();
            instance.FillMainData();

            Close();
        }
    }
}
