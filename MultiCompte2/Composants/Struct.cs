using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace MultiCompte2.Composants
{
    class Struct
    {
		public struct Processus
		{
			public Process Process;

			public Panel Panel;

			public TabPage Tab;

			public void Redimentionne()
			{
				Logger logger = new Logger();
				string newLine = Environment.NewLine;
				checked
				{
					try
					{
						int width = SystemInformation.FrameBorderSize.Width;
						int height = SystemInformation.FrameBorderSize.Height;
						int num = SystemInformation.FrameBorderSize.Width * 2;
						int num2 = SystemInformation.FrameBorderSize.Height * 2;
						Api.SetWindowPos(Process.MainWindowHandle, (IntPtr)0, (IntPtr)(-width), (IntPtr)(-height), (IntPtr)(Panel.ClientRectangle.Width + num), (IntPtr)(Panel.ClientRectangle.Height + num2), (IntPtr)16);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Erreur : Module 15");
						logger.WriteLog("Module15_Error", "Message :" + newLine + ex.Message + newLine + newLine + "StackTrace :" + newLine + ex.StackTrace);
					}
				}
			}

			public void rename()
			{
				Tab.Text = Process.MainWindowTitle;
			}

			public void suivre(IntPtr proc)
			{
				Logger logger = new Logger();
				string newLine = Environment.NewLine;
				try
				{
					if (!(proc == (IntPtr)Process.Id))
					{
						int num = checked((int)Core.Transforme_Intptr(MOVEPOS.X, MOVEPOS.Y));
						Api.SendMessage(Process.MainWindowHandle, (IntPtr)513, (IntPtr)0, (IntPtr)num);
						Api.SendMessage(Process.MainWindowHandle, (IntPtr)514, (IntPtr)0, (IntPtr)num);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Erreur : Module 16");
					logger.WriteLog("Module16_Error", "Message :" + newLine + ex.Message + newLine + newLine + "StackTrace :" + newLine + ex.StackTrace);
				}
			}

			public void release()
			{
				Logger logger = new Logger();
				string newLine = Environment.NewLine;
				try
				{
					Api.SetParent(Process.MainWindowHandle, Api.GetDesktopWindow());
				}
				catch (Exception ex)
				{
					MessageBox.Show("Erreur : Module 17");
					logger.WriteLog("Module17_Error", "Message :" + newLine + ex.Message + newLine + newLine + "StackTrace :" + newLine + ex.StackTrace);
				}
			}

			public object rec(bool @bool)
			{
				Logger logger = new Logger();
				string newLine = Environment.NewLine;
				object result = default(object);
				try
				{
					if (@bool)
					{
						int num = checked((int)Api.GetWindowLong((long)Process.MainWindowHandle, -16L));
						num = num & -12582913 & -8388609;
						Api.SetWindowLong((long)Process.MainWindowHandle, -16L, num);
					}
					Api.SetParent(Process.MainWindowHandle, Panel.Handle);
					return result;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Erreur : Module 18");
					logger.WriteLog("Module18_Error", "Message :" + newLine + ex.Message + newLine + newLine + "StackTrace :" + newLine + ex.StackTrace);
					return result;
				}
			}
		}

		public static Point MOVEPOS;

		public static List<Processus> Liste_Processus = new List<Processus>();
	}
}
