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
using Model;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para Reclamaciones.xaml
    /// </summary>
    public partial class Reclamaciones : Window
    {
        public List<Reclamacion> MainList { get; set; }
        public List<Reclamacion> BackUpList { get; set; }

        public Reclamaciones()
        {
            InitializeComponent();

            ComboBoxProfesor.ItemsSource = StaticReferences.Context.ProfesorDbSet.ToList();

            BackUpList = StaticReferences.Context.ReclamacionDbSet.ToList();
            MainList = BackUpList;

            MainDataGrid.ItemsSource = MainList;
        }

        private void CreateReclamacion_Click(object sender, RoutedEventArgs e)
        {
            var asunto = TxtAsunto.Text;
            var selectedProfesor = (Profesor)ComboBoxProfesor.SelectedValue;
            var contenido = TxtContenido.Text;
            var alumno = XamlBridge.CurrentUser.Persona1.Alumno;
            var numParte = alumno.Reclamacion.Count;

            var reclamacion = new Reclamacion()
            {
                Asunto = asunto,
                Alumno = alumno.Persona,
                Alumno1 = alumno,
                Contenido = contenido,
                NumParte = numParte,
                DirigidoA = selectedProfesor?.Trabajador,
                FechaEnvio = DateTime.Now,
            };

            StaticReferences.Context.ReclamacionDbSet.Add(reclamacion);
            StaticReferences.Context.SaveChanges();
            BackUpList = StaticReferences.Context.ReclamacionDbSet.ToList();
            UpdateDataGrid();
            Notification.CreateNotificaion("Se ha creado con exito");
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox senderAsCheckBox)
            {
                ChkTodas.IsChecked = false;
                ChkEnTramite.IsChecked = false;
                ChkTramitadas.IsChecked = false;
                senderAsCheckBox.IsChecked = true;

                UpdateDataGrid();
            }
        }

        private void UpdateDataGrid()
        {
            if (ChkTodas.IsChecked.Value)
            {
                MainList = BackUpList;
            }
            else if (ChkEnTramite.IsChecked.Value)
            {
                MainList = BackUpList
                    .Where(r => r.EnTramite.HasValue)
                    .ToList();
            }
            else if (ChkTramitadas.IsChecked.Value)
            {
                MainList = BackUpList
                    .Where(r => r.FechaRevision.HasValue)
                    .ToList();
            }

            MainDataGrid.ItemsSource = MainList;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedReclamacion = (Reclamacion)MainDataGrid.SelectedValue;
            TabPage.SelectedIndex = 1;
            TxtAsunto.Text = selectedReclamacion.Asunto;
            var dirigidoA = selectedReclamacion.DirigidoA;
            if (dirigidoA != null)
            {
                ComboBoxProfesor.SelectedValue = StaticReferences.Context.ProfesorDbSet
                    .Single(p => p.Trabajador.Equals(dirigidoA));
            }
            TxtContenido.Text = selectedReclamacion.Contenido;
        }
    }
}
