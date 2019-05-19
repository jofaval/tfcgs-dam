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

namespace Gestion_AcademicoAdministrativa_Abastos.Formularios
{
    /// <summary>
    /// Lógica de interacción para FichaPersona.xaml
    /// </summary>
    public partial class FichaPersona : Window
    {
        public FichaPersona()
        {
            InitializeComponent();
        }

        public void FillWithData(Model.Persona persona)
        {
            if (persona != null)
            {
                TxtDNI.Text = persona.Dni;
                TxtNIF.Text = persona.Nif;
                TxtNombre.Text = persona.Nombre;
                TxtApellidos.Text = persona.Apellidos;
                TxtEmail.Text = persona.Email;
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            FillWithData(DataRetriever.GetInstance().GetPersona(TxtDniSearch.Text));
        }
    }
}