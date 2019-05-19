using Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    public class XamlFunctionality
    {
        public static void FillDataGrid(DataGrid dataGrid, IEnumerable<object> collection)
        {
            if (collection != null)
            {
                dataGrid.ItemsSource = null;
                dataGrid.Items.Clear();
                dataGrid.ItemsSource = collection;
                var dataGridCols = dataGrid.Columns;

                var dataGridColsLen = dataGridCols.Count;
                for (int colIterator = 0; colIterator < dataGridColsLen; colIterator++)
                {
                    var dataGridCol = dataGridCols[colIterator];
                    dataGridCol.MinWidth = dataGridCol.ActualWidth;
                    dataGridCol.Width = new DataGridLength(0.95, DataGridLengthUnitType.Star);
                }
            }
        }

        internal static void QueryInfoOnWebsite()
        {
            var RunningProcessPaths = ProcessFileNameFinderClass.GetAllRunningProcessFilePaths();

            string process = "";

            var workingMsg = " está en funcionamiento,\nenseguida se abrirá.";
            if (RunningProcessPaths.Contains("chrome.exe"))
            {
                //firefox is running
                Notification.CreateNotificaion(string.Concat("chrome", workingMsg));
                process = "chrome.exe";
            }
            else if (RunningProcessPaths.Contains("firefox.exe"))
            {
                //Google Chrome is running
                Notification.CreateNotificaion(string.Concat("firefox", workingMsg));
                process = "firefox.exe";
            }
            else if (RunningProcessPaths.Contains("opera.exe"))
            {
                //Google Chrome is running
                Notification.CreateNotificaion(string.Concat("opera", workingMsg));
                process = "opera.exe";
            }
            System.Diagnostics.Process.Start(process, Constants.UrlHelper);
        }

        public static void ChangeWindowContent(Grid mainGrid, Window newWindow)
        {
            newWindow.Close();

            var newWindowMainGridContent = GetMainGridPanelFromWindow(newWindow);
            RemoveGridFromParent(newWindowMainGridContent);

            var mainGridParentChildrens = RemoveGridFromParent(mainGrid);
            mainGridParentChildrens.Add(newWindowMainGridContent);

            Grid.SetColumn(newWindowMainGridContent, 1);
            XamlBridge.MainPanelInstance = newWindowMainGridContent;
        }

        private static UIElementCollection RemoveGridFromParent(Grid dataGrid)
        {
            var gridParent = dataGrid.Parent;
            var gridParentChildrens = ((Grid)gridParent).Children;
            gridParentChildrens.Remove(dataGrid);
            return gridParentChildrens;
        }

        private static Grid GetMainGridPanelFromWindow(Window window)
        {
            if (window is Buscador buscador)
            {
                return buscador.MainGridContent;
            }
            else if (window is Horario horario)
            {
                return horario.MainPanel;
            }
            else if (window is MainWindow mainWindow)
            {
                return mainWindow.MainPanel;
            }
            else if (window is Buttons buttons)
            {
                return buttons.MainGridContent;
            }
            else if (window is LogIn login)
            {
                return login.MainPanel;
            }
            else if (window is Reclamaciones reclamaciones)
            {
                return reclamaciones.MainPanel;
            }
            else if (window is BuscadorV2 buscadorPersona)
            {
                return buscadorPersona.MainPanel;
            }

            return null;
        }

        public static void FillDataOfReadOnlyText(TextBox textBox, string content)
        {
            textBox.IsReadOnly = false;
            textBox.Text = content;
            textBox.IsReadOnly = true;
        }

        public static void ReadConfigurationFile()
        {

        }

        public static void ReadSavedUsernamePassword(LogIn logIn)
        {
            var file = Constants.UsernameFile;
            if (File.Exists(file))
            {
                var lines = File.ReadAllLines(file);
                logIn.UsernameField.Text =
                        Cryptography.Decrypt(
                            lines[0],
                            Constants.ApplicationTitle
                        );
                logIn.PasswordeField.Password =
                        Cryptography.Decrypt(
                            lines[1],
                            Constants.ApplicationTitle
                        );
            }
        }

        public static void WriteSaveUsernamePassword(LogIn logIn)
        {
            var file = Constants.UsernameFile;
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            using (StreamWriter w = File.AppendText(file))
            {
                w.WriteLine(
                    Cryptography.Encrypt(
                        logIn.UsernameField.Text,
                        Constants.ApplicationTitle
                    )
                    );

                w.WriteLine(
                    Cryptography.Encrypt(
                        logIn.PasswordeField.Password.ToString(),
                        Constants.ApplicationTitle
                    )
                );
            }
            var lines = File.ReadAllLines(file);
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<Window>().Any()
               : Application.Current.Windows.OfType<Window>().Any(w => w is T);
        }

        public static void CloseWindowInstancesOf<T>(string name = "") where T : Window
        {
            var openWindowsOfType = Application.Current.Windows.OfType<Window>().Where(w => w is T);
            foreach (var window in openWindowsOfType)
            {
                window.Close();
            }
        }

        public static bool CheckNet()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public static void ReplaceGrids(Grid originalGrid, Grid newGrid)
        {
            var originalGridChildren = ((Grid)originalGrid.Parent).Children;
            originalGridChildren.Remove(originalGrid);

            var newGridParent = (Grid)newGrid.Parent;
            if (newGridParent != null)
            {
                var newGridChildren = newGridParent.Children;
                newGridChildren.Remove(newGrid);
            }

            originalGridChildren.Add(newGrid);
        }
    }
}
