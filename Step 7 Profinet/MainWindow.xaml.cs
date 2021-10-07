using Step_7_Profinet.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Step_7_Profinet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window init = null;
        public MainWindow()
        {
            InitializeComponent();
            init = Window.GetWindow(this);
            this.Name = "MainWindow";

            Trace.WriteLine("##################################");
            ProfinetTrace.Info("Application Started", this.Name);
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void OnSplashEnd(object sender, RoutedEventArgs e)
        {
            this.userInterface.Visibility = Visibility.Visible;
            this.Width = this.userInterface.ActualWidth;
            this.Height = this.userInterface.ActualHeight;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void MinimizeCommand(object sender, RoutedEventArgs e)
        {
            init.WindowState = WindowState.Minimized;
        }
        private void CloseCommand(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
