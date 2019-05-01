﻿using System.Windows;
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

        private void MenuButtons_Click(object sender, RoutedEventArgs e)
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
                    MessageBox.Show("No implementado.");
                }
                else if (btnSender == ForthButton)
                {
                    XamlFunctionality.ChangeWindowContent(mainWindowPanel, new Reclamaciones());
                }
                else if (btnSender == FifthButton)
                {
                    MessageBox.Show("No implementado.");
                }
                else if (btnSender == HomeButton)
                {
                    XamlFunctionality.ChangeWindowContent(mainWindowPanel, new MainWindow());
                }
                else if (btnSender == LogOutButton)
                {
                    XamlBridge.CloseEverything();
                }
            }
        }
    }
}
