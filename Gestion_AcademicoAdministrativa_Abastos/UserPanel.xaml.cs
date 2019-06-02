using Controller;
using Model;
using Model.ViewModel;
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
                        select new PermisosUsuarioViewModel()
                        {
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            PermisoAdmin = p.PermisoAdmin,
                            PermisoAdministrativo = p.PermisoAdministrativo,
                            PermisProfesor = p.PermisProfesor,
                            PermisoAlumno = p.PermisoAlumno
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
                    if (StaticReferences.Context.PermisosUsuarioDbSet.Any(p => p.Nombre.Equals(nombrePermiso)))
                    {
                        Notification.CreateNotificaion("Ya existe");
                    }
                    permisos.Add(permisoUsuario);
                    context.SaveChanges();
                    Permisos.Add(permisos
                        .Select(p => new PermisosUsuarioViewModel()
                        {
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            PermisoAdmin = p.PermisoAdmin,
                            PermisoAdministrativo = p.PermisoAdministrativo,
                            PermisProfesor = p.PermisProfesor,
                            PermisoAlumno = p.PermisoAlumno
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

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var username = TxtUsername.Text;
            var dni = TxtPersona.Text;

            var persona = StaticReferences.Context.PersonaDbSet
                .SingleOrDefault(p => p.Dni.Equals(dni));

            var selectedPermisoViewModel = (PermisosUsuarioViewModel)ComboBoxPermisos.SelectedValue;

            if (selectedPermisoViewModel is null)
            {
                Notification.CreateNotificaion("Selecciona un grupo de usuarios");
                return;
            }
            var selectedPermiso = StaticReferences.Context.PermisosUsuarioDbSet
                .SingleOrDefault(p => p.Nombre.Equals(selectedPermisoViewModel.Nombre));

            if (persona is null)
            {
                Notification.CreateNotificaion("No se ha encontrado la persona");
                return;
            }

            if (StaticReferences.Context.UsuarioDbSet.Any(u => u.Username.Equals(username)))
            {
                Notification.CreateNotificaion("Ya existe el usuario");
                return;
            }

            if (StaticReferences.Context.UsuarioDbSet
                .AsEnumerable()
                .Any(u => u.Persona1.Equals(persona)))
            {
                Notification.CreateNotificaion("La persona ya tiene un usuario");
                return;
            }

            var password = TxtPassword.Text;
            var cyphredPassword = Cryptography.Encrypt(password, username);

            var usuario = new Usuario()
            {
                Username = username,
                Contrasenya = cyphredPassword,
                Persona = dni,
                Persona1 = persona,
                Nombre = selectedPermiso.Nombre,
                PermisosUsuario = selectedPermiso,
            };

            StaticReferences.Context.UsuarioDbSet.Add(usuario);
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha creado con exito");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var username = TxtUsername.Text;

            var usuario = StaticReferences.Context.UsuarioDbSet
                .SingleOrDefault(u => u.Username.Equals(username));

            if (usuario is null)
            {
                Notification.CreateNotificaion("No se ha encontrado");
                return;
            }

            StaticReferences.Context.UsuarioDbSet.Remove(usuario);
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha borrado con exito");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedPermiso = (PermisosUsuario)DataGridPermisos.SelectedValue;
            StaticReferences.Context.PermisosUsuarioDbSet.Remove(selectedPermiso);
            StaticReferences.Context.SaveChanges();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var username = TxtUsername.Text;
            var usuario = StaticReferences.Context.UsuarioDbSet
                .SingleOrDefault(u => u.Username.Equals(username));
            if (usuario is null)
            {
                Notification.CreateNotificaion("El usuario no existe");
                return;
            }
            else
            {
                var password = TxtPassword.Text;

                var selectedPermisoViewModel = (PermisosUsuarioViewModel)ComboBoxPermisos.SelectedValue;

                if (selectedPermisoViewModel is null)
                {
                    Notification.CreateNotificaion("Selecciona un grupo de usuarios");
                    return;
                }
                var selectedPermiso = StaticReferences.Context.PermisosUsuarioDbSet
                    .SingleOrDefault(p => p.Nombre.Equals(selectedPermisoViewModel.Nombre));


                usuario.Contrasenya = password;
                usuario.Nombre = selectedPermiso.Nombre;
                usuario.PermisosUsuario = selectedPermiso;
            }

            StaticReferences.Context.UsuarioDbSet.Remove(usuario);
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha modificado con exito");
        }

        private void RemovePermiso_Click(object sender, RoutedEventArgs e)
        {
            var permiso = TxtNombre.Text;
            var selectedPermiso = StaticReferences.Context.PermisosUsuarioDbSet
                .SingleOrDefault(p => p.Nombre.Equals(permiso));

            if (selectedPermiso is null)
            {
                Notification.CreateNotificaion("No se ha encontrado");
                return;
            }

            StaticReferences.Context.PermisosUsuarioDbSet.Remove(selectedPermiso);
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha borrado con exito");
        }
    }
}
