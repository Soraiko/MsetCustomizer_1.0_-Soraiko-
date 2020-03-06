using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm : Form
	{
		int max = 0;
		int count = 0;
		int ectobar_ = 0;
		int longueur = 0;
		int location = 0;
		int old_size = 0;
		int focus_ec1 = 0;
		int focus_ec2 = 0;
		bool swicth = true;
		int last_added = 0;
		int location_EC_cut = 0;
		string mset_filename = "";
		int last_focused_group = 0;
		byte[] mset_stream = new byte[0];
		byte[] dummy_sample = new byte[0];
		byte[] mset_stream_check = new byte[0];
		byte [] header_list_bytes = new byte[0];
		List<string> numeros = new List<string>(0);
		byte[] anb_or_mset_file_buffer = new byte[0];
		List<String> BAR_Errors = new List<String>(0);
		List<int[]> EC2_infos = new List<int[]>(0);
		List<int[]> EC1_infos = new List<int[]>(0);
		List<Button> EC1_buttons = new List<Button>(0);
		List<Button> EC2_buttons = new List<Button>(0);
		Color highlight_color = SystemColors.MenuHighlight;
		
		List<string> labels_EC1 = new string[] {
			/*0*/"Control: Skip animation",
			/*1*/"Control: Lock animation",
			/*2*/"Control: Wait for input",
			/*3*/"Model state: no gravity",
			/*4*/"Reaction command",
			/*5*/"Model state: 005 (Unknown)",
			/*6*/"Model state: 006 (Unknown)",
			/*7*/"Model state: 007 (Unknown)",
			/*8*/"Model state: 008 (Unknown)",
			/*9*/"Model state: 009 (Unknown)",
			/*10*/"Damage",
			/*11*/"Combo",
			/*12*/"Attack label: 0C (Unknown)",
			/*13*/"Attack label: 0D (Unknown)",
			/*14*/"Attack label: 0E (Unknown)",
			/*15*/"Attack label: 0F (Unknown)",
			/*16*/"Next Animation label",
			/*17*/"Target identification",
			/*18*/"Model state: 012 (Unknown)",
			/*19*/"Model state: 013 (Unknown)",
			/*20*/"Internal-model reaction command activator",
			/*21*/"Model state: 015 (Unknown)",
			/*22*/"Model state: 016 (Unknown)",
			/*23*/"DMY TEXA displayer",
			/*24*/"Model state: no gravity (2)",
			/*25*/"External model reaction command activator",
			/*26*/"Model state: 01A (Unknown)",
			/*27*/"Model state: 01B (Unknown)",
			/*28*/"Rotation to target",
			/*29*/"Stun state: 01D (Unknown)",
			/*30*/"Stun state: 01E (Unknown)",
			/*31*/"Stun state: 01F (Unknown)"
		}.ToList();
		
		List<string> labels_EC1_explanations = new string[] {
			/*0*/"Skips animations until Idle animation.",
			/*1*/"Locks current animation.",
			/*2*/"Wait for input to skip animation.",
			/*3*/"Locks current animation, disable controls and gravity.",
			/*4*/"Shows Boss reaction command (Sends ANBs 1010 on Sora once activated).",
			/*5*/"Unknown",
			/*6*/"Unknown",
			/*7*/"Unknown",
			/*8*/"Unknown",
			/*9*/"Unknown",
			/*10*/"Calls a predefined attack perimeter && effects from the PAX",
			/*11*/"Combo period, applies a combo if you attack.",
			/*12*/"Unknown",
			/*13*/"Unknown",
			/*14*/"Unknown",
			/*15*/"Unknown",
			/*16*/"Indicates which will be the next animation (Label, not property)",
			/*17*/"Identificates the target position, type, and number.",
			/*18*/"Unknown",
			/*19*/"Unknown",
			/*20*/"Shows a certain reaction command on a certain bone from current model.",
			/*21*/"Unknown",
			/*22*/"Unknown",
			/*23*/"Draws a TIM2 sprite on a predefined zone on current model.",
			/*24*/"Disables gravity but keeps kinetics.",
			/*25*/"Shows a certain reaction command on a certain bone from another model.",
			/*26*/"Unknown",
			/*27*/"Unknown",
			/*28*/"Rotates current model to his target.",
			/*29*/"Unknown",
			/*30*/"Unknown",
			/*31*/"Stun, stun combos && incapacities to attack"
		}.ToList();
			
		List<string> labels_EC2 = new string[] {
			/*0*/"Null",
			/*1*/"PAX Sprite",
			/*2*/"Footsep sound",
			/*3*/"T-stance",
			/*4*/"Unknown",
			/*5*/"Unknown",
			/*6*/"Throws potion",
			/*7*/"Character speed",
			/*8*/"WD sound",
			/*9*/"Unknown",
			/*10*/"Unknown",
			/*11*/"Unknown",
			/*12*/"Unknown",
			/*13*/"Unknown",
			/*14*/"Play IopVoice from VSB",
			/*15*/"Play IopVoice from AFM",
			/*16*/"Keyblade pop",
			/*17*/"Unknown",
			/*18*/"Unknown",
			/*19*/"Contact point",
			/*20*/"Unknown",
			/*21*/"Unknown",
			/*22*/"Unknown",
			/*23*/"Disappear",
			/*24*/"Appear",
			/*25*/"Unknown",
			/*26*/"Meshe disappear",
			/*27*/"Meshe appear",
			/*28*/"Unknown",
			/*29*/"Keyblade init",
			
		}.ToList();
		List<string> labels_EC2_explanations = new string[] {
			/*0*/"No effects. (Delete contacts with the floor, allows to jump)",
			/*1*/"Casts fire, smokes, lasers, lights, and all sounds accompanying them.",
			/*2*/"Play a footstep sound",
			/*3*/"Plays the 158th animation",
			/*4*/"Unknown",
			/*5*/"Unknown",
			/*6*/"Throws the last used potion potion",
			/*7*/"Change the animation frame step of current model (Works for some characters only)",
			/*8*/"Plays a wd sound from current a.fm or a system sound.",
			/*9*/"Unknown",
			/*10*/"Unknown",
			/*11*/"Unknown",
			/*12*/"Unknown",
			/*13*/"Unknown",
			/*14*/"Play a VAG IopVoice from a VSB file",
			/*15*/"Play a VAG IopVoice from a AFM file",
			/*16*/"Makes Keyblade pop",
			/*17*/"Unknown",
			/*18*/"Unknown",
			/*19*/"Ackoledge a contact between the map the the model",
			/*20*/"Unknown",
			/*21*/"Unknown",
			/*22*/"Unknown",
			/*23*/"Makes current model disappear from point A to B",
			/*24*/"Makes current model appear from point A to B",
			/*25*/"Unknown",
			/*26*/"Makes a meshe of the current model disappear",
			/*27*/"Makes a meshe of the current model appear",
			/*28*/"Unknown",
			/*29*/"Makes Keyblade appear with light",
		}.ToList();
		
		
		void EC1_listMouseEnter(object sender, EventArgs e) {if (false&&AutoRefreshEC.Checked) EC1_list.Focus();}
		void EC2_listMouseEnter(object sender, EventArgs e) {if (false&&AutoRefreshEC.Checked) EC2_list.Focus();}
		
		void AutoRefreshECCheckedChanged(object sender, EventArgs e) {EC1_list.MultiSelect = AutoRefreshEC.Checked; EC2_list.MultiSelect = AutoRefreshEC.Checked; if (AutoRefreshEC.Checked) new ListView[] {EC1_list,EC2_list}[last_focused_group].Focus();}
		void AutoRefreshIndexCheckedChanged(object sender, EventArgs e) {if (AutoRefreshEC.Checked&AutoRefreshIndex.Checked) new ListView[] {EC1_list,EC2_list}[last_focused_group].Focus();}
		
					
		void Ingame_test_checkboxCheckedChanged(object sender, EventArgs e)
		{
			GameAccess.Enabled = Ingame_test_checkbox.Checked;
			EC1_list.MultiSelect = AutoRefreshEC.Checked&Ingame_test_checkbox.Checked;
			EC2_list.MultiSelect = AutoRefreshEC.Checked&Ingame_test_checkbox.Checked;
			AutoRefreshIndex.Enabled = GameAccess.Enabled;
			AutoRefreshEC.Enabled = GameAccess.Enabled;
			if (GameAccess.Enabled==false)
			{
				time_label_middle.Text ="";
				FrameRectangle = new Rectangle(0,1,0,1);
				paneltime_ingame.Refresh();
			}
		}
		
		//Démarrage de l'application
		public MainForm()
		{
			InitializeComponent();
			MouseMessageFilter.MouseMove += new MouseEventHandler(OnGlobalMouseMove);
			paneltime_ingame.BackgroundImage= new Bitmap(paneltime_ingame.Width,paneltime_ingame.Height);
			paneltime.BackgroundImage= new Bitmap(paneltime.Width,paneltime.Height);
			EC1_buttons = new List<Button> {EC1_00,EC1_00,EC1_00,EC1_03,EC1_14,EC1_03,EC1_03,EC1_03,EC1_03,EC1_03,EC1_0A,EC1_0B,EC1_0C,EC1_0C,EC1_0C,EC1_0C,EC1_10,EC1_11,EC1_03,EC1_03,EC1_14,EC1_03,EC1_03,EC1_17,EC1_03,EC1_14,Unregistred,Unregistred,EC1_1C,EC1_1D,EC1_1D,EC1_1D,EC1_1D,EC1_1D,EC1_1D};
			EC2_buttons = new List<Button> {Unregistred,EC2_01,EC2_02,Unregistred,Unregistred,Unregistred,EC2_06,EC2_07,EC2_08,Unregistred,Unregistred,Unregistred,Unregistred,Unregistred,EC2_0E/*AFM Iop*/,EC2_0E/*Separate Iop*/,Unregistred,Unregistred,Unregistred,EC2_13,Unregistred,Unregistred,EC2_16,EC2_17,EC2_18,Unregistred,EC2_1A,EC2_1B,Unregistred,EC2_1D};
			while (EC1_buttons.Count<255) {EC1_buttons.Add(Unregistred);}
			while (EC2_buttons.Count<255) {EC2_buttons.Add(Unregistred);}
			while (labels_EC1.Count<255) {labels_EC1.Add("Unknown");}
			while (labels_EC1_explanations.Count<255) {labels_EC1_explanations.Add("Unknown");}
			while (labels_EC2.Count<255) {labels_EC2.Add("Unknown");}
			while (labels_EC2_explanations.Count<255) {labels_EC2_explanations.Add("Unknown");}
			
			//Init the windows appearing when clicking "Change this pointer"
			Initialize_PresentFilesListWindow_Componnents();
			//Init the windows appearing when clicking a button to change parameters of an effect caster
			Initialize_ParametreurWindow_Component();
			//Init the windows appearing when clicking a button to add an effect caster
			Initialize_NewECWindow_Componnents();
			Mset_File.Select();
			Text = AppName+"_"+ Version +"_["+ Auteur +"] (Verifications Incomplete, May be unstable)";
			EC1_list.Size = new Size(EC1_list.Width+SystemInformation.VerticalScrollBarWidth,EC1_list.Height);
			EC2_list.Size = new Size(EC2_list.Width+SystemInformation.VerticalScrollBarWidth,EC2_list.Height);
		}
		
		//Vérification de l'accès au fichier et si moveset ou pas
		void CheckAccessFileMSET(string file_to_check)
		{
			try
			{
				mset_filename = file_to_check;
				mset_stream_check = File.ReadAllBytes(file_to_check);
				if (mset_stream_check.Length%16>0)
					mset_stream_check = Combine(mset_stream_check,new byte[(16-mset_stream_check.Length%16)]);
				
				if (mset_stream_check[16] == 0x11&&(mset_stream_check[4]>0|mset_stream_check[5]>0)&&mset_stream_check[6] == 0&&mset_stream_check[7] == 0)
				{
					EnabledComponnents();
					OpenMSET(file_to_check);
				}
				else
				{
					if (MessageBox.Show("The file seem not to be a correct moveset,\r\nprocessing with this file make cause damages and/or erorrs !\r\nProcess anyway ?","Warning !",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
					{
						EnabledComponnents();
						OpenMSET(file_to_check);
					}
				}
			}
			catch
			{
				MessageBox.Show("Unable to access the file.\r\nIt is maybe used by another process.","Read Access denied", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}
		
		//Vérification de l'accès au fichier et si ANB ou pas
		void CheckAccessFileANB_MSET(string file_to_check)
		{
			try
			{
				anb_or_mset_file_buffer = File.ReadAllBytes(file_to_check);
				if (anb_or_mset_file_buffer.Length%16>0)
					anb_or_mset_file_buffer = Combine(anb_or_mset_file_buffer,new byte[16-(anb_or_mset_file_buffer.Length%16)]);
				
				sbyte type_check = 0;
				
				for (int i = 0;i<BitConverter.ToInt32(SubArray(anb_or_mset_file_buffer,4,4),0)&&type_check == 0;i++)
					if (anb_or_mset_file_buffer[16+(16*i)] == 9|anb_or_mset_file_buffer[16+(16*i)] == 0x11)
						type_check = (sbyte)anb_or_mset_file_buffer[16+(16*i)];
				
				if (type_check!= 0x11&&type_check!= 9)
					type_check = (MessageBox.Show("The file seem not to be MSET or ANB file.\r\nProcessing with this file make cause damages and/or erorrs !\r\nProcess anyway ?","Warning !",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) ? type_check : (sbyte)0;
				
				if (type_check>0)
					AddANB(file_to_check);
			}
			catch
			{
				MessageBox.Show("Unable to access the file.\r\nIt is maybe used by another process.","Read Access denied",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}
		
		//Ajout de l'ANB
		void AddANB(string file_to_check)
		{
			header_list_bytes[0] = 0;
			//Verifier si Mset ou Anb avant d'ajouter
			for (int i = 0;i<BitConverter.ToInt32(SubArray(anb_or_mset_file_buffer,4,4),0)&&header_list_bytes[0] == 0;i++)
				if (anb_or_mset_file_buffer[16+(16*i)] == 9)
				{
					header_list_bytes[0] = 0x11;
					header_list_bytes = Combine(Combine(SubArray(header_list_bytes,0,4),SubArray(anb_or_mset_file_buffer,16+(16*i)+4,4)),SubArray(header_list_bytes,8,8));
				}
				else if (anb_or_mset_file_buffer[16+(16*i)] == 16)
				{
					header_list_bytes[0] = 0x14;
					string name = Path.GetFileNameWithoutExtension(file_to_check).Length > 4 ? Path.GetFileNameWithoutExtension(file_to_check).Substring(0,4) : "0000".Substring(0,4-Path.GetFileNameWithoutExtension(file_to_check).Length)+Path.GetFileNameWithoutExtension(file_to_check);
					header_list_bytes = Combine(Combine(SubArray(header_list_bytes,0,4),System.Text.Encoding.ASCII.GetBytes(name)),SubArray(header_list_bytes,8,8));
				}
			
			header_list_bytes[2] = 0;
			header_list_bytes = Combine(Combine(SubArray(header_list_bytes,0,8),BitConverter.GetBytes(mset_stream.Length)),BitConverter.GetBytes(anb_or_mset_file_buffer.Length));
			//Ajout à la fin
				mset_stream = Combine(mset_stream,anb_or_mset_file_buffer); 
			//Ajout nouveau header
				mset_stream = Combine(Combine(SubArray(mset_stream,0,0x10+(moves_list.SelectedIndex*16)),header_list_bytes),SubArray(mset_stream,0x20+(moves_list.SelectedIndex*16),mset_stream.Length-(0x20+(moves_list.SelectedIndex*16))));
				
			label0__.Text = "";	
			Moves_listSelectedIndexChanged(null,null);
			moves_list.Refresh();
		}
		
		//Mise à jour des ordres
		void UpdateNumeros()
		{
			count = 0;
			max = ReadInteger2(4);
			numeros.Clear();
			BAR_Errors.Clear();
			BAR_Errors = new List<string>(Enumerable.Repeat(String.Empty, ReadInteger2(4)).ToList());
			for (int i = 0;i<max;i++)
			{
				if (ReadInteger4(0x1C+(i*16)) == 0)
				{
					if (ReadInteger4(0x18+(i*16))<mset_stream.Length)
						if (CheckCurrBar(i) == false)
							WriteInteger4(0x18+(i*16),16+(16*ReadInteger4(4)));
					if (dummy_sample.Length == 0)
						dummy_sample = SubArray(mset_stream,0x10+(i*16),16);
					dummy_sample[2] = 1;
					numeros.Add("");
				}
				else
				{
					try //FIX = 
					{
						if (mset_stream[ReadInteger4(0x18+(i*16))]!=0x42)
						BAR_Errors[i] = "Not Pointing a BAR file";
					}
					catch
					{
						BAR_Errors[i] = "Pointer out of Mset Bounds";
					}
					count++;
					numeros.Add(" (Pos. "+count.ToString()+")");
				}
			}
		}
		
		
		//Actualiser pointeurs
		void ActualiserPointeursBar(int debut_decalage,int decalage)
		{
			//Ajustement Pointeurs
			for (int i = 0;i<max+1;i++)
			{
				try {
				if (ReadInteger4(0x18+(i*16))>=debut_decalage)
					WriteInteger4(0x18+(i*16),ReadInteger4(0x18+(i*16))+decalage);
				} catch {}
			}
			for (int i=0;i<EC1_infos.Count-1;i++)
				if (EC1_infos[i][0]>=debut_decalage)
					EC1_infos[i][0]+=decalage;
			
			for (int i=0;i<EC2_infos.Count-1;i++)
				if (EC2_infos[i][0]>=debut_decalage)
					EC2_infos[i][0]+=decalage;
		}
		
		//private void InitializeComponent()
		
		//Remove EC
		void RemoveEC(byte ec_index) //0 = EC1 1 = EC2
		{
			ectobar_=GetEcToBar(location_EC_cut);
			if (ec_index == 0)
			{
				mset_stream[location_EC_cut]--;
				WriteInteger2(location_EC_cut+2,(short)(ReadInteger2(location_EC_cut+2)-EC1_infos[EC1_list.FocusedItem.Index][1]));
				byte[] before = SubArray(mset_stream,location_EC_cut,EC1_infos[EC1_list.FocusedItem.Index][0]-location_EC_cut);
				byte[] after = SubArray(mset_stream,EC1_infos[EC1_list.FocusedItem.Index][0]+EC1_infos[EC1_list.FocusedItem.Index][1],ectobar_-EC1_infos[EC1_list.FocusedItem.Index][0]-EC1_infos[EC1_list.FocusedItem.Index][1]+location_EC_cut);
				for (int i = 0;i<ectobar_;i++)
					mset_stream[location_EC_cut+i] = 0;
				for (int i = 0;i<before.Length;i++)
					mset_stream[location_EC_cut+i] = before[i];
				for (int i = 0;i<after.Length;i++)
					mset_stream[location_EC_cut+before.Length+i] = after[i];
			}
			if (ec_index == 1)
			{
				mset_stream[location_EC_cut+1]--;
				byte[] before = SubArray(mset_stream,location_EC_cut,EC2_infos[EC2_list.FocusedItem.Index][0]-location_EC_cut);
				byte[] after = SubArray(mset_stream,EC2_infos[EC2_list.FocusedItem.Index][0]+EC2_infos[EC2_list.FocusedItem.Index][1],ectobar_-EC2_infos[EC2_list.FocusedItem.Index][0]-EC2_infos[EC2_list.FocusedItem.Index][1]+location_EC_cut);
				for (int i = 0;i<ectobar_;i++)
					mset_stream[location_EC_cut+i] = 0;
				for (int i = 0;i<before.Length;i++)
					mset_stream[location_EC_cut+i] = before[i];
				for (int i = 0;i<after.Length;i++)
					mset_stream[location_EC_cut+before.Length+i] = after[i];
			}
			UpdateEffectCaster();
		}
		
		//Add EC
		void AddEC(byte ec_index, byte[] EC) //0 = EC1 1 = EC2
		{
			ectobar_ = GetEcToBar(location_EC_cut);
			int ecs_length = ReadInteger4(GetBARline(location,16)+12);
			AddECLine(1);
			int missing = EC.Length-(ectobar_-ecs_length);
			if (missing>0)
				AddECLine(AdjustBy16(missing)/16);
			WriteInteger4(GetBARline(location,16)+12,ecs_length+EC.Length);
			if (ec_index == 0)
			{
				mset_stream[location_EC_cut]++;
				byte[] after = (ecs_length>4) ? SubArray(mset_stream,location_EC_cut+ReadInteger2(location_EC_cut+2),ectobar_-ReadInteger2(location_EC_cut+2)) : new byte[0];
				for (int i=ReadInteger2(location_EC_cut+2);i<ectobar_;i++)
					mset_stream[location_EC_cut+i]=0;
				for (int i=0;i<EC.Length;i++)
					mset_stream[ReadInteger2(location_EC_cut+2)+location_EC_cut+i]=EC[i];
				for (int i=0;i<after.Length&&ReadInteger2(location_EC_cut+2)+EC.Length+i<ectobar_;i++)
					mset_stream[ReadInteger2(location_EC_cut+2)+EC.Length+location_EC_cut+i]=after[i];
				WriteInteger2(location_EC_cut+2,(short)(ReadInteger2(location_EC_cut+2)+EC.Length));
			}
			if (ec_index == 1)
			{
				mset_stream[location_EC_cut+1]++;
				for (int i=0;i<EC.Length;i++)
					mset_stream[location_EC_cut+i+ecs_length]=EC[i];
			}
			UpdateEffectCaster();
		}
		
		//Add x lines
		void AddECLine(int line_nums)
		{
			ectobar_ = GetEcToBar(location_EC_cut);
			if (location_EC_cut>0&&numeros[moves_list.SelectedIndex].Length>0)
			{
				if (ectobar_==-1) ectobar_ = 0;
				mset_stream = Combine(Combine(SubArray(mset_stream,0,location_EC_cut+ectobar_),new byte[16*line_nums]),SubArray(mset_stream,location_EC_cut+ectobar_,mset_stream.Length-(location_EC_cut+ectobar_)));
				WriteInteger4(GetBARline(location,16)+12,ReadInteger4(GetBARline(location,16)+12)+16*line_nums);
				ActualiserPointeursBar(location_EC_cut,16*line_nums);
				UpdateSizeDiff();
			}
		}
		
		//Remove x lines
		void RemoveECLine(int line_nums)
		{
			ectobar_ = GetEcToBar(location_EC_cut);
			if (ectobar_>16&&location_EC_cut>0&&numeros[moves_list.SelectedIndex].Length>0)
				if (ectobar_-(16*line_nums) >=  0)
				{
					mset_stream = Combine(SubArray(mset_stream,0,location_EC_cut+ectobar_-(line_nums*16)),SubArray(mset_stream,location_EC_cut+ectobar_,mset_stream.Length-(location_EC_cut+ectobar_)));
					ActualiserPointeursBar(location_EC_cut,-(16*line_nums));
					UpdateSizeDiff();
				}
		}
		
		//Get EC Length
		int GetEcToBar(int start)
		{
			int ectobar = -1;
			try
			{
				if (BTS(SubArray(mset_stream,start,3)) != "42-41-52")
				for (int i = 0;ectobar == -1;i = i+16)
					if (BTS(SubArray(mset_stream,start+i,3)) == "42-41-52")
						ectobar = i;
			} catch {ectobar = mset_stream.Length-start;}
			return ectobar;
		}
		
		//EC start
		void UpdateEffectCaster()
		{
			RemoveAdditionnalLines();
			EC1_infos.Clear();
			EC2_infos.Clear();
			EC1_list.Items.Clear();
			EC2_list.Items.Clear();
			int longueur_cum=4;
			//Cherche BAR 0x10
			if (GetBARline(location,16)!=-1)
			{
				/*try
				{*/
				ectobar_ = GetEcToBar(location_EC_cut);
				byte group_ec_1 = ectobar_>0 ? mset_stream[location_EC_cut]:(byte)0;
				byte group_ec_2 = ectobar_>0 ? mset_stream[location_EC_cut+1]:(byte)0;
				var EC_listItems_Temp = new List<string[]>(0);
				EC_listItems_Temp.Clear();
				//Navigation groupe 1
				for (int i=0,offset = 0;location_EC_cut+ectobar_ <= mset_stream.Length&&i<(group_ec_1*6)+offset;i += 6)
				{
					string start_frame = ReadInteger2(location_EC_cut+4+i).ToString();
					string end_frame = ReadInteger2(location_EC_cut+6+i).ToString();
					string type = mset_stream[location_EC_cut+8+i].ToString();
					string index = (mset_stream[location_EC_cut+9+i]>0) ? ReadInteger2(location_EC_cut+10+i).ToString() : "";
					
					
					//Décalage selon la longueur si superieure à 6 octets
					offset += 2*(mset_stream[location_EC_cut+9+i]);
					longueur_cum+=6+2*(mset_stream[location_EC_cut+9+i]);
					EC1_infos.Add(new int[] {
										location_EC_cut+4+i,
										6+2*(mset_stream[location_EC_cut+9+i])});
					i += 2*(mset_stream[location_EC_cut+9+i]);
					
					//Ajout de la ligne EC1 (Affichage)
					EC_listItems_Temp.Add(new string[] {start_frame,end_frame,type,index});
				}
				SortEC(EC_listItems_Temp,0);
				EC_listItems_Temp.Clear();
				
				int start_address_EC2 = (location_EC_cut+2 < mset_stream.Length) ? location_EC_cut+ReadInteger2(location_EC_cut+2):0;
				//Navigation groupe 2
				for (int i=0,offset=0;location_EC_cut+ectobar_ <= mset_stream.Length&&i<(group_ec_2*4)+offset;i += 4)
				{
					string start_frame = ReadInteger2(start_address_EC2+i).ToString();
					string end_frame = "Auto";
					string type = mset_stream[start_address_EC2+2+i].ToString();
					string index = "";
					
					//Exception pour le type "Chagement d'opacité" (0x17 et 0x18)
					if (type == "24"|type == "23")
						end_frame = (ReadInteger2(start_address_EC2+i)+ReadInteger2(start_address_EC2+4+i)).ToString();
					else
						index = ReadInteger2(start_address_EC2+4+i).ToString();
					
					//Décalage selon la longueur si superieure à 4 octets
					offset += 2*(mset_stream[start_address_EC2+3+i]);
					longueur_cum+=4+2*(mset_stream[start_address_EC2+3+i]);
					EC2_infos.Add(new int[] {
					                 	start_address_EC2+i,
					                 	4+2*(mset_stream[start_address_EC2+3+i])});
					i += 2*(mset_stream[start_address_EC2+3+i]);
					
					//Ajout de la ligne EC1 (Affichage)
					EC_listItems_Temp.Add(new string[] {start_frame,end_frame,type,index});
				}
				SortEC(EC_listItems_Temp,1);
				EC_listItems_Temp.Clear();
				
				//MAJ longueur bar index 16
				if (ReadInteger4(GetBARline(location,16)+12)>0)
					WriteInteger4(GetBARline(location,16)+12,longueur_cum);
				/*}
				catch
				{
					
				}*/
			}
		}
		
		//Delete pointed file
		void DeletePointedClick(object sender, EventArgs e)
		{
			bool is_there_something_to_delete = false;
			is_there_something_to_delete = ReadInteger4(0x1C+(moves_list.SelectedIndex*16))>0&&(GetBARline(location,9)>=0|GetBARline(location,16)>=0);
			
			//Vers DUMMY
			mset_stream = Combine(Combine(SubArray(mset_stream,0,0x10+(moves_list.SelectedIndex*16)),dummy_sample),SubArray(mset_stream,0x20+(moves_list.SelectedIndex*16),mset_stream.Length-(0x20+(moves_list.SelectedIndex*16))));
			
			//Retrait ANB
			if (is_there_something_to_delete&&numeros[moves_list.SelectedIndex].Length>0) 
			{
				if (moves_list.SelectedIndex==moves_list.Items.Count-1)
					mset_stream = SubArray(mset_stream,0,location);
				else
					mset_stream = Combine(SubArray(mset_stream,0,location),SubArray(mset_stream,location+longueur,mset_stream.Length-(location+longueur)));
				for (int i = 0;i<max;i++) try {
					if (ReadInteger4(0x18+(i*16)) == location) //Supprime tout ce qui pointe le fichier absent
					{
						mset_stream = Combine(Combine(SubArray(mset_stream,0,0x10+(i*16)),dummy_sample),SubArray(mset_stream,0x20+(i*16),mset_stream.Length-(0x20+(i*16))));
						numeros[i] = "";
						UpdateSizeDiff();
					}} catch {}
				
				//Ajustement Pointeurs
				ActualiserPointeursBar(location,-longueur);
				
				dummy_sample = SubArray(mset_stream,0x10+(moves_list.SelectedIndex*16),16);
			}
			else
				MessageBox.Show("Impossible to delete nothing.","Unable to delete a pointed file", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			
			UpdateNumeros();
			moves_list.Refresh();
			
			Moves_listSelectedIndexChanged(null,null);
			label0__.Text = "";
		}
		
		//Open EC file
		void EC_FileClick(object sender, EventArgs e)
		{
			OpenECFileDialog.InitialDirectory = Path.GetFullPath(Path.GetDirectoryName(mset_filename));
			if (OpenECFileDialog.ShowDialog()==DialogResult.OK)
				OpenECFile(OpenECFileDialog.FileName);
		}
		
		//Open EC file function
		void OpenECFile(string file)
		{
			try
			{
				byte[] ec_file_bytes = File.ReadAllBytes(file);
				bool continuer = false;
				try
				{
					if (ec_file_bytes[16] == 16&&ec_file_bytes[4]==1&&ec_file_bytes[5]==0&&ec_file_bytes[6]==0&&ec_file_bytes[7]==0)
						continuer = true;
					else
						continuer = (MessageBox.Show("The file seem not to be a correct Effect Caster,\r\nprocessing with this file make cause damages and/or erorrs !\r\nProcess anyway ?","Warning !",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes);
					if (continuer)
					{
						int longueur_new_ec = BitConverter.ToInt32(SubArray(ec_file_bytes,0x1C,4),0);
						ectobar_ = GetEcToBar(location_EC_cut);
						if (ectobar_!=-1)
						RemoveECLine(ectobar_/16);
						AddECLine(AdjustBy16(longueur_new_ec)/16);
						ec_file_bytes = SubArray(ec_file_bytes,32,AdjustBy16(longueur_new_ec));
						for (int i=0;i<ec_file_bytes.Length;i++)
							mset_stream[location_EC_cut+i] = ec_file_bytes[i];
						Moves_listSelectedIndexChanged(null,null);
					}
				}
				catch
				{
					//MessageBox.Show("Incorrect data found in the file brought an error.","Error !",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
				}
			}
			catch
			{
				MessageBox.Show("Unable to access the file.\r\nIt is maybe used by another process.","Read Access denied", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}
		
		//save EC file
		void EC_SaveButtonClick(object sender, EventArgs e)
		{
			SaveECFileDialog.InitialDirectory = Path.GetFullPath(Path.GetDirectoryName(mset_filename));
			byte[] name__ = SubArray(mset_stream,GetBARline(location,16)+4,4);
			byte[] length__ = SubArray(mset_stream,GetBARline(location,16)+12,4);
			SaveECFileDialog.FileName = ASCIIString(name__)+"_EC";
			if (SaveECFileDialog.ShowDialog()==DialogResult.OK)
			{
				try
				{
					if (ectobar_==-1)
						MessageBox.Show("The Effect Caster you are trying to save is empty.","Empty file", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					else
						File.WriteAllBytes(SaveECFileDialog.FileName,Combine(new byte[] {66,65,82,1,1,0,0,0,0,0,0,0,0,0,0,0,16,0,0,0,name__[0],name__[1],name__[2],name__[3],32,0,0,0,length__[0],length__[1],length__[2],length__[3]},SubArray(mset_stream,location_EC_cut,ectobar_)));
				}
				catch
				{
					MessageBox.Show("Unable to access the file.\r\nIt is maybe used by another process.","Write Access denied", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
		}
		//Special locations
		void DriveStartAnimationSlotToolStripMenuItemClick(object sender, EventArgs e) {moves_list.SelectedIndex = 215;}
		void StartMenuAnimtionSlotToolStripMenuItemClick(object sender, EventArgs e) {moves_list.SelectedIndex = 558;}
		void EffectCasterSpecialSlotToolStripMenuItemClick(object sender, EventArgs e) {moves_list.SelectedIndex = 628;}
		
		void Timer1Tick(object sender, EventArgs e)
		{
				string update = "";
				ectobar_ = GetEcToBar(location_EC_cut);
				for (int i=0;i<ectobar_;i+=16)
				{
					update+=BitConverter.ToString(SubArray(mset_stream,location_EC_cut+i,16))+"\r\n";
				}
				if (Debugger.Text != update)
				{
					Debugger.Text = update;
				}
		}
	}
}
