﻿using Controller;
using Model;
using Model.DataStructure;
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
    /// Lógica de interacción para FormularioHorario.xaml
    /// </summary>
    public partial class FormularioHorario : Window
    {
        public FormularioHorario()
        {
            InitializeComponent();
            var cursos = StaticReferences.Context.CursoDbSet.ToList();
            ComboBoxCurso.ItemsSource = cursos;
            var asignaturas = StaticReferences.Context.AsignaturaDbSet.ToList();
            ComboBoxAsignatura.ItemsSource = asignaturas;
            var valuesOfWeekEnum = Enum.GetValues(typeof(WeekEnum));
            ComboBoxDia.ItemsSource = valuesOfWeekEnum;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

            var selectedCurso = (Curso)ComboBoxCurso.SelectedValue;

            var selectedAsignatura = (Asignatura)ComboBoxAsignatura.SelectedValue;
            var asignaturaCodText = selectedAsignatura.Cod;

            //var horaInicio = TxtHoraInicio.Value.Value;
            //horaInicio.Year = 0;
            //var horaFinal = TxtHoraFinal.Value.Value;

            //Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreateHorario(selectedCurso, selectedAsignatura, horaInicio, horaFinal));
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
