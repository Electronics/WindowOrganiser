using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtensionMethods {
	public static class DataGridViewExtensions {
		public static DataGridViewRow ContainsInRow(this DataGridViewRowCollection rows, String column, String str) {
			foreach(DataGridViewRow r in rows) {

				if (r.Cells[column].Value==null) continue;
				//Console.WriteLine($"Comparing '{str}' to '{r.Cells[column].Value}'");
				if (str.Contains(r.Cells[column].Value.ToString())) return r; // get that the right way around!
			}
			//Console.WriteLine($"Did not find '{str}'");
			return null;
		}

		public static bool IsCellNullOrWhiteSpace(this DataGridViewRow r, String column) {
			return IsCellNullOrWhiteSpace(r.Cells[column]);
		}

		public static bool IsCellNullOrWhiteSpace(this DataGridViewCell c) {
			if (c == null || c.Value == null) return true;
			return String.IsNullOrWhiteSpace(c.Value.ToString());
		}
	}
}
