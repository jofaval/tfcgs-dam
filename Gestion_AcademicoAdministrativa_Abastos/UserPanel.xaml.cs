using Controller;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel()
        {
            InitializeComponent();
            var permisos = StaticReferences.Context.PermisosUsuarioDbSet.ToList();
            DataGridPermisos.ItemsSource = from p in permisos
                                           select new
                                           {
                                               p.Nombre,
                                               p.Descripcion,
                                               EsAdmin = p.PermisoAdmin,
                                               EsAdministrativo = p.PermisoAdministrativo,
                                               EsProfesor = p.PermisProfesor,
                                               EsAlumno = p.PermisoAlumno
                                           };
        }
    }
}
