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
    /// Lógica de interacción para Horario.xaml
    /// </summary>
    public partial class Horario : Window
    {
        public Horario()
        {
            InitializeComponent();
            var collection = AlumnoFunctionality.GetHorarios(XamlBridge.CurrentUser);
            XamlFunctionality.FillDataGrid(DataGridResult, collection);
            Console.WriteLine(collection.Count());
        }

    }
}
