using System;
using System.Windows.Forms;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm
	{
		private void AskHowMany(string title, string info)
		{
			this.HowManyNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.HowManyGroupBox1 = new System.Windows.Forms.GroupBox();
			this.HowManyButton1 = new System.Windows.Forms.Button();
			this.HowManyForm = new System.Windows.Forms.Form();
			((System.ComponentModel.ISupportInitialize)(this.HowManyNumericUpDown1)).BeginInit();
			this.HowManyGroupBox1.SuspendLayout();
			HowManyForm.SuspendLayout();
			// 
			// HowManyNumericUpDown1
			// 
			this.HowManyNumericUpDown1.Location = new System.Drawing.Point(26, 30);
			this.HowManyNumericUpDown1.Name = "HowManyNumericUpDown1";
			this.HowManyNumericUpDown1.Size = new System.Drawing.Size(149, 20);
			this.HowManyNumericUpDown1.TabIndex = 0;
			this.HowManyNumericUpDown1.Maximum = ReadInteger4(4);
			// 
			// HowManyGroupBox1
			// 
			this.HowManyGroupBox1.Controls.Add(this.HowManyButton1);
			this.HowManyGroupBox1.Controls.Add(this.HowManyNumericUpDown1);
			this.HowManyGroupBox1.Location = new System.Drawing.Point(12, 12);
			this.HowManyGroupBox1.Name = "HowManyGroupBox1";
			this.HowManyGroupBox1.Size = new System.Drawing.Size(200, 100);
			this.HowManyGroupBox1.TabIndex = 1;
			this.HowManyGroupBox1.TabStop = false;
			this.HowManyGroupBox1.Text = info;
			// 
			// HowManyButton1
			// 
			this.HowManyButton1.Location = new System.Drawing.Point(26, 56);
			this.HowManyButton1.Name = "HowManyButton1";
			this.HowManyButton1.Size = new System.Drawing.Size(149, 23);
			this.HowManyButton1.TabIndex = 1;
			this.HowManyButton1.Text = "Valid";
			this.HowManyButton1.UseVisualStyleBackColor = true;
			this.HowManyButton1.Click += new System.EventHandler(this.HowManyButton1Click);
			// 
			// HowManyForm
			// 
			HowManyForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			HowManyForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			HowManyForm.ClientSize = new System.Drawing.Size(225, 119);
			HowManyForm.Controls.Add(this.HowManyGroupBox1);
			HowManyForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			HowManyForm.Name = "HowManyForm";
			HowManyForm.ShowInTaskbar = false;
			HowManyForm.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			HowManyForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			HowManyForm.Text = title;
			((System.ComponentModel.ISupportInitialize)(this.HowManyNumericUpDown1)).EndInit();
			this.HowManyGroupBox1.ResumeLayout(false);
			HowManyForm.ResumeLayout(false);
			HowManyForm.ShowDialog();
		}
		
		void HowManyButton1Click(object sender, EventArgs e)
		{
			if (HowManyNumericUpDown1.Value > 0)
			{
				moves_list.SelectedIndex = (moves_list.Items.Count > 0) ? 0 : -1;
				int nouvelle_valeur = ReadInteger4(4);
				if (HowManyForm.Text.Contains("Delete"))
				{
					nouvelle_valeur -= (int)HowManyNumericUpDown1.Value;
					mset_stream = Combine(SubArray(mset_stream,0,16+nouvelle_valeur*16),SubArray(mset_stream,16+ReadInteger4(4)*16,mset_stream.Length-(16+ReadInteger4(4)*16)));
					ActualiserPointeursBar(16+ReadInteger4(4)*16,-16*(int)HowManyNumericUpDown1.Value);
					WriteInteger4(4,nouvelle_valeur);
					for (int i=0;i<(int)HowManyNumericUpDown1.Value;i++)
					moves_list.Items.RemoveAt(moves_list.Items.Count-1);
					
				}
				else
				{
					nouvelle_valeur += (int)HowManyNumericUpDown1.Value;
					byte[] addition = dummy_sample;
					for (int i=1;i<(int)HowManyNumericUpDown1.Value;i++)
						addition = Combine(addition,dummy_sample);
					mset_stream = Combine(Combine(SubArray(mset_stream,0,16+ReadInteger4(4)*16),addition),SubArray(mset_stream,16+ReadInteger4(4)*16,mset_stream.Length-(16+ReadInteger4(4)*16)));
					ActualiserPointeursBar(16+ReadInteger4(4)*16,16*(int)HowManyNumericUpDown1.Value);
					WriteInteger4(4,nouvelle_valeur);
					for (int i=0;i<(int)HowManyNumericUpDown1.Value;i++)
					moves_list.Items.Add(" ");
				}
				UpdateNumeros();
				UpdateSizeDiff();
				label5_.Text = count.ToString();
				Delete.Enabled = (moves_list.Items.Count>0);
				Down.Enabled = moves_list.Items.Count>1;
				Moves_listSelectedIndexChanged(null,null);
			}
			HowManyForm.Close();
		}
		
		private System.Windows.Forms.NumericUpDown HowManyNumericUpDown1;
		private System.Windows.Forms.GroupBox HowManyGroupBox1;
		private System.Windows.Forms.Button HowManyButton1;
		private System.Windows.Forms.Form HowManyForm;
		
	}
}
