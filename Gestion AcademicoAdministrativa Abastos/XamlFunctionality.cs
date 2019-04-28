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

        public static void ChangeWindowContent(Grid mainGridContent, Window newWindow)
        {
            var mainGridContentParentChildrens = RemoveGridFromParent(mainGridContent);

            var newWindowMainGridContent = GetMainGridPanelFromWindow(newWindow);

            var parent = (Grid) (newWindowMainGridContent.Parent);
            parent.Children.Remove(newWindowMainGridContent);

            mainGridContentParentChildrens.Add(newWindowMainGridContent);
            newWindow.Close();
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
                return horario.MainGridContent;
            }
            else if (window is MainWindow mainWindow)
            {
                return mainWindow.MainGridContent;
            }
            else if (window is Buttons buttons)
            {
                return buttons.MainGridContent;
            }

            return null;
        }
    }
}
