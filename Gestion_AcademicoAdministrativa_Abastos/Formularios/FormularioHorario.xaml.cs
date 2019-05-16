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

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para FormularioHorario.xaml
    /// </summary>
    public partial class FormularioHorario : Window
    {
        public FormularioHorario()
        {
            InitializeComponent();
            var cursos = StaticReferences.Context.CursoDbSet.ToList();
            ComboBoxCurso.ItemsSource = cursos;
            //var asignaturas = StaticReferences.Context.AsignaturaDbSet.ToList();
            //ComboBoxAsignatura.ItemsSource = asignaturas;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            StaticReferences.Initializer();
            var context = StaticReferences.Context;
            var cursos = context.CursoDbSet;

            //var cursoCodText = TxtCursoCod.Text;
            //var cursoNombreText = TxtCursoNombre.Text;
            //var curso = cursos.SingleOrDefault(c => c.Cod.Equals(cursoCodText) && c.Nombre.Equals(cursoNombreText));

            var asignaturas = context.AsignaturaDbSet;
            var selectedAsignatura = (dynamic)((ComboBoxItem)ComboBoxAsignatura.SelectedItem).Content;
            var asignaturaCodText = ((string)selectedAsignatura.Cod);
            var asignatura = asignaturas.SingleOrDefault(a => a.Cod.Equals(asignaturaCodText));

            var horaInicio = TxtHoraInicio.Value;

            var horario = new Model.Horario()
            {
                Anyo = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime),
                //CursoCod = cursoCodText,
                //CursoNombre = cursoNombreText,
                //Curso = curso,
                CodAsignatura = asignaturaCodText,
                Asignatura = asignatura,
            };
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
