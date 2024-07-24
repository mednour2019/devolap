namespace WindowsFormsApp3
{
    partial class Form5
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
			this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
			this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
			this.metroButton1 = new MetroFramework.Controls.MetroButton();
			this.metroButton2 = new MetroFramework.Controls.MetroButton();
			this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
			this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
			this.metroRadioButton3 = new MetroFramework.Controls.MetroRadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.metroButton3 = new MetroFramework.Controls.MetroButton();
			((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			this.SuspendLayout();
			// 
			// metroStyleManager1
			// 
			this.metroStyleManager1.Owner = this;
			// 
			// metroButton1
			// 
			this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroButton1.Location = new System.Drawing.Point(648, 523);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(75, 23);
			this.metroButton1.TabIndex = 14;
			this.metroButton1.Text = "NEXT";
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
			// 
			// metroButton2
			// 
			this.metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroButton2.Location = new System.Drawing.Point(5, 523);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new System.Drawing.Size(75, 23);
			this.metroButton2.TabIndex = 15;
			this.metroButton2.Text = "BACK";
			this.metroButton2.UseSelectable = true;
			this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click_1);
			// 
			// metroRadioButton1
			// 
			this.metroRadioButton1.AutoSize = true;
			this.metroRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroRadioButton1.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
			this.metroRadioButton1.Location = new System.Drawing.Point(226, 42);
			this.metroRadioButton1.Name = "metroRadioButton1";
			this.metroRadioButton1.Size = new System.Drawing.Size(143, 15);
			this.metroRadioButton1.TabIndex = 21;
			this.metroRadioButton1.Text = "Create new cube olap";
			this.metroRadioButton1.UseSelectable = true;
			this.metroRadioButton1.CheckedChanged += new System.EventHandler(this.metroRadioButton1_CheckedChanged);
			// 
			// metroRadioButton2
			// 
			this.metroRadioButton2.AutoSize = true;
			this.metroRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroRadioButton2.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
			this.metroRadioButton2.Location = new System.Drawing.Point(11, 14);
			this.metroRadioButton2.Name = "metroRadioButton2";
			this.metroRadioButton2.Size = new System.Drawing.Size(164, 15);
			this.metroRadioButton2.TabIndex = 22;
			this.metroRadioButton2.Text = "Manage cube calculations";
			this.metroRadioButton2.UseSelectable = true;
			this.metroRadioButton2.CheckedChanged += new System.EventHandler(this.metroRadioButton2_CheckedChanged);
			// 
			// metroRadioButton3
			// 
			this.metroRadioButton3.AutoSize = true;
			this.metroRadioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroRadioButton3.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
			this.metroRadioButton3.Location = new System.Drawing.Point(9, 16);
			this.metroRadioButton3.Name = "metroRadioButton3";
			this.metroRadioButton3.Size = new System.Drawing.Size(306, 15);
			this.metroRadioButton3.TabIndex = 24;
			this.metroRadioButton3.Text = "Dispatch cube to the local server or another server";
			this.metroRadioButton3.UseSelectable = true;
			this.metroRadioButton3.CheckedChanged += new System.EventHandler(this.metroRadioButton3_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(78, 43);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(139, 126);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Choose cube olap";
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.Gainsboro;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 18;
			this.listBox1.Location = new System.Drawing.Point(8, 25);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 94);
			this.listBox1.TabIndex = 39;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pictureBox2);
			this.groupBox2.Controls.Add(this.metroTextBox1);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.metroRadioButton2);
			this.groupBox2.Location = new System.Drawing.Point(22, 205);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(304, 213);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(56, 175);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(20, 23);
			this.pictureBox2.TabIndex = 30;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// metroTextBox1
			// 
			// 
			// 
			// 
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(117, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new System.Drawing.Point(78, 175);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new System.Drawing.Size(139, 23);
			this.metroTextBox1.TabIndex = 29;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.metroTextBox1.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
			this.metroTextBox1.Click += new System.EventHandler(this.metroTextBox1_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupBox3.Controls.Add(this.listBox2);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(87, 41);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(149, 126);
			this.groupBox3.TabIndex = 30;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Choose cube olap";
			// 
			// listBox2
			// 
			this.listBox2.BackColor = System.Drawing.Color.Gainsboro;
			this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 18;
			this.listBox2.Location = new System.Drawing.Point(14, 25);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(120, 94);
			this.listBox2.TabIndex = 39;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.pictureBox3);
			this.groupBox4.Controls.Add(this.metroTextBox2);
			this.groupBox4.Controls.Add(this.metroRadioButton3);
			this.groupBox4.Controls.Add(this.groupBox3);
			this.groupBox4.Location = new System.Drawing.Point(351, 206);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(323, 212);
			this.groupBox4.TabIndex = 31;
			this.groupBox4.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(65, 173);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(20, 23);
			this.pictureBox3.TabIndex = 32;
			this.pictureBox3.TabStop = false;
			// 
			// metroTextBox2
			// 
			// 
			// 
			// 
			this.metroTextBox2.CustomButton.Image = null;
			this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(127, 1);
			this.metroTextBox2.CustomButton.Name = "";
			this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox2.CustomButton.TabIndex = 1;
			this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox2.CustomButton.UseSelectable = true;
			this.metroTextBox2.CustomButton.Visible = false;
			this.metroTextBox2.Lines = new string[0];
			this.metroTextBox2.Location = new System.Drawing.Point(87, 173);
			this.metroTextBox2.MaxLength = 32767;
			this.metroTextBox2.Name = "metroTextBox2";
			this.metroTextBox2.PasswordChar = '\0';
			this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBox2.SelectedText = "";
			this.metroTextBox2.SelectionLength = 0;
			this.metroTextBox2.SelectionStart = 0;
			this.metroTextBox2.ShortcutsEnabled = true;
			this.metroTextBox2.Size = new System.Drawing.Size(149, 23);
			this.metroTextBox2.TabIndex = 31;
			this.metroTextBox2.UseSelectable = true;
			this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.metroTextBox2.TextChanged += new System.EventHandler(this.metroTextBox2_TextChanged);
			this.metroTextBox2.Click += new System.EventHandler(this.metroTextBox2_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.metroRadioButton1);
			this.groupBox6.Location = new System.Drawing.Point(22, 105);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(652, 101);
			this.groupBox6.TabIndex = 34;
			this.groupBox6.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(214, 449);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(250, 18);
			this.label2.TabIndex = 35;
			this.label2.Text = "Click  NEXT to create new cube olap";
			// 
			// groupBox7
			// 
			this.groupBox7.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupBox7.Controls.Add(this.label1);
			this.groupBox7.Controls.Add(this.pictureBox1);
			this.groupBox7.Controls.Add(this.pictureBox6);
			this.groupBox7.Controls.Add(this.label2);
			this.groupBox7.Controls.Add(this.groupBox2);
			this.groupBox7.Controls.Add(this.groupBox4);
			this.groupBox7.Controls.Add(this.groupBox6);
			this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox7.Location = new System.Drawing.Point(5, 23);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(718, 494);
			this.groupBox7.TabIndex = 36;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Option area";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(60, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 39;
			this.label1.Text = "Choose an option";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Enabled = false;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(7, 39);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(49, 58);
			this.pictureBox1.TabIndex = 38;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox6
			// 
			this.pictureBox6.BackColor = System.Drawing.Color.Black;
			this.pictureBox6.Enabled = false;
			this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
			this.pictureBox6.Location = new System.Drawing.Point(331, 12);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(50, 52);
			this.pictureBox6.TabIndex = 37;
			this.pictureBox6.TabStop = false;
			// 
			// metroButton3
			// 
			this.metroButton3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroButton3.Location = new System.Drawing.Point(311, 523);
			this.metroButton3.Name = "metroButton3";
			this.metroButton3.Size = new System.Drawing.Size(75, 23);
			this.metroButton3.TabIndex = 37;
			this.metroButton3.Text = "Cancel";
			this.metroButton3.UseSelectable = true;
			this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click_1);
			// 
			// Form5
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(729, 550);
			this.Controls.Add(this.metroButton3);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.metroButton2);
			this.Controls.Add(this.metroButton1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.MaximizeBox = false;
			this.Name = "Form5";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form5_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form5_FormClosed);
			this.Load += new System.EventHandler(this.Form5_Load);
			((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}