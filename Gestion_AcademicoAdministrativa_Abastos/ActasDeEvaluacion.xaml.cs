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
using Model.ViewModel;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para ActasDeEvaluacion.xaml
    /// </summary>
    public partial class ActasDeEvaluacion : Window
    {
        public Curso CurrentCurso { get; set; }
        public Profesor CurrentProfesor { get; set; }
        public List<ActaEvaluacionViewModel> Actas { get; set; }

        public ActasDeEvaluacion()
        {
            InitializeComponent();
            var profesor = XamlBridge.CurrentUser.Persona1.Trabajador.Profesor;
            CurrentProfesor = profesor;
            var academicYear = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime);
            var curso = profesor.Tutores
                .AsEnumerable()
                .FirstOrDefault(t => t.Anyo.Equals(academicYear))
                .Curso;
            CurrentCurso = curso;
            LabelCurso.Content = curso.Nombre;
            Actas = StaticReferences.Context.ActasEvaluacionDbSet
                .Select(a => new ActaEvaluacionViewModel()
                {
                    Fecha = a.Fecha,
                    Temas = a.Temas,
                    Contenido = a.Contenido,
                })
                .AsEnumerable()
                .ToList();
            DataGridActas.ItemsSource = Actas;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var contenido = TxtContenido.Text;
            var temas = TxtTemas.Text;

            var date = DateTime.Now;
            if (date == null)
            {
                date = StaticReferences.CurrentDateTime;
            }
            var actaEvaluacion = new ActasEvaluacion()
            {
                Curso = CurrentCurso,
                CursoCod = CurrentCurso.Cod,
                CursoNombre = CurrentCurso.Nombre,
                Contenido = contenido,
                Temas = temas,
                Fecha = StaticReferences.CurrentDateTime,
                Profesor = CurrentProfesor.Trabajador,
                Profesor1 = CurrentProfesor,
            };

            StaticReferences.Context.ActasEvaluacionDbSet.Add(actaEvaluacion);
            StaticReferences.Context.SaveChanges();
            Actas = StaticReferences.Context.ActasEvaluacionDbSet
                .Select(a => new ActaEvaluacionViewModel()
                {
                    Fecha = a.Fecha,
                    Temas = a.Temas,
                    Contenido = a.Contenido,
                })
                .AsEnumerable()
                .ToList();
            DataGridActas.ItemsSource = Actas;
            Notification.CreateNotification("Añadido con éxito");
        }
    }
}
