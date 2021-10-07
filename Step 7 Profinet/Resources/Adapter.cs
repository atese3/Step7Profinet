using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_7_Profinet.Resources
{
    public static class Adapter
    {
        private static PLC _plcInstance = null;
        private static ExceptionCode _exceptionCode = ExceptionCode.ExceptionNo;

        public static ExceptionCode ExceptionCode
        {
            get { return Adapter._exceptionCode; }
            set { Adapter._exceptionCode = value; }
        }
        public static PLC PlcInstance
        {
            get { return Adapter._plcInstance; }
            set { Adapter._plcInstance = value; }
        }
        public static bool SetPlcInstance(CPU_Type cpuType, string ipAddress, short numericUpDownRack, short numericUpDownSlot)
        {
            try
            {
                PlcInstance = new PLC(cpuType, ipAddress, numericUpDownRack, numericUpDownSlot);
                return true;
            }
            catch (Exception ex)
            {
                ProfinetTrace.Error(ex.Message, "Adapter Class");
                return false;
            }
        }
    }
}
