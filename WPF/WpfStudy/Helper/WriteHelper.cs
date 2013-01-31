using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public static class WriteHelper
    {
        public static void DebugWrite(this string mes, string title = "")
        {
            System.Diagnostics.Debug.WriteLine(string.Format("-----------------------------{0} START---------------------------------", title));
            System.Diagnostics.Debug.WriteLine(mes);
            System.Diagnostics.Debug.WriteLine(string.Format("-----------------------------{0} END---------------------------------", title));
        }
    }
}
