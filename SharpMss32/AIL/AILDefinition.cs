using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpMSS
{
    public partial class AILAPI
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int Decompressor();

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void LogCallback(string msg, int indent);

        public enum LogLevel : int
        {
            None,
            Debug,
            SysDebug
        }
    }
}
