using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpMSS;

namespace SharpMss32Example
{
    public partial class TestPanel : UserControl, IExamplePanel
    {
        public string PanelName => "Test Panel";

        public Control Control => this;

        private static IntPtr propertyname = Marshal.StringToCoTaskMemAnsi("SharpMss ExampleProvider");
        public TestPanel()
        {
            InitializeComponent();
        }

        ~TestPanel()
        {
            Debug.WriteLine($"Freeing {nameof(propertyname)}");
            Marshal.FreeCoTaskMem(propertyname);
        }

        private static int PROVIDER_propertyImpl(uint id, ref IntPtr data, int j, int k)
        {
            Debug.WriteLine($"Id = 0x{id:x}", category: nameof(PROVIDER_propertyImpl));
            switch (id)
            {
                case 0xffffff9b: // version
                    data = new IntPtr(0x130); // has to be >=1.3.0
                    return 1;
                case 0xffffff9c: // name
                    data = propertyname;
                    return 1;
                default:
                    break;
            }
            data = IntPtr.Zero;
            return 0;
        }

        static Stack<GCHandle> Sharpgch = new Stack<GCHandle>(10);
        private static int SharpEntry(
            int pHandle,
            RIBAPI.CallReason reason,
            RIBAPI.AllocProviderHandleDelegate allocProviderHandle,
            RIBAPI.RegisterInterfaceDelegate registerInterface,
            RIBAPI.UnregisterInterfaceDelegate unregisterInterface
            )
        {
            Debug.WriteLine($"Reason - {reason}", category: nameof(SharpEntry));

            if (reason == RIBAPI.CallReason.Unload)
            {
                unregisterInterface(pHandle, null, 0, null);

                foreach (var gch in Sharpgch)
                {
                    gch.Free();
                }

                Sharpgch.Clear();

                return 1;
            }

            // Minimal requirement
            var propertyImplFunc = new RIBAPI.PropertyDelegate(PROVIDER_propertyImpl);
            Sharpgch.Push(GCHandle.Alloc(propertyImplFunc));
            var interfaceData = new RIBAPI.InterfaceEntry()
            {
                Name = RIBAPI.ProviderProperty,
                Type = RIBAPI.InterfaceEntry.EntryType.Function,
                Data = Marshal.GetFunctionPointerForDelegate(propertyImplFunc),
                Format = RIBAPI.InterfaceEntry.FormatType.None,
            };
            Sharpgch.Push(GCHandle.Alloc(interfaceData));
            var registerResult = registerInterface(pHandle, "Test", 1, interfaceData);
            if (registerResult == RIBAPI.Result.NotFound)
            {
                Debug.WriteLine(AILAPI.GetLastError(), category: nameof(SharpEntry));
                Debugger.Break();
            }
            return 1;
        }

        private static void StaticApplicationProviderExample()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "MSS Bank|*.msscmp"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            AILAPI.OpenSoundbank(openFileDialog.FileName, null);

            Debug.WriteLine(AILAPI.GetLastError());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaticApplicationProviderExample();
        }
    }
}