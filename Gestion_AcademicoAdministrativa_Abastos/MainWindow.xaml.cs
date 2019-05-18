using Controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ApplicationTitle { get; set; }

        public int HeightRows { get; set; }

        public MainWindow()
        {
            PreLoadedContent();
            InitializeComponent();

            var screenSize = Screen.PrimaryScreen.Bounds.Size;
            WindowVar.Width = screenSize.Width;
            WindowVar.Height = screenSize.Height;

            MaximizeMinimize();

            Left = 0;
            Top = 0;

            BackgroundGrid.Margin = new Thickness(5);
            FillMainData();
        }

        internal void CloseApp()
        {
            Close();
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

        public void MakeDataEditable()
        {
            var isNotEditable = TxtNombre.IsReadOnly;

            if (!isNotEditable)
            {
                TxtNombre.Select(0, 0);
                var currentUserPerson = XamlBridge.CurrentUser.Persona1;
                currentUserPerson.Nombre = TxtNombre.Text;
                currentUserPerson.Apellidos = TxtApellidos.Text;
                currentUserPerson.Email = TxtEmail.Text;

                StaticReferences.Initializer();
                var context = StaticReferences.Context;
                context.SaveChanges();
            }

            TxtNombre.IsReadOnly = !TxtNombre.IsReadOnly;
            TxtApellidos.IsReadOnly = !TxtApellidos.IsReadOnly;
            TxtEmail.IsReadOnly = !TxtEmail.IsReadOnly;
        }

        public void FillMainData()
        {
            var user = XamlBridge.CurrentUser;
            if (user != null)
            {
                var persona = user.Persona1;

                XamlFunctionality.FillDataOfReadOnlyText(TxtDni, persona.Dni);
                XamlFunctionality.FillDataOfReadOnlyText(TxtNif, persona.Nif);
                XamlFunctionality.FillDataOfReadOnlyText(TxtNombre, persona.Nombre);
                XamlFunctionality.FillDataOfReadOnlyText(TxtApellidos, persona.Apellidos);
                XamlFunctionality.FillDataOfReadOnlyText(TxtEmail, persona.Email);
                var telefonos = from telefono in persona.Telefono.ToList()
                                select new
                                {
                                    Telefono = telefono.Telefono1,
                                    telefono.Comentario,
                                };

                XamlFunctionality.FillDataGrid(DataGridTelefono, telefonos);
            }
        }

        internal void MaximizeMinimize()
        {
            ControladorWPF.MaximizeNormalize(this, TopBar);
            if (WindowState == WindowState.Maximized)
            {
                BackgroundGrid.Margin = new Thickness(0);
            }
            else
            {
                BackgroundGrid.Margin = new Thickness(Constants.MainWindowThickness);
            }
        }

        internal void SetSize(int[] windowSizeArray)
        {
            Width = windowSizeArray[0];
            Height = windowSizeArray[1];
            CenterScreen();
        }

        private void CenterScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = Width;
            double windowHeight = Height;
            Left = (screenWidth / 2) - (windowWidth / 2);
            Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void PreLoadedContent()
        {
            DataContext = this;
            ApplicationTitle = Constants.ApplicationTitle;
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

        public void RemoveButtonsFromButtonPanel()
        {
            var buttonChildrens = MainGridContent.Children;
            buttonChildrens.Remove(buttonChildrens[0]);
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
                if (WindowState == ControladorWPF.WinowMaximizedState)
                {
                    TopBar.Height = double.NaN;
                }
                else
                {
                    TopBar.Height = Constants.TopBarHeight;
                }
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (!XamlFunctionality.IsWindowOpen<Configuration>(nameof(Configuration)))
            {
                var config = new Configuration()
                {
                    Visibility = Visibility.Visible
                };
            }
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
            WindowState = ControladorWPF.WinowMMinimizedState;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(0.25 * 1000));
            anim.Completed += (s, _) => System.Windows.Application.Current.Shutdown();
            BeginAnimation(OpacityProperty, anim);
        }

        private void WindowVar_Activated(object sender, EventArgs e)
        {
            Topmost = false;
        }

        private void MainWindow_OnActivated(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => WindowStyle = WindowStyle.None));
        }
    }
}
