using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpMSS;

namespace SharpMss32Example
{
    public partial class ExampleForm : Form
    {
        internal ExampleForm()
        {
            InitializeComponent();
        }

        internal void RegisterExamplePanel(IExamplePanel example)
        {
            var page = new TabPage(example.PanelName);
            page.Controls.Add(example.Control);
            tabControl.TabPages.Add(page);
        }
    }
}
