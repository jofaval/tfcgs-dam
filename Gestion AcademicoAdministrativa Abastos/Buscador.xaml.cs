using Controller;
using EntityFrameworkModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Lógica de interacción para Buscador.xaml
    /// </summary>
    public partial class Buscador : Window
    {
        public Buscador()
        {
            InitializeComponent();
            //DataGridResult.DataContext = this.Profesores;
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (sender is TextBox txtBox)
            //{
            //    Console.WriteLine(txtBox.Text);
            //}
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var profesoresResultList = AlumnoFunctionality.GetProfesores(TxtSearch.Text, IgnoreMayus.IsChecked, ExactMatch.IsChecked);
            
            DataGridResult.ItemsSource = profesoresResultList as IEnumerable<object>;

            var dataGridCols = DataGridResult.Columns;

            var dataGridColsLen = dataGridCols.Count;
            for (int colIterator = 0; colIterator < dataGridColsLen; colIterator++)
            {
                var dataGridCol = dataGridCols[colIterator];
                dataGridCol.MinWidth = dataGridCol.ActualWidth;
                dataGridCol.Width = new DataGridLength(0.95, DataGridLengthUnitType.Star);
            }
        }
    }
}
