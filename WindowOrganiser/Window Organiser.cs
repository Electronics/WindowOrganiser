﻿using System;
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
using System.IO;
using Newtonsoft.Json;

namespace WindowOrganiser
{
    public partial class WindowOrganiser : Form
    {
		DataTable dTable = new DataTable();
		private static KeyHandler keyHandler;
		public static Dictionary<string , int> shortcuts = new Dictionary<string , int>(); // configName to keyValue
		

        public WindowOrganiser()
        {
            InitializeComponent();
			// populate our shortcuts dictionary from preferences
			if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.shortcuts)) {
				Console.WriteLine($"Found pre-existing preferences: {Properties.Settings.Default.shortcuts}");
				shortcuts = JsonConvert.DeserializeObject<Dictionary<string , int>>(Properties.Settings.Default.shortcuts);
			}
			keyHandler = new KeyHandler(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			Console.WriteLine($"I am running in {Directory.GetCurrentDirectory()}, but am using {Environment.SpecialFolder.ApplicationData} for data");
			String[] arguments = Environment.GetCommandLineArgs();
			if (arguments.Count() == 1 || String.IsNullOrWhiteSpace(arguments[1])) {
				loadContextMenu();
				SetupDataGridView();
				loadTable("default");
				findNewWindows(false);
				addShortcuts();
			} else {
				Console.WriteLine($"Detected command line argument - {arguments[1]}");
				SetupDataGridView();
				loadAndMove(arguments[1]);
				Application.Exit();
			}
        }

		public static void addShortcuts() {
			foreach (KeyValuePair<string, int> entry in shortcuts) {
				keyHandler.Register(Constants.NOMOD , entry.Value);
			}
		}

		public static void removeShortcuts() {
			keyHandler.Unregister();
		}

		private void findNewWindows(bool overwritePos) {			
			foreach(KeyValuePair<IntPtr, string> window in WindowFinder.GetOpenWindows()) {
				bool getPos = overwritePos;
				IntPtr handle = window.Key;
				string title = window.Value;

				DataRow r = dTable.Rows.ContainsInRow("windowName" , title);
				if(r!=null) {
					Console.WriteLine($"Found already existing window '{title}' => '{r["windowName"]}', updating handle");
					r["handle"] = handle.ToInt32();
				} else {
					Console.WriteLine($"Generating new row for '{title}'");
					r = dTable.Rows.Add();
					r["windowName"] = title;
					r["handle"] = handle.ToInt32();
					getPos = true;
				}

				if(getPos) {
					Console.WriteLine($"Grabbing current window position for '{r["windowName"]}'");
					WindowFinder.Rect rectangle = new WindowFinder.Rect();
					WindowFinder.GetWindowRect(handle , ref rectangle);

					r["xPos"] = rectangle.Left;
					r["yPos"] = rectangle.Top;
					r["width"] = rectangle.Right - rectangle.Left;
					r["height"] = rectangle.Bottom - rectangle.Top;
				}
			}
		}

		private void moveWindows() {
			foreach(DataRow r in dTable.Rows) {
				if(checkRowForMove(r)) {
					Console.WriteLine($"Moving '{r["windowName"]}'");
					WindowMover.MoveWindow((IntPtr)r.Field<int>("handle"),r.Field<int>("xPos"),r.Field<int>("yPos"),r.Field<int>("width"),r.Field<int>("height"),true);
					
				}
			}
		}

		private void cullRows() {
			Console.WriteLine("Culling table");
			List<DataRow> toDelete = new List<DataRow>();
			foreach (DataRow r in dTable.Rows) {
				if (DBNull.Value.Equals(r["move"]) || !r.Field<bool>("move")) toDelete.Add(r);
			}
			foreach (DataRow r in toDelete) {
				r.Delete();
			}
		}

		private void saveTable() {
			cullRows();
			Console.WriteLine("Writing table to file");
			string input = Microsoft.VisualBasic.Interaction.InputBox("Save", "New Config Name", "default", 0, 0);
			System.IO.Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) , "WindowOrganiser"));
			dTable.WriteXml(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindowOrganiser", $"{input}.xml"));

			loadContextMenu();
		}

		private void loadTable(String configName) {
			dTable.Clear();
			Console.WriteLine($"Loading table {configName} from file");
            try {
                dTable.ReadXml(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindowOrganiser", $"{configName}.xml"));
            } catch (FileNotFoundException) { } catch (System.IO.DirectoryNotFoundException) { }
		}

		private bool checkRowForMove(DataRow r) {
			if (DBNull.Value.Equals(r["move"])) return false;
			if (!r.Field<bool>("move")) return false;
			foreach(DataColumn c in dTable.Columns) {
				if (r.GetType() != typeof(String)) continue;
				if (r.IsCellNullOrWhiteSpace(c.ColumnName)) return false;
			}
			return true;
		}

		private void loadContextMenu() {
			notifyIcon1.ContextMenu = new ContextMenu();
            try {
                foreach (String s in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindowOrganiser"), "*.xml"))
                {
                    String configName = Path.GetFileNameWithoutExtension(s);
                    Console.WriteLine($"Found config file: {configName}");
                    notifyIcon1.ContextMenu.MenuItems.Add(configName, (something, ev) =>
                    {
                        loadAndMove(configName);
                    });
                }
            } catch(System.IO.DirectoryNotFoundException e) {
                // We haven't made this directory yet
            }
		}

		private void loadAndMove(String name) {
			loadTable(name);
			findNewWindows(false);
			moveWindows();
		}

		private void SetupDataGridView()
        {
			dTable.TableName = "App Positions";
			dataGridView.DataSource = dTable;

            dataGridView.RowHeadersVisible = true;
            dataGridView.AllowUserToResizeColumns = true;

			dTable.Columns.Add("move" , typeof(bool));
			dTable.Columns.Add("windowName" , typeof(String));
			dTable.Columns.Add("handle", typeof(int));
			//dTable.Columns["handle"].ReadOnly = true;

            dTable.Columns.Add("xPos" , typeof(int));
            dTable.Columns.Add("yPos" , typeof(int));
            dTable.Columns.Add("width" , typeof(int));
			dTable.Columns.Add("height" , typeof(int));

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView.Refresh();
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
			saveTable();
		}

		private void button_load_Click(object sender , EventArgs e) {
			loadTable(Microsoft.VisualBasic.Interaction.InputBox("Load", "New Config Name", "default", 0, 0));
		}

		private void button_cull_Click(object sender , EventArgs e) {
			cullRows();
		}

		private void Form1_Resize(object sender , EventArgs e) {
			if (FormWindowState.Minimized == WindowState) Hide();
		}

		private void notifyIcon1_MouseDoubleClick(object sender , MouseEventArgs e) {
			Show();
			WindowState = FormWindowState.Normal;
		}

		protected override void WndProc(ref Message m) {
			if (m.Msg == Constants.WM_HOTKEY_MSG_ID) {
				int pressedKey = (int)(m.LParam) >> 16;
				foreach(KeyValuePair<string, int> entry in shortcuts) {
					if(pressedKey == entry.Value) {
						Console.WriteLine($"Got a key press({entry.Value}) for {entry.Key}");
						loadAndMove(entry.Key);
					}
				}
			}
			base.WndProc(ref m);
		}

		private void button_settings_Click(object sender , EventArgs e) {
			var form = new SettingsPopup();
			form.ShowDialog(this);
		}
	}
}
