using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtensionMethods {
	public static class DataTableExtensions {
		public static DataRow ContainsInRow(this DataRowCollection rows, String column, String str) {
			foreach(DataRow r in rows) {
				if (r[column]==null) continue;
				//Console.WriteLine($"Comparing '{str}' to '{r.Cells[column].Value}'");
				if (str.Contains(r.Field<string>(column))) return r; // get that the right way around!
			}
			//Console.WriteLine($"Did not find '{str}'");
			return null;
		}

		public static bool IsCellNullOrWhiteSpace(this DataRow r, String column) {
			return String.IsNullOrWhiteSpace(r.Field<string>(column));
		}
	}
}
