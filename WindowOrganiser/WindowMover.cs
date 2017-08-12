using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowOrganiser {
	class WindowMover {
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
		// bRepaint specifies whether to tell the window that it has been moved/resized so it can re-distribute it's stuff on screen (most things catch the move anyway)


		[DllImport("user32.dll")]
		public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
		// nCmdShow see https://msdn.microsoft.com/en-us/library/windows/desktop/ms633548(v=vs.85).aspx
	}
}
