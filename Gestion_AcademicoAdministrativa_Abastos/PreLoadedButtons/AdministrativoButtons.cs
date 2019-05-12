using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos.PreLoadedButtons
{
    public class AdministrativoButtons
    {
        static public List<Button> CreateAdministrativoView()
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

            var FormPersona = new Button()
            {
                Name = "FormPersona",
                Content = "Formularios Persona",
                Style = menuButtonStyle
            };
            buttonList.Add(FormPersona);
            Grid.SetRow(FormPersona, numRow);
            numRow++;

            var FromCurso = new Button()
            {
                Name = "FromCurso",
                Content = "Formularios Curso",
                Style = menuButtonStyle
            };
            buttonList.Add(FromCurso);
            Grid.SetRow(FromCurso, numRow);
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

            void AdministrativoView_Click(object sender, RoutedEventArgs e)
            {
                if (sender is Button btnSender)
                {
                    if (btnSender == HomeButton)
                    {
                        var backUpMainPanel = XamlBridge.BackUpMainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);
                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == FormPersona)
                    {
                        var backUpMainPanel = new FormularioPersona().MainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);
                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == FromCurso)
                    {
                        //var backUpMainPanel = new FormularioCurso().MainPanel;
                        //XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        //XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == LogOutButton)
                    {
                        StaticButtonViews.LogOutFromMainWindow();
                    }
                }
            };

            foreach (var button in buttonList)
            {
                button.Click += new RoutedEventHandler(AdministrativoView_Click);
            }

            return buttonList;
        }
    }
}
