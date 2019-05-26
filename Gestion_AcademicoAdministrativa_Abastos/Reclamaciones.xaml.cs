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
        public List<Reclamacion> Todas { get; set; }
        public List<Reclamacion> EnTramite { get; set; }
        public List<Reclamacion> Tramitadas { get; set; }

        public Reclamaciones()
        {
            InitializeComponent();
            ComboBoxProfesor.ItemsSource = StaticReferences.Context.ProfesorDbSet.ToList();
            var reclamaciones = StaticReferences.Context.ReclamacionDbSet;
            Todas = reclamaciones.ToList();
            foreach (var item in Todas)
            {
                Console.WriteLine(item.Asunto);
            }
            DataGridTodas.ItemsSource = Todas;
            EnTramite = reclamaciones
                .Where(r => r.EnTramite.HasValue)
                .ToList();
            DataGridEnTramite.ItemsSource = EnTramite;
            Tramitadas = reclamaciones
                .Where(r => r.FechaRevision.HasValue)
                .ToList();
            DataGridTramitadas.ItemsSource = Tramitadas;
        }

        private void CreateReclamacion_Click(object sender, RoutedEventArgs e)
        {
            var asunto = TxtAsunto.Text;
            var selectedProfesor = (Profesor)ComboBoxProfesor.SelectedValue;
            var contenido = TxtAsunto.Text;
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
            //Todas.Add(reclamacion);
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha creado con exito");
        }
    }
}
