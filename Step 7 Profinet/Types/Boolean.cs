using System;
using System.Collections.Generic;
using System.Text;

namespace Step_7_Profinet.Types
{
    public static class Boolean
    {
        public static bool GetValue(byte value, int bit)
        {
            if ((value & (int)Math.Pow(2, bit)) != 0)
                return true;
            else
                return false;
        }

        public static byte SetBit(byte value, int bit)
        {
            return (byte)(value | (byte)Math.Pow(2, bit));
        }

        public static byte ClearBit(byte value, int bit)
        {
            return (byte)(value & (byte)(~(byte)Math.Pow(2, bit)));
        }

    }
}
