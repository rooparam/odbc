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
        private long charIndex =0;
        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
        private RichTextBox MyControl;
        public LogWriter(RichTextBox control)
        {
            MyControl = control;
        }

        public override void Write(char value)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(Write);
                MyControl.Invoke(d, new object[] { value.ToString() });
            }
            else
            {
                MyControl.AppendText(value.ToString());
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
                MyControl.AppendText(value);
            }
        }

        public  void WriteInfo(string value)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteInfo);
                MyControl.Invoke(d, new object[] { "[ Info    ] " + value + Environment.NewLine });
            }
            else
            {
                MyControl.AppendText(value);
            }            
        }
        public void WriteInfo(string value, System.Drawing.Color color)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteInfo);
                MyControl.Invoke(d, new object[] { "[ Info    ] " + value + Environment.NewLine });
            }
            else
            {
                int startIndex = MyControl.TextLength;
                MyControl.AppendText(value);
                MyControl.Select(startIndex, value.Length);
                //Set the selected text fore and background color
                MyControl.SelectionColor = color;
                //MyControl.SelectionBackColor = System.Drawing.Color.Red;

            }

        }
        public override void WriteLine(string value)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteLine);
                MyControl.Invoke(d, new object[] {value + Environment.NewLine });
            }
            else
            {
                MyControl.AppendText(value);
            }
            
        } 
        public void WriteError(string value)
        {
            if (MyControl.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteError);
                MyControl.Invoke(d, new object[] { "[ Error   ] " + value +Environment.NewLine });
            }
            else
            {
                int startIndex = MyControl.TextLength;
                MyControl.AppendText(value);
                MyControl.Select(startIndex, value.Length);
                //Set the selected text fore and background color
                MyControl.SelectionColor = System.Drawing.Color.Red;
                //MyControl.SelectionBackColor = System.Drawing.Color.Red;
            }
        }

    }
}
