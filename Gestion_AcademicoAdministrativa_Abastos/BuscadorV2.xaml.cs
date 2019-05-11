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
    /// Lógica de interacción para BuscadorV2.xaml
    /// </summary>
    public partial class BuscadorV2 : Window
    {
        public List<dynamic> PersonaList { get; set; }
        public int SelectedIndex { get; set; }
        public int Step { get; set; }

        public BuscadorV2()
        {
            PersonaList = new List<dynamic>();
            Step = 15;
            InitializeComponent();
            TxtStep.Text = Step.ToString();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Step);
            var joiner = Constants.StringJoiner;
            var currentUserPerson = XamlBridge.CurrentUser.Persona1;

            var name = TxtSearch.Text;
            var ignoreMayus = IgnoreMayus.IsChecked;
            var exactMatch = ExactMatch.IsChecked;

            var saved = StaticReferences.Context.PersonaDbSet.AsEnumerable()
                .Where(p => DataIntegrityChecker.FullyCheckIfContainsString(p.Nombre, name, ignoreMayus, exactMatch))
                .Select(p => new
                {
                    p.Dni,
                    p.Nif,
                    p.Nombre,
                    p.Apellidos,
                    Direccion = string.Concat(p.Calle, joiner, p.Patio, joiner, p.Piso, joiner, p.Puerta),
                });

            PersonaList.Clear();
            foreach (var savedItem in saved)
            {
                PersonaList.Add(savedItem);
            }

            LabelNumRows.Content = PersonaList.Count;

            LoadPageData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                correcto = (SelectedIndex * Step) < PersonaList.Count - Step;
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

            XamlFunctionality.FillDataGrid(DataGridResult, PersonaList
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
                    Step = int.Parse(content);
                    LoadPageData();
                }
            }
        }
    }
}
