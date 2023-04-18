using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using SharpMSS;

namespace SharpMss32Example
{
    public partial class Binka2WavPanel : UserControl, IExamplePanel
    {
        private string binkaFilepath;

        public Binka2WavPanel()
        {
            InitializeComponent();
        }

        public Control Control => this;

        public string PanelName => "Binka 2 Wav Example";

        private static void LogMssDebug(string msg, int indent)
        {
            Debug.WriteLine($"{nameof(LogMssDebug)} captured: '{msg}'");
        }

        private static bool TryConvertToWav(string filename, out byte[] buffer)
        {
            byte[] inputFiledata = File.ReadAllBytes(filename);
            var logFn = new AILAPI.LogCallback(LogMssDebug);
            var gch = GCHandle.Alloc(logFn);
            AILAPI.ConfigureLogging($"{nameof(Binka2WavPanel)}.mss32.log", logFn, AILAPI.LogLevel.Debug);
            int pHandle = RIBAPI.LoadProviderLibrary("binkawin.asi");
            int resultBufferSize = 0;
            IntPtr resultBuffer = new IntPtr();
            string extension = Path.GetExtension(filename);
            var decompRes = AILAPI.DecompressASI(inputFiledata, inputFiledata.Length, extension, ref resultBuffer, ref resultBufferSize, null);
            if (decompRes == 0)
            {
                Debug.WriteLine("Failed to convert {0}: {1}",
                    Path.GetFileName(filename),
                    AILAPI.GetLastError());
                buffer = null;
                return false;
            }
            byte[] wavBuffer = new byte[resultBufferSize];
            Marshal.Copy(resultBuffer, wavBuffer, 0, wavBuffer.Length);
            AILAPI.MemFreeLock(resultBuffer);
            RIBAPI.FreeProviderLibrary(pHandle);
            AILAPI.Shutdown();
            gch.Free();
            buffer = wavBuffer;
            return true;
        }

        private void letsGoButton_Click(object sender, EventArgs e)
        {
            if (TryConvertToWav(binkaFilepath, out byte[] wavBuffer))
            {
                string outputpath = Path.Combine(Path.GetDirectoryName(binkaFilepath), Path.GetFileNameWithoutExtension(binkaFilepath) + ".wav");
                File.WriteAllBytes(outputpath, wavBuffer);
                MessageBox.Show($"Successfully converted {Path.GetFileName(binkaFilepath)}", "File converted");
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Binka|*.binka"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileLabel.Text = $"{Path.GetFileName(fileDialog.FileName)}    ->    {Path.GetFileNameWithoutExtension(fileDialog.FileName)}.wav";
                binkaFilepath = fileDialog.FileName;
            }
        }
    }
}
