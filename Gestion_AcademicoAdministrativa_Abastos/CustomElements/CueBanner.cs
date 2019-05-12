using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace Gestion_AcademicoAdministrativa_Abastos.CustomElements
{
    //https://jasonkemp.ca/blog/the-missing-net-4-cue-banner-in-wpf-i-mean-watermark-in-wpf/
    public static class CueBannerService
    {
        //there is absolutely no way to write this statement out
        //to look pretty
        public static readonly DependencyProperty CueBannerProperty = DependencyProperty.RegisterAttached(
                                      "CueBanner",
                                      typeof(object), typeof(CueBannerService),
                                      new FrameworkPropertyMetadata(null, CueBannerPropertyChanged));

        public static object GetCueBanner(Control control)
        {
            return control.GetValue(CueBannerProperty);
        }

        public static void SetCueBanner(Control control, object value)
        {
            control.SetValue(CueBannerProperty, value);
        }

        private static void CueBannerPropertyChanged(DependencyObject d,
                                             DependencyPropertyChangedEventArgs e)
        {
            Control control = (Control)d;
            control.Loaded += Control_Loaded;

            if (d is ComboBox || d is TextBox)
            {
                control.GotFocus += Control_GotFocus;
                control.LostFocus += Control_Loaded;
            }
        }

        private static void Control_GotFocus(object sender, RoutedEventArgs e)
        {
            Control c = (Control)sender;
            if (ShouldShowCueBanner(c))
            {
                RemoveCueBanner(c);
            }
        }

        private static void Control_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox senderAsTextBox)
            {
                Console.WriteLine(senderAsTextBox.Name);
                    var count = VisualTreeHelper.GetChildrenCount(senderAsTextBox);
                Console.WriteLine(count);
                for (int innerChildIterator = 0; innerChildIterator < count; innerChildIterator++)
                {
                    var children = VisualTreeHelper.GetChild(senderAsTextBox, innerChildIterator);
                }
            }
            Control control = (Control)sender;
            if (ShouldShowCueBanner(control))
            {
                ShowCueBanner(control);
            }
        }

        private static void RemoveCueBanner(UIElement control)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);
            layer.Visibility = Visibility.Hidden;

            Adorner[] adorners = layer.GetAdorners(control);
            if (adorners == null) return;
            foreach (Adorner adorner in adorners)
            {
                if (adorner is CueBannerAdorner)
                {
                    adorner.Visibility = Visibility.Hidden;
                    layer.Remove(adorner);
                }
            }
        }

        private static void ShowCueBanner(Control control)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);
            layer.Visibility = Visibility.Visible;
            layer.Add(new CueBannerAdorner(control, GetCueBanner(control)));
        }

        private static bool ShouldShowCueBanner(Control c)
        {
            DependencyProperty dp = GetDependencyProperty(c);
            if (dp == null) return true;
            return c.GetValue(dp).Equals("");
        }

        private static DependencyProperty GetDependencyProperty(Control control)
        {
            if (control is ComboBox)
                return ComboBox.TextProperty;
            if (control is TextBoxBase)
                return TextBox.TextProperty;
            return null;
        }
    }

    internal class CueBannerAdorner : Adorner
    {
        private readonly ContentPresenter contentPresenter;

        public CueBannerAdorner(UIElement adornedElement, object cueBanner) :
           base(adornedElement)
        {
            this.IsHitTestVisible = false;

            contentPresenter = new ContentPresenter
            {
                Content = cueBanner,
                Opacity = 0.7,
                Margin =
               new Thickness(Control.Margin.Left + Control.Padding.Left,
                             Control.Margin.Top + Control.Padding.Top, 0, 0),
            };
        }

        private Control Control
        {
            get { return (Control)this.AdornedElement; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return contentPresenter;
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            //here's the secret to getting the adorner
            //to cover the whole control
            contentPresenter.Measure(Control.RenderSize);
            return Control.RenderSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }
    }
}
