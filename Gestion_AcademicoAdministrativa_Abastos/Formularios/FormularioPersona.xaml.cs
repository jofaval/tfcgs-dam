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

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreatePersona(dni, nif, nombre, apellidos, email, telefono));
        }
    }
}
