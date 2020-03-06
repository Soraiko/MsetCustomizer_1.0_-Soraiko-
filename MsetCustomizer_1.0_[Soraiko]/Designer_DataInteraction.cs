using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm
	{
		[DllImport("user32.dll")]
    	public extern static Int16 GetKeyState(Int16 nVirtKey);
    	
		Rectangle FrameRectangle;
		//Updte ingame bar
		void Paneltime_ingamePaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			try
			{
				g.FillRectangle(Brushes.Red, FrameRectangle);
			} catch {}
		}
		
		//Updte paneltime bar
		void PaneltimePaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if (RectangledFrames.Width>0)
			try
			{
				LinearGradientBrush brush = new LinearGradientBrush(RectangledFrames,SystemColors.ControlDark,new Color[] {SystemColors.ControlDark,SystemColors.Control}[RectangledFramesIndex],LinearGradientMode.Horizontal);
				g.FillRectangle(brush, RectangledFrames);
				int left = (RectangledFramesIndex==1&&RectangledFrames.X==0)? 1 : RectangledFrames.X;
				g.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(left-1+RectangledFramesIndex,RectangledFrames.Y-1,RectangledFrames.Width+1-RectangledFramesIndex,RectangledFrames.Height));
			} catch {}
			else
				g.Clear((sender as PictureBox).BackColor);
			
		}
		
		void Label_whiteClick(object sender, EventArgs e)
		{
			MessageBox.Show("White Slots are \"DUMMY\" slots.\r\n"+
			                "\"DUMMY\" slots are \"empty\" slots.\r\n"+
			                "But they generally point at the end of the BAR header list \r\n"+
			                "(Location of first ANB) but with a 0 length.\r\n","Color: White", MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		void Label_grayClick(object sender, EventArgs e)
		{
			MessageBox.Show("Gray Slots are \"ANB\" slots.\r\n"+
			                "If the application finds a pointed ANB, the slot gets gray.\r\n"+
			                "Deleting a Gray slot makes it turn to a \"DUMMY\" slot.\r\n\r\n"+
			                "Warning ! Deleting a Bar slot does not delete the pointed file.\r\n" +
			                "To delete the pointed file, right click the Bar slot and click \r\n" +
			                "[Delete pointed file...].\r\n\r\n"+
			                "If the deleted ANB file was pointed by others Bar slots,\r\n"+
			                "they will all turn into \"DUMMY\".","Color: Gray", MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		void Label_dark_grayClick(object sender, EventArgs e)
		{
			MessageBox.Show("Dark Gray Slots are \"Second\" movesets slots.\r\n"+
			                "Second moveset usually are for P_Exxx && W_Exxx models, and\r\n"+
			                "can be in any moveset. (Boss, Skateboard, Chest...)\r\n\r\n"+
			                "You can extract/replace it in a new file and then open it another "+AppName+".\r\n"+
			                "[Right click]>[Extract pointed file...]"
			                ,"Color: Dark Gray", MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		void Label_redClick(object sender, EventArgs e)
		{
			MessageBox.Show("Red Slots are \"Duplicating\" slots,\r\n"+
			                "they appear red when you port a Bar slot to another.\r\n"+
			                "[Right click]>[Duplicate Bar slot...]\r\n\r\n"+
			                "Duplicating a Bar slot can be useful if you want two ANB slots\r\n"+
			                "to point one ANB file.\r\n"+
			                "(Duplication must be applied on a DUMMY slot !)"
			                ,"Color: Red", MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		void Label_orangeClick(object sender, EventArgs e)
		{
			MessageBox.Show("Slots get orange when a pointer error has been detected.\r\n"+
			                "Right click on it and select [Fix this pointer...] to find\r\n" +
			                "the good pointer among the files present in the main moveset.","Color: Orange", MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		//Permettre clic droit
		void Moves_listMouseDown(object sender, MouseEventArgs e) {moves_list.SelectedIndex = moves_list.IndexFromPoint(e.X, e.Y);}
		
		//Ouverture et vérification du moveset
		void OpenMSET(string filename)
		{
			try
			{
			mset_stream = mset_stream_check;
			old_size = mset_stream.Length;
			dummy_sample = new byte[0];
			UpdateNumeros();
			moves_list.Items.Clear();
			moves_list.Items.AddRange(numeros.ToArray());
			moves_list.SelectedIndex = (moves_list.Items.Count > 0) ? 0 : -1;
			UpdateSizeDiff();
			label5_.Text = count.ToString();
			groupBox3.Enabled = moves_list.Items.Count>0;
			Delete.Enabled = (moves_list.Items.Count>0);
			Down.Enabled = moves_list.Items.Count>1;} catch {}
		}
		
		//Largeur
		void EC_listColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
		{
			EC1_list.ColumnWidthChanged -= new ColumnWidthChangedEventHandler(EC_listColumnWidthChanged);
			EC2_list.ColumnWidthChanged -= new ColumnWidthChangedEventHandler(EC_listColumnWidthChanged);
			FrameSEC1.Width=FrameEEC1.Width=IndexEC1.Width=TypeEC1.Width=FrameSEC2.Width=FrameEEC2.Width=IndexEC2.Width=TypeEC2.Width=70;
			EC1_list.ColumnWidthChanged += new ColumnWidthChangedEventHandler(EC_listColumnWidthChanged);
			EC2_list.ColumnWidthChanged += new ColumnWidthChangedEventHandler(EC_listColumnWidthChanged);
		}
		
		//Fermeture
		void MainFormFormClosing(object sender, FormClosingEventArgs e) {System.Diagnostics.Process.GetCurrentProcess().Kill();}
		
		//Drop du fichier Mset
		void Mset_FileDragDrop(object sender, DragEventArgs e)
		{
			string dropped_file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
			if (File.Exists(dropped_file))
				CheckAccessFileMSET(dropped_file);
			
		}
		//Drop du fichier Moveset
		void Mset_FileDragOver(object sender, DragEventArgs e)
		{
			string over_file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
			e.Effect = File.Exists(over_file) ? DragDropEffects.Copy : DragDropEffects.None;
		}
		
		//Drop du fichier EC
		void EC_FileDragDrop(object sender, DragEventArgs e)
		{
			string dropped_file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
			if (File.Exists(dropped_file))
				OpenECFile(dropped_file);
		}
		
		//Drop du fichier EC
		void EC_FileDragOver(object sender, DragEventArgs e)
		{
			string over_file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
			e.Effect = File.Exists(over_file) ? DragDropEffects.Copy : DragDropEffects.None;
		}
		
		//Ouverture avec le bouton
		void Mset_FileClick(object sender, EventArgs e)
		{
			try
			{
				SeekPCSX2();
				OpenMsetFileDialog.FileName = "";
				OpenMsetFileDialog.FileName = System.Text.Encoding.ASCII.GetString(ReadBytes(PTR(PTR(0x20341708,0x20000008),0x20000028),32)).TrimEnd('\0');
			} catch {}
			if (OpenMsetFileDialog.ShowDialog() == DialogResult.OK)
				CheckAccessFileMSET(OpenMsetFileDialog.FileName);
		}
		
		//Accès des Items possibles si fichier correct
		void EnabledComponnents()
		{
			SaveButton.Enabled = true;
			EC_SaveButton.Enabled =true;
			EC_File.Enabled =true;
			moves_list.Enabled = true;
			label3_.Enabled = true;
			label8_.Enabled = true;
		}
		
		//Mise à jour de la difference de taille générale (ROUGE && VERT)
		void UpdateSizeDiff()
		{
			label4_.Text = "0x"+old_size.ToString("X");
			label9_.Text = "0x"+mset_stream.Length.ToString("X") + save_label;
			save_label="";
			label9_.BackColor = ((old_size >=  mset_stream.Length)) ? Color.FromArgb(150,255, 150) : Color.FromArgb(255,150, 150);
		}
		//Montée
		void UpClick(object sender, EventArgs e)
		{
			byte[] up_one = SubArray(mset_stream,(moves_list.SelectedIndex*16),16);
			string up_numeros_string = numeros[moves_list.SelectedIndex].ToString();
			for (int i = 0;i<15;i++)
			{
				mset_stream[0x10+(moves_list.SelectedIndex*16)+i] = up_one[i];
				mset_stream[(moves_list.SelectedIndex*16)+i] = header_list_bytes[i];
			}
			numeros[moves_list.SelectedIndex] = numeros[moves_list.SelectedIndex-1].ToString();
			numeros[moves_list.SelectedIndex-1] = up_numeros_string;
			moves_list.SelectedIndex--;
		}
		
		//Descente
		void DownClick(object sender, EventArgs e)
		{
			byte[] down_one = SubArray(mset_stream,0x20+(moves_list.SelectedIndex*16),16);
			string down_numeros_string = numeros[moves_list.SelectedIndex+1].ToString();
			for (int i = 0;i<15;i++)
			{
				mset_stream[0x10+(moves_list.SelectedIndex*16)+i] = down_one[i];
				mset_stream[0x20+(moves_list.SelectedIndex*16)+i] = header_list_bytes[i];
			}
			numeros[moves_list.SelectedIndex+1] = numeros[moves_list.SelectedIndex].ToString();
			numeros[moves_list.SelectedIndex] = down_numeros_string;
			moves_list.SelectedIndex++;
		}
		
		//Relachement du drop
		void Moves_listDragDrop(object sender, DragEventArgs e)
		{
			if (moves_list.Items.Count>0)
			{
				string dropped_file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
				if (File.Exists(dropped_file))
				{
					bool confirm = (numeros[moves_list.SelectedIndex].Length == 0) || MessageBox.Show("The pointed file will be replaced !\r\n Continue ?", "Warning !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
					if (confirm)
						CheckAccessFileANB_MSET(dropped_file);
				}
			}
		}
		
		//Drop du fichier Moveset
		void Moves_listDragOver(object sender, DragEventArgs e)
		{
			if (moves_list.Items.Count>0)
			{
				string over_file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
				if (File.Exists(over_file))
					e.Effect = DragDropEffects.Copy;
				else
					e.Effect = DragDropEffects.None;
				
			}
		}
		
		//Sauvegarde du fichier
		void SaveClick(object sender, EventArgs e)
		{
			SaveMsetFileDialog.InitialDirectory = Path.GetFullPath(Path.GetDirectoryName(mset_filename));
			SaveMsetFileDialog.FileName = Path.GetFileNameWithoutExtension(mset_filename)+"_New";
			if (SaveMsetFileDialog.ShowDialog() == DialogResult.OK) try {
				File.WriteAllBytes(SaveMsetFileDialog.FileName,mset_stream);} catch {
				MessageBox.Show("Unable to save the file.\r\nIt is maybe used by another process.","Write Access denied",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);}
		}
		
		//Début duplication
		void CopyHeaderClick(object sender, EventArgs e)
		{
			if (ReadInteger4(0x1C+(moves_list.SelectedIndex*16))>0)
			{
				copyHeader.Text = "Stop Duplication";
				if (CopyBlink.Enabled)
					StopDuplication();
				else
					CopyBlink.Enabled = true;
			}
			else
				MessageBox.Show("You cannot port a DUMMY slot.","Unable to duplicate BAR slot", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}
		
		//Fin duplication
		void StopDuplication()
		{
			copyHeader.Text = "Duplicate ANB line...";
			CopyBlink.Enabled = false;
			highlight_color = SystemColors.MenuHighlight;
			moves_list.Refresh();
		}
		
		//Animation duplication
		void CopyBlinkTick(object sender, EventArgs e)
		{
			swicth = (swicth == false);
			highlight_color = (swicth) ? SystemColors.MenuHighlight : Color.Red;
			int visibleItems = moves_list.ClientSize.Height / moves_list.ItemHeight;
			if (moves_list.SelectedIndex >=  moves_list.TopIndex && moves_list.SelectedIndex <= moves_list.TopIndex+visibleItems)
			{
				moves_list.SelectedIndexChanged -= new EventHandler(Moves_listSelectedIndexChanged);
				int last = moves_list.SelectedIndex;
				moves_list.SelectedIndex = -1;
				moves_list.SelectedIndex = last;
				moves_list.SelectedIndexChanged += new EventHandler(Moves_listSelectedIndexChanged);
			}
		}
		
		
		//Touche enfoncée (Echap = Interrompre duplicaiton)
		void Moves_listKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				CleanClick(null,null);
			
			if (e.KeyCode == Keys.Escape)
				if (CopyBlink.Enabled)
					StopDuplication();
		}
		
		//Extraire ANB
		void ExtractClick(object sender, EventArgs e)
		{
			SaveANBFileDialog.InitialDirectory = Path.GetFullPath(Path.GetDirectoryName(mset_filename));
			if (header_list_bytes[0] == 0x11)
			{
				SaveANBFileDialog.FileName = label3_.Text;
				SaveANBFileDialog.Filter = "Anb Files|*.anb";
			}
			if (header_list_bytes[0] == 0x14)
			{
				SaveANBFileDialog.FileName = ASCIIString(SubArray(header_list_bytes,4,4));
				SaveANBFileDialog.Filter = "Mset Files|*.mset";
			}
			if (numeros[moves_list.SelectedIndex].Length>0)
			{	if (SaveANBFileDialog.ShowDialog() == DialogResult.OK) try {
				File.WriteAllBytes(SaveANBFileDialog.FileName,SubArray(mset_stream,location,longueur));} catch {
				MessageBox.Show("Unable to save the file.\r\nIt is maybe used by another process.","Write Access denied",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);}
			}
			else
				MessageBox.Show("The file you are trying to save is empty.\r\nPlease try another.","Empty file",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			
		}
		
		//Modification du nom du ANB
		void ChangementNomAnb()
		{
			label3_.Text = label3_.Text+"    ".Substring(0,4-label3_.Text.Length);
			byte[] new_name = System.Text.Encoding.ASCII.GetBytes(label3_.Text);
			
			for (int i = 0;i<ReadInteger4(location+4);i++)
				if (mset_stream[16+location+16*i] == 9)
			{
				//MAJ ANB
				for (int t = 0;t<4;t++) mset_stream[(16+location+16*i)+4+t] = new_name[t];
				i = ReadInteger4(location+4);
			}
			
			//MAJ ANB LISTE
			for (int t = 0;t<4;t++) mset_stream[0x14+(moves_list.SelectedIndex*16)+t] = new_name[t];
			UpdateNumeros();
			moves_list.Refresh();
		}
		
		//Modification du nom EC
		void ChangementNomEC()
		{
			label8_.Text = label8_.Text+"    ".Substring(0,4-label8_.Text.Length);
			byte[] new_name = System.Text.Encoding.ASCII.GetBytes(label8_.Text);
			for (int i = 0;i<ReadInteger4(location+4);i++)
				if (mset_stream[16+location+16*i] == 16)
			{
				//MAJ EC
				for (int t = 0;t<4;t++) mset_stream[(16+location+16*i)+4+t] = new_name[t];
				i = ReadInteger4(location+4);
			}
			UpdateNumeros();
			moves_list.Refresh();
		}
		
		//Label 3 quité (Nom ANB)
		void Label3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				ChangementNomAnb();
			
			if (e.KeyCode == Keys.Escape)
			{
				label3_.Parent.Focus();
				label3_.Text = old_label3_;
				old_label3_ = "";
			}
			moves_list.Refresh();
		}
		
		//Label 8 quitté (Nom EC)
		void Label8_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				ChangementNomEC();
			
			if (e.KeyCode == Keys.Escape)
			{
				label8_.Parent.Focus();
				label8_.Text = old_label8_;
				old_label8_ = "";
			}
			moves_list.Refresh();
		}
		
		//Quitter zone nom ANB
		void Label3_Leave(object sender, EventArgs e) {ChangementNomAnb();}
		//Historique si quitter zone
		string old_label3_ = ""; void Label3_Enter(object sender, EventArgs e) {old_label3_ = label3_.Text;}
		//Quitter zone nom EC
		void Label8_Leave(object sender, EventArgs e) {ChangementNomEC();}
		//Historique si quitter zone
		string old_label8_ = ""; void Label8_Enter(object sender, EventArgs e) {old_label8_ = label8_.Text;}
		
		//Supprimer scrolls
		void Update_FocusTick(object sender, EventArgs e)
		{
			UpdateListView();
			if (Update_Focus.Interval == 1)
			{
				Update_Focus.Interval=10;
			}
			else
			{
				Update_Focus.Enabled = false;
				Update_Focus.Interval = 1;
			}
		}
		
		//Supprimer scrolls
		void OnGlobalMouseMove(object sender, MouseEventArgs e)
		{
			ShowScrollBar(moves_list.Handle, 0, false);
			ShowScrollBar(EC1_list.Handle, 0, false);
			ShowScrollBar(EC2_list.Handle, 0, false);
		}
		
		//Supprimer scrolls && adapter listes
		void UpdateListView()
		{
			ShowScrollBar(moves_list.Handle, 0, false);
			ShowScrollBar(EC1_list.Handle, 0, false);
			ShowScrollBar(EC2_list.Handle, 0, false);
			if (last_focused_group==0)
			{
				try{EC1_list.EnsureVisible(EC1_list.FocusedItem.Index);} catch {}
				EC1_list.Refresh();
			}
			else
			{
				try{EC2_list.EnsureVisible(EC2_list.FocusedItem.Index);} catch {}
				EC2_list.Refresh();
			}
		}
		
		//Remove splitter blink
		void EC_splitterSplitterMoved(object sender, SplitterEventArgs e)
		{
			blink_preview.Visible = false;
			Split_blink.Enabled=false;
		}
		
		//Dessins des items
		private void Moves_listDrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
			int itemIndex = e.Index;

			if (itemIndex >= 0 && itemIndex < moves_list.Items.Count)
			{
				Graphics g = e.Graphics;
				
				// Background Color
				Color back = SystemColors.ScrollBar;
				if (numeros[e.Index].Length == 0)
					back = Color.White;
				
				if (mset_stream[0x10+(itemIndex*16)] == 0x14)
					back = Color.Gray;
				string suffixe = "            [";
				if (BAR_Errors[e.Index].Length>0)
				{
					back = Color.Orange;
					suffixe = @"    /!\     [";
				}
				
				SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? highlight_color : back);
				g.FillRectangle(backgroundColorBrush, e.Bounds);
				
				// Set text color
				string itemText = "SLOT "+itemIndex.ToString("d3")+suffixe+ASCIIString(SubArray(mset_stream,0x14+(itemIndex*16),4))+"]";
				
				SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
				g.DrawString(itemText, e.Font, itemTextColorBrush, moves_list.GetItemRectangle(itemIndex).Location);
				
				// Clean up
				backgroundColorBrush.Dispose();
				itemTextColorBrush.Dispose();
				
			}
			e.DrawFocusRectangle();
		}
		
		//Set all Icons of Group 1 to gray
		void ResetEC1Icons(object sender)
		{
			for (int i=0;i<EC1_buttons.Count;i++)
				if (EC1_buttons[i]!=null&&EC1_buttons[i]!=(sender as Button)) EC1_buttons[i].Enabled=false;
			EC_label.Text = "";
			EC_label_info.Text = "";
		}
		
		//Set all Icons of Group 2 to gray
		void ResetEC2Icons(object sender)
		{
			for (int i=0;i<EC2_buttons.Count;i++)
				if (EC2_buttons[i]!=null&&EC2_buttons[i]!=(sender as Button)) EC2_buttons[i].Enabled=false;
			EC_label.Text = "";
			EC_label_info.Text = "";
		}
		
		int[] blink=new int[] {0,1};
		//Suppression barre départ
		void Blink_previewMouseEnter(object sender, EventArgs e)
		{
			blink_preview.Visible = false;
			Split_blink.Enabled=false;
		}
		
		//Timer barre départ
		void Split_blinkTick(object sender, EventArgs e)
		{
			blink_preview.BackColor = Color.FromArgb(SystemColors.Control.R,SystemColors.Control.G-blink[0],SystemColors.Control.B-blink[0]);
			blink[0]+=5*blink[1];
			if (blink[0]==0|blink[0]==200)
				blink[1]=-blink[1];
		}
		
		//Debut edition texte EC1
		void EC1_listDoubleClick(object sender, EventArgs e)
		{
			EC1ListViewText_row = (int)Math.Floor((double)EC1_list.PointToClient(MousePosition).X/(double)70);
			string texte = EC1_list.SelectedItems[0].SubItems[EC1ListViewText_row].Text;
			if (texte!=""&&texte!="Auto")
			{
				EC1ListViewTextEdit = new TextBox();
				EC1ListViewTextEdit.Location = new Point(EC1ListViewText_row*70+2,EC1_list.FocusedItem.Bounds.Y+2);
				EC1ListViewTextEdit.Size = new Size(67,18);
				EC1ListViewTextEdit.BorderStyle = BorderStyle.None;
				EC1ListViewTextEdit.MaxLength = 6;
				EC1ListViewTextEdit.Name = "EC1ListViewTextEdit";
				EC1ListViewTextEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
				EC1ListViewTextEdit.Text = texte;
				EC1ListViewTextEdit.TextChanged += new EventHandler(EC1ListViewTextEditTextChanged);
				EC1ListViewTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EC1ListViewTextEditKeyDown);
				EC1ListViewTextEdit.Leave += new EventHandler(EC1ListViewTextEditLeave);
				EC1_list.Controls.Add(EC1ListViewTextEdit);
				EC1ListViewTextEdit.Focus();
			}
		}
		
		//Debut edition texte EC2
		void EC2_listDoubleClick(object sender, EventArgs e)
		{
			EC2ListViewText_row = (int)Math.Floor((double)EC2_list.PointToClient(MousePosition).X/(double)70);
			string texte = EC2_list.SelectedItems[0].SubItems[EC2ListViewText_row].Text;
			if (texte!=""&&texte!="Auto")
			{
				EC2ListViewTextEdit = new TextBox();
				EC2ListViewTextEdit.Location = new Point(EC2ListViewText_row*70+2,EC2_list.FocusedItem.Bounds.Y+2);
				EC2ListViewTextEdit.Size = new Size(67,18);
				EC2ListViewTextEdit.BorderStyle = BorderStyle.None;
				EC2ListViewTextEdit.MaxLength = 6;
				EC2ListViewTextEdit.Name = "EC2ListViewTextEdit";
				EC2ListViewTextEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
				EC2ListViewTextEdit.Text = texte;
				EC2ListViewTextEdit.TextChanged += new EventHandler(EC2ListViewTextEditTextChanged);
				EC2ListViewTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EC2ListViewTextEditKeyDown);
				EC2ListViewTextEdit.Leave += new EventHandler(EC2ListViewTextEditLeave);
				EC2_list.Controls.Add(EC2ListViewTextEdit);
				EC2ListViewTextEdit.Focus();
			}
		}
		
		//Chagement item
		void Moves_listSelectedIndexChanged(object sender, EventArgs e)
		{
			if (moves_list.SelectedIndex>=moves_list.Items.Count)
			{
				moves_list.SelectedIndex--;
				return;
			}
			Add.Enabled = true;
			Clean.Enabled = moves_list.SelectedIndex != -1;
			ResetEC1Icons(null);
			ResetEC2Icons(null);
			EC_label.Text = "";
			EC_label_info.Text = "";
			ChangePointer.Text = BAR_Errors[moves_list.SelectedIndex].Length > 0 ? "Fix this pointer..." : "Change this pointer...";
			//Fin Duplication
			if (CopyBlink.Enabled)
				for (int i = 0;i<15;i++) mset_stream[0x10+(moves_list.SelectedIndex*16)+i] = header_list_bytes[i];
			
			Up.Enabled = moves_list.SelectedIndex>0;
			Down.Enabled = moves_list.SelectedIndex<moves_list.Items.Count-1;
			//MAJ des labels
			if (moves_list.SelectedIndex >=  0)
			{
				header_list_bytes = SubArray(mset_stream,0x10+(moves_list.SelectedIndex*16),16);
				Edit.Enabled = (BTS(header_list_bytes).Contains(BTS(SubArray(dummy_sample,4,12))));
				groupBox2.Enabled = header_list_bytes[0] == 0x11;
				groupBox1.Text = groupBox2.Enabled? "Pointed ANB Infos" : "Pointed MSET Infos";
				label3.Text = groupBox2.Enabled ? "ANB Name:" : "MSET Name:";
				
				label0_.Text = moves_list.SelectedIndex.ToString();
				label0__.Text = numeros[moves_list.SelectedIndex].ToString();
				location = BitConverter.ToInt32(SubArray(header_list_bytes,8,4),0);
				label1_.Text = groupBox2.Enabled ? "" : "0x"+location.ToString("X");
				longueur = BitConverter.ToInt32(SubArray(header_list_bytes,12,4),0);
				
				/*Recherche vraie longueur --> */
				try {while (BTS(SubArray(mset_stream,location+longueur,3))!= "42-41-52") longueur++;}
				catch {longueur = mset_stream.Length-location;}
				
				label2_.Text = groupBox2.Enabled ? "" : "0x"+longueur.ToString("X");
				label3_.Text = groupBox2.Enabled ? "" : ASCIIString(SubArray(header_list_bytes,4,4)); 
				
				//Recherche des proprietes du ANB (BAR index 9)
				if (GetBARline(location,9)>=0)
				{
					label3_.Text = ReadString(GetBARline(location,9)+4);
					label1_.Text = "0x"+(location+ReadInteger4(GetBARline(location,9)+8)).ToString("X");
					int longueur_anb = ReadInteger4(GetBARline(location,9)+12);
					longueur_anb = AdjustBy16(longueur_anb);
					label2_.Text = "0x"+(longueur_anb).ToString("X");
				}
				
				label6_.Text = "";
				label7_.Text = "";
				label8_.Text = "";
				//Recherche des proprietes du PAX Effects Caster (BAR index 16)
				if (GetBARline(location,16)>=0)
				{
					label8_.Text = ReadString(GetBARline(location,16)+4);
					label6_.Text = "0x"+(location+ReadInteger4(GetBARline(location,16)+8)).ToString("X");
					label6_.Text += (label7_.Text == "0") ? " (Supposed)" : "";
					location_EC_cut = location+48+ReadInteger4(GetBARline(location,9)+12);
					int longueur_ec = (ReadInteger4(GetBARline(location,16)+12));
					//longueur_ec = AdjustBy16(longueur_ec);
					label7_.Text = "0x"+(longueur_ec).ToString("X");
				}
				UpdateNumeros();
				UpdateSizeDiff();
				//Démarrage partie EC
				if (CheckCurrBar(moves_list.SelectedIndex))
					UpdateEffectCaster();
				moves_list.Refresh();
			}
			UpdateFrameScheme(3);
			if (AutoRefreshIndex.Checked)
			new ListView[] {EC1_list,EC2_list}[last_focused_group].Focus();
		}
		
		//Supprimer Ligne BAR
		void DeleteClick(object sender, EventArgs e)
		{
			AskHowMany("Delete BAR header(s)", "How many Headers do you want to delete ?");
		}
		
		//Ajouter lignes
		void AddClick(object sender, EventArgs e)
		{
			AskHowMany("Add BAR header(s)", "How many Headers do you want to add ?");
		}
		
		// Add pointed file
		void ChangedPointerClick(object sender, EventArgs e)
		{
			Main_to_PresentFilesList();
		}
		
		//Remplacer/ajouter dans le slot
		void EditClick(object sender, EventArgs e)
		{
			if (header_list_bytes[0] == 0x11)
				OpenANBFileDialog.Filter = "Anb Files|*.anb";
			if (header_list_bytes[0] == 0x14)
				OpenANBFileDialog.Filter = "Mset Files|*.mset";
			
			bool confirm = (numeros[moves_list.SelectedIndex].Length == 0) || MessageBox.Show("The pointed file will be replaced !\r\nContinue ?", "Warning !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
			if (confirm)
				if (OpenANBFileDialog.ShowDialog() == DialogResult.OK)
					CheckAccessFileANB_MSET(OpenANBFileDialog.FileName);
		}
		
		//Effacer le fichier pointé
		void CleanClick(object sender, EventArgs e)
		{
			//Vers DUMMY
			mset_stream = Combine(Combine(SubArray(mset_stream,0,0x10+(moves_list.SelectedIndex*16)),dummy_sample),SubArray(mset_stream,0x20+(moves_list.SelectedIndex*16),mset_stream.Length-(0x20+(moves_list.SelectedIndex*16))));
			
			UpdateNumeros();
			moves_list.Refresh();
			Moves_listSelectedIndexChanged(null,null);
			label0__.Text = "";
		}
		
		private TextBox EC2ListViewTextEdit;
		int EC2ListViewText_row = 0;
		private TextBox EC1ListViewTextEdit;
		int EC1ListViewText_row = 0;
		
		//Entrée EC2 texte
		void EC2ListViewTextEditKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				EC2ListViewTextEditLeave(null,null);
				e.Handled = true;
        		e.SuppressKeyPress = true;
			}
			if (e.KeyCode==Keys.Escape)
			{
				EC2_list.Controls.Remove(EC2ListViewTextEdit);
			}
		}
		
		//Entrée EC1 texte
		void EC1ListViewTextEditKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				EC1ListViewTextEditLeave(null,null);
				e.Handled = true;
        		e.SuppressKeyPress = true;
			}
			if (e.KeyCode==Keys.Escape)
			{
				EC1_list.Controls.Remove(EC1ListViewTextEdit);
			}
		}
		
		//Texte EC1 changé
		void EC1ListViewTextEditTextChanged(object sender, EventArgs e)
		{
			try
			{
				int select_index = EC1ListViewTextEdit.SelectionStart;
				int input_int = int.Parse(EC1ListViewTextEdit.Text);
				short max_value = EC1ListViewText_row==2 ? (short)255:short.MaxValue;
				short min_value = EC1ListViewText_row==2 ? (short)0:(short)-1;
				if (input_int>max_value)
					EC1ListViewTextEdit.Text = max_value.ToString();
				if (input_int<min_value)
					EC1ListViewTextEdit.Text = min_value.ToString();
				EC1ListViewTextEdit.Select(select_index, 0);
			} catch {}
		}
		
		//Texte EC2 changé
		void EC2ListViewTextEditTextChanged(object sender, EventArgs e)
		{
			try
			{
				int select_index = EC2ListViewTextEdit.SelectionStart;
				int input_int = int.Parse(EC2ListViewTextEdit.Text);
				short max_value = EC2ListViewText_row==2 ? (short)255:short.MaxValue;
				short min_value = EC2ListViewText_row==2 ? (short)0:(short)-1;
				if (input_int>max_value)
					EC2ListViewTextEdit.Text = max_value.ToString();
				if (input_int<min_value)
					EC2ListViewTextEdit.Text = min_value.ToString();
				EC2ListViewTextEdit.Select(select_index, 0);
			} catch {}
		}
		
		//Sortie editeur de texte EC1
		void EC1ListViewTextEditLeave(object sender, EventArgs e)
		{
			try
			{
				short valeur = short.Parse(EC1ListViewTextEdit.Text);
				EC1_list.SelectedItems[0].SubItems[EC1ListViewText_row].Text = valeur.ToString();
				int addresse_effet = EC1_infos[EC1_list.FocusedItem.Index][0];
				switch (EC1ListViewText_row)
				{
					case 0:
						WriteInteger2(addresse_effet,valeur);
					break;
					case 1:
						WriteInteger2(addresse_effet+2,valeur);
					break;
					case 2:
						mset_stream[addresse_effet+4]=(byte)valeur;
					break;
					case 3:
						WriteInteger2(addresse_effet+6,valeur);
					break;
				}
			} catch {}
			EC1_list.Controls.Remove(EC1ListViewTextEdit);
			UpdateEffectCaster();
			EC1_listSelectedIndexChanged(null,null);
		}
		
		//Sortie editeur de texte EC2
		void EC2ListViewTextEditLeave(object sender, EventArgs e)
		{
			try
			{
				short valeur = short.Parse(EC2ListViewTextEdit.Text);
				EC2_list.SelectedItems[0].SubItems[EC2ListViewText_row].Text = valeur.ToString();
				int addresse_effet = EC2_infos[EC2_list.FocusedItem.Index][0];
				switch (EC2ListViewText_row)
				{
					case 0:
						WriteInteger2(addresse_effet,valeur);
					break;
					case 1:
						WriteInteger2(addresse_effet+4,(short)(valeur-ReadInteger2(addresse_effet)));
					break;
					case 2:
						mset_stream[addresse_effet+2]=(byte)valeur;
						if (valeur==23|valeur==24)
						{
							EC2_list.SelectedItems[0].SubItems[1].Text=(ReadInteger2(addresse_effet+4)+ReadInteger2(addresse_effet)).ToString();
							EC2_list.SelectedItems[0].SubItems[3].Text="";
						}
						else
						{
							EC2_list.SelectedItems[0].SubItems[1].Text="Auto";
							EC2_list.SelectedItems[0].SubItems[3].Text=ReadInteger2(addresse_effet+4).ToString();
						}
					break;
					case 3:
						WriteInteger2(addresse_effet+4,valeur);
					break;
				}
			} catch {}
			EC2_list.Controls.Remove(EC2ListViewTextEdit);
			UpdateEffectCaster();
			EC2_listSelectedIndexChanged(null,null);
		}
		
		//Update Icon of Group 1
		void EC1_listSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!AutoRefreshEC.Checked)
			try {focus_ec1=EC1_list.FocusedItem.Index;
			ButtonsLabelsRefresh(0,EC1_list.FocusedItem.Index);
			UpdateFrameScheme(0);} catch {}
			else
			{
				ResetEC1Icons(null);
				ResetEC2Icons(null);
			}
			EC1_list.Refresh();
		}
		
		//Update Icon of Group 2
		void EC2_listSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!AutoRefreshEC.Checked)
			try {focus_ec2=EC2_list.FocusedItem.Index;
			ButtonsLabelsRefresh(1,EC2_list.FocusedItem.Index);
			UpdateFrameScheme(1);} catch {}
			else
			{
				ResetEC1Icons(null);
				ResetEC2Icons(null);
			}
			EC2_list.Refresh();
		}
		
		//Refresh labels && buttons
		void ButtonsLabelsRefresh(int which, int index)
		{
			ResetEC1Icons(null);
			ResetEC2Icons(null);
			try {
				byte ec_type = which==0 ? mset_stream[EC1_infos[index][0]+4] : mset_stream[EC2_infos[index][0]+2];
				if (which==0)
				{
					EC1_buttons[ec_type].Enabled=true;
					EC_label.Text = labels_EC1[ec_type];
					EC_label_info.Text = labels_EC1_explanations[ec_type];
				}
				else if (which==1)
				{
					EC2_buttons[ec_type].Enabled=true;
					EC_label.Text = labels_EC2[ec_type];
					EC_label_info.Text = labels_EC2_explanations[ec_type];
				}
			}
			catch
			{
				EC_label.Text = "";
				EC_label_info.Text = "";
			}
		}
		
		//Update last selected
		void EC1_listMouseClick(object sender, MouseEventArgs e) {last_focused_group=0; if (EC1_list.FocusedItem!=null) UpdateFrameScheme(0); else UpdateFrameScheme(3);}
		void EC2_listMouseClick(object sender, MouseEventArgs e) {last_focused_group=1; if (EC2_list.FocusedItem!=null) UpdateFrameScheme(1); else UpdateFrameScheme(3);}
		
		//Show available buttons for EC1
		void Add_G1Click(object sender, EventArgs e)
		{
			last_focused_group=0;
			foreach (Button curr_button in EC1_buttons)
				curr_button.Enabled = true;
			ResetEC2Icons(sender);
			Unregistred.Enabled = true;
		}
		
		//Show available buttons for EC2
		void Add_G2Click(object sender, EventArgs e)
		{
			last_focused_group=1;
			foreach (Button curr_button in EC2_buttons)
			{
				curr_button.Enabled = true;
			}
			ResetEC1Icons(sender);
			Unregistred.Enabled = true;
		}
		
		//Manuel select Ec1
		void EC1Select(int index)
		{
			for (int i=0;i<EC1_list.Items.Count-1;i++) {EC1_list.Items[i].Selected=false; EC1_list.Items[i].Focused=false;}
			try {EC1_list.Items[index].Selected = true; EC1_list.Items[index].Focused=true; focus_ec1 = index; EC1_list.Focus();} catch {}
		}
		
		//Manuel select Ec2
		void EC2Select(int index)
		{
			for (int i=0;i<EC2_list.Items.Count-1;i++) {EC2_list.Items[i].Selected=false; EC2_list.Items[i].Focused=false;}
			try {EC2_list.Items[index].Selected = true; EC2_list.Items[index].Focused=true; focus_ec2 = index; EC2_list.Focus();} catch {}
		}
		
		//Delete Group 1 effect
		void Del_G1Click(object sender, EventArgs e)
		{
			last_focused_group=0;
			if (EC1_list.FocusedItem!=null)
			{
				byte[] previous = new byte[0];
					try {previous = SubArray(mset_stream,EC1_infos[EC1_list.FocusedItem.Index-1][0],EC1_infos[EC1_list.FocusedItem.Index-1][1]);} catch {}
			
				RemoveEC(0);
				DefineLastAdded(previous);
			}
		}
		
		//Delete Group 2 effect
		void Del_G2Click(object sender, EventArgs e)
		{
			last_focused_group=1;
			if (EC2_list.FocusedItem!=null)
			{
				byte[] previous = new byte[0];
					try {previous = SubArray(mset_stream,EC2_infos[EC2_list.FocusedItem.Index-1][0],EC2_infos[EC2_list.FocusedItem.Index-1][1]);} catch {}
				RemoveEC(1);
				DefineLastAdded(previous);
			}
		}
		
		//Disable Buttons
		bool DisableButtons(object input_) {			Button input_button = (input_ as Button);
			int count = 0;
			foreach (Button curr_button in EC1_buttons)
				if (curr_button!=input_button&&curr_button.Enabled)
				{
					count++;
					curr_button.Enabled = false;
				}
			foreach (Button curr_button in EC2_buttons)
				if (curr_button!=input_button&&curr_button.Enabled)
				{
					count++;
					curr_button.Enabled = false;
				}
			return count >0;
		}
		
		//Call Parametreur_Window
		void ShowParameterWindow(int ec_index, int address, object sender)
		{
			Parametreur_pictureBox1.BackgroundImage=(sender as Button).Image;
			Parametreur_MainForm.Text = EC_label.Text;
			List<int[]> current_ec_info = new List<int[]>[] {EC1_infos,EC2_infos}[ec_index];
			int start = new int[] {6,4}[ec_index];
			int index = new int[] {focus_ec1,focus_ec2}[ec_index];
			address_ec_parametrer = current_ec_info[index][0];
			old_ec_length_parametrer = current_ec_info[index][1];
			Parametreur_Value_1.Enabled = mset_stream[address+start-1] > 0;
			Parametreur_Value_1.Text = "";
			for (int i=start;i<current_ec_info[index][1];i=i+2)
				AddParamSlot(ReadInteger2(current_ec_info[index][0]+i).ToString());
			Parametreur_Add.Visible = (Parametreur_Value_1.Text!="");
			Parametreur_Remove.Visible = (Parametreur_Value_1.Text!="");
			Parametreur_MainForm.ShowDialog();
		}
		
		//Fonction principale d'appui EC1
		void ButtonEC1Click(int type_value, object sender)
		{
			if (DisableButtons(sender))
			{
				NewEC_Window_textBox2.Text = "0";
				NewEC_Window_textBox2.Enabled = true;
				NewEC_Window_textBox3.Enabled = false;
				NewEC_Window_textBox3.Text = type_value.ToString();
				NewEC_Window.ShowDialog();
			}
			else if (EC1_list.FocusedItem!=null)
				ShowParameterWindow(0,EC1_infos[EC1_list.FocusedItem.Index][0],sender);
			ResetEC1Icons(sender);
			ResetEC2Icons(sender);
		}
		
		//Fonction principale d'appui EC2
		void ButtonEC2Click(int type_value, object sender)
		{
			if (DisableButtons(sender))
			{
				NewEC_Window_textBox2.Text = type_value==23 | type_value== 24 ? "0":"Auto";
				NewEC_Window_textBox2.Enabled = type_value==23 | type_value== 24;
				NewEC_Window_textBox3.Enabled = false;
				NewEC_Window_textBox3.Text = type_value.ToString();
				NewEC_Window.ShowDialog();
			}
			else if (EC2_list.FocusedItem!=null)
				ShowParameterWindow(1,EC2_infos[EC2_list.FocusedItem.Index][0],sender);
			ResetEC1Icons(sender);
			ResetEC2Icons(sender);
		}
		
		// Button 1
		void EC1_00Click(object sender, EventArgs e) {ButtonEC1Click(0,sender);}
		
		// Button 3
		void EC1_03Click(object sender, EventArgs e) {ButtonEC1Click(3,sender);}
		
		// Button 10
		void EC1_0AClick(object sender, EventArgs e) {ButtonEC1Click(10,sender);}
		
		// Button 11
		void EC1_0BClick(object sender, EventArgs e) {ButtonEC1Click(11,sender);}
		
		// Button 12
		void EC1_0CClick(object sender, EventArgs e) {ButtonEC1Click(12,sender);}
		
		// Button 16
		void EC1_10Click(object sender, EventArgs e) {ButtonEC1Click(16,sender);}
		
		// Button 17
		void EC1_11Click(object sender, EventArgs e) {ButtonEC1Click(17,sender);}
		
		//Button 20
		void EC1_14Click(object sender, EventArgs e) {ButtonEC1Click(20,sender);}
		
		// Button 23
		void EC1_17Click(object sender, EventArgs e) {ButtonEC1Click(23,sender);}
		
		// Button 28
		void EC1_1CClick(object sender, EventArgs e) {ButtonEC1Click(28,sender);}
		
		// Button 29
		void EC1_1DClick(object sender, EventArgs e) {ButtonEC1Click(29,sender);}
		
		// Button 1
		void EC2_01Click(object sender, EventArgs e) {ButtonEC2Click(1,sender);}
		
		// Button 2
		void EC2_02Click(object sender, EventArgs e) {ButtonEC2Click(2,sender);}
		
		// Button 6
		void EC2_06Click(object sender, EventArgs e) {ButtonEC2Click(6,sender);}
		
		// Button 7
		void EC2_07Click(object sender, EventArgs e) {ButtonEC2Click(7,sender);}
		
		// Button 8
		void EC2_08Click(object sender, EventArgs e) {ButtonEC2Click(8,sender);}
		
		// Button 14
		void EC2_0EClick(object sender, EventArgs e) {ButtonEC2Click(14,sender);}
		
		// Button 19
		void EC2_13Click(object sender, EventArgs e) {ButtonEC2Click(19,sender);}
		
		// Button 22
		void EC2_16Click(object sender, EventArgs e) {ButtonEC2Click(22,sender);}
		
		// Button 23
		void EC2_17Click(object sender, EventArgs e) {ButtonEC2Click(23,sender);}
		
		// Button 24
		void EC2_18Click(object sender, EventArgs e) {ButtonEC2Click(24,sender);}
		
		// Button 26
		void EC2_1AClick(object sender, EventArgs e) {ButtonEC2Click(26,sender);}
		
		// Button 27
		void EC2_1BClick(object sender, EventArgs e) {ButtonEC2Click(27,sender);}
		
		// Button 28
		void EC2_1DClick(object sender, EventArgs e) {ButtonEC2Click(29,sender);}
		
		//Click unregistred button
		void UnregistredClick(object sender, EventArgs e)
		{
			if (DisableButtons(sender))
			{
				if (last_focused_group==0)
				{
					NewEC_Window_textBox2.Enabled = true;
					NewEC_Window_textBox2.Text = "0";
				}
				else
				{
					NewEC_Window_textBox2.Enabled = false;
					NewEC_Window_textBox2.Text = "Auto";
				}
				NewEC_Window_textBox3.Enabled = true;
				NewEC_Window_textBox3.Text = "0";
				NewEC_Window.ShowDialog();
			}
			else if (last_focused_group==0)
			{
				if (EC1_list.FocusedItem!=null)
				ShowParameterWindow(1,EC1_infos[EC1_list.FocusedItem.Index][0],sender);
			}
			else
			{
				if (EC2_list.FocusedItem!=null)
				ShowParameterWindow(1,EC2_infos[EC2_list.FocusedItem.Index][0],sender);
			}
			ResetEC1Icons(sender);
			ResetEC2Icons(sender);
		}
		
		//Wait 100ms to focus new/edited items
		void ListFocusTick(object sender, EventArgs e)
		{
			try {
				if (last_focused_group==0)
					EC1Select(last_added);
				else
					EC2Select(last_added);
				
				ButtonsLabelsRefresh(last_focused_group,last_added);
				UpdateFrameScheme((sbyte)last_focused_group);
			ListFocus.Enabled = false;
			} catch {}
		}
		
		//EC1 copy paste
		byte[] EC1_copy = new byte[0];
		void EC1_listKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Decimal)	//Insta test
			{
				try
				{
					SeekPCSX2();
					float start_frame = BitConverter.ToSingle(ReadBytes(PTR(0x20341708,0x20000170),4),0);
					float max_frame = BitConverter.ToSingle(ReadBytes(PTR(0x20341708,0x2000016C),4),0);
					if (start_frame+2>=max_frame)
						start_frame=(max_frame-start_frame);
					start_frame+=2;
					WriteIntegerRAM(PTR(0x20341708,0x20000150),0x1C93940,4);
					WriteBytes(0x21C93940,new byte[] {1,0,16,0,0,0,0,0,0,0,0,0,0,0,0,0},16);
					WriteBytes(0x21C93944,new byte[EC1_infos[EC1_list.FocusedItem.Index][1]+4],EC1_infos[EC1_list.FocusedItem.Index][1]+4);
					WriteBytes(0x21C93944,SubArray(mset_stream,EC1_infos[EC1_list.FocusedItem.Index][0],EC1_infos[EC1_list.FocusedItem.Index][1]),EC1_infos[EC1_list.FocusedItem.Index][1]);
					WriteIntegerRAM(0x21C93944,(int)start_frame,2);
					WriteIntegerRAM(0x21C93948,-1,4);
					System.Threading.Thread.Sleep(100);
					WriteIntegerRAM(PTR(0x20341708,0x20000150),0x1C93A00,4);
				}
				catch
				{
					
				}
			}
			if (e.KeyCode == Keys.Delete)
				Del_G1Click(null,null);
			
			if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
				try {EC1_copy = SubArray(mset_stream,EC1_infos[EC1_list.FocusedItem.Index][0],EC1_infos[EC1_list.FocusedItem.Index][1]);} catch{}
			
			if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
				if (EC1_copy.Length>0)
				{
					AddEC(0,EC1_copy);
					DefineLastAdded(EC1_copy);
				}
			if (IsKeyDown(Keys.Add)|IsKeyDown(Keys.Subtract))
			{
				short ind_dec = IsKeyDown(Keys.Subtract) ? (short)-1 : (short)1;
				if (IsKeyDown(Keys.NumPad4)^IsKeyDown(Keys.NumPad5)^IsKeyDown(Keys.NumPad6))
			    {
					if (IsKeyDown(Keys.NumPad4)&EC1_infos[EC1_list.FocusedItem.Index][1]>=10) {WriteInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+8,(short)(ReadInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+8)+ind_dec));}
					if (IsKeyDown(Keys.NumPad5)&EC1_infos[EC1_list.FocusedItem.Index][1]>=12) {WriteInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+10,(short)(ReadInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+10)+ind_dec));}
					if (IsKeyDown(Keys.NumPad6)&EC1_infos[EC1_list.FocusedItem.Index][1]>=14) {WriteInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+12,(short)(ReadInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+12)+ind_dec));}
			    }
				else if (IsKeyDown(Keys.NumPad1)^IsKeyDown(Keys.NumPad2)^IsKeyDown(Keys.NumPad3))
				try {
					short valeur = 0;
					sbyte index = -1;
					if (IsKeyDown(Keys.NumPad1)) index=0;
					if (IsKeyDown(Keys.NumPad2)) index=1;
					if (IsKeyDown(Keys.NumPad3)&&EC1_list.FocusedItem.SubItems[3].Text != "") index=3;
					if (index>-1)
						valeur = (short)(ReadInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+new short[] {0,2,0,6}[index])+ind_dec);
					
					if (valeur>=-1|index==3)
					{
						WriteInteger2(EC1_infos[EC1_list.FocusedItem.Index][0]+new short[] {0,2,0,6}[index],valeur);
						EC1_list.FocusedItem.SubItems[index].Text = valeur.ToString();
					}
					UpdateFrameScheme(0);
				} catch{}
			}
		}
		public static bool IsKeyDown(Keys key) {return (GetKeyState(Convert.ToInt16(key)) & 0X80) == 0X80;}
		
		//EC2 copy paste
		byte[] EC2_copy = new byte[0];
		void EC2_listKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Decimal) //Insta Test
			{
				try
				{
					SeekPCSX2();
					float start_frame = BitConverter.ToSingle(ReadBytes(PTR(0x20341708,0x20000170),4),0);
					float max_frame = BitConverter.ToSingle(ReadBytes(PTR(0x20341708,0x2000016C),4),0);
					if (start_frame+2>=max_frame)
						start_frame=(max_frame-start_frame);
					start_frame+=2;
					WriteIntegerRAM(PTR(0x20341708,0x20000150),0x1C93940,4);
					WriteBytes(0x21C93940,new byte[] {0,1,16,0,0,0,0,0,0,0,0,0,0,0,0,0},16);
					WriteBytes(0x21C93950,new byte[EC2_infos[EC2_list.FocusedItem.Index][1]+4],EC2_infos[EC2_list.FocusedItem.Index][1]+4);
					byte[] EC = SubArray(mset_stream,EC2_infos[EC2_list.FocusedItem.Index][0],EC2_infos[EC2_list.FocusedItem.Index][1]);
					WriteBytes(0x21C93950,EC,EC.Length);
					WriteIntegerRAM(0x21C93950,(int)start_frame,2);
					System.Threading.Thread.Sleep(100);
					WriteIntegerRAM(PTR(0x20341708,0x20000150),0x1C93A00,4);
				}
				catch
				{
					
				}
			}
			if (e.KeyCode == Keys.Delete)
				Del_G2Click(null,null);
			if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
				try {EC2_copy = SubArray(mset_stream,EC2_infos[EC2_list.FocusedItem.Index][0],EC2_infos[EC2_list.FocusedItem.Index][1]);} catch{}
			
			if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
				if (EC2_copy.Length>0)
				{
					AddEC(1,EC2_copy);
					DefineLastAdded(EC2_copy);
				}
			if (IsKeyDown(Keys.Add)|IsKeyDown(Keys.Subtract))
			{
				short ind_dec = IsKeyDown(Keys.Subtract) ? (short)-1 : (short)1;
				if (IsKeyDown(Keys.NumPad4)^IsKeyDown(Keys.NumPad5)^IsKeyDown(Keys.NumPad6))
			    {
					if (IsKeyDown(Keys.NumPad4)&EC2_infos[EC2_list.FocusedItem.Index][1]>=8) {WriteInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+6,(short)(ReadInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+6)+ind_dec));}
					if (IsKeyDown(Keys.NumPad5)&EC2_infos[EC2_list.FocusedItem.Index][1]>=10) {WriteInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+8,(short)(ReadInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+8)+ind_dec));}
					if (IsKeyDown(Keys.NumPad6)&EC2_infos[EC2_list.FocusedItem.Index][1]>=12) {WriteInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+10,(short)(ReadInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+10)+ind_dec));}
			    }
				else if (IsKeyDown(Keys.NumPad1)^IsKeyDown(Keys.NumPad2)^IsKeyDown(Keys.NumPad3))
				try {
					short valeur = 0;
					sbyte index = -1;
					if (IsKeyDown(Keys.NumPad1)) index=0;
					if (IsKeyDown(Keys.NumPad2)&&EC2_list.FocusedItem.SubItems[1].Text != "Auto") index=1;
					if (IsKeyDown(Keys.NumPad3)&&EC2_list.FocusedItem.SubItems[3].Text != "") index=3;
					if (index>-1)
						valeur = (short)(ReadInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+new short[] {0,4,0,4}[index])+ind_dec);
					if (valeur>=-1|index==3)
					{
						WriteInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]+new short[] {0,4,0,4}[index],valeur);
						EC2_list.FocusedItem.SubItems[index].Text = (valeur+new short[] {0,ReadInteger2(EC2_infos[EC2_list.FocusedItem.Index][0]),0,0}[index]).ToString();
					}
					UpdateFrameScheme(1);
				} catch{}
			}
		}
	}
}
