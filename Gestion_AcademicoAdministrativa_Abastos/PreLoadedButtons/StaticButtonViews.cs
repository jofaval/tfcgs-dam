using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos.PreLoadedButtons
{
    public class StaticButtonViews
    {
        delegate void Menu_Click(object sender, RoutedEventArgs e);

        static public List<Button> LoadFromView(ViewsEnum viewEnum)
        {
            switch (viewEnum)
            {
                case ViewsEnum.ALUMNO:
                    return AlumnoButtons.CreateAlumnoView();
                case ViewsEnum.PROFESOR:
                    return ProfesorButtons.CreateProfesorView();
                case ViewsEnum.ADMINISTRATIVO:
                    return CreateAdministrativoView();
                case ViewsEnum.ADMINISTRADOR:
                    return CreateAdministradorView();
                default:
                    return null;
            }
        }

        static public List<Button> CreateAdministrativoView()
        {
            var buttonList = new List<Button>();
            return buttonList;
        }

        static public List<Button> CreateAdministradorView()
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

            var SQLEditor = new Button()
            {
                Name = "SQLEditor",
                Content = "Editor de T-SQL",
                Style = menuButtonStyle
            };
            buttonList.Add(SQLEditor);
            Grid.SetRow(SQLEditor, numRow);
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
                    if (btnSender == HomeButton)
                    {
                        var backUpMainPanel = XamlBridge.BackUpMainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == SQLEditor)
                    {
                        var sqlEditorMainPanel = new SQLEditor().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, sqlEditorMainPanel);

                        XamlBridge.MainPanelInstance = sqlEditorMainPanel;
                    }
                    else if (btnSender == LogOutButton)
                    {
                        LogOutFromMainWindow();
                    }
                }
            };

            foreach (var button in buttonList)
            {
                button.Click += new RoutedEventHandler(AlumnoView_Click);
            }

            return buttonList;
        }

        static public void LogOutFromMainWindow()
        {
            var mainWindowInstance = XamlBridge.MainWindowInstance;

            XamlBridge.BackgroundGrid = mainWindowInstance.BackgroundGrid;
            var mainPanel = mainWindowInstance.MainPanel;
            XamlBridge.MainPanelInstance = mainPanel;
            XamlBridge.BackUpMainPanel = mainPanel;

            XamlFunctionality.ChangeWindowContent(mainPanel, new LogIn());

            mainWindowInstance.RemoveButtonsFromButtonPanel();
        }
    }
}
