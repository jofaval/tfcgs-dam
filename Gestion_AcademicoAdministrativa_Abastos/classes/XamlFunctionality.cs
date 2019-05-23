using Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        internal static void QueryInfoOnWebsite(string url = "")
        {
            if (string.IsNullOrEmpty(url))
            {
                url = Constants.UrlHelper;
            }
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
            System.Diagnostics.Process.Start(process, url);
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

        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        /// by CrimsonX
        /// https://stackoverflow.com/questions/636383/how-can-i-find-wpf-controls-by-name-or-type
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }
}
