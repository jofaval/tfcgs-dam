using Controller;
using Model;
using Model.ViewModel;
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

            if (aula is null)
            {
                Notification.CreateNotificaion("No se ha encontrado");
            }
            else
            {
                context.AulaDbSet.Remove(aula);
                context.SaveChanges();
                Notification.CreateNotificaion("Borrado con exito");
            }
        }

        private void CreateOrdenador_Click(object sender, RoutedEventArgs e)
        {
            var context = StaticReferences.Context;

            var piso = TxtPiso.Text;
            var num = TxtNum.Text;

            var aula = context.AulaDbSet
                .SingleOrDefault(a => a.Num.Equals(num)
                && a.Piso.Equals(piso));

            if (aula is null)
            {
                Notification.CreateNotificaion("No se ha encontrado el aula");
                return;
            }

            var cod = TxtCod.Text;
            var estado = TxtEstado.Text;
            var ip = TxtIP.Text;
            var sistemaOperativo = TxtSO.Text;

            if (context.OrdenadorDbSet.Any(o => o.Num.Equals(num)
                && o.Piso.Equals(piso)
                && o.CodOrdenadorAula.Equals(cod)))
            {
                Notification.CreateNotificaion("Ya existe");
                return;
            }
            var ordenador = new Ordenador()
            {
                Piso = piso,
                Num = num,
                CodOrdenadorAula = cod,
                Estado = estado,
                Ip = ip,
                SistemaOperativo = sistemaOperativo,
                Aula = aula,
            };
            context.OrdenadorDbSet.Add(ordenador);
            context.SaveChanges();
            BtnQueryOrdenadores_Click(null, null);

            Notification.CreateNotificaion("Se ha creado con exito");
        }

        private void ModifyOrdenador_Click(object sender, RoutedEventArgs e)
        {
            var context = StaticReferences.Context;

            var piso = TxtPiso.Text;
            var num = TxtNum.Text;

            var aula = context.AulaDbSet
                .SingleOrDefault(a => a.Num.Equals(num)
                && a.Piso.Equals(piso));

            if (aula is null)
            {
                Notification.CreateNotificaion("No se ha encontrado el aula");
                return;
            }

            var cod = TxtCod.Text;
            var estado = TxtEstado.Text;
            var ip = TxtIP.Text;
            var sistemaOperativo = TxtSO.Text;
            var ordenador = context.OrdenadorDbSet.SingleOrDefault(o => o.Num.Equals(num)
                && o.Piso.Equals(piso)
                && o.CodOrdenadorAula.Equals(cod));

            if (ordenador is null)
            {
                Notification.CreateNotificaion("No es ha encontrado el ordenador");
                return;
            }

            ordenador.Estado = estado;
            ordenador.Ip = ip;
            ordenador.SistemaOperativo = sistemaOperativo;

            context.Entry(ordenador).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            BtnQueryOrdenadores_Click(null, null);

            Notification.CreateNotificaion("Se ha modificado con exito");
        }

        private void DeleteOrdenador_Click(object sender, RoutedEventArgs e)
        {
            var piso = TxtPiso.Text;
            var num = TxtNum.Text;
            var cod = TxtCod.Text;

            var context = StaticReferences.Context;
            var ordenador = context.OrdenadorDbSet
                .SingleOrDefault(o => o.Num.Equals(num)
                && o.Piso.Equals(piso)
                && o.CodOrdenadorAula.Equals(cod));

            if (context.OrdenadorDbSet.Any(o => o.Num.Equals(num)
                && o.Piso.Equals(piso)
                && o.CodOrdenadorAula.Equals(cod)))
            {
                context.OrdenadorDbSet.Remove(ordenador);
                context.SaveChanges();
                Notification.CreateNotificaion("Borrado con exito");
            }
            else
            {
                Notification.CreateNotificaion("No se ha encontrado");
            }
            BtnQueryOrdenadores_Click(null, null);
        }

        private void BtnQueryOrdenadores_Click(object sender, RoutedEventArgs e)
        {
            var ordenadores = StaticReferences.Context.OrdenadorDbSet
                .Where(o => o.Num.Equals(TxtNum.Text)
                && o.Piso.Equals(TxtPiso.Text))
                .Select(o => 
                new OrdenadorViewModel
                {
                    Piso = o.Piso,
                    Num = o.Num,
                    CodOrdenadorAula = o.CodOrdenadorAula,
                    Estado = o.Estado,
                    Ip = o.Ip,
                    SistemaOperativo = o.SistemaOperativo,
                }
                )
                .ToList();
            DataGridOrdenadores.ItemsSource = ordenadores;
        }

        private void QueryEntry_Click(object sender, RoutedEventArgs e)
        {
            var ordenador = (OrdenadorViewModel)DataGridOrdenadores.SelectedValue;
            TxtCod.Text = ordenador.CodOrdenadorAula;
            TxtEstado.Text = ordenador.Estado;
            TxtIP.Text = ordenador.Ip;
            TxtSO.Text = ordenador.SistemaOperativo;
            TabPages.SelectedIndex = 1;
        }
    }
}
