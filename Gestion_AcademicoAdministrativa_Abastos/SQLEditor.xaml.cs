using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string script = TxtQuery.Text;
            using (var dataBaseContext = new AbastosDbContext())
            {
                try
                {
                    var resultList = dataBaseContext.Database.SqlQuery<List<string>>(script).ToList();

                    Console.WriteLine(resultList.ToString());

                    foreach (var item in resultList)
                    {
                        if (item is List<string> itemList)
                        {
                            foreach (var element in itemList)
                            {
                                Console.WriteLine(element);
                            }
                        }
                    }

                    DataGridResult.ItemsSource = resultList;
                }
                catch (Exception ex)
                {
                    Notification.CreateNotificaion(ex.Message);
                }
            }
        }
    }
}
