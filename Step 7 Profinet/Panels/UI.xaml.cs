using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Step_7_Profinet.Panels
{
    /// <summary>
    /// Interaction logic for UI.xaml
    /// </summary>
    public partial class UI : UserControl
    {
        public UI()
        {
            InitializeComponent();
        }
        private void UIConnectionOn(object sender, RoutedEventArgs e)
        {
            this.readWritePanel.IsEnabled = true;
            this.readWritePanel.Opacity = 1;
        }
        private void UIConnectionOff(object sender, RoutedEventArgs e)
        {
            this.readWritePanel.IsEnabled = false;
            this.readWritePanel.Opacity = .4;
        }

        private void Minimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RaiseMinimizeEvent();
        }

        private void Close_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            RaiseCloseEvent();
        }
        //***************************************
        //----------------------
        /// <summary>
        /// Onsaveclick event to listen process from outside of the component
        /// </summary>
        public static readonly RoutedEvent MinimizeEvent = EventManager.RegisterRoutedEvent(
         "Minimize", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UI));
        // Provide CLR accessors for the event
        public event RoutedEventHandler Minimize
        {
            add { AddHandler(MinimizeEvent, value); }
            remove { RemoveHandler(MinimizeEvent, value); }
        }
        // This method raises the Save event
        void RaiseMinimizeEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(UI.MinimizeEvent);
            RaiseEvent(newEventArgs);
        }
        //--------------------
        //***************************************
        //----------------------
        /// <summary>
        /// Onsaveclick event to listen process from outside of the component
        /// </summary>
        public static readonly RoutedEvent CloseEvent = EventManager.RegisterRoutedEvent(
         "Close", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UI));
        // Provide CLR accessors for the event
        public event RoutedEventHandler Close
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }
        // This method raises the Save event
        void RaiseCloseEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(UI.CloseEvent);
            RaiseEvent(newEventArgs);
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            this.hareExit.Visibility = Visibility.Visible;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.hareExit.Visibility = Visibility.Collapsed;
        }

        private void Image_MouseEnter_1(object sender, MouseEventArgs e)
        {
            this.hareMin.Visibility = Visibility.Visible;
        }

        private void Image_MouseLeave_1(object sender, MouseEventArgs e)
        {
            this.hareMin.Visibility = Visibility.Collapsed;
        }
        //--------------------
    }
}
