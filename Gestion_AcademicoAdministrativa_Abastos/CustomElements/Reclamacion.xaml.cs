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

        public string EnTramite { get; set; }
        public string FechaEnvio { get; set; }
        public string FechaRevision { get; set; }

        public string NumParte { get; set; }
        public string Respuesta { get; set; }
        public string Revisor { get; set; }

        public Reclamacion()
        {
            InitializeComponent();
            //Console.WriteLine(XamlFunctionality.CheckNet() ? "Funciona" : "No hay internet");
        }

        public static Grid CreateReclamacion(Model.Reclamacion reclamacion)
        {
            return new Reclamacion()
            {
                Asunto = reclamacion.Asunto,
                Contenido = reclamacion.Contenido,
                DirigidoA = reclamacion.DirigidoA,
                EnTramite = reclamacion.EnTramite.Value ? "Sí" : "No disponible",
                FechaEnvio = reclamacion.FechaEnvio.HasValue ? reclamacion.FechaEnvio.Value.ToString() : "No disponible",
                FechaRevision = reclamacion.FechaRevision.HasValue ? reclamacion.FechaRevision.Value.ToString() : "No disponible",
                NumParte = reclamacion.NumParte.ToString("D6"),
                Respuesta = reclamacion.Respuesta,
                Revisor = reclamacion.Revisor,
            }.MainGridContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
