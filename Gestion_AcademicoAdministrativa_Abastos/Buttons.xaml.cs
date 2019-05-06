using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para Buttons.xaml
    /// </summary>
    public partial class Buttons : Window
    {
        public Buttons()
        {
            InitializeComponent();
            var buttons = StaticButtonViews.LoadFromView(Model.DataStructure.ViewsEnum.ALUMNO);
            var menuPanelChildrens = MenuButtons.Children;
            foreach (var button in buttons)
            {
                menuPanelChildrens.Add(button);
            }
        }
    }
}
