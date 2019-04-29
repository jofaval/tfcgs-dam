using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    public class XamlFunctionality
    {
        public static void FillDataGrid(DataGrid grid, IEnumerable<object> collection)
        {
            if (collection != null)
            {
                grid.ItemsSource = collection;
                var dataGridCols = grid.Columns;

                var dataGridColsLen = dataGridCols.Count;
                for (int colIterator = 0; colIterator < dataGridColsLen; colIterator++)
                {
                    var dataGridCol = dataGridCols[colIterator];
                    dataGridCol.MinWidth = dataGridCol.ActualWidth;
                    dataGridCol.Width = new DataGridLength(0.95, DataGridLengthUnitType.Star);
                }
            }
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

        private static UIElementCollection RemoveGridFromParent(Grid grid)
        {
            var gridParent = grid.Parent;
            var gridParentChildrens = ((Grid)gridParent).Children;
            gridParentChildrens.Remove(grid);
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

            return null;
        }

        public static void FillDataOfReadOnlyText(TextBox textBox, string content)
        {
            textBox.IsReadOnly = false;
            textBox.Text = content;
            textBox.IsReadOnly = true;
        }
    }
}
