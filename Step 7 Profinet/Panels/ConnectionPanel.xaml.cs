using Step_7_Profinet.Resources;
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
    /// Interaction logic for ConnectionPanel.xaml
    /// </summary>
    public partial class ConnectionPanel : UserControl
    {
        private PLC plc = null;

        public ConnectionPanel()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIPAddress.Text)) throw new Exception("Please enter the IP address");
                int selectionIndex = comboPlcName.SelectedIndex;
                CPU_Type cpuType = CPU_Type.S7200;
                string ipAddress = txtIPAddress.Text.Trim();
                switch (selectionIndex)
                {
                    case 0:
                        cpuType = CPU_Type.S7200;
                        break;
                    case 1:
                        cpuType = CPU_Type.S7300;
                        break;
                    case 2:
                        cpuType = CPU_Type.S7400;
                        break;
                    case 3:
                        cpuType = CPU_Type.S71200;
                        break;
                    default:
                        comboPlcName.SelectedIndex = 3;
                        cpuType = CPU_Type.S71200;
                        break;
                }
                bool success = Adapter.SetPlcInstance(cpuType, ipAddress, (short)numericUpDownRack.Value, (short)numericUpDownSlot.Value);

                if (!success) throw new Exception("PLC Adapter Connection Failed");

                plc = Adapter.PlcInstance;
                if (!plc.IsAvailable) throw new Exception("Cannot Find PLC to Connect to");
                Adapter.ExceptionCode = plc.Open();
                if (Adapter.ExceptionCode != ExceptionCode.ExceptionNo) throw new Exception(plc.lastErrorString);
                this.SetEnabledButtons(false);
                RaiseConnectionOnEvent();
            }
            catch (Exception ex)
            {
                ProfinetTrace.Error(ex.Message, "Connection Panel");
            }
        }
        private void SetEnabledButtons(bool input)
        {
            this.btnConnect.IsEnabled = input;
            this.btnDisconnect.IsEnabled = !input;
            this.numericUpDownRack.IsEnabled = input;
            this.numericUpDownSlot.IsEnabled = input;
            this.txtIPAddress.IsEnabled = input;
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.SetEnabledButtons(true);
                RaiseConnectionOffEvent();
            }
            catch (Exception ex)
            {
                ProfinetTrace.Error(ex.Message, "Connection Panel");
            }
        }

        //***************************************
        //----------------------
        /// <summary>
        /// Onsaveclick event to listen process from outside of the component
        /// </summary>
        public static readonly RoutedEvent ConnectionOnEvent = EventManager.RegisterRoutedEvent(
         "ConnectionOn", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ConnectionPanel));
        // Provide CLR accessors for the event
        public event RoutedEventHandler ConnectionOn
        {
            add { AddHandler(ConnectionOnEvent, value); }
            remove { RemoveHandler(ConnectionOnEvent, value); }
        }
        // This method raises the Save event
        void RaiseConnectionOnEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ConnectionPanel.ConnectionOnEvent);
            RaiseEvent(newEventArgs);
        }
        //--------------------
        //***************************************
        //----------------------
        /// <summary>
        /// Onsaveclick event to listen process from outside of the component
        /// </summary>
        public static readonly RoutedEvent ConnectionOffEvent = EventManager.RegisterRoutedEvent(
         "ConnectionOff", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ConnectionPanel));
        // Provide CLR accessors for the event
        public event RoutedEventHandler ConnectionOff
        {
            add { AddHandler(ConnectionOffEvent, value); }
            remove { RemoveHandler(ConnectionOffEvent, value); }
        }
        // This method raises the Save event
        void RaiseConnectionOffEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ConnectionPanel.ConnectionOffEvent);
            RaiseEvent(newEventArgs);
        }
        //--------------------
    }
}
