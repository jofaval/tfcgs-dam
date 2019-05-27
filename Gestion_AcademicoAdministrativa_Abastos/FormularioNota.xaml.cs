using Controller;
using Model;
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
using Model;
using System.Globalization;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para FormularioNota.xaml
    /// </summary>
    public partial class FormularioNota : Window
    {
        public Asignatura SelectedAsignatura { get; set; }

        public FormularioNota()
        {
            InitializeComponent();
            //new Alumno().Convocatoria.Last().Evaluacion.Last().Nota
            var profesor = XamlBridge.CurrentUser.Persona1.Trabajador.Profesor;
            var list = ProfesorFunctionality.GetAsignaturasImpartidas(profesor).ToList();

            ComboBoxAsignatura.ItemsSource = list;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var selectedAlumno = (Alumno)ComboBoxAlumno.SelectedValue;
            var selectedCurso = selectedAlumno.Estudio.Last().Curso;

            //var convocatoria = new Convocatoria()
            //{
            //    Alumno = selectedAlumno.Persona,
            //    Alumno1 = selectedAlumno,
            //    Curso = selectedCurso,
            //    CursoCod = selectedCurso.Cod,
            //    CursoNombre = selectedCurso.Nombre,
            //    Num = 1,
            //    CodAsignatura = SelectedAsignatura.Cod,
            //    Asignatura = SelectedAsignatura,
            //};
            //StaticReferences.Context.ConvocatoriaDbSet.Add(convocatoria);
            //StaticReferences.Context.SaveChanges();

            //var evaluacion = new Evaluacion()
            //{
            //    Alumno = selectedAlumno.Persona,
            //    CursoCod = selectedCurso.Cod,
            //    CursoNombre = selectedCurso.Nombre,
            //    EvaluacionNum = 1,
            //    ConvocatoriaNum = 1,
            //    Convocatoria = convocatoria,
            //    CodAsignatura = SelectedAsignatura.Cod,
            //};
            //StaticReferences.Context.EvaluacionDbSet.Add(evaluacion);
            //StaticReferences.Context.SaveChanges();

            var nota = new Nota()
            {
                Evaluacion = null,
                Alumno = selectedAlumno.Persona,
                CodAsignatura = SelectedAsignatura.Cod,
                CursoCod = selectedCurso.Cod,
                CursoNombre = selectedCurso.Nombre,
                Observaciones = TxtObservaciones.Text,
                Valoracion = double.Parse(TxtNota.Text, CultureInfo.InvariantCulture),
            };

            var evaluacion = selectedAlumno.Convocatoria.Last().Evaluacion.Last();
            evaluacion.Nota = nota;
            StaticReferences.Context.Entry(evaluacion).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha creado con exito");
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var selectedAlumno = (Alumno)ComboBoxAlumno.SelectedValue;

            var nota = selectedAlumno.Convocatoria.Last().Evaluacion.Last().Nota;

            nota.Observaciones = TxtObservaciones.Text;
            nota.Valoracion = double.Parse(TxtNota.Text, CultureInfo.InvariantCulture);

            StaticReferences.Context.Entry(nota).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha modificado con exito");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedAlumno = (Alumno)ComboBoxAlumno.SelectedValue;

            var nota = selectedAlumno.Convocatoria.Last().Evaluacion.Last().Nota;

            StaticReferences.Context.NotaDbSet.Remove(nota);
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Se ha borrado con exito");
        }

        private void ComboBoxAsignatura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAsignatura = (Asignatura)ComboBoxAsignatura.SelectedValue;
            var list = ProfesorFunctionality.GetAlumnosWhereAsignaturasImpartidas(selectedAsignatura).ToList();

            ComboBoxAlumno.ItemsSource = list;
            SelectedAsignatura = selectedAsignatura;
        }
    }
}
