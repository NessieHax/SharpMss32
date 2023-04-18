using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpMSS
{
    public class LibHandle
    {
        private IntPtr _handle;
        private Exception _lastException;

        public Exception LastException => _lastException;

        public LibHandle(string dllname)
        {
            _handle = Kernel32.LoadLibrary(dllname);
            if (!IsValidPtr(_handle))
            {
                throw new Exception("Failed to load dll into system memory", _lastException);
            }
        }

        private Exception GetWin32Exception()
        {
            return Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        private bool IsValidPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                _lastException = GetWin32Exception();
                return false;
            }
            return true;
        }

        public bool TryGetProcDelegate<TDelegate>(string procName, out TDelegate func) where TDelegate : Delegate
        {
            var result = Kernel32.GetProcAddress(_handle, procName);
            bool success = IsValidPtr(result);
            func = success
                ? Marshal.GetDelegateForFunctionPointer<TDelegate>(result)
                : default!;
            return success;
        }

        public void Release()
        {
            Kernel32.FreeLibrary(_handle);
        }

        ~LibHandle()
        {
            Release();
        }

    }
}
