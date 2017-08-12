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
using ExtensionMethods;

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
			SetupDataGridView();
			findNewWindows(false);
        }

		private void findNewWindows(bool getPos) {
			foreach(KeyValuePair<IntPtr, string> window in WindowFinder.GetOpenWindows()) {
				IntPtr handle = window.Key;
				string title = window.Value;

				DataGridViewRow r = dataGridView1.Rows.ContainsInRow("windowName" , title);
				if(r!=null) {
					Console.WriteLine($"Found already existing window '{title}' => '{r.Cells["windowName"].Value}', updating handle");
					r.Cells["handle"].Value = handle;
				} else {
					Console.WriteLine($"Generating new row for '{title}'");
					r = dataGridView1.Rows[dataGridView1.Rows.Add()];
					r.Cells["windowName"].Value = title;
					r.Cells["handle"].Value = handle;
					getPos = true;
				}

				if(getPos) {
					WindowFinder.Rect rectangle = new WindowFinder.Rect();
					WindowFinder.GetWindowRect(handle , ref rectangle);

					r.Cells["xPos"].Value = rectangle.Left;
					r.Cells["yPos"].Value = rectangle.Top;
					r.Cells["width"].Value = rectangle.Right - rectangle.Left;
					r.Cells["height"].Value = rectangle.Bottom - rectangle.Top;
				}
			}
		}

		private void moveWindows() {
			foreach(DataGridViewRow r in dataGridView1.Rows) {
				if(checkRowForMove(r)) {
					Console.WriteLine($"Moving '{r.Cells["windowName"].Value}'");
					WindowMover.MoveWindow((IntPtr)int.Parse(r.Cells["handle"].Value.ToString()) , (int)int.Parse(r.Cells["xPos"].Value.ToString()) , (int)int.Parse(r.Cells["yPos"].Value.ToString()) , (int)int.Parse(r.Cells["width"].Value.ToString()) , (int)int.Parse(r.Cells["height"].Value.ToString()) , true);
					
				}
			}
		}

		private void saveTable() {
			
		}

		private bool checkRowForMove(DataGridViewRow r) {
			if (r.Cells["move"] == null || r.Cells["move"].Value == null) return false;
			if (!(bool)r.Cells["move"].Value) return false;
			foreach(DataGridViewCell c in r.Cells) {
				if (c.GetType() == typeof(DataGridViewCheckBoxCell)) continue;
				if (c.IsCellNullOrWhiteSpace()) return false;
			}
			return true;
		}

		private void SetupDataGridView()
        {
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.AllowUserToResizeColumns = true;

			DataGridViewCheckBoxColumn isUsed = new DataGridViewCheckBoxColumn();
			isUsed.HeaderText = "Move";
			isUsed.Name = "move";
			dataGridView1.Columns.Insert(0 , isUsed);

			dataGridView1.Columns.Add("windowName" , "Window Name");
			dataGridView1.Columns.Add("handle", "Handle");
			dataGridView1.Columns["handle"].ReadOnly = true;

            dataGridView1.Columns.Add("xPos" , "X Pos");
            dataGridView1.Columns.Add("yPos" , "Y Pos");
            dataGridView1.Columns.Add("width" , "Width");
			dataGridView1.Columns.Add("height" , "Height");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

		private void button1_Click(object sender , EventArgs e) {
			findNewWindows(false);
		}

		private void button_move_Click(object sender , EventArgs e) {
			findNewWindows(false);
			moveWindows();
		}

		private void button_getPos_Click(object sender , EventArgs e) {
			findNewWindows(true);
		}

		private void button_save_Click(object sender , EventArgs e) {

		}
	}
}
