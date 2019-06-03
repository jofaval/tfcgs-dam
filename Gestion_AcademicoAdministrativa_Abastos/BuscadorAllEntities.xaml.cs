using Controller;
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
    /// Lógica de interacción para BuscadorAllEntities.xaml
    /// </summary>
    public partial class BuscadorAllEntities : Window
    {
        public List<dynamic> UserRoleList { get; set; }
        public IEnumerable<dynamic> ContainerList { get; set; }
        public int SelectedIndex { get; set; }
        public int Step { get; set; }

        public BuscadorAllEntities()
        {
            UserRoleList = new List<dynamic>();
            Step = 15;
            InitializeComponent();
            ComboBoxEntityTypes.ItemsSource = typeof(EntitiyTypes).GetEnumValues();
        }

        private void NextPrevious_Click(object sender, RoutedEventArgs e)
        {
            var correcto = false;
            if (sender == ButtonPrevious)
            {
                correcto = SelectedIndex > 0;
                if (correcto)
                {
                    SelectedIndex--;
                }
            }
            else if (sender == ButtonNext)
            {
                correcto = (SelectedIndex * Step) < UserRoleList.Count - Step;
                if (correcto)
                {
                    SelectedIndex++;
                }
            }
            if (correcto)
            {
                LoadPageData();
            }
        }

        private void LoadPageData()
        {
            var startIndex = SelectedIndex * Step;
            LabelStartIndex.Content = startIndex;
            var endIndex = startIndex + Step;
            LabelEndIndex.Content = endIndex;

            XamlFunctionality.FillDataGrid(DataGridResult, UserRoleList
                .Where((elemn, index) => index >= startIndex && index < endIndex)
                .ToList());
        }

        private void TxtStep_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Constants.RegexOnlyNumber.IsMatch(e.Text);
        }

        private void TxtStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox senderAsTextBox)
            {
                var content = senderAsTextBox.Text;
                if (!content.Equals(string.Empty))
                {
                    var parsedValue = int.Parse(content);
                    Step = parsedValue;
                    if (parsedValue > 0)
                    {
                        var count = UserRoleList.Count - 1;
                        var indexWithParsedValue = SelectedIndex * parsedValue;
                        if (indexWithParsedValue >= count)
                        {
                            var fixedValue = (count / parsedValue) - 1;
                            SelectedIndex = fixedValue;
                        }
                    }
                    LoadPageData();
                }
            }
        }

        private void ComboBoxEntityTypes_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            TxtStep.Text = Step.ToString();
            var selectedEntityType = (EntitiyTypes)ComboBoxEntityTypes.SelectedValue;
            var context = StaticReferences.Context;

            #region SWITCH OF TYPES
            switch (selectedEntityType)
            {
                case EntitiyTypes.Administrativo:
                    ContainerList = context.AdministrativoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Alumno:
                    ContainerList = context.AlumnoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Asignatura:
                    ContainerList = context.AsignaturaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.AsistenciaDiaAsignatura:
                    ContainerList = context.AsistenciaDiaAsignaturaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.AsistenciaSemanaAsignatura:
                    ContainerList = context.AsistenciaSemanaAsignaturaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Aula:
                    ContainerList = context.AulaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Bachiller:
                    ContainerList = context.BachillerDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Baja:
                    ContainerList = context.BajaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Certificado:
                    ContainerList = context.CertificadoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.CertificadoMatricula:
                    ContainerList = context.CertificadoMatriculaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.CertificadoNotas:
                    ContainerList = context.CertificadoNotasDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.CertificadoTitulo:
                    ContainerList = context.CertificadoTituloDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Ciclo:
                    ContainerList = context.CicloDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Convocatoria:
                    ContainerList = context.ConvocatoriaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Curso:
                    ContainerList = context.CursoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Departamento:
                    ContainerList = context.DepartamentoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Eso:
                    ContainerList = context.EsoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Especial:
                    ContainerList = context.EspecialDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Evaluacion:
                    ContainerList = context.EvaluacionDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Horario:
                    ContainerList = context.HorarioDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Impartimiento:
                    ContainerList = context.ImpartimientoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Mantenimiento:
                    ContainerList = context.MantenimientoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Nota:
                    ContainerList = context.NotaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Ordenador:
                    ContainerList = context.OrdenadorDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.PermisosUsuario:
                    ContainerList = context.PermisosUsuarioDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Persona:
                    ContainerList = context.PersonaDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Profesor:
                    ContainerList = context.ProfesorDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.ProfesorSustituto:
                    ContainerList = context.ProfesorSustitutoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Proyecto:
                    ContainerList = context.ProyectoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Reclamacion:
                    ContainerList = context.ReclamacionDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Superior:
                    ContainerList = context.SuperiorDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Telefono:
                    ContainerList = context.TelefonoDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Titulo:
                    ContainerList = context.TituloDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Trabajador:
                    ContainerList = context.TrabajadorDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Usuario:
                    ContainerList = context.UsuarioDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Tutores:
                    ContainerList = context.TutoresDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.Estudio:
                    ContainerList = context.EstudiosDbSet.ToList().Cast<dynamic>();
                    break;
                case EntitiyTypes.ActasEvaluacion:
                    ContainerList = context.ActasEvaluacionDbSet.ToList().Cast<dynamic>();
                    break;
                default:
                    break;
            }
            #endregion

            UserRoleList.Clear();
            foreach (var savedItem in ContainerList)
            {
                UserRoleList.Add(savedItem);
            }

            SelectedIndex = 0;
            var count = UserRoleList.Count;
            LabelNumRows.Content = UserRoleList.Count;
            if (count == 0)
            {
                Notification.CreateNotification(Constants.NoResults);
            }

            LoadPageData();
        }
    }
}
