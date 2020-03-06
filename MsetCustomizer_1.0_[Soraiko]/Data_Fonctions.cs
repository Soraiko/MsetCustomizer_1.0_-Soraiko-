using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm
	{
		[DllImport("user32.dll")]
        static public extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);
		
        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, [Out] int lpNumberOfBytesWritten);
		[DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
		static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
		[DllImport("kernel32.dll", SetLastError = false)]
		static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
		[Flags]
		public enum ProcessAccessFlags : uint	{All = 0x001F0FFF}
		Process PCSX= new Process();
		static IntPtr pcsx_open;
		public static byte[] ReadMemory(Process process, int address, int numOfBytes, out int bytesRead) {byte[] buffer = new byte[numOfBytes];bytesRead = 0; try {ReadProcessMemory(pcsx_open, new IntPtr(address), buffer, numOfBytes, out bytesRead);} catch {} return buffer;}
		public void WriteBytes(int address, byte[] ValueToWrite, int numberOfBytesToWrite) {try {WriteProcessMemory(pcsx_open, (IntPtr)address, ValueToWrite, numberOfBytesToWrite, 0);} catch {}}
		public byte[] ReadBytes(int address, int numOfBytes) {byte[] buffer = new byte[numOfBytes]; int ReturnBytesRead; try {buffer= ReadMemory(PCSX,address,numOfBytes,out ReturnBytesRead);} catch {} return buffer;}
		public int ReadInteger(int address, int length)
		{byte[] BytesAsked = ReadBytes(address, length); for (int i=3;i>0&&length < 4;i--) BytesAsked[i] = 0; int to_return = 0; try {to_return= BitConverter.ToInt32(ReadBytes(address, length),0);} catch {} return to_return;}
		public void WriteIntegerRAM(int address, int ValueToWrite, int numberOfBytesToWrite) {WriteBytes(address, BitConverter.GetBytes(ValueToWrite), numberOfBytesToWrite);}
		public int PTR(int address, int offset) {return ReadInteger(address,4)+offset;}
		
		//Read String from PCSX2 RAM
		string ReadStringRAM(int address, int length)
		{
			byte[] buffer = ReadBytes(address,length);
			int auto_length = 0;
			while (auto_length<buffer.Length&&buffer[auto_length]!=0) {auto_length++;}
			return System.Text.Encoding.ASCII.GetString(SubArray(buffer,0,auto_length));
		}
		
		public void SeekPCSX2()
		{
			try
			{
				Process.GetProcessById(PCSX.Id);
			}
			catch 
			{
				bool enable = GameAccess.Enabled;
				GameAccess.Enabled = false;
				foreach (Process curr_proc in Process.GetProcesses())
				if (curr_proc.ProcessName.Contains("pcsx2"))
				{
					PCSX=curr_proc;
					pcsx_open = OpenProcess(0x001F0FFF, false, PCSX.Id);
				}
				GameAccess.Enabled = enable;
			}
		}
		
		void GameAccessTick(object sender, EventArgs e)
		{
			try
			{
				SeekPCSX2();
				int address___ = PTR(PTR(0x20341708,0x2000014C),0x1fffffd0);
				Ingame_label.Text = ASCIIString(ReadBytes(address___,3))=="BAR" ?"Animation found at "+address___.ToString("X8"):"Searching animation...";
				address___ = SearchBytes(mset_stream,ReadBytes(address___+0x100,0x300))-0x100;
				int ec_loc = ReadInteger4(address___+0x28);
				int ec_len = ReadInteger4(address___+0x2C);
				WriteBytes(0x21c93a00,Combine(SubArray(mset_stream,address___+ec_loc,ec_len),new byte[0x100]),ec_len+0x100);
				if (ReadInteger(PTR(0x20341708,0x20000150),4)==0||ReadInteger(PTR(0x20341708,0x20000150),4)-ReadInteger(PTR(0x20341708,0x2000014C),4)+0x30==ec_loc)
					WriteIntegerRAM(PTR(0x20341708,0x20000150),0x1c93a00,4);
				int line = SearchBytes(SubArray(mset_stream,0,16+16*ReadInteger4(4)),BitConverter.GetBytes(address___));
				while (false&&ReadInteger4(line+4)==0)
				{
					int old_line = line;
					WriteInteger4(old_line,0);
					line = SearchBytes(SubArray(mset_stream,0,16+16*ReadInteger4(4)),BitConverter.GetBytes(address___));
					WriteInteger4(old_line,address___);
				}
				if (line>-1)
				if (moves_list.SelectedIndex!=((line-24)/16)&&AutoRefreshIndex.Checked)
					moves_list.SelectedIndex=((line-24)/16);
			}
			catch 
			{
			}
			try
			{
				float max_frame = GetMaxFrame(location);
				float start_frame = BitConverter.ToSingle(ReadBytes(PTR(0x20341708,0x20000170),4),0);
				time_label_middle.Text = start_frame.ToString();
				float ratio = start_frame/max_frame;
				FrameRectangle = new Rectangle(0, 0, (int)(300*ratio), paneltime_ingame.Height);
				paneltime_ingame.Invalidate();
				
				if (AutoRefreshEC.Checked)
				{
					for (int i=0;i<EC1_list.Items.Count;i++)
						if (start_frame>=int.Parse(EC1_list.Items[i].Text)&(EC1_list.Items[i].SubItems[1].Text=="-1"||start_frame<=int.Parse(EC1_list.Items[i].SubItems[1].Text)))
						{
							EC1_list.Items[i].Selected = true;
							EC1_list.EnsureVisible(i);
						}
						else
							EC1_list.Items[i].Selected = false;
						
					for (int i=0;i<EC2_list.Items.Count;i++)
						if (start_frame>=int.Parse(EC2_list.Items[i].Text)&(EC2_list.Items[i].SubItems[1].Text=="Auto"||start_frame<=int.Parse(EC2_list.Items[i].SubItems[1].Text)))
						{
							EC2_list.Items[i].Selected = true;
							EC2_list.EnsureVisible(i);
						}
						else
							EC2_list.Items[i].Selected = false;
				}
			}
			catch
			{
				
			}
		}
		
		
		public string ASCIIString(byte[] input) {return System.Text.Encoding.ASCII.GetString(input);}
		public string ReadString(int string_loc) {return System.Text.Encoding.ASCII.GetString(SubArray(mset_stream,string_loc,4));}
		public byte[] SubArray(byte[] data, long index, long length) {byte[] result = new byte[length];  Array.Copy(data, index, result, 0, length); return result;}
		public byte[] Combine(byte[] a, byte[] b) {byte[] c = new byte[a.Length + b.Length];  System.Buffer.BlockCopy(a, 0, c, 0, a.Length); System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);  return c;}
		
		//Rechercher des octets
		public int SearchBytes(byte[] input, byte[] needle)
		{
			var len = needle.Length;
			var limit = input.Length - len;
			for(var i = 0; i<=limit; i++)
			{
				var k = 0;
				for(; k<len; k++)
					if(needle[k] != input[i+k]) break;
				if(k == len) return i;
			}
			return -1;
		}
		
		//Update Scheme frame
		void UpdateFrameScheme(sbyte index)
		{
			bool do_ = (index ==0)? EC1_list.FocusedItem != null : EC2_list.FocusedItem != null;
			float max_frame = GetMaxFrame(location);
			time_label_start.Text = "0.0";
			time_label_end.Text = max_frame.ToString("0.0");
			time_label_curr.Text = "";
			if (index==3)
				RectangledFrames= new Rectangle(0,0,0,0);
			
			try {
			if (do_)
			{
				int address_entree = (index==0) ? EC1_infos[EC1_list.FocusedItem.Index][0] : EC2_infos[EC2_list.FocusedItem.Index][0];
				bool opacity_type = (mset_stream[address_entree+2]==0x18|mset_stream[address_entree+2]==0x17);
				float start_frame = (float)(ReadInteger2(address_entree));
				float end_frame = (float)(ReadInteger2(address_entree+2));
					if (index==1)
						if (opacity_type)
							end_frame = (float)(start_frame+ReadInteger2(address_entree+4));
						else
							end_frame = (int)max_frame;
					else if ((int)end_frame==-1)
						end_frame = (int)max_frame;
				
				float ratio = (end_frame-start_frame)/max_frame;
				RectangledFrames = new Rectangle((int)((start_frame*300)/max_frame), 0, (int)(300*ratio), paneltime.Height);
				time_label_curr.Text = start_frame.ToString("0.0");
				time_label_curr.Text += index==0|opacity_type ? " --> "+end_frame.ToString("0.0"):"";
				
				int tlc_width =MeasureSizeFont(time_label_curr)+2;
				int tlc_x = (int)(tlc_width/-2)+RectangledFrames.X+(int)(RectangledFrames.Width/2);
				if (tlc_width<RectangledFrames.Width)
				{
					tlc_width=RectangledFrames.Width;
					tlc_x=RectangledFrames.X;
				}
				if (tlc_x<0) tlc_x=0;
				if (index==1&&!opacity_type) tlc_x=(int)(tlc_width/-2)+RectangledFrames.X;
				if (tlc_x+tlc_width>300) tlc_x=300-tlc_width;
				
				time_label_curr.Location = new Point(paneltime.Location.X+tlc_x,time_label_curr.Location.Y);
				time_label_curr.Size = new Size(tlc_width,time_label_curr.Height);
				if (opacity_type)
					index=0;
				RectangledFramesIndex=index;
				
			}
			} catch {}
			paneltime.Invalidate();
		}
		Rectangle RectangledFrames= new Rectangle(-100,-100,1,1);
		int RectangledFramesIndex = 0;
		//Get font size 
		public int MeasureSizeFont(Label input_label)
		{
			Graphics graphics = Graphics.FromImage(new Bitmap(input_label.Width,input_label.Height));
			string text=input_label.Text;
			Font font=input_label.Font;
			var format  = new StringFormat();
			var rect = new RectangleF(0,0,1000,1000);
			var ranges = new CharacterRange[] {new CharacterRange(0,text.Length)};
			var regions = new Region[1];
			format.SetMeasurableCharacterRanges (ranges);
			regions = graphics.MeasureCharacterRanges (text, font, rect, format);
			rect = regions[0].GetBounds (graphics);
			return (int)(rect.Right + 1.0f);
		}
		
		//Get max frame of selected animation
		float GetMaxFrame(int bar_17_location)
		{
			float curr=-1f;
			if (CheckCurrBar(moves_list.SelectedIndex))
			{
				int frames_Address = bar_17_location+ReadInteger4(GetBARline(bar_17_location,9)+8);
				while (BTS(SubArray(mset_stream,frames_Address,16))==BTS(new byte[16]))
				{
					frames_Address+=16;
				}
				int frames_Address_min = frames_Address+ReadInteger4(frames_Address+0x44);
				int frames_Address_max = frames_Address+ReadInteger4(frames_Address+0x48);
				float bigger = -1f;
				while (frames_Address_min<frames_Address_max)
				{
					curr=BitConverter.ToSingle(SubArray(mset_stream,frames_Address_min,4),0);
					if (curr>bigger)
					{
						bigger=curr;
					}
					frames_Address_min+=4;
				}
			}
			return curr;
		}
		
		//Bytes to string
		string BTS(byte[] input) {return BitConverter.ToString(input);}
		
		//Lire entier 32bits
		int ReadInteger4(int address)
		{
			return BitConverter.ToInt32(SubArray(mset_stream,address,4),0);
		}
		
		//Lire entier 16bits
		short ReadInteger2(int address)
		{
			return BitConverter.ToInt16(new byte [] {mset_stream[address],mset_stream[address+1]},0);
		}
		
		//Ecrire entier 32bits
		void WriteInteger4(int adr,int valeur)
		{
			byte[] out_ = BitConverter.GetBytes(valeur);
			mset_stream[adr] = out_[0];
			mset_stream[adr+1] = out_[1];
			mset_stream[adr+2] = out_[2];
			mset_stream[adr+3] = out_[3];
		}
		
		//Ecrire entier 16bits
		void WriteInteger2(int adr,short valeur)
		{
			byte[] out_ = BitConverter.GetBytes(valeur);
			mset_stream[adr] = out_[0];
			mset_stream[adr+1] = out_[1];
		}
		
		//(Modulo 16) -> 0
		int AdjustBy16(int entry) 	{return (entry<16) ? ((entry>0) ? 16:0) : entry+16-(entry%16);}
		//Vérification si pointeur OK
		bool CheckCurrBar(int i){try {return BTS(SubArray(mset_stream, ReadInteger4(0x18+i*16), 3)) == "42-41-52";} catch {return false;}}
		
		//Chercher la ligne BAR avec le type désiré
		int GetBARline(int BAR_header_loc,byte bar_type)
		{
			if (CheckCurrBar(moves_list.SelectedIndex))
			for (int i = 0;i<ReadInteger2(BAR_header_loc+4);i++)
				if (mset_stream[16+BAR_header_loc+16*i] == bar_type)
					return (16+BAR_header_loc+16*i);
			return -1;
		}
		
		//Sort Effect Caster Items
		void SortEC(List<string[]> input,sbyte index)
		{
			try
			{
				List<int[]> EC_info_to_sort = new List<int[]>(0);
				EC_info_to_sort.AddRange(new int[][][] {EC1_infos.ToArray(),EC2_infos.ToArray()}[index]);
				int smaller;
				if (index==0)
				{
					EC1_list.Items.Clear();
					EC1_infos.Clear();
				}
				else
				{
					EC2_list.Items.Clear();
					EC2_infos.Clear();
				}
				
				while (input.Count>0)
				{
					smaller=0;
					for (int i=0;i<input.Count;i++)
					{
						bool stop = false;
						for (int compare = 0;compare<4&!stop;compare++)
							try
							{
								if (int.Parse(input[i][compare])<int.Parse(input[smaller][compare]))
									smaller = i;
								else if (int.Parse(input[i][compare])>int.Parse(input[smaller][compare]))
									stop = true;
							}
							catch {}
						
					}
					if (index==0)
					{
						EC1_list.Items.Add(new ListViewItem(input[smaller]));
						EC1_infos.Add(new int[][] {(int[])EC_info_to_sort[smaller]}[0]);
					}
					else
					{
						EC2_list.Items.Add(new ListViewItem(input[smaller]));
						EC2_infos.Add(new int[][] {(int[])EC_info_to_sort[smaller]}[0]);
					}
					input.RemoveAt(smaller);
					EC_info_to_sort.RemoveAt(smaller);
				}
				Update_Focus.Enabled = true;
			} catch {}
		}
		
		string save_label = "";
		//Remove 16 bytes additionnal lines ending Effect casters
		void RemoveAdditionnalLines()
		{
			try{
				ectobar_ = GetEcToBar(location+ReadInteger4(GetBARline(location,9)+8)+ReadInteger4(GetBARline(location,9)+12));
				if (ectobar_==-1) return;
				int lines_to_remove = 0;
				for (int i=location_EC_cut+ectobar_;i>location_EC_cut;i-=16)
				{
					if (BTS(SubArray(mset_stream,i,16)) == BTS(new byte[16])&&i>location_EC_cut+ReadInteger4(GetBARline(location,16)+12))
						lines_to_remove++;
				}
				if (lines_to_remove>0)
				{
					save_label=" (+0x"+(lines_to_remove*16).ToString("X")+" saved)";
					RemoveECLine(lines_to_remove);
				}
				
			} catch {}
		}
		//Search last added/edited
		void DefineLastAdded(byte[] Ec_entry)
		{
			int  max_ = new int[] {EC1_infos.Count,EC2_infos.Count}[last_focused_group];
			for (int i=0;i<max_&&Ec_entry.Length>0;i++)
			{
				if (last_focused_group==0)
				{
					if (BTS(SubArray(mset_stream,EC1_infos[i][0],EC1_infos[i][1]))==BTS(Ec_entry))
					{last_added=i;}
				}
				if (last_focused_group==1)
				{
					if (BTS(SubArray(mset_stream,EC2_infos[i][0],EC2_infos[i][1]))==BTS(Ec_entry))
					{last_added=i;}
				}
			}
			ListFocus.Enabled = true;
		}
	}
}
