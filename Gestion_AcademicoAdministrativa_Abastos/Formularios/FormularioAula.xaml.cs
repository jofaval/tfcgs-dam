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
    /// Lógica de interacción para FormularioAula.xaml
    /// </summary>
    public partial class FormularioAula : Window
    {
        public FormularioAula()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var piso = TxtPiso.Text;
            var num = TxtNum.Text;

            var aula = new Aula()
            {
                Piso = piso,
                Num = num,
            };

            if (StaticReferences.Context.AulaDbSet.Any(a => a.Num.Equals(num) && a.Piso.Equals(piso)))
            {
                Notification.CreateNotificaion("Ya existe");
                return;
            }

            StaticReferences.Context.AulaDbSet.Add(aula);
            StaticReferences.Context.SaveChanges();
            Notification.CreateNotificaion("Creado con exito");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var piso = TxtPiso.Text;
            var num = TxtNum.Text;

            var context = StaticReferences.Context;
            var aula = context.AulaDbSet
                .SingleOrDefault(a => a.Num.Equals(num)
                && a.Piso.Equals(piso));

            if (context.AulaDbSet.Contains(aula))
            {
                context.AulaDbSet.Remove(aula);
                context.SaveChanges();
                Notification.CreateNotificaion("Borrado con exito");
            }
            else
            {
                Notification.CreateNotificaion("No se ha encontrado");
            }
        }
    }
}
