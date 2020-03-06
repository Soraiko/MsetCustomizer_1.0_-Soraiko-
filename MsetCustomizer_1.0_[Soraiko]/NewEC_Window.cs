using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm : Form
	{
		private Button NewEC_Window_button1;
		private Label NewEC_Window_label1;
		private Label NewEC_Window_label2;
		private Label NewEC_Window_label3;
		private FlowLayoutPanel NewEC_Window_flowLayoutPanel1;
		private TextBox NewEC_Window_textBox1;
		private TextBox NewEC_Window_textBox2;
		private TextBox NewEC_Window_textBox3;
		private Form NewEC_Window;
		
		private void Initialize_NewECWindow_Componnents()
		{
			NewEC_Window_button1 = new Button();
			NewEC_Window_label1 = new Label();
			NewEC_Window_label2 = new Label();
			NewEC_Window_label3 = new Label();
			NewEC_Window_flowLayoutPanel1 = new FlowLayoutPanel();
			NewEC_Window_textBox1 = new TextBox();
			NewEC_Window_textBox2 = new TextBox();
			NewEC_Window_textBox3 = new TextBox();
			NewEC_Window = new Form();
			NewEC_Window_flowLayoutPanel1.SuspendLayout();
			// 
			// button1
			// 
			NewEC_Window_button1.Location = new Point(77, 77);
			NewEC_Window_button1.Name = "NewEC_Window_button1";
			NewEC_Window_button1.Size = new Size(122, 30);
			NewEC_Window_button1.TabIndex = 1;
			NewEC_Window_button1.Text = "Add";
			NewEC_Window_button1.UseVisualStyleBackColor = true;
			NewEC_Window_button1.Click += new EventHandler(this.NewEC_Window_ValidateClick);
			// 
			// label1
			// 
			NewEC_Window_label1.Location = new Point(13, 0);
			NewEC_Window_label1.Name = "NewEC_Window_label1";
			NewEC_Window_label1.Size = new Size(70, 20);
			NewEC_Window_label1.TabIndex = 2;
			NewEC_Window_label1.Text = "Start frame";
			NewEC_Window_label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			NewEC_Window_label2.Location = new Point(89, 0);
			NewEC_Window_label2.Name = "NewEC_Window_label2";
			NewEC_Window_label2.Size = new Size(70, 20);
			NewEC_Window_label2.TabIndex = 3;
			NewEC_Window_label2.Text = "End frame";
			NewEC_Window_label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			NewEC_Window_label3.Location = new Point(165, 0);
			NewEC_Window_label3.Name = "NewEC_Window_label3";
			NewEC_Window_label3.Size = new Size(70, 20);
			NewEC_Window_label3.TabIndex = 4;
			NewEC_Window_label3.Text = "Type";
			NewEC_Window_label3.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// flowLayoutPanel1
			// 
			NewEC_Window_flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
			NewEC_Window_flowLayoutPanel1.Controls.Add(NewEC_Window_label1);
			NewEC_Window_flowLayoutPanel1.Controls.Add(NewEC_Window_label2);
			NewEC_Window_flowLayoutPanel1.Controls.Add(NewEC_Window_label3);
			NewEC_Window_flowLayoutPanel1.Controls.Add(NewEC_Window_textBox1);
			NewEC_Window_flowLayoutPanel1.Controls.Add(NewEC_Window_textBox2);
			NewEC_Window_flowLayoutPanel1.Controls.Add(NewEC_Window_textBox3);
			NewEC_Window_flowLayoutPanel1.Location = new Point(13, 12);
			NewEC_Window_flowLayoutPanel1.Name = "NewEC_Window_flowLayoutPanel1";
			NewEC_Window_flowLayoutPanel1.Padding = new Padding(10, 0, 0, 0);
			NewEC_Window_flowLayoutPanel1.Size = new Size(249, 56);
			NewEC_Window_flowLayoutPanel1.TabIndex = 5;
			// 
			// textBox1
			// 
			NewEC_Window_textBox1.BorderStyle = BorderStyle.FixedSingle;
			NewEC_Window_textBox1.Location = new Point(13, 23);
			NewEC_Window_textBox1.Name = "NewEC_Window_textBox1";
			NewEC_Window_textBox1.Size = new Size(70, 20);
			NewEC_Window_textBox1.TabIndex = 5;
			NewEC_Window_textBox1.TextChanged += new EventHandler(ShortTextboxTextChanged);
			NewEC_Window_textBox1.Text = "0";
			// 
			// textBox2
			// 
			NewEC_Window_textBox2.BorderStyle = BorderStyle.FixedSingle;
			NewEC_Window_textBox2.Location = new Point(89, 23);
			NewEC_Window_textBox2.Name = "NewEC_Window_textBox2";
			NewEC_Window_textBox2.Size = new Size(70, 20);
			NewEC_Window_textBox2.TabIndex = 6;
			NewEC_Window_textBox2.TextChanged += new EventHandler(ShortTextboxTextChanged);
			NewEC_Window_textBox2.Text = "0";
			// 
			// textBox3
			// 
			NewEC_Window_textBox3.BorderStyle = BorderStyle.FixedSingle;
			NewEC_Window_textBox3.Location = new Point(165, 23);
			NewEC_Window_textBox3.Name = "NewEC_Window_textBox3";
			NewEC_Window_textBox3.Size = new Size(70, 20);
			NewEC_Window_textBox3.TabIndex = 7;
			NewEC_Window_textBox3.TextChanged += new EventHandler(ShortTextboxTextChanged);
			NewEC_Window_textBox3.Text = "0";
			// 
			// MainForm
			// 
			NewEC_Window.AutoScaleDimensions = new SizeF(6F, 13F);
			NewEC_Window.AutoScaleMode = AutoScaleMode.Font;
			NewEC_Window.ClientSize = new Size(273, 116);
			NewEC_Window.Controls.Add(NewEC_Window_flowLayoutPanel1);
			NewEC_Window.Controls.Add(NewEC_Window_button1);
			NewEC_Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			NewEC_Window.MaximizeBox = false;
			NewEC_Window.MaximumSize = new Size(289, 150);
			NewEC_Window.MinimizeBox = false;
			NewEC_Window.MinimumSize = new Size(289, 150);
			NewEC_Window.Name = "NewEC_Window";
			NewEC_Window.ShowInTaskbar = false;
			NewEC_Window.SizeGripStyle = SizeGripStyle.Hide;
			NewEC_Window.StartPosition = FormStartPosition.CenterParent;
			NewEC_Window.Text = "Add";
			NewEC_Window_flowLayoutPanel1.ResumeLayout(false);
			NewEC_Window_flowLayoutPanel1.PerformLayout();
		}
		
		
		//Adapt text short (2 bytes)
		void ShortTextboxTextChanged(object sender, EventArgs e)
		{
			try
			{
				TextBox Txb = (sender as TextBox);
				if (Txb.Text != "Auto")
				{
					int selected = Txb.SelectionStart > 4 ? 5 : Txb.SelectionStart;
					int max_ = (Txb==NewEC_Window_textBox3) ? 255:short.MaxValue;
					int min = (Txb==NewEC_Window_textBox3) ? 0:short.MinValue;
					if (int.Parse(Txb.Text)>max_)
						Txb.Text=max_.ToString();
					if (int.Parse(Txb.Text)<min)
						Txb.Text=min.ToString();
					Txb.Text= short.Parse(Txb.Text).ToString();
					Txb.Select(selected,0);
					NewEC_Window_button1.Enabled = true;
					if (last_focused_group==1)
					{
						NewEC_Window_textBox2.Enabled = (NewEC_Window_textBox3.Text == "23" |NewEC_Window_textBox3.Text == "24");
						if (NewEC_Window_textBox2.Enabled)
						{
							if (NewEC_Window_textBox2.Text == "Auto")
								NewEC_Window_textBox2.Text = "0";
						}
						else
							NewEC_Window_textBox2.Text = "Auto";
					}
				}
				
			} catch {NewEC_Window_button1.Enabled = false;}
		}
		
		
		//Validate
		void NewEC_Window_ValidateClick(object sender, EventArgs e)
		{
			bool pas_ec = true;
			//Si ec absent
			try {pas_ec = (ASCIIString(SubArray(mset_stream,location+48+ReadInteger4(GetBARline(location,9)+12),3))=="BAR");} catch {}
			if (pas_ec)
			{
				mset_stream = Combine(Combine(SubArray(mset_stream,0,location_EC_cut),new byte[] {0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0}),SubArray(mset_stream,location_EC_cut,mset_stream.Length-location_EC_cut));
				WriteInteger4(GetBARline(location,16)+12,4);
				WriteInteger4(GetBARline(location,16)+8,48+ReadInteger4(GetBARline(location,9)+12));
				ActualiserPointeursBar(location_EC_cut,16);
				ectobar_=16;
			}
			byte[] start_frame = BitConverter.GetBytes(short.Parse(NewEC_Window_textBox1.Text));
			byte[] end_frame = (last_focused_group==0) ? BitConverter.GetBytes(short.Parse(NewEC_Window_textBox2.Text)) : new byte[2];
			
			
			byte type = byte.Parse(NewEC_Window_textBox3.Text);
			byte[] valeur = (last_focused_group==1&&(type == 23 | type == 24)) ?
				BitConverter.GetBytes(short.Parse(NewEC_Window_textBox2.Text)-short.Parse(NewEC_Window_textBox1.Text)) :new byte[2];
			
			byte[] EC = (type ==0) ? new byte[] {start_frame[0],start_frame[1],end_frame[0],end_frame[1],type,0} : new byte[][] {new byte[] {start_frame[0],start_frame[1],end_frame[0],end_frame[1],type,1,0,0},new byte[] {start_frame[0],start_frame[1],type,1,valeur[0],valeur[1]}}[last_focused_group];
			AddEC((byte)last_focused_group,EC);
			
			Moves_listSelectedIndexChanged(null,null);
			DefineLastAdded(EC);
			NewEC_Window.Close();
		}
	}
}
