using Model;
using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para SQLEditor.xaml
    /// </summary>
    public partial class SQLEditor : Window
    {
        public SQLEditor()
        {
            InitializeComponent();
        }

        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string script = TxtQuery.Text;
                var abastosConnectionString = ConfigurationManager.ConnectionStrings["Abastos"].ConnectionString;

                using (var connectionSQL = new SqlConnection(abastosConnectionString))
                {
                    using (var dataAdapter = new SqlDataAdapter(script, connectionSQL))
                    {
                        var dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        DataGridResult.ItemsSource = dataTable.DefaultView;
                        Notification.CreateNotification("Se ha ejecutado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                Notification.CreateNotification(ex.Message);
            }
        }
    }
}
