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
    /// Interaction logic for WR_Integer.xaml
    /// </summary>
    public partial class WR_Integer : UserControl
    {
        public WR_Integer()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Adapter.ExceptionCode != ExceptionCode.ExceptionNo) return;
                this.txtIO.Text = Adapter.PlcInstance.Read(this.txtAddress.Text.Trim()).ToString();
            }
            catch (Exception ex)
            {
                ProfinetTrace.Error(ex.Message, "Read/Write Integer");
            }
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Adapter.ExceptionCode != ExceptionCode.ExceptionNo) return;
                Adapter.PlcInstance.Write(this.txtIO.Text.Trim(), this.txtAddress.Text.Trim()).ToString();

            }
            catch (Exception ex)
            {
                ProfinetTrace.Error(ex.Message, "Read/Write Integer");
            }
        }
    }
}
