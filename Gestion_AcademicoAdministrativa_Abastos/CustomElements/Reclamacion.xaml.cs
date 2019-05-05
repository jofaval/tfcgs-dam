using Controller;
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

namespace Gestion_AcademicoAdministrativa_Abastos.CustomElements
{
    /// <summary>
    /// Lógica de interacción para Reclamacion.xaml
    /// </summary>
    public partial class Reclamacion : Window
    {
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public string DirigidoA { get; set; }

        public bool EnTramite { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaRevision { get; set; }

        public int NumParte { get; set; }
        public string Respuesta { get; set; }
        public string Revisor { get; set; }

        public Reclamacion()
        {
            InitializeComponent();
            Console.WriteLine(XamlFunctionality.CheckNet() ? "Funciona" : "No hay internet");
        }

        public static Grid CreateReclamacion(Model.Reclamacion reclamacion)
        {
            return new Reclamacion()
            {
                Asunto = reclamacion.Asunto,
                Contenido = reclamacion.Contenido,
                DirigidoA = reclamacion.DirigidoA,
                EnTramite = reclamacion.EnTramite ?? false,
                FechaEnvio = reclamacion.FechaEnvio ?? new DateTime(),
                FechaRevision = reclamacion.FechaRevision ?? new DateTime(),
                NumParte = reclamacion.NumParte,
                Respuesta = reclamacion.Respuesta,
                Revisor = reclamacion.Revisor,
            }.MainGridContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
