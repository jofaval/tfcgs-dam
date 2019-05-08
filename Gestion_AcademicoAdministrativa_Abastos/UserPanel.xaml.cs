using Controller;
using Model;
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

        private void CreatePermisoButton_Click(object sender, RoutedEventArgs e)
        {
            var nombrePermiso = TxtNombre.Text;
            var descripcionPermiso = TxtDescripcion.Text;

            var permisoAdministrador = CheckBoxPermisoAdministrador.IsChecked.Value;
            var permisoAdministrativo = CheckBoxPermisoAdministrador.IsChecked.Value;
            var permisoProfesor = CheckBoxPermisoAdministrador.IsChecked.Value;
            var permisoAlumno = CheckBoxPermisoAdministrador.IsChecked.Value;

            if (nombrePermiso.Equals(string.Empty))
            {
                Notification.CreateNotificaion("No puede existir un permiso sin nombre");
            }
            else
            {
                var permisoUsuario = new PermisosUsuario
                {
                    Nombre = nombrePermiso,
                    Descripcion = descripcionPermiso,
                    PermisoAdmin = permisoAdministrador,
                    PermisoAdministrativo = permisoAdministrativo,
                    PermisProfesor = permisoProfesor,
                    PermisoAlumno = permisoAlumno,
                };
                StaticReferences.Context.PermisosUsuarioDbSet.Add(permisoUsuario);
                StaticReferences.Context.SaveChanges();
            }
        }
    }
}
