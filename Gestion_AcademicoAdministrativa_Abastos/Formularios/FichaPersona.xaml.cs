using Controller;
using Gestion_AcademicoAdministrativa_Abastos.CustomElements;
using Model;
using Model.DataStructure;
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
        public Persona SelectedPersona { get; set; }

        public FichaPersona()
        {
            DataContext = this;
            InitializeComponent();
            var comboBoxTrabajadorTypeItems = ComboBoxTrabajadorType.Items;
            var trabajadoresEnumValues = Enum.GetValues(typeof(TrabajadoresEnum)).Cast<TrabajadoresEnum>();
            foreach (var trabajadorTypeFromEnum in trabajadoresEnumValues)
            {
                comboBoxTrabajadorTypeItems.Add(trabajadorTypeFromEnum);
            }
        }

        public void FillWithData(Persona persona)
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
                TxtCalle.Text = persona.Calle;
                TxtPatio.Text = persona.Patio;
                TxtPiso.Text = persona.Piso;
                TxtPuerta.Text = persona.Puerta;
                TxtCodigoPostal.Text = persona.CodigoPostal;
                FechaNacmimiento.SelectedDate = persona.FechaNacimiento;
                var alumno = persona.Alumno;
                if (alumno != null)
                {
                    FillAlumnoWithData(alumno);
                }
            }
        }

        public void FillAlumnoWithData(Alumno alumno)
        {
            TxtNumExpediente.Text = alumno.NumExpediente;
            TxtNIA.Text = alumno.NumExpediente;
            FechaMatriculacion.SelectedDate = alumno.FechaMatriculacion;
        }

        public void ClearPersonaData()
        {
            var emptyString = string.Empty;
            TxtDNI.Text = emptyString;
            TxtNIF.Text = emptyString;
            TxtNombre.Text = emptyString;
            TxtApellidos.Text = emptyString;
            TxtEmail.Text = emptyString;
            TxtCalle.Text = emptyString;
            TxtPatio.Text = emptyString;
            TxtPiso.Text = emptyString;
            TxtPuerta.Text = emptyString;
            TxtCodigoPostal.Text = emptyString;
            FechaNacmimiento.SelectedDate = new DateTime();
            SelectedPersona = null;
            ClearAlumno();
        }

        public void ClearAlumno()
        {
            TxtNumExpediente.Text = string.Empty;
            TxtNIA.Text = string.Empty;
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

        private void CreatePersona_Click(object sender, RoutedEventArgs e)
        {
            var dni = TxtDNI.Text;
            var nif = TxtNIF.Text;
            var nombre = TxtNombre.Text;
            var apellidos = TxtApellidos.Text;
            var email = TxtEmail.Text;
            var calle = TxtCalle.Text;
            var patio = TxtPatio.Text;
            var piso = TxtPiso.Text;
            var puerta = TxtPuerta.Text;
            var codigoPostal = TxtCodigoPostal.Text;

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
            else if (string.IsNullOrWhiteSpace(calle)
                || string.IsNullOrWhiteSpace(patio)
                || string.IsNullOrWhiteSpace(piso)
                || string.IsNullOrWhiteSpace(puerta)
                || string.IsNullOrWhiteSpace(codigoPostal))
            {
                Notification.CreateNotificaion("Se ha de rellenar la dirección completa.");
                return;
            }

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreatePersona(dni, nif, nombre, apellidos, email, calle, patio, piso, puerta, codigoPostal, FechaNacmimiento.SelectedDate.Value));
        }

        private void ModifyPersona_Click(object sender, RoutedEventArgs e)
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

        private void RemovePersona_Click(object sender, RoutedEventArgs e)
        {
            StaticReferences.Context.PersonaDbSet.Remove(SelectedPersona);
            StaticReferences.Context.SaveChanges();
            ClearPersonaData();
        }

        private void CreateAlumno_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = FechaNacmimiento.SelectedDate.Value;
            var numExpediente = TxtNumExpediente.Text;
            var nia = TxtNIA.Text;

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreateAlumno(SelectedPersona, numExpediente, nia, selectedDate));
        }

        private void ModifyAlumno_Click(object sender, RoutedEventArgs e)
        {
            var alumno = SelectedPersona.Alumno;
            alumno.NumExpediente = TxtNumExpediente.Text;
            alumno.FechaMatriculacion = FechaMatriculacion.SelectedDate.Value;
            SelectedPersona.Alumno = alumno;
            StaticReferences.Context.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
        }

        private void RemoveAlumno_Click(object sender, RoutedEventArgs e)
        {
            SelectedPersona.Alumno = null;
            StaticReferences.Context.Entry(SelectedPersona).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
        }

        private void CreateTrabajador_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModifyTrabajador_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveTrabajador_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxTrabajadorType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}