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
    /// Lógica de interacción para BuscadorPersona.xaml
    /// </summary>
    public partial class BuscadorPersona : Window
    {
        public List<dynamic> PersonaList { get; set; }
        public int SelectedIndex { get; set; }
        public int Step { get; set; }

        public BuscadorPersona()
        {
            PersonaList = new List<dynamic>();
            Step = 10;
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Step);
            var joiner = Constants.StringJoiner;
            var currentUserPerson = XamlBridge.CurrentUser.Persona1;

            var saved = StaticReferences.Context.PersonaDbSet
                .Select(p => new
                {
                    p.Dni,
                    p.Nif,
                    p.Nombre,
                    p.Apellidos,
                    Direccion = string.Concat(p.Calle, joiner, p.Patio, joiner, p.Piso, joiner, p.Puerta),
                });

            foreach (var savedItem in saved)
            {
                PersonaList.Add(savedItem);
            }

            LoadPageData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == ButtonPrevious)
            {
                if (SelectedIndex > 0)
                {
                    SelectedIndex--;
                }
            }
            else if (sender == ButtonNext)
            {
                if (SelectedIndex < PersonaList.Count - 1)
                {
                    SelectedIndex++;
                }
            }

            LoadPageData();
        }

        private void LoadPageData()
        {
            var startIndex = SelectedIndex * 10;
            var endIndex = startIndex + Step;

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
