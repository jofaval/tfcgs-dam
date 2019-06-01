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
    /// Lógica de interacción para FormularioCurso.xaml
    /// </summary>
    public partial class FormularioCurso : Window
    {
        public FormularioCurso()
        {
            InitializeComponent();
            TxtCod.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtNombre.PreviewTextInput += Restrictions.AlphabetOnlyText;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var nombre = TxtNombre.Text;
            var fechaMatriculacion = TxtDate.Value;
            var turnoTarde = TxtShift.IsChecked.Value;

            string msg = ComponentGenerator.GetInstance().CreateCurso(cod, nombre, fechaMatriculacion, turnoTarde);

            Notification.CreateNotificaion(msg);
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var nombre = TxtNombre.Text;
            var fechaMatriculacion = TxtDate.Value;
            var turnoTarde = TxtShift.IsChecked.Value;

            var context = StaticReferences.Context;
            var curso = context.CursoDbSet.SingleOrDefault(c => c.Cod.Equals(cod));

            if (curso is null)
            {
                Notification.CreateNotificaion("No se ha encontrado");
                return;
            }
            
            curso.Nombre = nombre;
            curso.FechaMatriculacion = fechaMatriculacion;
            curso.TurnoTarde = turnoTarde;

            context.Entry(curso).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Notification.CreateNotificaion("Se ha borrado con exito");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var context = StaticReferences.Context;
            var curso = context.CursoDbSet.SingleOrDefault(c => c.Cod.Equals(TxtCod.Text));

            if (curso is null)
            {
                Notification.CreateNotificaion("No se ha encontrado");
                return;
            }

            context.CursoDbSet.Remove(curso);
            context.SaveChanges();

            Notification.CreateNotificaion("Se ha borrado con exito");
        }

        private void DeleteSubTipo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModifySubTipo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateSubTipo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
