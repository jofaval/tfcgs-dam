using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Posibles_Interfaces_de_Usuario
{
    public class ControladorWPF
    {
        public const WindowState WinowNormalState = System.Windows.WindowState.Normal;
        public const WindowState WinowMaximizedState = System.Windows.WindowState.Maximized;
        public const WindowState WinowMMinimizedState = System.Windows.WindowState.Minimized;

        public const int MarginMaximizedState = 0;
        public const int MarginNormalState = 10;

        public const Visibility visible = Visibility.Visible;
        public const Visibility hidden = Visibility.Hidden;

        public const double TopBarHeight = 25;

        public static void MaximizeNormalize(Window targetdWindow, Grid TopBar)
        {
            var margin = ((MainWindow)targetdWindow).BackgroundGrid.Margin;
            var margin2 = targetdWindow.Margin;
            if (targetdWindow.WindowState == WinowNormalState)
            {
                //BackgroundGrid.Background = radialGradientBrush;
                TopBar.Height = Double.NaN;
                targetdWindow.WindowState = WinowMaximizedState;
                /*margin = new Thickness(MarginMaximizedState);
                margin2 = new Thickness(MarginMaximizedState);*/
            }
            else
            {
                //BackgroundGrid.Background = solidColorBrush;
                TopBar.Height = TopBarHeight;
                targetdWindow.WindowState = WinowNormalState;
                /*margin = new Thickness(MarginNormalState);
                margin2 = new Thickness(MarginNormalState);*/
            }
        }

        public static void ChangeVisibility(Window targetdWindow)
        {
            if (targetdWindow.Visibility == hidden)
            {
                targetdWindow.Visibility = visible;
            }
            else
            {
                targetdWindow.Visibility = hidden;
            }
        }
    }
}
