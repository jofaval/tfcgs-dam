using Controller;
using Gestion_AcademicoAdministrativa_Abastos.Formularios;
using Model;
using Model.DataStructure;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
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
    /// Lógica de interacción para BuscadorV2.xaml
    /// </summary>
    public partial class BuscadorV2 : Window
    {
        public List<dynamic> UserRoleList { get; set; }
        public List<dynamic> ContainerList { get; set; }
        public int SelectedIndex { get; set; }
        public int Step { get; set; }

        public BuscadorV2()
        {
            UserRoleList = new List<dynamic>();
            Step = 15;
            InitializeComponent();
            var selectedView = XamlBridge.ViewEnum;
            if (selectedView.Equals(ViewsEnum.Profesor))
            {
                ContainerList = DataRetriever.GetInstance().GetListByUser(selectedView, XamlBridge.CurrentUser.Persona1.Trabajador.Profesor).ToList();
            }
            else
            {
                ContainerList = DataRetriever.GetInstance().GetListByUser(selectedView).ToList();
            }
            if (!selectedView.Equals(ViewsEnum.Administrativo))
            {
                DataGridContextMenu.Visibility = Visibility.Hidden;
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            TxtStep.Text = Step.ToString();
            Console.WriteLine(Step);
            var joiner = Constants.StringJoiner;
            var currentUserPerson = XamlBridge.CurrentUser.Persona1;

            var name = TxtSearch.Text;
            var ignoreMayus = IgnoreMayus.IsChecked;
            var exactMatch = ExactMatch.IsChecked;

            var saved = ContainerList
                .Cast<dynamic>()
                .Where(person => DataIntegrityChecker.FullyCheckIfContainsString((person as IIsPersona).Nombre, name, ignoreMayus, exactMatch))
                .OrderBy(person => (person as IIsPersona).Nombre);

            UserRoleList.Clear();
            foreach (var savedItem in saved)
            {
                Console.WriteLine(savedItem);
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

        private void QueryEntry_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGridResult.SelectedItem;
            if (selectedItem is PersonaViewModel selectedItemAsPersonaViewModel)
            {
                //Notification.CreateNotificaion();
                var persona = DataRetriever.GetInstance().GetPersona(selectedItemAsPersonaViewModel.Dni);
                var fichaPersona = new FichaPersona();
                XamlBridge.FichaPersona = fichaPersona;
                fichaPersona.Close();
                fichaPersona.FillWithData(persona);
                var backUpMainPanel = fichaPersona.MainPanel;
                XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                XamlBridge.MainPanelInstance = backUpMainPanel;
            }
        }
    }
}
