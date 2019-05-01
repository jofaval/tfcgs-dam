using Controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Gestion AcademicoAdministrativa Abastos
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

        internal void CloseApp()
        {
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        internal void RestartApp()
        {
            CloseApp();
            var splashScreen = new SplashScreen
            {
                Visibility = Visibility.Visible,
            };
        }

        public int HeightRows { get; set; }

        public MainWindow()
        {
            PreLoadedContent();

            InitializeComponent();

            var screenSize = Screen.PrimaryScreen.Bounds.Size;
            WindowVar.Width = screenSize.Width;
            WindowVar.Height = screenSize.Height;

            XamlBridge.MainWinowInstance = this;
            XamlBridge.BackgroundGrid = BackgroundGrid;
            XamlBridge.MainPanelInstance = MainPanel;
            //UIElementCollection mainGridContentChildrens = AddButtonPanel();

            ControladorWPF.MaximizeNormalize(this, TopBar);
            BackgroundGrid.Margin = new Thickness(10);
            FillMainData();
        }

        public void FillMainData()
        {
            var user = XamlBridge.CurrentUser;
            if (user != null)
            {
                var persona = user.Persona1;
                Console.WriteLine(persona.Nombre);

                XamlFunctionality.FillDataOfReadOnlyText(TxtDni, persona.Dni);
                XamlFunctionality.FillDataOfReadOnlyText(TxtNif, persona.Nif);
                XamlFunctionality.FillDataOfReadOnlyText(TxtNombre, persona.Nombre);
                XamlFunctionality.FillDataOfReadOnlyText(TxtApellidos, persona.Apellidos);
                XamlFunctionality.FillDataOfReadOnlyText(TxtEmail, persona.Email);
                DataGridTelefono.ItemsSource = persona.Telefono;
            }
        }

        private void PreLoadedContent()
        {
            DataContext = this;
            ApplicationTitle = Constants.ApplicationTitle;

            HeightRows = 100;

            radialGradientBrush.GradientStops.Add(gradientStopTop);
            radialGradientBrush.GradientStops.Add(gradientStopBottom);
        }

        public UIElementCollection AddButtonPanel()
        {
            var buttons = new Buttons();
            buttons.Close();

            var mainGridContentChildrens = MainGridContent.Children;

            var mainGridContent = buttons.MainGridContent;
            ((Grid)buttons.MainGridContent.Parent).Children.Remove(mainGridContent);

            mainGridContentChildrens.Add(mainGridContent);
            Grid.SetRow(mainGridContent, 0);

            return mainGridContentChildrens;
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
