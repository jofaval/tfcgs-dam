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
    /// Lógica de interacción para ActasDeEvaluacion.xaml
    /// </summary>
    public partial class ActasDeEvaluacion : Window
    {
        public Curso CurrentCurso { get; set; }
        public Profesor CurrentProfesor { get; set; }
        public List<Actas> Actas { get; set; }

        public ActasDeEvaluacion()
        {
            InitializeComponent();
            var profesor = XamlBridge.CurrentUser.Persona1.Trabajador.Profesor;
            CurrentProfesor = profesor;
            var academicYear = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime);
            //var curso = profesor.Tutores
            //    .AsEnumerable()
            //    .FirstOrDefault(t => t.Anyo.Equals(academicYear))
            //    .Curso;
            var curso = StaticReferences.Context.CursoDbSet.SingleOrDefault(c => c.Cod.Equals("7J"));
            CurrentCurso = curso;
            LabelCurso.Content = curso.Nombre;
            Actas = StaticReferences.Context.ActasEvaluacionDbSet
                .AsEnumerable()
                .Select(a => new
                {
                    a.Fecha,
                    Profesor = a.Profesor1?.Trabajador1?.NombreCompleto(),
                })
                .ToList();
            DataGridActas.ItemsSource = Actas;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var contenido = TxtContenido.Text;
            var temas = TxtTemas.Text;

            var actaEvaluacion = new ActasEvaluacion()
            {
                Curso = CurrentCurso,
                CursoCod = CurrentCurso.Cod,
                CursoNombre = CurrentCurso.Nombre,
                Contenido = contenido,
                Temas = temas,
                Fecha = DateTime.Now,
                Profesor = CurrentProfesor.Trabajador,
                Profesor1 = CurrentProfesor,
            };

            StaticReferences.Context.ActasEvaluacionDbSet.Add(actaEvaluacion);
            Actas.Add(actaEvaluacion);
            StaticReferences.Context.SaveChanges();
        }
    }
}
