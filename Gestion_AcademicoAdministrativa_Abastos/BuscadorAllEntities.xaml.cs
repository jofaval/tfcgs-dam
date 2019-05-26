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
        public List<dynamic> ContainerList { get; set; }
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

            switch (selectedEntityType)
            {
                case EntitiyTypes.Administrativo:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Alumno:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Asignatura:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.AsistenciaDiaAsignatura:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.AsistenciaSemanaAsignatura:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Aula:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Bachiller:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Baja:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Certificado:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.CertificadoMatricula:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.CertificadoNotas:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.CertificadoTitulo:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Ciclo:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Convocatoria:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Curso:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Departamento:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Eso:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Especial:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Evaluacion:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Horario:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Impartimiento:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Mantenimiento:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Nota:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Ordenador:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.PermisosUsuario:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Persona:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Profesor:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.ProfesorSustituto:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Proyecto:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Reclamacion:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Superior:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Telefono:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Titulo:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Trabajador:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Usuario:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Tutores:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.Estudio:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                case EntitiyTypes.ActasEvaluacion:
                    ContainerList = context.AdministrativoDbSet.Cast<dynamic>().ToList();
                    break;
                default:
                    break;
            }


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
                Notification.CreateNotificaion(Constants.NoResults);
            }

            LoadPageData();
        }
    }
}
