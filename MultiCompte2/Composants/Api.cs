using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MultiCompte2.Composants;

namespace MultiCompte2.Composants
{
    class Api
    {
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, IntPtr x, IntPtr y, IntPtr cx, IntPtr cy, IntPtr wFlags);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, IntPtr msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr WindowFromPoint(Point Point);

		[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern long GetCursorPos(ref Point lpPoint);

		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SetWindowLongA", ExactSpelling = true, SetLastError = true)]
		public static extern long SetWindowLong(long hwnd, long nIndex, long dwNewLong);

		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "GetWindowLongA", ExactSpelling = true, SetLastError = true)]
		public static extern long GetWindowLong(long hwnd, long nIndex);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool RegisterHotKey(IntPtr handle, int id, HotKey.FsModifiers fsModifier, Keys vk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int UnregisterHotKey(IntPtr hWnd, int id);
	}
}
