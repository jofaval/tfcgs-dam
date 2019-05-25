using Controller;
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
            var asignaturas = StaticReferences.Context.AsignaturaDbSet.ToList();
            ComboBoxAsignatura.ItemsSource = asignaturas;
            var valuesOfWeekEnum = Enum.GetValues(typeof(WeekEnum));
            ComboBoxDia.ItemsSource = valuesOfWeekEnum;
            ComboBoxProfesores.ItemsSource = StaticReferences.Context.ProfesorDbSet.ToList();
            ComboBoxAulas.ItemsSource = StaticReferences.Context.AulaDbSet.ToList();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var selectedCurso = (Curso)ComboBoxCurso.SelectedValue;

            var selectedAsignatura = (Asignatura)ComboBoxAsignatura.SelectedValue;
            var asignaturaCodText = selectedAsignatura.Cod;

            var horaInicio = TxtHoraInicio.Value.Value;
            var horaFinal = TxtHoraFinal.Value.Value;

            var day = (byte)((WeekEnum)ComboBoxDia.SelectedValue);

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreateHorario(selectedCurso, selectedAsignatura, horaInicio, horaFinal, day));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedCurso = (Curso)ComboBoxCurso.SelectedValue;

            var selectedAsignatura = (Asignatura)ComboBoxAsignatura.SelectedValue;
            var asignaturaCodText = selectedAsignatura.Cod;

            var horaInicio = TxtHoraInicio.Value.Value;
            var horaFinal = TxtHoraFinal.Value.Value;

            var day = (byte)(WeekEnum)ComboBoxDia.SelectedValue;

            var horario = new Model.Horario()
            {
                Anyo = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime),
                CursoCod = selectedCurso.Cod,
                CursoNombre = selectedCurso.Nombre,
                CodAsignatura = asignaturaCodText,
                HoraInicio = horaInicio,
                HoraFinal = horaFinal,
                Dia = day,
            };

            var context = StaticReferences.Context;
            if (context.HorarioDbSet.AsEnumerable().Contains(horario))
            {
                context.HorarioDbSet.Remove(horario);
                context.SaveChanges();
            }
            else
            {
                Notification.CreateNotificaion("No se ha encontrado");
                return;
            }
        }

        private void CreateImpartimiento_Click(object sender, RoutedEventArgs e)
        {
            var impartimiento = new Impartimiento()
            {

            };

            StaticReferences.Context.ImpartimientoDbSet.AsEnumerable().Contains(impartimiento);
        }

        private void DeleteImpartimiento_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
