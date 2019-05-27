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

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para RevisarReclamaciones.xaml
    /// </summary>
    public partial class RevisarReclamaciones : Window
    {
        public List<Model.Reclamacion> PendingRecalmaciones { get; set; }
        public RevisarReclamaciones()
        {
            InitializeComponent();
            PendingRecalmaciones = StaticReferences.Context.ReclamacionDbSet
                .Where(r => !r.EnTramite.HasValue)
                .ToList();
            DataGridReclamacionesPendientes.ItemsSource = PendingRecalmaciones;

    }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
