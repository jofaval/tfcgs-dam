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
            XamlFunctionality.QueryInfoOnWebsite();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameField.Text;
            var password = Cryptography.Encrypt(PasswordeField.Password, Constants.EncryptationKey);

            var user = DataRetriever.GetInstance().GetUser(username, password);
            if (user != null)
            {
                XamlBridge.CurrentUser = user;
                var possibleViews = DataRetriever.PosibleViews(user);
                if (possibleViews.Count > 1)
                {
                    var viewSelector = new ViewSelector()
                    {
                        Visibility = Visibility.Visible,
                        LogInInstance = this,
                    };
                    viewSelector.FillViewsComboBox(possibleViews);
                }
                else
                {
                    XamlBridge.ViewEnum = possibleViews.ElementAt(0);
                    FinalizeLogIn();
                }
                

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
