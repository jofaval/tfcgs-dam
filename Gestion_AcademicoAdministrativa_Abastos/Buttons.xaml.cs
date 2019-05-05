using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para Buttons.xaml
    /// </summary>
    public partial class Buttons : Window
    {
        public Buttons()
        {
            InitializeComponent();
        }

        private void MenuButtons_Click(object sender, RoutedEventArgs eventArgs)
        {
            if (sender is Button btnSender)
            {
                var mainWindowPanel = XamlBridge.MainPanelInstance;
                if (btnSender == FirstButton)
                {
                    XamlFunctionality.ChangeWindowContent(mainWindowPanel, new Buscador());
                }
                else if (btnSender == SecondButton)
                {
                    XamlFunctionality.ChangeWindowContent(mainWindowPanel, new Horario());
                }
                else if (btnSender == ThirdButton)
                {
                    XamlBridge.MainWindowInstance.MakeDataEditable();
                }
                else if (btnSender == ForthButton)
                {
                    XamlFunctionality.ChangeWindowContent(mainWindowPanel, new Reclamaciones());
                }
                else if (btnSender == FifthButton)
                {
                    Notification.CreateNotificaion("No implementado.");
                }
                else if (btnSender == HomeButton)
                {
                    var backUpMainPanel = XamlBridge.BackUpMainPanel;

                    XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                    XamlBridge.MainPanelInstance = backUpMainPanel;
                }
                else if (btnSender == LogOutButton)
                {
                    XamlBridge.CloseEverything();

                    //Application.Current.Shutdown();
                    System.Windows.Forms.Application.Restart();
                }
            }
        }
    }
}
