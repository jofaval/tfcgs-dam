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
                    return AdministrativoButtons.CreateAdministrativoView();
                case ViewsEnum.ADMINISTRADOR:
                    return AdministradorButtons.CreateAdministradorView();
                default:
                    return null;
            }
        }

        static public void LogOutFromMainWindow()
        {
            var mainWindowInstance = XamlBridge.MainWindowInstance;

            XamlBridge.BackgroundGrid = mainWindowInstance.BackgroundGrid;

            XamlFunctionality.ChangeWindowContent(XamlBridge.MainPanelInstance, new LogIn());

            mainWindowInstance.RemoveButtonsFromButtonPanel();
        }
    }
}
