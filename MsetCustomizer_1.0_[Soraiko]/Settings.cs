using System;
using System.IO;

namespace Settings_Form
{
	public static class MainForm
	{
		public static System.ComponentModel.IContainer components = null;
		public static System.Windows.Forms.GroupBox groupBox1;
		public static System.Windows.Forms.Label label1;
		public static System.Windows.Forms.ComboBox comboBox1;
		public static System.Windows.Forms.Form MainForm_;
		
		public static void InitializeComponent()
		{
			MainForm_= new System.Windows.Forms.Form();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label1 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			groupBox1.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(comboBox1);
			groupBox1.Location = new System.Drawing.Point(11, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(273, 233);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			label1.Location = new System.Drawing.Point(19, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(236, 23);
			label1.TabIndex = 5;
			label1.Text = "Warn if trying to replace a pointed file";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox1
			// 
			comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[] {
			"Yes",
			"No"});
			comboBox1.Location = new System.Drawing.Point(19, 45);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(236, 21);
			comboBox1.TabIndex = 4;
			comboBox1.SelectedIndexChanged += new System.EventHandler(ComboBox1SelectedIndexChanged);
			// 
			// MainForm_
			// 
			MainForm_.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			MainForm_.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			MainForm_.ClientSize = new System.Drawing.Size(299, 254);
			MainForm_.Controls.Add(groupBox1);
			MainForm_.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			MainForm_.MaximumSize = new System.Drawing.Size(315, 288);
			MainForm_.MinimumSize = new System.Drawing.Size(315, 288);
			MainForm_.Name = "MainForm_";
			MainForm_.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			MainForm_.Text = "Settings";
			groupBox1.ResumeLayout(false);
			Combo_Indexes();
		}
		
		public static void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			File.WriteAllLines(Path.GetPathRoot(Environment.SystemDirectory) + @"windows\MSETCUST.ini",new string[] {
				comboBox1.SelectedIndex.ToString()
				
				
				});
		}
		
		public static void Combo_Indexes()
		{
			try
			{
				string[] indexes = File.ReadAllLines(Path.GetPathRoot(Environment.SystemDirectory) + @"windows\MSETCUST.ini");
				comboBox1.SelectedIndex = int.Parse(indexes[0]);
			}
			catch
			{
				
			}
		}
	}
}
