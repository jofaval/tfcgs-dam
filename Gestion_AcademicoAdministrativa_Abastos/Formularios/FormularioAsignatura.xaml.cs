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
    /// Lógica de interacción para FormularioAsignatura.xaml
    /// </summary>
    public partial class FormularioAsignatura : Window
    {
        public FormularioAsignatura()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var nombre = TxtNombre.Text;
            var rama = TxtBranch.Text;

            var msg = ComponentGenerator.GetInstance().CreateAsignatura(cod, nombre, rama);
            Notification.CreateNotificaion(msg);
        }
    }
}
