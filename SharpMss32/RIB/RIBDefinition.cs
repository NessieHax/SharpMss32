using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SharpMSS
{
    public partial class RIBAPI
    {
        /// <summary>
        /// Default entry name of AIL providers(.asi, .flt and .mix)
        /// </summary>
        [Obsolete]
        public const string MainEntryPointName = "_RIB_Main@20";

        public const string ProviderProperty = "PROVIDER_property";

        public enum Result : int
        {
            Success,         // Success -- no error
            NotAllAvailable, // Some requested functions/attribs not available
            NotFound,        // Resource not found
            OutOfMemory,     // Out of system RAM
        }

        public enum CallReason : int
        {
            Unload,
            Load
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int PropertyDelegate(
            uint id,
            ref IntPtr data,
            int i,
            int j
            );

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int AllocProviderHandleDelegate(
            IntPtr hModule
            );

        /// <summary>
        /// TODO: allow <see cref="InterfaceEntry"/>[]
        /// </summary>
        /// <param name="pHandle">Handle to the provider</param>
        /// <param name="interfaceName"></param>
        /// <param name="itemCount"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate Result RegisterInterfaceDelegate(
            int pHandle,
            string interfaceName,
            int itemCount,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)]
            InterfaceEntry[] items
            );

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate Result UnregisterInterfaceDelegate(
            int pHandle,
            string interfaceName,
            int count,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)]
            InterfaceEntry[] items
            );

        /// <summary>
        /// Provides delegate for <see cref="LoadStaticProviderLibrary(MainEntryPoint, string)"/>
        /// </summary>
        /// <param name="pHandle">Provider handle</param>
        /// <param name="reason">Reason why this entry was called</param>
        /// <param name="allocProviderHandle">Allocator for provider handle if needed</param>
        /// <param name="registerInterface">Register provider interfaces</param>
        /// <param name="unregisterInterface">Unregister provider</param>
        /// <returns>1 on success, otherwise 0;</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate int MainEntryPoint(int pHandle, CallReason reason,
            AllocProviderHandleDelegate allocProviderHandle,
            RegisterInterfaceDelegate registerInterface,
            UnregisterInterfaceDelegate unregisterInterface
            );

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Size = 0x10, Pack = 4)]
        public class InterfaceEntry
        {
            public enum EntryType : int
            {
                Function,
                Attribute,
                Preference
            }

            public enum FormatType : int
            {
                None = 0, // No type
                Custom,   // Used for pointers to application-specific structures
                Dec,      // Used for 32-bit integer values to be reported in decimal
                Hex,      // Used for 32-bit integer values to be reported in hex
                Float,    // Used for 32-bit single-precision FP values
                Percent,  // Used for 32-bit single-precision FP values to be reported as percentages
                Bool,     // Used for Boolean-constrained integer values to be reported as TRUE or FALSE
                String    // Used for pointers to null-terminated ASCII strings
            }

            /// <summary>
            /// Type of data this entry hold (see <see cref="EntryType"/>).
            /// </summary>
            [FieldOffset(0x00)]
            public EntryType Type;

            /// <summary>
            /// Name of the entry.
            /// </summary>
            [FieldOffset(0x04)]
            public string Name;

            /// <summary>
            /// Arbitrary data this entry holds
            /// </summary>
            [FieldOffset(0x08)]
            public IntPtr Data;

            /// <summary>
            /// Format type for <see cref="Data"/>.
            /// </summary>
            [FieldOffset(0x0C)]
            public FormatType Format;
        }

    }
}
