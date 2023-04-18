using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace SharpMSS
{
    public static partial class AILAPI
    {
        public static string GetLastError()
        {
            return Marshal.PtrToStringAnsi(AILAPI.LastError());
        }

        /// <summary>
        /// Decompresses a given file type
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <param name="dataSize">Size of the data to decompress</param>
        /// <param name="codec">Codec name of the file type</param>
        /// <param name="result">Reference to a buffer where the decompressed data is written to</param>
        /// <param name="resultsize">Reference to an interger how big the decompressed data is</param>
        /// <param name="decompressor">Preserved, set to <see cref="null"/></param>
        /// <returns></returns>
        [DllImport("mss32.dll", EntryPoint = "_AIL_decompress_ASI@24", CharSet = CharSet.Ansi)]
        public static extern int DecompressASI(
            [MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            int dataSize,
            string codec,
            ref IntPtr result,
            ref int resultsize,
            Decompressor decompressor
            );

        [DllImport("mss32.dll", EntryPoint = "_AIL_last_error@0")]
        public static extern IntPtr LastError();

        [DllImport("mss32.dll", EntryPoint = "_AIL_set_redist_directory@4", CharSet = CharSet.Ansi)]
        public static extern IntPtr SetRedistDirectory(string redistDir);

        [DllImport("mss32.dll", EntryPoint = "_AIL_mem_free_lock@4")]
        public static extern void MemFreeLock(IntPtr ptr);

        [Obsolete("Don't use. Causes crash")]
        [HandleProcessCorruptedStateExceptions]
        [DllImport("mss32.dll", EntryPoint = "_AIL_startup@0", CallingConvention = CallingConvention.StdCall)]
        public static extern int Startup();

        [DllImport("mss32.dll", EntryPoint = "_AIL_shutdown@0", CallingConvention = CallingConvention.StdCall)]
        public static extern int Shutdown();

        [DllImport("mss32.dll", EntryPoint = "_AIL_open_soundbank@8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr OpenSoundbank(
                string filename,
                string bankFilename
            );

        [DllImport("mss32.dll", EntryPoint = "_AIL_configure_logging@12", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void ConfigureLogging(
            string logFile,
            LogCallback logCallback,
            LogLevel logLevel
            );
    }
}
