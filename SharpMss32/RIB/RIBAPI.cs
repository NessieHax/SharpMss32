using System;
using System.Runtime.InteropServices;

namespace SharpMSS
{
    // <https://github.com/CookiePLMonster/VBdec/blob/master/mss/mss.h>
    public static partial class RIBAPI
    {
        [DllImport("mss32.dll", EntryPoint = "_RIB_load_static_provider_library@8", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int LoadStaticProviderLibrary(
            MainEntryPoint entry,
            string name
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_alloc_provider_handle@4")]
        public static extern int AllocProviderHandle(
            IntPtr hModule
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_free_provider_handle@4")]
        public static extern void FreeProviderHandle(
            int pHandle
            );

        /// <summary>
        /// Allocates internal provider, loads provider via <see cref="Kernel32.LoadLibrary(string)"/>
        /// and calls its <see cref="MainEntryPoint"/> with <see cref="CallReason.Load"/>
        /// </summary>
        /// <param name="filename">File path to .asi, .flt or .mix</param>
        /// <returns>Provider handle</returns>
        [DllImport("mss32.dll", EntryPoint = "_RIB_load_provider_library@4", CharSet = CharSet.Ansi)]
        public static extern int LoadProviderLibrary(
            string filename
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_free_provider_library@4")]
        public static extern void FreeProviderLibrary(
            int pHandle
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_register_interface@16", CharSet = CharSet.Ansi)]
        public static extern Result RegisterInterface(
            int pHandle,
            string interfaceName,
            int count,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeConst = 4)]
            ref InterfaceEntry[] items
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_request_interface@16", CharSet = CharSet.Ansi)]
        public static extern Result RequestInterface(
            int pHandle,
            string interfaceName,
            int count,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)]
            ref InterfaceEntry[] item
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_request_interface_entry@20", CharSet = CharSet.Ansi)]
        public static extern Result RequestInterfaceEntry(
            int pHandle,
            string interfaceName,
            InterfaceEntry.EntryType entryType,
            string entryName,
            ref IntPtr data
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_unregister_interface@16", CharSet = CharSet.Ansi)]
        public static extern Result UnregisterInterface(
            int pHandle,
            string interfaceName,
            int count,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeConst = 4)]
            InterfaceEntry[] items
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_enumerate_interface@20", CharSet = CharSet.Ansi)]
        public static extern int EnumerateInterface(
            int pHandle,
            string interfaceName,
            InterfaceEntry.EntryType entryType,
            ref int next,
            [MarshalAs(UnmanagedType.LPStruct)]
            ref InterfaceEntry interfaceEntry
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_enumerate_providers@12", CharSet = CharSet.Ansi)]
        public static extern int EnumerateProviders(
            string interfaceName,
            ref int next,
            ref IntPtr pHandle
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_type_string@8", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TypeString(
            IntPtr data,
            InterfaceEntry.FormatType format
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_find_file_provider@12", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindFileProvider(
            string interfaceName,
            string attributeName,
            string fileSuffix
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_find_files_provider@20", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int FindFilesProvider(
            string interfaceName,
            string attributeName1,
            string fileSuffix1,
            string attributeName2,
            string fileSuffix2
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_find_file_dec_provider@20", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void FindFileDecProvider(
            string interfaceName,
            string attributeName1,
            int attributeValue1,
            string attributeName2,
            string fileSuffix2
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_find_provider@12", CharSet = CharSet.Ansi)]
        public static extern void FindProvider(
            string interfaceName,
            string attributeName,
            string attributeValue
            );

        /// <summary>
        /// Loads all providers found in <see cref="AILAPI.SetRedistDirectory(string)"/> that match <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">Wildcard allowed filter like "*.asi"</param>
        [DllImport("mss32.dll", EntryPoint = "_RIB_load_application_providers@4", CharSet = CharSet.Ansi)]
        public static extern void LoadApplicationProviders(
            string filter
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_set_provider_user_data@12")]
        public static extern void SetProviderUserData(
            int pHandle,
            int index,
            IntPtr data
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_provider_user_data@8")]
        public static extern IntPtr ProviderUserData(
            int pHandle,
            int index
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_set_provider_system_data@12")]
        public static extern void SetProviderSystemData(
            int pHandle,
            int index,
            IntPtr data
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_provider_system_data@8")]
        public static extern IntPtr ProviderSystemData(
            int pHandle,
            int index
            );

        [DllImport("mss32.dll", EntryPoint = "_RIB_error@0")]
        public static extern IntPtr Error();
    }
}
