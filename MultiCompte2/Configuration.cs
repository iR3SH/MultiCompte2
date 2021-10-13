using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MultiCompte2.Composants;
using System.Collections;

namespace MultiCompte2
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            base.Load += Options_Load;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			if (decimal.Compare(numericUpDown1.Value, 0m) == 0)
			{
				MessageBox.Show("Utilité d'ouvrir 0 Dofus ? Aucune...", "MultiCompte", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				Core.wparam("winOpen", numericUpDown1.Value.ToString());
			}
			if(isSound.Checked)
            {
				Core.wparam("isSoundActivated", "1");
            }
			else
            {
				Core.wparam("isSoundActivated", "0");
            }
			Enum.TryParse<Keys>(Keys.Text, out var result);
			HotKey.FsModifiers fsModifiers = HotKey.FsModifiers.None;
			IEnumerator enumerator = default(IEnumerator);
			try
			{
				enumerator = groupBox1.Controls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Control control = (Control)enumerator.Current;
					if ((object)control.GetType() != typeof(CheckBox))
					{
						continue;
					}
					CheckBox checkBox = (CheckBox)control;
					if (checkBox.Checked)
					{
						Core.wparam(checkBox.Name, "1");
						switch (checkBox.Name)
						{
							case "Alt":
								fsModifiers |= HotKey.FsModifiers.Alt;
								break;
							case "Ctrl":
								fsModifiers |= HotKey.FsModifiers.Control;
								break;
							case "windows":
								fsModifiers |= HotKey.FsModifiers.Windows;
								break;
						}
					}
					else
					{
						Core.wparam(checkBox.Name, "0");
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			label2.Visible = true;
			timer1.Start();
			if (Operators.CompareString(Keys.Text, "", TextCompare: false) != 0)
			{
				Core.wparam("hotkey", Keys.Text);
				Api.RegisterHotKey(Handle, 444719, fsModifiers, result);
			}
		}

		private void Options_Load(object sender, EventArgs e)
		{
			IEnumerator enumerator = default(IEnumerator);
			try
			{
				enumerator = ((IEnumerable)HotKey.Liste_Touche).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
					if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(objectValue)))
					{
						Keys.Items.Add(RuntimeHelpers.GetObjectValue(objectValue));
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			Api.UnregisterHotKey(Handle, 444719);
			Core.setparam(numericUpDown1, Alt, Ctrl, WinKey, Keys);
		}

        private void button1_Click(object sender, EventArgs e)
        {
			string value = Conversions.ToString((int)MessageBox.Show("Êtes-vous sûr de vouloir reinitialiser le programme ?\r\nCelà effacera touts vos paramètre actuels", "MultiCompte", MessageBoxButtons.YesNo, MessageBoxIcon.Hand));
			if (Conversions.ToDouble(value) == 6.0)
			{
				Core.reset();
				Core.setparam(numericUpDown1, Alt, Ctrl, WinKey, Keys);
				Keys.Text = "";
				label3.Visible = true;
				timer1.Start();
			}
			else
			{
				MessageBox.Show("Une erreur est survenue", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
			label2.Visible = false;
			label3.Visible = false;
			timer1.Start();
		}
    }
}
