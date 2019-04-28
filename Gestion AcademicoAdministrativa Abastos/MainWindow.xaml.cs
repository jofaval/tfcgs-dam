using Controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Gestion_AcademicoAdministrativa_Abastos
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
            ApplicationTitle = Constants.ApplicationTitle;
            HeightRows = 100;
            radialGradientBrush.GradientStops.Add(gradientStopTop);
            radialGradientBrush.GradientStops.Add(gradientStopBottom);
            InitializeComponent();

            var screenSize = Screen.PrimaryScreen.Bounds.Size;
            WindowVar.Width = screenSize.Width;
            WindowVar.Height = screenSize.Height;

            XamlBridge.MainWinowInstance = this;
            XamlBridge.BackgroundGrid = BackgroundGrid;
            XamlBridge.BackUpMainPanel = MainPanel;

            var buttons = new Buttons();
            buttons.Close();

            var mainGridContentChildrens = MainGridContent.Children;

            var mainGridContent = buttons.MainGridContent;
            ((Grid)buttons.MainGridContent.Parent).Children.Remove(mainGridContent);

            mainGridContentChildrens.Add(mainGridContent);
            Grid.SetRow(mainGridContent, 0);

            ////DESCOMENTAR
            //var loginWindow = new LogIn
            //{
            //    Visibility = Visibility.Visible
            //};

            //var mainGridContentChildrens = BackgroundGrid.Children;
            //mainGridContentChildrens.Remove(MainGridContent);
            //var loginWindowMainGrid = loginWindow.LogInMainGrid;
            //XamlBridge.BackUpLoginGridContent = loginWindowMainGrid;
            //loginWindow.TestGrid.Children.Remove(loginWindowMainGrid);
            //mainGridContentChildrens.Add(loginWindowMainGrid);
            //Grid.SetRow(loginWindowMainGrid, 1);
            //loginWindow.Close();

            ControladorWPF.MaximizeNormalize(this, TopBar);
            BackgroundGrid.Margin = new Thickness(10);
            //XamlFunctionality.ChangeWindowContent(MainGridContent, buttons);
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

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = ControladorWPF.WinowMMinimizedState;
        }
    }
}
