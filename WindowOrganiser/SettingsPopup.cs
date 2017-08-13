using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowOrganiser {
	public partial class SettingsPopup : Form {
		Dictionary<String , int> keyDict = new Dictionary<string , int>(); // keyName to keyValue

		public SettingsPopup() {
			InitializeComponent();
		}

		private void SettingsPopup_Load(object sender , EventArgs e) {
			// de-register shortcuts (could have f**d up and set the shortcuts to a mouse click or something)
			WindowOrganiser.removeShortcuts();

			foreach(Keys k in Enum.GetValues(typeof(Keys))) {
				//Console.WriteLine($"{Enum.GetName(typeof(Keys), k)} {(int)k}");
				String name = Enum.GetName(typeof(Keys) , k);
				if(!keyDict.Keys.Contains(name)) keyDict.Add(name , (int)k);
			}

			foreach (String s in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindowOrganiser"),"*.xml")) {
				String configName = Path.GetFileNameWithoutExtension(s);
				Console.WriteLine($"Found config file: {configName}");

				// read in the preferences data

				tableLayoutPanel.RowCount++;
				tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute , 50F));
				tableLayoutPanel.Controls.Add(new Label() { Text = configName, Font = new Font(FontFamily.GenericSansSerif,10), AutoSize = true } , 0 , tableLayoutPanel.RowCount - 1);

				ComboBox tempcb = new ComboBox();
				tempcb.Name = configName;
				tempcb.Dock = DockStyle.Fill;
				tempcb.AllowDrop = false;
				tempcb.DropDownStyle = ComboBoxStyle.DropDownList;
				tempcb.Items.AddRange(keyDict.Keys.ToArray());
				tempcb.SelectedIndexChanged += new System.EventHandler(ComboBox_SelectedIndexChanged);

				// check if we have a preference stored already, if so, display it
				if(WindowOrganiser.shortcuts.ContainsKey(configName)) {
					if (WindowOrganiser.shortcuts[configName]==0) tempcb.SelectedText = "";
					else tempcb.SelectedItem = keyDict.FirstOrDefault(x => x.Value == WindowOrganiser.shortcuts[configName]).Key;
				}

				tableLayoutPanel.Controls.Add(tempcb , 1 , tableLayoutPanel.RowCount - 1);
			}
		}

		private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			String name = ((ComboBox)sender).Name;
			String selectedItem = ((ComboBox)sender).SelectedItem.ToString();
			//Console.WriteLine($"Combobox '{name}' changed to {selectedItem}");

			// if it already exists in the preferences it will just be updated
			WindowOrganiser.shortcuts[name] = keyDict[selectedItem];
		}

		private void SettingsPopup_FormClosing(object sender , FormClosingEventArgs e) {
			// now update preferences
			Properties.Settings.Default.shortcuts = JsonConvert.SerializeObject(WindowOrganiser.shortcuts);
			Properties.Settings.Default.Save();

			//reload the key hooks
			WindowOrganiser.addShortcuts();
		}
	}
}
