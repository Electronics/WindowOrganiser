using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowOrganiser {
	public class KeyHandler
	{
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		private int modifier;
		private int key;
		private IntPtr hWnd;
		private int id;

		public KeyHandler(Form form) {
			this.hWnd = form.Handle;
			id = this.GetHashCode();
		}

		public KeyHandler(int modifier, Keys key, Form form)
		{
			this.modifier = modifier;
			this.key = (int)key;
			this.hWnd = form.Handle;
			id = this.GetHashCode();
		}

		public override int GetHashCode()
		{
			return key ^ hWnd.ToInt32();
		}

		public bool Register()
		{
			return RegisterHotKey(hWnd, id, modifier, key);
		}

		public bool Register(int modifier, Keys key) {
			return RegisterHotKey(hWnd , id , modifier , (int)key);
		}

		public bool Register(int modifier, int key) {
			return RegisterHotKey(hWnd , id , modifier , key);
		}

		public bool Unregister()
		{
			return UnregisterHotKey(hWnd, id);
		}
	}
}
