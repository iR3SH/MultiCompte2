using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using MultiCompte2.Composants;

namespace MultiCompte2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            base.Resize += Form1_Resize;
            base.Load += Form1_Load;
            HOTKEY_ACTIVE += Start;
            base.FormClosing += Form1_FormClosing;
            //InitializeComponent();
        }

        public delegate void HOTKEY_ACTIVEEventHandler(int id);
        private HOTKEY_ACTIVEEventHandler HOTKEY_ACTIVEEvent;

        public event HOTKEY_ACTIVEEventHandler HOTKEY_ACTIVE
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                HOTKEY_ACTIVEEvent = (HOTKEY_ACTIVEEventHandler)Delegate.Combine(HOTKEY_ACTIVEEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                HOTKEY_ACTIVEEvent = (HOTKEY_ACTIVEEventHandler)Delegate.Remove(HOTKEY_ACTIVEEvent, value);
            }
        }

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.Mainfct(2, tabControl1, Handle);
        }
		private void Start(int id)
		{
			checked
			{
				try
				{
					switch (id)
					{
						case 444719:
							{
								int selectedIndex = tabControl1.SelectedIndex;
								if (selectedIndex == tabControl1.Controls.Count - 1)
								{
									selectedIndex = 0;
									tabControl1.SelectedIndex = 0;
								}
								else
								{
									selectedIndex++;
									tabControl1.SelectedIndex = selectedIndex;
								}
								break;
							}
						case 1:
							foreach (Struct.Processus liste_Processu in Struct.Liste_Processus)
							{
								liste_Processu.rename();
							}
							break;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
			}
		}

        private void Form1_Load(object sender, EventArgs e)
        {
			Core.Mainfct(1, tabControl1, Handle);
			Api.RegisterHotKey(Handle, 1, HotKey.FsModifiers.None, Keys.F5);
		}

		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 786)
			{
				if (m.WParam.ToInt32() == 444719)
				{
					HOTKEY_ACTIVEEvent?.Invoke(444719);
				}
				if (m.WParam.ToInt32() == 1)
				{
					HOTKEY_ACTIVEEvent?.Invoke(1);
				}
			}
			base.WndProc(ref m);
		}

        private void Form1_Resize(object sender, EventArgs e)
        {
			Core.Mainfct(1, tabControl1, Handle);
			Api.RegisterHotKey(Handle, 1, HotKey.FsModifiers.None, Keys.F5);
		}

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Configuration configuration = new Configuration();
			configuration.ShowDialog();
        }

        private void toggle1_CheckedChanged(object sender)
        {
			if (timer1.Enabled)
			{
				timer1.Stop();
				return;
			}
			MessageBox.Show("Le déplacement auto est fonctionnel il faut appuyer sur le bouton milieu de la souris.");
			timer1.Start();
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
			Core.Mainfct(8, tabControl1, Handle);
		}

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
			Core.DragStartPosition = new Point(e.X, e.Y);
		}

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
			if (e.Button == MouseButtons.Left)
			{
				Rectangle rectangle = new Rectangle(Core.DragStartPosition, Size.Empty);
				rectangle.Inflate(SystemInformation.DragSize);
				TabPage tabPage = Core.HoverTab(tabControl1);
				if (tabPage != null && !rectangle.Contains(e.X, e.Y))
				{
					tabControl1.DoDragDrop(tabPage, DragDropEffects.All);
				}
				Core.DragStartPosition = Point.Empty;
			}
		}

        private void tabControl1_DragOver(object sender, DragEventArgs e)
        {
			TabPage tabPage = Core.HoverTab(tabControl1);
			if (tabPage == null)
			{
				e.Effect = DragDropEffects.None;
			}
			else
			{
				if (!e.Data.GetDataPresent(typeof(TabPage)))
				{
					return;
				}
				e.Effect = DragDropEffects.Move;
				TabPage tabPage2 = (TabPage)e.Data.GetData(typeof(TabPage));
				if (tabPage != tabPage2)
				{
					Rectangle tabRect = tabControl1.GetTabRect(tabControl1.TabPages.IndexOf(tabPage));
					tabRect.Inflate(-3, -3);
					TabControl tabControl = tabControl1;
					Point p = new Point(e.X, e.Y);
					if (tabRect.Contains(tabControl.PointToClient(p)))
					{
						Core.SwapTabPages(tabControl, tabPage2, tabPage);
						tabControl1.SelectedTab = tabPage2;
					}
				}
			}
		}

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Core.Mainfct(4, tabControl1, Handle);
			Core.Mainfct(1, tabControl1, Handle);
		}

        private void lancerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			Core.Mainfct(3, tabControl1, Handle);
			Core.Mainfct(1, tabControl1, Handle);
		}

        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			Configuration configuration = new Configuration();
			configuration.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
			Core.Mainfct(7, tabControl1, Handle);
		}

        private void lancerToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Core.Mainfct(3, tabControl1, Handle);
			Core.Mainfct(1, tabControl1, Handle);
		}

        private void renommerToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Core.Mainfct(5, tabControl1, Handle);
		}
    }
}
