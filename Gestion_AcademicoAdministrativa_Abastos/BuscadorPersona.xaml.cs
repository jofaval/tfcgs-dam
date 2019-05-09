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
        public string Step { get; set; }

        public BuscadorPersona()
        {
            PersonaList = new List<dynamic>();
            Step = 10.ToString();
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

            Button_Click(null, null);
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

            var startIndex = SelectedIndex * 10;
            var endIndex = startIndex + int.Parse(Step);

            XamlFunctionality.FillDataGrid(DataGridResult, PersonaList
                .Where((elemn, index) => index >= startIndex && index < endIndex)
                .ToList());
        }
    }
}
