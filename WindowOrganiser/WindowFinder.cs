﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


using HWND = System.IntPtr;

namespace WindowOrganiser
{
    public class WindowFinder
    {

		/// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
		/// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
		/// from AzzamAziz on https://stackoverflow.com/questions/28178254/get-all-open-windows
		public static IDictionary<HWND, string> GetOpenWindows()
		{

			HWND shellWindow = GetShellWindow();
			Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

			EnumWindows(delegate(HWND hWnd, int lParam)
			{
				if (hWnd == shellWindow) return true;
				if (!IsWindowVisible(hWnd)) return true;

				int length = GetWindowTextLength(hWnd);
				if (length == 0) return true;

				StringBuilder builder = new StringBuilder(length);
				GetWindowText(hWnd, builder, length + 1);

				windows[hWnd] = builder.ToString();
				return true;

			}, 0);

			return windows;
		}

		private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

		[DllImport("USER32.DLL")]
		private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

		[DllImport("USER32.DLL")]
		private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("USER32.DLL")]
		private static extern int GetWindowTextLength(HWND hWnd);

		[DllImport("USER32.DLL")]
		private static extern bool IsWindowVisible(HWND hWnd);

		[DllImport("USER32.DLL")]
		private static extern IntPtr GetShellWindow();

		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

		public struct Rect {
			public int Left { get; set; }
			public int Top { get; set; }
			public int Right { get; set; }
			public int Bottom { get; set; }
		}
    }

}
