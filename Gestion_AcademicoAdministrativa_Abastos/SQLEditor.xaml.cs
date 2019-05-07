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
                        var ds = new DataSet();
                        dataAdapter.Fill(ds);
                        DataGridResult.ItemsSource = ds.Tables[0].AsEnumerable().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Notification.CreateNotificaion(ex.Message);
            }
        }
    }
}
