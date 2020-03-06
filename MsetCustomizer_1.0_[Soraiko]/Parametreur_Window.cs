using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm : Form
	{
		private FlowLayoutPanel Parametreur_flowLayoutPanel1;
		private Button Parametreur_Add;
		private PictureBox Parametreur_pictureBox1;
		private GroupBox Parametreur_groupBox1;
		private TextBox Parametreur_Value_1;
		private Label Parametreur_label1;
		private Button Parametreur_Validate;
		private Form Parametreur_MainForm;
		private System.Windows.Forms.Button Parametreur_Remove;
		
		private void Initialize_ParametreurWindow_Component()
		{
			Parametreur_MainForm= new Form();
			Parametreur_flowLayoutPanel1 = new FlowLayoutPanel();
			Parametreur_Add = new Button();
			Parametreur_pictureBox1 = new PictureBox();
			Parametreur_groupBox1 = new GroupBox();
			Parametreur_Value_1 = new TextBox();
			Parametreur_label1 = new Label();
			Parametreur_Validate = new Button();
			this.Parametreur_Remove = new System.Windows.Forms.Button();
			Parametreur_flowLayoutPanel1.SuspendLayout();
			((ISupportInitialize)(Parametreur_pictureBox1)).BeginInit();
			Parametreur_groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// Parametreur_flowLayoutPanel1
			// 
			Parametreur_flowLayoutPanel1.Controls.Add(Parametreur_Add);
			Parametreur_flowLayoutPanel1.Controls.Add(Parametreur_Remove);
			Parametreur_flowLayoutPanel1.Dock = DockStyle.Fill;
			Parametreur_flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			Parametreur_flowLayoutPanel1.Location = new Point(0, 0);
			Parametreur_flowLayoutPanel1.Name = "Parametreur_flowLayoutPanel1";
			Parametreur_flowLayoutPanel1.Padding = new Padding(40, 0, 0, 0);
			Parametreur_flowLayoutPanel1.Size = new Size(205, 183);
			Parametreur_flowLayoutPanel1.TabIndex = 0;
			Parametreur_flowLayoutPanel1.WrapContents = false;
			Parametreur_flowLayoutPanel1.AutoScroll = true;
			// 
			// Parametreur_Add
			// 
			Parametreur_Add.Location = new Point(43, 8);
			Parametreur_Add.Name = "Parametreur_Add";
			Parametreur_Add.Size = new Size(120, 23);
			Parametreur_Add.TabIndex = 1;
			Parametreur_Add.Text = "Add Parameter";
			Parametreur_Add.UseVisualStyleBackColor = true;
			Parametreur_Add.Click += new EventHandler(Parametreur_AddClick);
			// 
			// Parametreur_Remove
			// 
			this.Parametreur_Remove.Location = new System.Drawing.Point(43, 37);
			this.Parametreur_Remove.Name = "Parametreur_Remove";
			this.Parametreur_Remove.Size = new System.Drawing.Size(120, 23);
			this.Parametreur_Remove.TabIndex = 2;
			this.Parametreur_Remove.Text = "Remove Parameter";
			this.Parametreur_Remove.UseVisualStyleBackColor = true;
			this.Parametreur_Remove.Click += new System.EventHandler(this.Parametreur_RemoveClick);
			// 
			// Parametreur_pictureBox1
			// 
			Parametreur_pictureBox1.Location = new Point(12, 12);
			Parametreur_pictureBox1.Name = "Parametreur_pictureBox1";
			Parametreur_pictureBox1.Size = new Size(50, 50);
			Parametreur_pictureBox1.TabIndex = 1;
			Parametreur_pictureBox1.TabStop = false;
			// 
			// Parametreur_groupBox1
			// 
			Parametreur_groupBox1.Controls.Add(Parametreur_flowLayoutPanel1);
			Parametreur_groupBox1.Location = new Point(12, 68);
			Parametreur_groupBox1.Margin = new Padding(30);
			Parametreur_groupBox1.Name = "Parametreur_groupBox1";
			Parametreur_groupBox1.Size = new Size(205, 183);
			Parametreur_groupBox1.TabIndex = 2;
			Parametreur_groupBox1.TabStop = false;
			Parametreur_groupBox1.Text = "Parameters";
			// 
			// Parametreur_Value_1
			// 
			Parametreur_Value_1.BorderStyle = BorderStyle.FixedSingle;
			Parametreur_Value_1.CharacterCasing = CharacterCasing.Upper;
			Parametreur_Value_1.Location = new Point(101, 42);
			Parametreur_Value_1.Name = "Parametreur_Value_1";
			Parametreur_Value_1.Size = new Size(100, 20);
			Parametreur_Value_1.TabIndex = 3;
			Parametreur_Value_1.TextAlign = HorizontalAlignment.Center;
			Parametreur_Value_1.TextChanged += new EventHandler(Parametreur_Value_1TextChanged);
			// 
			// Parametreur_label1
			// 
			Parametreur_label1.Location = new Point(101, 10);
			Parametreur_label1.Name = "Parametreur_label1";
			Parametreur_label1.Size = new Size(100, 29);
			Parametreur_label1.TabIndex = 4;
			Parametreur_label1.Text = "Value:\r\n(Parameter 1)";
			Parametreur_label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// Parametreur_Validate
			// 
			Parametreur_Validate.Location = new Point(74, 257);
			Parametreur_Validate.Name = "Parametreur_Validate";
			Parametreur_Validate.Size = new Size(75, 23);
			Parametreur_Validate.TabIndex = 5;
			Parametreur_Validate.Text = "OK";
			Parametreur_Validate.UseVisualStyleBackColor = true;
			Parametreur_Validate.Click += new EventHandler(this.Parametreur_ValidateClick);
			// 
			// Parametreur_MainForm
			// 
			Parametreur_MainForm.AutoScaleDimensions = new SizeF(6F, 13F);
			Parametreur_MainForm.AutoScaleMode = AutoScaleMode.Font;
			Parametreur_MainForm.ClientSize = new Size(227, 285);
			Parametreur_MainForm.Controls.Add(Parametreur_Validate);
			Parametreur_MainForm.Controls.Add(Parametreur_label1);
			Parametreur_MainForm.Controls.Add(Parametreur_Value_1);
			Parametreur_MainForm.Controls.Add(Parametreur_groupBox1);
			Parametreur_MainForm.Controls.Add(Parametreur_pictureBox1);
			Parametreur_MainForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Parametreur_MainForm.MaximizeBox = false;
			Parametreur_MainForm.MinimizeBox = false;
			Parametreur_MainForm.Name = "Parametreur_MainForm";
			Parametreur_MainForm.ShowIcon = false;
			Parametreur_MainForm.ShowInTaskbar = false;
			Parametreur_MainForm.SizeGripStyle = SizeGripStyle.Hide;
			Parametreur_MainForm.StartPosition = FormStartPosition.CenterParent;
			Parametreur_MainForm.Text = "Parameters";
			Parametreur_MainForm.FormClosing += new FormClosingEventHandler(Parametreur_MainFormFormClosing);
			
			Parametreur_flowLayoutPanel1.ResumeLayout(false);
			((ISupportInitialize)(Parametreur_pictureBox1)).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		
		readonly List<TextBox> parametres = new List<TextBox>(0);
		
		//Add empty parameter
		void Parametreur_AddClick(object sender, EventArgs e)
		{
			AddParamSlot("0");
		}
		
		//Annulation
		void Parametreur_MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			Parametreur_flowLayoutPanel1.Controls.Clear();
			parametres.Clear();
		}
		
		int address_ec_parametrer = 0;
		int old_ec_length_parametrer = 0;
		//Validate
		void Parametreur_ValidateClick(object sender, EventArgs e)
		{
			ectobar_ = GetEcToBar(location_EC_cut);
			int base_length = new int[] {6,4}[last_focused_group];
			int ecs_length = ReadInteger4(GetBARline(location,16)+12);
			int addition_ec_length = (base_length+parametres.Count*2)-old_ec_length_parametrer;
			
			mset_stream[address_ec_parametrer+base_length-1] = (byte)parametres.Count;
			byte[] EC = Combine(SubArray(mset_stream,address_ec_parametrer,base_length),new byte[parametres.Count*2]);
			for (int i=0;i<parametres.Count;i++)
			{
				short curr_par = short.Parse(parametres[i].Text);
				byte[] curr_par_byte_array = BitConverter.GetBytes(curr_par);
				EC[base_length+i*2]=curr_par_byte_array[0];
				EC[base_length+i*2+1]=curr_par_byte_array[1];
			}
			AddECLine(1);
			int missing = (addition_ec_length-(ectobar_-ecs_length));
			if (missing>0&&addition_ec_length>0)
				AddECLine(AdjustBy16(missing)/16);
			
			byte[] after = SubArray(mset_stream,address_ec_parametrer+old_ec_length_parametrer,location_EC_cut+ectobar_-address_ec_parametrer-old_ec_length_parametrer);
			for (int i = address_ec_parametrer;i<ectobar_;i++)
				mset_stream[i] = 0;
			for (int i = 0;i<EC.Length;i++)
				mset_stream[address_ec_parametrer+i] = EC[i];
			for (int i = 0;i<after.Length;i++)
				mset_stream[address_ec_parametrer+EC.Length+i] = after[i];
			
			if (last_focused_group == 0)
				WriteInteger2(location_EC_cut+2,(short)(ReadInteger2(location_EC_cut+2)+addition_ec_length));
			
			RemoveAdditionnalLines();
			Moves_listSelectedIndexChanged(null,null);
			DefineLastAdded(EC);
			Parametreur_MainForm.Close();
		}
		
		//Add parameter with initial string
		void AddParamSlot(string valeur)
		{
			if (parametres.Count == 0)
			{
				Parametreur_Value_1.Enabled = true;
				Parametreur_Value_1.Text = valeur;
			}
			var new_one = new TextBox();
			new_one.BorderStyle = BorderStyle.FixedSingle;
			new_one.TextAlign = HorizontalAlignment.Center;
			new_one.Size = new Size(120, 23);
			new_one.Text = valeur;
			new_one.TextChanged += new EventHandler(Parametreur_x_1TextChanged);
			new_one.CharacterCasing = CharacterCasing.Upper;
			parametres.Add(new_one);
			Parametreur_flowLayoutPanel1.Controls.Clear();
			Parametreur_flowLayoutPanel1.Controls.AddRange(parametres.ToArray());
			Parametreur_flowLayoutPanel1.Controls.Add(Parametreur_Add);
			Parametreur_flowLayoutPanel1.Controls.Add(Parametreur_Remove);
		}
		
		//Edit parameter 1 (2 bytes)
		void Parametreur_Value_1TextChanged(object sender, EventArgs e)
		{
			try
			{
				int selected = Parametreur_Value_1.SelectionStart > 4 ? 5 : Parametreur_Value_1.SelectionStart;
				if (int.Parse(Parametreur_Value_1.Text)>short.MaxValue)
					Parametreur_Value_1.Text=short.MaxValue.ToString();
				if (int.Parse(Parametreur_Value_1.Text)<short.MinValue)
					Parametreur_Value_1.Text=short.MinValue.ToString();
				Parametreur_Value_1.Text= short.Parse(Parametreur_Value_1.Text).ToString();
				parametres[0].Text = Parametreur_Value_1.Text;
				Parametreur_Value_1.Select(selected,0);
				Parametreur_Validate.Enabled = true;
			} catch {Parametreur_Validate.Enabled = !Parametreur_MainForm.Modal;}
		}
		
		//Edit parameter x (2 bytes)
		void Parametreur_x_1TextChanged(object sender, EventArgs e)
		{
			try
			{
				TextBox Txb = (sender as TextBox);
				int selected = Txb.SelectionStart > 4 ? 5 : Txb.SelectionStart;
				if (Txb==parametres[0]) Parametreur_Value_1.Text = Txb.Text;
				
				if (int.Parse(Txb.Text)>short.MaxValue)
					Txb.Text=short.MaxValue.ToString();
				if (int.Parse(Txb.Text)<short.MinValue)
					Txb.Text=short.MinValue.ToString();
				Txb.Text= short.Parse(Txb.Text).ToString();
				Txb.Select(selected,0);
				Parametreur_Validate.Enabled = true;
			} catch {Parametreur_Validate.Enabled = false;}
		}
		
		//Remove parameter
		void Parametreur_RemoveClick(object sender, EventArgs e)
		{
			if (parametres.Count>0)
			{
				Parametreur_flowLayoutPanel1.Controls.Remove(parametres[parametres.Count-1]);
				parametres.Remove(parametres[parametres.Count-1]);
			}
			if (parametres.Count==0)
			{
				Parametreur_Value_1.Text = "";
				Parametreur_Value_1.Enabled = false;
			}
			else
				Parametreur_Value_1.Enabled = true;
			
		}
	}
}
