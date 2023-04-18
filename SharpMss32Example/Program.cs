using System;
using System.Windows.Forms;

namespace SharpMss32Example
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new ExampleForm();
            form.RegisterExamplePanel(new TestPanel());
            form.RegisterExamplePanel(new Binka2WavPanel());
            Application.Run(form);
        }
    }
}
