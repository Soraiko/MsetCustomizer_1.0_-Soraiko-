using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm : Form
	{
		
		private Form PresentFilesList;
		private GroupBox PresentFilesList_groupBox1;
		private ListView PresentFilesList_listView1;
		private ColumnHeader PresentFilesList_columnHeader3;
		private Button PresentFilesList_button1;
		private ColumnHeader PresentFilesList_columnHeader1;
		private ColumnHeader PresentFilesList_columnHeader2;
		private ColumnHeader PresentFilesList_columnHeader4;
		private ColumnHeader PresentFilesList_columnHeader5;
		
		private void Initialize_PresentFilesListWindow_Componnents()
		{
			PresentFilesList= new Form();
			PresentFilesList_groupBox1 = new GroupBox();
			PresentFilesList_button1 = new Button();
			PresentFilesList_listView1 = new ListView();
			PresentFilesList_columnHeader1 = new ColumnHeader();
			PresentFilesList_columnHeader2 = new ColumnHeader();
			PresentFilesList_columnHeader3 = new ColumnHeader();
			PresentFilesList_columnHeader4 = new ColumnHeader();
			PresentFilesList_columnHeader5 = new ColumnHeader();
			PresentFilesList_groupBox1.SuspendLayout();
			PresentFilesList.SuspendLayout();
			// 
			// PresentFilesList_groupBox1
			// 
			PresentFilesList_groupBox1.Controls.Add(PresentFilesList_button1);
			PresentFilesList_groupBox1.Controls.Add(PresentFilesList_listView1);
			PresentFilesList_groupBox1.Location = new Point(13, 8);
			PresentFilesList_groupBox1.Name = "PresentFilesList_groupBox1";
			PresentFilesList_groupBox1.Size = new Size(430, 227);
			PresentFilesList_groupBox1.TabIndex = 0;
			PresentFilesList_groupBox1.TabStop = false;
			// 
			// PresentFilesList_button1
			// 
			PresentFilesList_button1.Location = new Point(14, 178);
			PresentFilesList_button1.Name = "PresentFilesList_button1";
			PresentFilesList_button1.Size = new Size(400, 36);
			PresentFilesList_button1.TabIndex = 1;
			PresentFilesList_button1.Text = "Add this pointer to Bar slot";
			PresentFilesList_button1.UseVisualStyleBackColor = true;
			PresentFilesList_button1.Click += new System.EventHandler(PresentFilesList_button1Click);
			// 
			// PresentFilesList_listView1
			// 
			PresentFilesList_listView1.Columns.AddRange(new ColumnHeader[] {
			                                            	PresentFilesList_columnHeader1,
			                                            	PresentFilesList_columnHeader2,
			                                            	PresentFilesList_columnHeader3,
			                                            	PresentFilesList_columnHeader4,
			                                            	PresentFilesList_columnHeader5});
			PresentFilesList_listView1.FullRowSelect = true;
			PresentFilesList_listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			PresentFilesList_listView1.Location = new Point(14, 21);
			PresentFilesList_listView1.Name = "PresentFilesList_listView1";
			PresentFilesList_listView1.Size = new Size(400-SystemInformation.VerticalScrollBarWidth+19, 150);
			
			PresentFilesList_listView1.TabIndex = 0;
			PresentFilesList_listView1.UseCompatibleStateImageBehavior = false;
			PresentFilesList_listView1.View = View.Details;
			PresentFilesList_listView1.DoubleClick += new EventHandler(PresentFilesList_listView1DoubleClick);
			PresentFilesList_listView1.ColumnWidthChanged += new ColumnWidthChangedEventHandler(PresentFilesList_listViewColumnWidthChanged);
			// 
			// PresentFilesList_columnHeader1
			// 
			PresentFilesList_columnHeader1.Text = "ANB Name";
			PresentFilesList_columnHeader1.Width = 76;
			// 
			// PresentFilesList_columnHeader2
			// 
			PresentFilesList_columnHeader2.Text = "EC Name";
			PresentFilesList_columnHeader2.Width = 76;
			// 
			// PresentFilesList_columnHeader3
			// 
			PresentFilesList_columnHeader3.Text = "Location";
			PresentFilesList_columnHeader3.Width = 76;
			// 
			// PresentFilesList_columnHeader4
			// 
			PresentFilesList_columnHeader4.Text = "Length";
			PresentFilesList_columnHeader4.Width = 76;
			// 
			// PresentFilesList_columnHeader5
			// 
			PresentFilesList_columnHeader5.Text = "";
			PresentFilesList_columnHeader5.Width = 76;
			// 
			// MainForm
			// 
			PresentFilesList.AutoScaleDimensions = new SizeF(6F, 13F);
			PresentFilesList.AutoScaleMode = AutoScaleMode.Font;
			PresentFilesList.ClientSize = new Size(457, 249);
			PresentFilesList.Controls.Add(PresentFilesList_groupBox1);
			PresentFilesList.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			PresentFilesList.MaximizeBox = false;
			PresentFilesList.MinimizeBox = false;
			PresentFilesList.Name = "MainForm";
			PresentFilesList.ShowIcon = false;
			PresentFilesList.ShowInTaskbar = false;
			PresentFilesList.SizeGripStyle = SizeGripStyle.Hide;
			PresentFilesList.Text = "Present files";
			PresentFilesList.StartPosition = FormStartPosition.CenterParent;
			PresentFilesList_groupBox1.ResumeLayout(false);
			PresentFilesList.ResumeLayout(false);

		}
		//Click fenetre pointeurs
		void PresentFilesList_listView1DoubleClick(object sender, EventArgs e) {UpdateHeader();}
		void PresentFilesList_button1Click(object sender, EventArgs e) {UpdateHeader();}
		
		//Mettre header
		void UpdateHeader()
		{
			for (int i = 0;i<15;i++) mset_stream[0x10+(moves_list.SelectedIndex*16)+i] = bars[PresentFilesList_listView1.FocusedItem.Index][i];
			Moves_listSelectedIndexChanged(null,null);
			moves_list.Refresh();
			PresentFilesList.Close();
		}
		
		//Largeur
		void PresentFilesList_listViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
		{
			PresentFilesList_listView1.ColumnWidthChanged -= new ColumnWidthChangedEventHandler(PresentFilesList_listViewColumnWidthChanged);
			PresentFilesList_columnHeader1.Width = PresentFilesList_columnHeader2.Width = PresentFilesList_columnHeader4.Width = PresentFilesList_columnHeader5.Width = 76;
			PresentFilesList_listView1.ColumnWidthChanged += new ColumnWidthChangedEventHandler(PresentFilesList_listViewColumnWidthChanged);
		}
		
		//Fonction remplissage listbox (Listage des fichiers pointés et non pointés)
		List<byte[]> bars = new List<byte[]>(0);
		void Main_to_PresentFilesList()
		{
			bars.Clear();
			int in_header = 0;
			PresentFilesList_listView1.Items.Clear();
			List<int> bars_4stirng = new List<int>(0);
			
			//Fichier pointés
			for (int i=0;i<moves_list.Items.Count-1;i++)
				try {
				int loc = ReadInteger4(0x18+(i*16));
				if (ReadInteger4(0x1C+(i*16))>0&&BTS(SubArray(mset_stream,loc,3))== "42-41-52"&&GetBARline(loc,9)>0)
				{
					bool add_or_not = true;
					foreach (byte[] curr_bar_array in bars)
						if (BTS(curr_bar_array)==BTS(SubArray(mset_stream,0x10+(i*16),16)))
							add_or_not=false;
						
					if (add_or_not)
					{
						PresentFilesList_listView1.Items.Add(new ListViewItem(new string[] {ReadString(GetBARline(loc,9)+4),ReadString(GetBARline(loc,16)+4),"0x"+ReadInteger4(0x18+(i*16)).ToString("X"),"0x"+ReadInteger4(0x1C+(i*16)).ToString("X"),"Pointed"}));
						bars.Add(SubArray(mset_stream,0x10+(i*16),16));
					}
				}} catch{}
			
			int next_BAR=0;
			//Fichier non pointés
			int offset = 16;
			do
			{
				try
				{
					next_BAR = SearchBytes(SubArray(mset_stream,offset,mset_stream.Length-offset),new byte[] {0x42,0x41,0x52,1});
					if (next_BAR>=0)
					{
						next_BAR+=offset;
						byte[] add = BitConverter.GetBytes(next_BAR);
						in_header = SearchBytes(SubArray(mset_stream,0,16+16*ReadInteger4(4)),add);
						
						int longueur_pointed = 0;
						try {longueur_pointed = ReadInteger4(GetBARline(next_BAR,9)+12)+ReadInteger4(GetBARline(next_BAR,16)+12)+0x30;} catch {}
						if (in_header==-1)
							if (GetBARline(next_BAR,9)>=0)
							{
								PresentFilesList_listView1.Items.Add(new ListViewItem(new string[] {ReadString(GetBARline(next_BAR,9)+4), ReadString(GetBARline(next_BAR,16)+4), "0x"+next_BAR.ToString("X"), "0x"+(ReadInteger4(GetBARline(next_BAR,9)+12)+ReadInteger4(GetBARline(next_BAR,16)+12)+0x30).ToString("X"),"Not Pointed"}));
								bars.Add(Combine(Combine(Combine(new byte[] {17,0,0,0},SubArray(mset_stream,GetBARline(next_BAR,9)+4,4)),BitConverter.GetBytes(next_BAR)),
				                BitConverter.GetBytes(longueur_pointed)));
							}
						offset=next_BAR+16;
					}
				}
				catch
				{
					
				}
			}
			while (next_BAR>=0);
			PresentFilesList.ShowDialog();
		}
		
		
		
	}
}
