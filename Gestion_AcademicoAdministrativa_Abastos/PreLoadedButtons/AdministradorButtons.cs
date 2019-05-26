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

            var ChangePassButton = new Button()
            {
                Name = "ChangePassButton",
                Content = "Cambiar Contraseña",
                Style = menuButtonStyle
            };
            buttonList.Add(ChangePassButton);
            Grid.SetRow(ChangePassButton, numRow);
            numRow++;

            var BuscadorPersonaButton = new Button()
            {
                Name = "BuscadorV2",
                Content = "Buscador de Personas",
                Style = menuButtonStyle
            };
            buttonList.Add(BuscadorPersonaButton);
            Grid.SetRow(BuscadorPersonaButton, numRow);
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
                Content = "Panel de Usuarios",
                Style = menuButtonStyle
            };
            buttonList.Add(UserPanelButton);
            Grid.SetRow(UserPanelButton, numRow);
            numRow++;

            var EntitiesSearch = new Button()
            {
                Name = "EntitiesSearch",
                Content = "Buscador de Entidades",
                Style = menuButtonStyle
            };
            buttonList.Add(EntitiesSearch);
            Grid.SetRow(EntitiesSearch, numRow);
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
                    else if (btnSender == ChangePassButton)
                    {
                        var mainPanel = new ChangePassword().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
                    }
                    else if (btnSender == SQLEditorButton)
                    {
                        var mainPanel = new SQLEditor().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
                    }
                    else if (btnSender == UserPanelButton)
                    {
                        var mainPanel = new UserPanel().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
                    }
                    else if (btnSender == BuscadorPersonaButton)
                    {
                        var mainPanel = new BuscadorV2().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
                    }
                    else if (btnSender == EntitiesSearch)
                    {
                        var mainPanel = new BuscadorAllEntities().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
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
