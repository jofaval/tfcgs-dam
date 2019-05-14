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

            var FormCurso = new Button()
            {
                Name = "FormCurso",
                Content = "Formularios Curso",
                Style = menuButtonStyle
            };
            buttonList.Add(FormCurso);
            Grid.SetRow(FormCurso, numRow);
            numRow++;

            var FormAsignatura = new Button()
            {
                Name = "FormAsignatura",
                Content = "Formularios Asignatura",
                Style = menuButtonStyle
            };
            buttonList.Add(FormAsignatura);
            Grid.SetRow(FormAsignatura, numRow);
            numRow++;

            var FormAula = new Button()
            {
                Name = "FormAula",
                Content = "Formularios Aula",
                Style = menuButtonStyle
            };
            buttonList.Add(FormAula);
            Grid.SetRow(FormAula, numRow);
            numRow++;

            var FormDepartamento = new Button()
            {
                Name = "FormDepartamento",
                Content = "Formularios Departamento",
                Style = menuButtonStyle
            };
            buttonList.Add(FormDepartamento);
            Grid.SetRow(FormDepartamento, numRow);
            numRow++;

            var FormTrabajador = new Button()
            {
                Name = "FormTrabajador",
                Content = "Formularios Trabajador",
                Style = menuButtonStyle
            };
            buttonList.Add(FormTrabajador);
            Grid.SetRow(FormTrabajador, numRow);
            numRow++;

            var FormHorario = new Button()
            {
                Name = "FormHorario",
                Content = "Formularios Horario",
                Style = menuButtonStyle
            };
            buttonList.Add(FormHorario);
            Grid.SetRow(FormHorario, numRow);
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
                    else if (btnSender == FormCurso)
                    {
                        var backUpMainPanel = new FormularioCurso().MainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == FormAsignatura)
                    {
                        var backUpMainPanel = new FormularioAsignatura().MainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == FormAula)
                    {
                        var backUpMainPanel = new FormularioAula().MainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == FormDepartamento)
                    {
                        var backUpMainPanel = new FormularioDepartamento().MainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == FormTrabajador)
                    {
                        var backUpMainPanel = new FormularioTrabajador().MainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == FormHorario)
                    {
                        var backUpMainPanel = new FormularioHorario().MainPanel;
                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
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
