using Controller;
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
    /// Lógica de interacción para RevisarReclamaciones.xaml
    /// </summary>
    public partial class RevisarReclamaciones : Window
    {
        public List<ReclamacionViewModel> PendingRecalmaciones { get; set; }
        public Model.Reclamacion SelectedReclamacion  { get; set; }

        public RevisarReclamaciones()
        {
            InitializeComponent();
            var trabajador = StaticReferences.Context.TrabajadorDbSet;
            PendingRecalmaciones = StaticReferences.Context.ReclamacionDbSet
                .Where(r => !r.EnTramite.HasValue)
                .AsEnumerable()
                .Select(r => new ReclamacionViewModel
                {
                    Alumno = r.Alumno1,
                    Asunto = r.Asunto,
                    Contenido = r.Contenido,
                    DirigidoA = trabajador
                    .Single(t => t.Persona.Equals(r.DirigidoA)).NombreCompleto(),
                    NumParte = r.NumParte,
                })
                .ToList();
            DataGridReclamacionesPendientes.ItemsSource = PendingRecalmaciones;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedReclamacion = (ReclamacionViewModel) DataGridReclamacionesPendientes.SelectedValue;
            var selectedAlumno = selectedReclamacion.Alumno;
            var selectedNumParte = selectedReclamacion.NumParte;
            SelectedReclamacion = StaticReferences.Context.ReclamacionDbSet
                .AsEnumerable()
                .Single(r => r.Alumno1.Equals(selectedAlumno)
                && r.NumParte.Equals(selectedNumParte));
            SelectedReclamacion.EnTramite = true;
            StaticReferences.Context.Entry(SelectedReclamacion).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
            TabPage.SelectedIndex = 1;
            TxtAsunto.Text = selectedReclamacion.Asunto;
            TxtContenido.Text = selectedReclamacion.Contenido;
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            SelectedReclamacion.FechaRevision = DateTime.Now;
            SelectedReclamacion.Revisor = XamlBridge.CurrentUser.Persona;
            SelectedReclamacion.Respuesta = TxtRespuesta.Text;
            StaticReferences.Context.Entry(SelectedReclamacion).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
        }
    }
}
