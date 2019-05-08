using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos.PreLoadedButtons
{
    public class AdministradorButtons
    {
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

            var SQLEditorButton = new Button()
            {
                Name = "SQLEditor",
                Content = "Editor de T-SQL",
                Style = menuButtonStyle
            };
            buttonList.Add(SQLEditorButton);
            Grid.SetRow(SQLEditorButton, numRow);
            numRow++;

            var UserPanelButton = new Button()
            {
                Name = "UserPanel",
                Content = "Editor de T-SQL",
                Style = menuButtonStyle
            };
            buttonList.Add(UserPanelButton);
            Grid.SetRow(UserPanelButton, numRow);
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

            void AlumnoView_Click(object sender, RoutedEventArgs e)
            {
                if (sender is Button btnSender)
                {
                    if (btnSender == HomeButton)
                    {
                        var backUpMainPanel = XamlBridge.BackUpMainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == SQLEditorButton)
                    {
                        var sqlEditorMainPanel = new SQLEditor().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, sqlEditorMainPanel);

                        XamlBridge.MainPanelInstance = sqlEditorMainPanel;
                    }
                    else if (btnSender == UserPanelButton)
                    {
                        var sqlEditorMainPanel = new UserPanel().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, sqlEditorMainPanel);

                        XamlBridge.MainPanelInstance = sqlEditorMainPanel;
                    }
                    else if (btnSender == LogOutButton)
                    {
                        StaticButtonViews.LogOutFromMainWindow();
                    }
                }
            };

            foreach (var button in buttonList)
            {
                button.Click += new RoutedEventHandler(AlumnoView_Click);
            }

            return buttonList;
        }
    }
}
