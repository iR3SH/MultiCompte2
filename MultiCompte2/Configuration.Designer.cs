
namespace MultiCompte2
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Keys = new System.Windows.Forms.ComboBox();
            this.Ctrl = new System.Windows.Forms.CheckBox();
            this.WinKey = new System.Windows.Forms.CheckBox();
            this.Alt = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Keys);
            this.groupBox1.Controls.Add(this.Ctrl);
            this.groupBox1.Controls.Add(this.WinKey);
            this.groupBox1.Controls.Add(this.Alt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raccourci";
            // 
            // Keys
            // 
            this.Keys.FormattingEnabled = true;
            this.Keys.Location = new System.Drawing.Point(57, 57);
            this.Keys.Name = "Keys";
            this.Keys.Size = new System.Drawing.Size(73, 23);
            this.Keys.TabIndex = 3;
            // 
            // Ctrl
            // 
            this.Ctrl.AutoSize = true;
            this.Ctrl.Location = new System.Drawing.Point(6, 59);
            this.Ctrl.Name = "Ctrl";
            this.Ctrl.Size = new System.Drawing.Size(45, 19);
            this.Ctrl.TabIndex = 2;
            this.Ctrl.Text = "Ctrl";
            this.Ctrl.UseVisualStyleBackColor = true;
            // 
            // WinKey
            // 
            this.WinKey.AutoSize = true;
            this.WinKey.Location = new System.Drawing.Point(53, 34);
            this.WinKey.Name = "WinKey";
            this.WinKey.Size = new System.Drawing.Size(66, 19);
            this.WinKey.TabIndex = 1;
            this.WinKey.Text = "WinKey";
            this.WinKey.UseVisualStyleBackColor = true;
            // 
            // Alt
            // 
            this.Alt.AutoSize = true;
            this.Alt.Location = new System.Drawing.Point(6, 34);
            this.Alt.Name = "Alt";
            this.Alt.Size = new System.Drawing.Size(41, 19);
            this.Alt.TabIndex = 0;
            this.Alt.Text = "Alt";
            this.Alt.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(154, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autres";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(166, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Dofus à Lancer :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sauvegarder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(306, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sauvegardé !";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(154, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Réinitialisé !";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 122);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Keys;
        private System.Windows.Forms.CheckBox Ctrl;
        private System.Windows.Forms.CheckBox WinKey;
        private System.Windows.Forms.CheckBox Alt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}