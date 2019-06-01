using System.Linq;
using System.Windows;
using Controller;
using Gestion_AcademicoAdministrativa_Abastos.Classes;
using Model;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para FormularioDepartamento.xaml
    /// </summary>
    public partial class FormularioDepartamento : Window
    {
        public FormularioDepartamento()
        {
            InitializeComponent();
            ComboBoxAula.ItemsSource = StaticReferences.Context.AulaDbSet.ToList();
            TxtCod.PreviewTextInput += Restrictions.AlphabetOnlyText;
            TxtNombre.PreviewTextInput += Restrictions.AlphabetOnlyText;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var context = StaticReferences.Context;
            if (context.DepartamentoDbSet
                .Any(d => d.Cod.Equals(cod)))
            {
                Notification.CreateNotificaion("Ya existe");
                return;
            }
            var nombre = TxtNombre.Text;
            var aula = (Aula)ComboBoxAula.SelectedValue;

            var departamento = new Departamento()
            {
                Cod = cod,
                Nombre = nombre,
                Aula = aula,
            };

            context.DepartamentoDbSet.Add(departamento);
            context.SaveChanges();

            Notification.CreateNotificaion("Se ha creado con exito");
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var context = StaticReferences.Context;
            var departamento = context.DepartamentoDbSet
                .SingleOrDefault(d => d.Cod.Equals(cod));
            var aula = (Aula)ComboBoxAula.SelectedValue;
            if (departamento is null)
            {
                Notification.CreateNotificaion("No se ha encontrado el registro");
                return;
            }
            var nombre = TxtNombre.Text;

            departamento.Nombre = nombre;
            departamento.Aula = aula;

            context.Entry(departamento).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Notification.CreateNotificaion("Se ha modificado con exito");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var cod = TxtCod.Text;
            var context = StaticReferences.Context;
            var departamento = context.DepartamentoDbSet
                .SingleOrDefault(d => d.Cod.Equals(cod));
            if (departamento is null)
            {
                Notification.CreateNotificaion("No se ha encontrado el registro");
                return;
            }

            context.DepartamentoDbSet.Remove(departamento);
            context.SaveChanges();

            Notification.CreateNotificaion("Se ha modificado con exito");
        }
    }
}
