using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Rocket.RDVQA.Tools.Core
{
    class LogWriter : System.IO.TextWriter
    {
        private delegate void SafeCallDelegate(string text);
        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
        private Control MyControl;
        public LogWriter(Control control)
        {
            MyControl = control;
        }

        public override void Write(char value)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(Write);
                MyControl.Invoke(d, new object[] { value });
            }
            else
            {
                MyControl.Text += value;
            }
        }

        public override void Write(string value)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(Write);
                MyControl.Invoke(d, new object[] { value });
            }
            else
            {
                MyControl.Text += value;
            }
        }
        public void WriteLline(string value)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(Write);
                MyControl.Invoke(d, new object[] { value });
            }
            else
            {
                MyControl.Text += value + "\n";
            }
            
        }

    }
}
