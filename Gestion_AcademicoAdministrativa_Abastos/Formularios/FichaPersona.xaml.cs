using Controller;
using Gestion_AcademicoAdministrativa_Abastos.CustomElements;
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

namespace Gestion_AcademicoAdministrativa_Abastos.Formularios
{
    /// <summary>
    /// Lógica de interacción para FichaPersona.xaml
    /// </summary>
    public partial class FichaPersona : Window
    {
        public Model.Persona SelectedPersona { get; set; }

        public FichaPersona()
        {
            DataContext = this;
            InitializeComponent();
        }

        public void FillWithData(Model.Persona persona)
        {
            if (persona != null)
            {
                SelectedPersona = persona;
                SelectedPersonaLabel.Content = persona.ToString();
                TxtDNI.Text = persona.Dni;
                TxtNIF.Text = persona.Nif;
                TxtNombre.Text = persona.Nombre;
                TxtApellidos.Text = persona.Apellidos;
                TxtEmail.Text = persona.Email;
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var persona = DataRetriever.GetInstance().GetPersona(TxtDniSearch.Text);
            if (persona is null)
            {
                Notification.CreateNotificaion(Constants.NoResults);
            }
            else
            {
                FillWithData(persona);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var notification = ConfirmNotification.CreateNotificaion();
            DynamicMojo.SwapMethodBodies(
                typeof(ConfirmNotification).GetMethod(nameof(notification.DoWhenFinished)),
                typeof(FichaPersona).GetMethod(nameof(ModifyContent))
            );
        }

        public void ModifyContent()
        {
            Notification.CreateNotificaion("Funciona");
            if (SelectedPersona != null)
            {
                XamlBridge.FichaPersona.TxtNombre.Text = XamlBridge.FichaPersona.TxtNombre.Text + "Funciona";
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}