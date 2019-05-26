using Controller;
using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para Horario.xaml
    /// </summary>
    public partial class Horario : Window
    {
        public Horario()
        {
            InitializeComponent();
            var currentUser = XamlBridge.CurrentUser;
            var selectedView = XamlBridge.ViewEnum;
            IEnumerable<object> collection;
            switch (selectedView)
            {
                case ViewsEnum.Alumno:
                    collection = AlumnoFunctionality.GetHorarios(currentUser);
                    break;
                case ViewsEnum.Profesor:
                    collection = ProfesorFunctionality.GetHorarios(currentUser.Persona1.Trabajador.Profesor);
                    break;
                case ViewsEnum.Administrativo:
                case ViewsEnum.Administrador:
                default:
                    collection = null;
                    break;
            }
            XamlFunctionality.FillDataGrid(DataGridResult, collection);
        }
    }
}
