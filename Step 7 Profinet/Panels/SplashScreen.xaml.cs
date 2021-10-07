using Step_7_Profinet.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : UserControl
    {
        //***************************************
        Timer cycleTimer;

        private void start()
        {
            cycleTimer = new Timer();
            cycleTimer.Elapsed += new ElapsedEventHandler(CycleTimedEvent);
            cycleTimer.Interval = 5000;
            cycleTimer.Enabled = true;
        }
        private void CycleTimedEvent(object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Visibility = Visibility.Collapsed;
                cycleTimer.Stop();
                RaiseOnCloseEvent();
                ProfinetTrace.Info("Animation Stopped", "Splash Screen");
            });
        }
        //***************************************
        //----------------------
        /// <summary>
        /// Onsaveclick event to listen process from outside of the component
        /// </summary>
        public static readonly RoutedEvent OnCloseEvent = EventManager.RegisterRoutedEvent(
         "OnClose", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SplashScreen));
        // Provide CLR accessors for the event
        public event RoutedEventHandler OnClose
        {
            add { AddHandler(OnCloseEvent, value); }
            remove { RemoveHandler(OnCloseEvent, value); }
        }
        // This method raises the Save event
        void RaiseOnCloseEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(SplashScreen.OnCloseEvent);
            RaiseEvent(newEventArgs);
        }
        //--------------------
        public SplashScreen()
        {
            InitializeComponent();
            start();
            ProfinetTrace.Info("Animation Started", "Splash Screen");
        }
    }
}
