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
using Controller;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para ormularioPersona.xaml
    /// </summary>
    public partial class FormularioPersona : Window
    {
        public FormularioPersona()
        {
            InitializeComponent();
            var buscadorPersona = new BuscadorV2();
            XamlFunctionality.ReplaceGrids(ModifyTab, buscadorPersona.ContentPanel);
            buscadorPersona.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var dni = TxtDNI.Text;
            var nif = TxtNIF.Text;
            var nombre = TxtNombre.Text;
            var apellidos = TxtApellidos.Text;
            var email = TxtEmail.Text;
            var telefono = TxtTelefono.Text;

            if (string.IsNullOrWhiteSpace(dni))
            {
                Notification.CreateNotificaion("El campo DNI es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(nif))
            {
                Notification.CreateNotificaion("El campo NIF es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(nombre))
            {
                Notification.CreateNotificaion("El campo Nombre es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(apellidos))
            {
                Notification.CreateNotificaion("El campo Apellidos es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                Notification.CreateNotificaion("El campo Email es obligatorio");
                return;
            }

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreatePersona(dni, nif, nombre, apellidos, email, telefono));
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Notification.CreateNotificaion(ComponentRemover.GetInstance().RemovePersona(TxtDNIRemove.Text));
        }
    }
}
