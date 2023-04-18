using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpMss32Example
{
    internal interface IExamplePanel
    {
        public string PanelName { get; }
        public Control Control { get; }
    }
}
