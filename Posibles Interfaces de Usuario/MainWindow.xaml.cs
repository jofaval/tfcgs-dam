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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Posibles_Interfaces_de_Usuario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ApplicationTitle { get; set; }
        public const double TopBarHeight = 25;

        public RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
        public SolidColorBrush solidColorBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00000000"));
        public GradientStop gradientStopTop = new GradientStop((Color)ColorConverter.ConvertFromString("#FFA2FF00"), 0);
        public GradientStop gradientStopBottom = new GradientStop((Color)ColorConverter.ConvertFromString("#FFA2FF00"), 0);

        public int HeightRows { get; set; }

        public MainWindow()
        {
            DataContext = this;
            ApplicationTitle = "Gestión Académico-Administrativa Abastos";
            HeightRows = 100;
            radialGradientBrush.GradientStops.Add(gradientStopTop);
            radialGradientBrush.GradientStops.Add(gradientStopBottom);
            InitializeComponent();

            /*var screenSize = Screen.PrimaryScreen.Bounds.Size;
            WindowVar.Width = screenSize.Width;
            WindowVar.Height = screenSize.Height;*/

            var loginWindow = new LogIn();
            loginWindow.Visibility = Visibility.Visible;

            var mainGridContentChildrens = BackgroundGrid.Children;
            XamlBridge.BackgroundGrid = this.BackgroundGrid;
            XamlBridge.BackUpMainGridContent = MainGridContent;
            mainGridContentChildrens.Remove(MainGridContent);
            var loginWindowMainGrid = loginWindow.LogInMainGrid;
            XamlBridge.BackUpLoginGridContent = loginWindowMainGrid;
            loginWindow.TestGrid.Children.Remove(loginWindowMainGrid);
            mainGridContentChildrens.Add(loginWindowMainGrid);
            Grid.SetRow(loginWindowMainGrid, 1);
            loginWindow.Close();
            ControladorWPF.MaximizeNormalize(this, TopBar);
            BackgroundGrid.Margin = new Thickness(10);
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
                if (this.WindowState == ControladorWPF.WinowMaximizedState)
                {
                    TopBar.Height = Double.NaN;
                }
                else
                {
                    TopBar.Height = TopBarHeight;
                }
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            ControladorWPF.MaximizeNormalize(this, TopBar);
        }

        private void TopBar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ControladorWPF.MaximizeNormalize(this, TopBar);
            }
        }

        private void BtnMinimize_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = ControladorWPF.WinowMMinimizedState;
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            var mainGridContent = this.MainGridContent;
            var mainGridContentParent = mainGridContent.Parent;
            var mainGridContentParentChildrens = ((Grid) mainGridContentParent).Children;
            mainGridContentParentChildrens.Remove(mainGridContent);

            var buscador = new Buscador();

            var buscadorMainGridContent = buscador.MainGridContent;

            var parent = (Grid)(buscadorMainGridContent.Parent);
            parent.Children.Remove(buscadorMainGridContent);

            mainGridContentParentChildrens.Add(buscadorMainGridContent);
            buscador.Close();
        }
    }
}
