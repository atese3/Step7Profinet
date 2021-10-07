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
    /// Interaction logic for WR_RealNumber.xaml
    /// </summary>
    public partial class WR_RealNumber : UserControl
    {
        private int db;
        private int startByteAddr;
        public WR_RealNumber()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (Adapter.ExceptionCode != ExceptionCode.ExceptionNo) return;
                string[] tempStrg = this.txtAddress.Text.Trim().Split('.');
                int size = tempStrg.Length;
                double value = 0;
                db = 0;
                startByteAddr = 0;
                if (size >= 2)
                {
                    db = int.Parse(tempStrg[0].Substring(2, tempStrg[0].Length - 2));
                    startByteAddr = int.Parse(tempStrg[1].Substring(3, tempStrg[1].Length - 3));
                }
                ProfinetTrace.Info("Read Value = " + value.ToString(), "Read/Write Real Number");
                value = Types.Double.FromDWord((uint)Adapter.PlcInstance.Read(this.txtAddress.Text.Trim()));
                this.txtIO.Text = value.ToString("0.#");
            }
            catch (Exception ex)
            {
                ProfinetTrace.Error(ex.Message, "Read/Write Real Number");
            }
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Adapter.ExceptionCode != ExceptionCode.ExceptionNo) return;
                byte[] values = Types.Double.ToByteArray(double.Parse(this.txtAddress.Text.Trim()));
                if (db != 0 && startByteAddr != 0)
                    Adapter.PlcInstance.WriteBytes(DataType.DataBlock, 90, 248, values);
                else
                    Adapter.PlcInstance.WriteBytes(DataType.Marker, 0, int.Parse(this.txtIO.Text.Trim().Substring(2, this.txtIO.Text.Length - 2)), values);
            }
            catch (Exception ex)
            {
                ProfinetTrace.Error(ex.Message, "Read/Write Real Number");
            }
              
        }
    }
}
