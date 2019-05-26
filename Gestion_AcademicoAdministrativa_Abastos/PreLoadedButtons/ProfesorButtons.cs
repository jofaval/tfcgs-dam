using Controller;
using Gestion_AcademicoAdministrativa_Abastos.Threads;
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

            var ChangePassButton = new Button()
            {
                Name = "ChangePassButton",
                Content = "Cambiar Contraseña",
                Style = menuButtonStyle
            };
            buttonList.Add(ChangePassButton);
            Grid.SetRow(ChangePassButton, numRow);
            numRow++;

            var FirstButton = new Button()
            {
                Name = "FirstButton",
                Content = "Buscador Personal",
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

            var GuardiaButton = new Button()
            {
                Name = "GuardiaButton",
                Content = "De Guardia",
                Style = menuButtonStyle
            };
            buttonList.Add(GuardiaButton);
            Grid.SetRow(GuardiaButton, numRow);
            numRow++;

            var academicYear = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime);
            if (XamlBridge.CurrentUser.Persona1.Trabajador.Profesor.Tutores.Any(t => t.Anyo.Equals(academicYear)))
            {
                var ActasButton = new Button()
                {
                    Name = "ActasButton",
                    Content = "Actas de Evaluación",
                    Style = menuButtonStyle
                };
                buttonList.Add(ActasButton);
                Grid.SetRow(ActasButton, numRow);
                numRow++;
                ActasButton.Click += (object sender, RoutedEventArgs e) =>
                {
                    var mainPanel = new ActasDeEvaluacion().MainPanel;

                    XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                    XamlBridge.MainPanelInstance = mainPanel;
                };
            }

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
                    XamlBridge.RobotoProfesorGuardia?.Abort();

                    var mainWindowPanel = XamlBridge.MainPanelInstance;
                    if (btnSender == FirstButton)
                    {
                        XamlFunctionality.ChangeWindowContent(mainWindowPanel, new BuscadorV2());
                    }
                    else if (btnSender == ChangePassButton)
                    {
                        var mainPanel = new ChangePassword().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
                    }
                    else if (btnSender == SecondButton)
                    {
                        XamlFunctionality.ChangeWindowContent(mainWindowPanel, new Horario());
                    }
                    else if (btnSender == GuardiaButton)
                    {
                        var backUpMainPanel = new ProfesorGuardia();
                        XamlBridge.ProfesorGuardia = backUpMainPanel;
                        var thread = RobotoProfesorGuardia.CreateThread();
                        XamlBridge.RobotoProfesorGuardia = thread;
                        thread.Start();

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel.MainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel.MainPanel;
                    }
                    else if (btnSender == HomeButton)
                    {
                        var backUpMainPanel = XamlBridge.BackUpMainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
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
