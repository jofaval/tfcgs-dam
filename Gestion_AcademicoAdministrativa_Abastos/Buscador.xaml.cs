using Controller;
using Model;
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
            var currentUserPerson = XamlBridge.CurrentUser.Persona1;
            XamlFunctionality.FillDataGrid(DataGridResult,
                currentUserPerson.Alumno != null ?
                AlumnoFunctionality.GetProfesores(TxtSearch.Text, IgnoreMayus.IsChecked, ExactMatch.IsChecked)
                :
                ProfesorFunctionality.GetAlumnos(TxtSearch.Text, currentUserPerson.Trabajador.Profesor, IgnoreMayus.IsChecked, ExactMatch.IsChecked)
                );
        }
    }
}
