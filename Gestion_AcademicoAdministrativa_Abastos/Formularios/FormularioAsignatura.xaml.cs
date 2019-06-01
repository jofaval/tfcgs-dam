using Controller;
using Gestion_AcademicoAdministrativa_Abastos.Classes;
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
            TxtCod.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtNombre.PreviewTextInput += Restrictions.AlphabetOnlyText;
            TxtBranch.PreviewTextInput += Restrictions.AlphabetOnlyText;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var nombre = TxtNombre.Text;
            var rama = TxtBranch.Text;

            var msg = ComponentGenerator.GetInstance().CreateAsignatura(cod, nombre, rama);
            Notification.CreateNotificaion(msg);
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var nombre = TxtNombre.Text;
            var rama = TxtBranch.Text;

            var context = StaticReferences.Context;
            var asignatura = context.AsignaturaDbSet
                .SingleOrDefault(a => a.Cod.Equals(cod));
            if (asignatura is null)
            {
                Notification.CreateNotificaion("No se ha podido encontrar");
            }
            else
            {
                asignatura.Nombre = nombre;
                asignatura.Rama = rama;
                context.Entry(asignatura).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var context = StaticReferences.Context;
            var asignatura = context.AsignaturaDbSet
                .SingleOrDefault(a => a.Cod.Equals(cod));
            if (context.AsignaturaDbSet.Contains(asignatura))
            {
                context.AsignaturaDbSet.Remove(asignatura);
                context.SaveChanges();
            }
        }
    }
}
