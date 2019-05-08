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
        public List<dynamic> Permisos { get; set; }
        public UserPanel()
        {
            Permisos = new List<dynamic>();
            InitializeComponent();
            var permisos = StaticReferences.Context.PermisosUsuarioDbSet.ToList();
            DataGridPermisos.ItemsSource = Permisos;
            ComboBoxPermisos.ItemsSource = Permisos;
            var saved = from p in permisos
                        select new
                        {
                            p.Nombre,
                            p.Descripcion,
                            EsAdmin = p.PermisoAdmin,
                            EsAdministrativo = p.PermisoAdministrativo,
                            EsProfesor = p.PermisProfesor,
                            EsAlumno = p.PermisoAlumno
                        };
            foreach (var savedItem in saved)
            {
                Permisos.Add(savedItem);
            }
        }

        private void CreatePermisoButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    return;
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
                    var context = StaticReferences.Context;
                    var permisos = context.PermisosUsuarioDbSet;
                    permisos.Add(permisoUsuario);
                    context.SaveChanges();
                    Permisos.Add(permisos
                        .Select(p => new
                        {
                            p.Nombre,
                            p.Descripcion,
                            EsAdmin = p.PermisoAdmin,
                            EsAdministrativo = p.PermisoAdministrativo,
                            EsProfesor = p.PermisProfesor,
                            EsAlumno = p.PermisoAlumno
                        })
                        .Single(n => n.Nombre.Equals(nombrePermiso)));
                }
                Notification.CreateNotificaion($"El permiso de nombre {nombrePermiso} se ha creado con éxito");
                TxtNombre.Text = string.Empty;
                TxtDescripcion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Notification.CreateNotificaion(ex.Message);
            }
        }
    }
}
