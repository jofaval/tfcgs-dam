using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    public class StaticButtonViews
    {
        delegate void Menu_Click(object sender, RoutedEventArgs e);

        static public List<Button> LoadFromView(ViewsEnum viewEnum)
        {
            switch (viewEnum)
            {
                case ViewsEnum.ALUMNO:
                    return CreateAlumnoView();
                case ViewsEnum.PROFESOR:
                    return CreateProfesorView();
                case ViewsEnum.ADMINISTRATIVO:
                    return CreateAdministrativoView();
                case ViewsEnum.ADMINISTRADOR:
                    return CreateAdministradorView();
                default:
                    return null;
            }
        }

        static public List<Button> CreateAlumnoView()
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

            var ForthButton = new Button()
            {
                Name = "ForthButton",
                Content = "Reclamaciones",
                Style = menuButtonStyle
            };
            buttonList.Add(ForthButton);
            Grid.SetRow(ForthButton, numRow);
            numRow++;

            var FifthButton = new Button()
            {
                Name = "FifthButton",
                Content = "Solicitudes",
                Style = menuButtonStyle
            };
            buttonList.Add(FifthButton);
            Grid.SetRow(FifthButton, numRow);
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

            Menu_Click AlumnoView_Click = delegate (object sender, RoutedEventArgs e)
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
            };

            foreach (var button in buttonList)
            {
                button.Click += new RoutedEventHandler(AlumnoView_Click);
            }

            return buttonList;
        }

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

            var LogOutButton = new Button()
            {
                Name = "LogOutButton",
                Content = "Salir",
                Style = menuButtonStyle
            };
            buttonList.Add(LogOutButton);
            Grid.SetRow(LogOutButton, numRow);
            numRow++;

            Menu_Click AlumnoView_Click = delegate (object sender, RoutedEventArgs e)
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
                    else if (btnSender == LogOutButton)
                    {
                        XamlBridge.CloseEverything();

                        //Application.Current.Shutdown();
                        System.Windows.Forms.Application.Restart();
                    }
                }
            };

            foreach (var button in buttonList)
            {
                button.Click += new RoutedEventHandler(AlumnoView_Click);
            }

            return buttonList;
        }

        static public List<Button> CreateAdministrativoView()
        {
            var buttonList = new List<Button>();
            return buttonList;
        }

        static public List<Button> CreateAdministradorView()
        {
            var buttonList = new List<Button>();
            return buttonList;
        }
    }
}
