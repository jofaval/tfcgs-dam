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
using Controller;
using Model;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para ActasDeEvaluacion.xaml
    /// </summary>
    public partial class ActasDeEvaluacion : Window
    {
        public ActasDeEvaluacion()
        {
            InitializeComponent();
            var profesor = XamlBridge.CurrentUser.Persona1.Trabajador.Profesor;
            var academicYear = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime);
            var curso = profesor.Tutores
                .AsEnumerable()
                .FirstOrDefault(t => t.Anyo.Equals(academicYear))
                .Curso;
            LabelCurso.Content = curso.Nombre;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
