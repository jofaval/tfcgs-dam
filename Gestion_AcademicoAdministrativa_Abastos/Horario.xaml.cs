using Controller;
using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    /// Lógica de interacción para Horario.xaml
    /// </summary>
    public partial class Horario : Window
    {
        public Horario()
        {
            InitializeComponent();
            //var collection = AlumnoFunctionality.GetHorarios(XamlBridge.CurrentUser);
            //XamlFunctionality.FillDataGrid(DataGridResult, collection);
            //Console.WriteLine(collection.Count());
            var collection = StaticReferences.Context.HorarioDbSet
                .AsEnumerable()
                .OrderBy(h => new { h.Dia, h.HoraInicio })
                .Select(h => new
                {
                    Dia = (WeekEnum)h.Dia,
                    HoraInicio = ExtractHour(h.HoraInicio),
                    HoraFinal = ExtractHour(h.HoraFinal),
                    Asignatura = h.Asignatura.Nombre,
                })
                .ToList();
            XamlFunctionality.FillDataGrid(DataGridResult, collection);
        }

        public string ExtractHour(DateTime dateTime)
        {
            return string.Concat(dateTime.Hour.ToString("D2"), ':', dateTime.Minute.ToString("D2"));
        }
    }
}
