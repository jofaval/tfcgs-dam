using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos.PreLoadedButtons
{
    public class ProfesorButtons
    {
        static public List<Button> CreateProfesorView()
        {
            var buttonList = new List<Button>();

            var menuButtonStyle = (Style)Application.Current.Resources["MenuButton"];
            var numRow = 0;

            var HomeButton = new Button()
            {
                Name = "HomeButton",
                Content = "Home",
                Style = menuButtonStyle
            };
            buttonList.Add(HomeButton);
            Grid.SetRow(HomeButton, numRow);
            numRow++;

            var FirstButton = new Button()
            {
                Name = "FirstButton",
                Content = "Buscador Profesorado",
                Style = menuButtonStyle
            };
            buttonList.Add(FirstButton);
            Grid.SetRow(FirstButton, numRow);
            numRow++;

            var SecondButton = new Button()
            {
                Name = "SecondButton",
                Content = "Horario",
                Style = menuButtonStyle
            };
            buttonList.Add(SecondButton);
            Grid.SetRow(SecondButton, numRow);
            numRow++;

            var ThirdButton = new Button()
            {
                Name = "ThirdButton",
                Content = "Editar Informacion",
                Style = menuButtonStyle
            };
            buttonList.Add(ThirdButton);
            Grid.SetRow(ThirdButton, numRow);
            numRow++;

            var ActasButton = new Button()
            {
                Name = "ActasButton",
                Content = "Actas de Evaluación",
                Style = menuButtonStyle
            };
            buttonList.Add(ActasButton);
            Grid.SetRow(ActasButton, numRow);
            numRow++;

            var LogOutButton = new Button()
            {
                Name = "LogOutButton",
                Content = "Salir",
                Style = menuButtonStyle
            };
            buttonList.Add(LogOutButton);
            Grid.SetRow(LogOutButton, numRow);
            numRow++;

            void ProfesorView_Click(object sender, RoutedEventArgs e)
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
                    else if (btnSender == HomeButton)
                    {
                        var backUpMainPanel = XamlBridge.BackUpMainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == ActasButton)
                    {
                        var backUpMainPanel = new ActasDeEvaluacion()
                        {
                            Visibility = Visibility.Visible,
                        };
                    }
                    else if (btnSender == LogOutButton)
                    {
                        //XamlBridge.CloseEverything();

                        //Application.Current.Shutdown();
                        StaticButtonViews.LogOutFromMainWindow();
                    }
                }
            };

            foreach (var button in buttonList)
            {
                button.Click += new RoutedEventHandler(ProfesorView_Click);
            }

            return buttonList;
        }
    }
}
