using Controller;
using Model;
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
    /// Lógica de interacción para FormularioCurso.xaml
    /// </summary>
    public partial class FormularioCurso : Window
    {
        public FormularioCurso()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var nombre = TxtNombre.Text;
            var fechaMAtriculacion = TxtDate.Value;
            var turnoTarde = TxtShift.IsChecked.Value;
            string msg = ComponentGenerator.GetInstance().CreateCurso(cod, nombre, fechaMAtriculacion, turnoTarde);
            Notification.CreateNotificaion(msg);
        }
    }
}
