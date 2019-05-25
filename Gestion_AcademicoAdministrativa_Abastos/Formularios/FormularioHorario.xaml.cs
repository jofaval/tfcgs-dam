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
            var horario = GetHorario();

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
            var horario = GetHorario();
            if (horario is null)
            {
                Notification.CreateNotificaion("No se ha encontrado el horario");
                return;
            }

            var selectedProfesor = (Profesor)ComboBoxProfesores.SelectedValue;
            var selectedAula = (Aula)ComboBoxAulas.SelectedValue;

            var impartimiento = new Impartimiento()
            {
                Profesor1 = selectedProfesor,
                Profesor = selectedProfesor.Trabajador,
                Aula = selectedAula,
                AulaNum = selectedAula.Num,
                AulaPiso = selectedAula.Piso,
                Anyo = horario.Anyo,
                CursoCod = horario.CursoCod,
                CursoNombre = horario.CursoNombre,
                CodAsignatura = horario.CodAsignatura,
                HoraInicio = horario.HoraInicio,
                HoraFinal = horario.HoraFinal,
                Dia = horario.Dia,
                Horario = horario,
            };

            if (StaticReferences.Context.ImpartimientoDbSet.AsEnumerable().Contains(impartimiento))
            {
                Notification.CreateNotificaion("Ya existe");
            }
            else
            {
                StaticReferences.Context.ImpartimientoDbSet.Add(impartimiento);
                StaticReferences.Context.SaveChanges();
                Notification.CreateNotificaion("Se ha creado con exito");
            }

        }

        private void DeleteImpartimiento_Click(object sender, RoutedEventArgs e)
        {
            var horario = GetHorario();
            if (horario is null)
            {
                Notification.CreateNotificaion("No se ha encontrado el horario");
                return;
            }

            var selectedProfesor = (Profesor)ComboBoxProfesores.SelectedValue;
            var selectedAula = (Aula)ComboBoxAulas.SelectedValue;

            var impartimiento = StaticReferences.Context.ImpartimientoDbSet
                .AsEnumerable()
                .SingleOrDefault(i =>
                i.Profesor1.Equals(selectedProfesor)
                && i.Aula.Equals(selectedAula)
                && i.Horario.Equals(horario)
            );

            if (impartimiento is null)
            {
                Notification.CreateNotificaion("No se ha encontrado registro");
            }
            else
            {
                StaticReferences.Context.ImpartimientoDbSet.Remove(impartimiento);
                StaticReferences.Context.SaveChanges();
                Notification.CreateNotificaion("Se ha borrado con exito");
            }
        }

        public Model.Horario GetHorario()
        {
            var selectedCurso = (Curso)ComboBoxCurso.SelectedValue;

            var selectedAsignatura = (Asignatura)ComboBoxAsignatura.SelectedValue;
            var asignaturaCodText = selectedAsignatura.Cod;

            var horaInicio = TxtHoraInicio.Value.Value;
            var horaFinal = TxtHoraFinal.Value.Value;

            var day = (byte)(WeekEnum)ComboBoxDia.SelectedValue;

            return StaticReferences.Context.HorarioDbSet
                .AsEnumerable()
            .SingleOrDefault(
                h => h.Anyo.Equals(AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime))
               && h.CursoCod.Equals(selectedCurso.Cod)
               && h.CursoNombre.Equals(selectedCurso.Nombre)
               && h.CodAsignatura.Equals(asignaturaCodText)
               && h.HoraInicio.Equals(horaInicio)
               && h.HoraFinal.Equals(horaFinal)
               && h.Dia.Equals(day)
            );
        }
    }
}
