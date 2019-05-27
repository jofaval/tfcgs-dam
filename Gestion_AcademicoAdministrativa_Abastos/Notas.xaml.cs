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
using Controller;
using Model.ViewModel;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para Notas.xaml
    /// </summary>
    public partial class Notas : Window
    {
        public Notas()
        {
            InitializeComponent();
            var selectedAlumno = XamlBridge.CurrentUser.Persona1.Alumno;
            var asignaturas = StaticReferences.Context.AsignaturaDbSet.ToList();
            var query = StaticReferences.Context.NotaDbSet
                .AsEnumerable()
                .Where(n => n.Alumno.Equals(selectedAlumno.Persona1.Dni))
                .Select(n => new NotasViewModel
                {
                    Curso = n.CursoNombre,
                    Asignatura = asignaturas
                    .Where(a => a.Cod.Equals(n.CodAsignatura))
                    .Select(a => a.Nombre)
                    .Single(),
                    Evaluacion = n.EvaluacionNum,
                    Valoracion = n.Valoracion,
                    Observaciones = n.Observaciones,
                })
                .ToList();
            DataGridNotas.ItemsSource = query;
        }
    }
}
