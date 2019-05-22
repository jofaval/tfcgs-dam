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
                case ViewsEnum.Alumno:
                    return AlumnoButtons.CreateAlumnoView();
                case ViewsEnum.Profesor:
                    return ProfesorButtons.CreateProfesorView();
                case ViewsEnum.Administrativo:
                    return AdministrativoButtons.CreateAdministrativoView();
                case ViewsEnum.Administrador:
                    return AdministradorButtons.CreateAdministradorView();
                default:
                    return null;
            }
        }

        static public void LogOutFromMainWindow()
        {
            var mainWindowInstance = XamlBridge.MainWindowInstance;

            XamlBridge.BackgroundGrid = mainWindowInstance.BackgroundGrid;
            XamlBridge.CurrentUser = null;

            XamlFunctionality.ChangeWindowContent(XamlBridge.MainPanelInstance, new LogIn());

            mainWindowInstance.RemoveButtonsFromButtonPanel();
        }
    }
}
