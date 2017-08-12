using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowOrganiser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			foreach(KeyValuePair<IntPtr, string> window in WindowFinder.GetOpenWindows()) {
				IntPtr handle = window.Key;
				string title = window.Value;

				if (title.Contains("Firefox") && title.Contains("Messenger")) {
					Console.WriteLine("{0}: {1}", handle, title);

					WindowMover.MoveWindow(handle , 80 , 80 , 400 , 400 , true);
				}
			}
        }
    }
}
