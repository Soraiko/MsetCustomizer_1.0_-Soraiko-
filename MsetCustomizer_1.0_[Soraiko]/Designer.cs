using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace MsetCustomizer_1.___Soraiko_
{
	public partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		private Button Mset_File;
		private OpenFileDialog OpenMsetFileDialog;
		private ListBox moves_list;
		private GroupBox groupBox1;
		private TextBox label3_;
		private Label label3;
		private Label label0_;
		private Label label0;
		private Label label2_;
		private Label label2;
		private Label label1_;
		private Label label1;
		private Label label0__;
		private GroupBox groupBox0;
		private Label label5_;
		private Label label5;
		private Label label4_;
		private Label label4;
		private Button Add;
		private Button Delete;
		private Button Up;
		private Button Down;
		private GroupBox groupBox3;
		private Button SaveButton;
		private OpenFileDialog OpenANBFileDialog;
		private GroupBox Open_Save_group;
		private GroupBox list_group;
		private SaveFileDialog SaveMsetFileDialog;
		private ContextMenuStrip Moves_listMenuStrip;
		private ToolStripMenuItem copyHeader;
		private Timer CopyBlink;
		private Label label9_;
		private Label label9;
		private ToolStripMenuItem extractPointed;
		private SaveFileDialog SaveANBFileDialog;
		private ListView EC1_list;
		private GroupBox EC_group;
		private Button Del_G1;
		private ColumnHeader FrameSEC1;
		private ColumnHeader FrameEEC1;
		private ColumnHeader TypeEC1;
		private ColumnHeader IndexEC1;
		
		private ListView EC2_list;
		private ColumnHeader FrameSEC2;
		private ColumnHeader TypeEC2;
		private ColumnHeader IndexEC2;
		private ColumnHeader FrameEEC2;
		private Timer GameAccess;
		private Label label_gray;
		private Panel panel2;
		private Label label_white;
		private Panel panel1;
		private Label label_red;
		private Label label_dark_gray;
		private Panel panel3;
		private ToolStripMenuItem ChangePointer;
		private ToolStripMenuItem deletePointed;
		private Label label_orange;
		private Panel panel5;
		private Button EC1_00;
		private Button EC1_0A;
		private Button EC1_14;
		private Button EC1_17;
		
		private Button EC2_01;
		private Button EC2_02;
		private Button EC2_06;
		private Button EC2_07;
		private Button EC2_08;
		private Button EC2_0E;
		private Button EC2_13;
		private Button EC2_17;
		private Button EC2_18;
		private Button EC2_1A;
		private Button EC2_1B;
		private Button EC2_1D;
		private Button Add_G1;
		private Panel panel4;
		private Label label7_;
		private Label label7;
		private Label label8;
		private Label label6_;
		private Label label6;
		private TextBox label8_;
		private GroupBox groupBox2;
		private Button Add_G2;
		private Button Del_G2;
		private Button Unregistred;
		private SplitContainer EC_splitter;
		private GroupBox EC1_2_group;
		private FlowLayoutPanel flowLayoutPanel1;
		private Label EC_label;
		private FlowLayoutPanel G1_Flow;
		private FlowLayoutPanel G2_flow;
		private System.Windows.Forms.PictureBox paneltime;
		private System.Windows.Forms.Label time_label_curr;
		private System.Windows.Forms.Label time_label_end;
		private System.Windows.Forms.Label time_label_start;
		private System.Windows.Forms.Panel blink_preview;
		private System.Windows.Forms.Timer Split_blink;
		private System.Windows.Forms.Button EC1_1C;
		private System.Windows.Forms.Button EC1_03;
		private System.Windows.Forms.Button EC2_16;
		private System.Windows.Forms.Button EC1_0B;
		private System.Windows.Forms.Label EC_label_info;
		private System.Windows.Forms.Button EC1_10;
		private System.Windows.Forms.Button EC1_11;
		private System.Windows.Forms.Button EC1_1D;
		private System.Windows.Forms.Button EC1_0C;
		private System.Windows.Forms.Timer ListFocus;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button EC_SaveButton;
		private System.Windows.Forms.Button EC_File;
		private System.Windows.Forms.OpenFileDialog OpenECFileDialog;
		private System.Windows.Forms.SaveFileDialog SaveECFileDialog;
		private System.Windows.Forms.CheckBox Ingame_test_checkbox;
		private System.Windows.Forms.Label Ingame_label;
		private System.Windows.Forms.Label time_label_middle;
		private System.Windows.Forms.PictureBox paneltime_ingame;
		private System.Windows.Forms.CheckBox AutoRefreshIndex;
		private System.Windows.Forms.Timer Update_Focus;
		private System.Windows.Forms.ToolTip KeysTip;
		private System.Windows.Forms.CheckBox AutoRefreshEC;
		private System.Windows.Forms.ToolStripMenuItem gotoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem driveStartAnimationSlotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startMenuAnimtionSlotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem effectCasterSpecialSlotToolStripMenuItem;
		private System.Windows.Forms.Label Debugger;
		private System.Windows.Forms.Timer DebugTimer;
		private System.Windows.Forms.Button Clean;
		private System.Windows.Forms.Button Edit;
		private System.Windows.Forms.GroupBox groupBox5;
		
		
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.Mset_File = new System.Windows.Forms.Button();
			this.OpenMsetFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.moves_list = new System.Windows.Forms.ListBox();
			this.Moves_listMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ChangePointer = new System.Windows.Forms.ToolStripMenuItem();
			this.copyHeader = new System.Windows.Forms.ToolStripMenuItem();
			this.extractPointed = new System.Windows.Forms.ToolStripMenuItem();
			this.deletePointed = new System.Windows.Forms.ToolStripMenuItem();
			this.gotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.driveStartAnimationSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startMenuAnimtionSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.effectCasterSpecialSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3_ = new System.Windows.Forms.TextBox();
			this.label0__ = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label0_ = new System.Windows.Forms.Label();
			this.label0 = new System.Windows.Forms.Label();
			this.label2_ = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1_ = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox0 = new System.Windows.Forms.GroupBox();
			this.label9_ = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label5_ = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4_ = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Add = new System.Windows.Forms.Button();
			this.Delete = new System.Windows.Forms.Button();
			this.Up = new System.Windows.Forms.Button();
			this.Down = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Clean = new System.Windows.Forms.Button();
			this.Edit = new System.Windows.Forms.Button();
			this.OpenANBFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveButton = new System.Windows.Forms.Button();
			this.Open_Save_group = new System.Windows.Forms.GroupBox();
			this.list_group = new System.Windows.Forms.GroupBox();
			this.label_orange = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label_red = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label_dark_gray = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label_gray = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label_white = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SaveMsetFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.CopyBlink = new System.Windows.Forms.Timer(this.components);
			this.SaveANBFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.EC_group = new System.Windows.Forms.GroupBox();
			this.EC_label_info = new System.Windows.Forms.Label();
			this.EC_label = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.EC1_00 = new System.Windows.Forms.Button();
			this.EC1_03 = new System.Windows.Forms.Button();
			this.EC1_0A = new System.Windows.Forms.Button();
			this.EC1_0B = new System.Windows.Forms.Button();
			this.EC1_0C = new System.Windows.Forms.Button();
			this.EC1_10 = new System.Windows.Forms.Button();
			this.EC1_11 = new System.Windows.Forms.Button();
			this.EC1_14 = new System.Windows.Forms.Button();
			this.EC1_17 = new System.Windows.Forms.Button();
			this.EC1_1C = new System.Windows.Forms.Button();
			this.EC1_1D = new System.Windows.Forms.Button();
			this.EC2_01 = new System.Windows.Forms.Button();
			this.EC2_02 = new System.Windows.Forms.Button();
			this.EC2_06 = new System.Windows.Forms.Button();
			this.EC2_07 = new System.Windows.Forms.Button();
			this.EC2_08 = new System.Windows.Forms.Button();
			this.EC2_0E = new System.Windows.Forms.Button();
			this.EC2_13 = new System.Windows.Forms.Button();
			this.EC2_16 = new System.Windows.Forms.Button();
			this.EC2_17 = new System.Windows.Forms.Button();
			this.EC2_18 = new System.Windows.Forms.Button();
			this.EC2_1A = new System.Windows.Forms.Button();
			this.EC2_1B = new System.Windows.Forms.Button();
			this.EC2_1D = new System.Windows.Forms.Button();
			this.Unregistred = new System.Windows.Forms.Button();
			this.EC1_2_group = new System.Windows.Forms.GroupBox();
			this.paneltime = new System.Windows.Forms.PictureBox();
			this.paneltime_ingame = new System.Windows.Forms.PictureBox();
			this.time_label_middle = new System.Windows.Forms.Label();
			this.blink_preview = new System.Windows.Forms.Panel();
			this.time_label_curr = new System.Windows.Forms.Label();
			this.time_label_end = new System.Windows.Forms.Label();
			this.time_label_start = new System.Windows.Forms.Label();
			this.EC_splitter = new System.Windows.Forms.SplitContainer();
			this.Add_G1 = new System.Windows.Forms.Button();
			this.Del_G1 = new System.Windows.Forms.Button();
			this.G1_Flow = new System.Windows.Forms.FlowLayoutPanel();
			this.EC1_list = new System.Windows.Forms.ListView();
			this.FrameSEC1 = new System.Windows.Forms.ColumnHeader();
			this.FrameEEC1 = new System.Windows.Forms.ColumnHeader();
			this.TypeEC1 = new System.Windows.Forms.ColumnHeader();
			this.IndexEC1 = new System.Windows.Forms.ColumnHeader();
			this.Add_G2 = new System.Windows.Forms.Button();
			this.Del_G2 = new System.Windows.Forms.Button();
			this.EC2_list = new System.Windows.Forms.ListView();
			this.FrameSEC2 = new System.Windows.Forms.ColumnHeader();
			this.FrameEEC2 = new System.Windows.Forms.ColumnHeader();
			this.TypeEC2 = new System.Windows.Forms.ColumnHeader();
			this.IndexEC2 = new System.Windows.Forms.ColumnHeader();
			this.G2_flow = new System.Windows.Forms.FlowLayoutPanel();
			this.Debugger = new System.Windows.Forms.Label();
			this.GameAccess = new System.Windows.Forms.Timer(this.components);
			this.label7_ = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6_ = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8_ = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Split_blink = new System.Windows.Forms.Timer(this.components);
			this.ListFocus = new System.Windows.Forms.Timer(this.components);
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.EC_SaveButton = new System.Windows.Forms.Button();
			this.EC_File = new System.Windows.Forms.Button();
			this.OpenECFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveECFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.Ingame_test_checkbox = new System.Windows.Forms.CheckBox();
			this.Ingame_label = new System.Windows.Forms.Label();
			this.AutoRefreshIndex = new System.Windows.Forms.CheckBox();
			this.Update_Focus = new System.Windows.Forms.Timer(this.components);
			this.AutoRefreshEC = new System.Windows.Forms.CheckBox();
			this.KeysTip = new System.Windows.Forms.ToolTip(this.components);
			this.DebugTimer = new System.Windows.Forms.Timer(this.components);
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.Moves_listMenuStrip.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox0.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.Open_Save_group.SuspendLayout();
			this.list_group.SuspendLayout();
			this.EC_group.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.EC1_2_group.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.paneltime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paneltime_ingame)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EC_splitter)).BeginInit();
			this.EC_splitter.Panel1.SuspendLayout();
			this.EC_splitter.Panel2.SuspendLayout();
			this.EC_splitter.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// Mset_File
			// 
			this.Mset_File.AllowDrop = true;
			this.Mset_File.Dock = System.Windows.Forms.DockStyle.Left;
			this.Mset_File.Location = new System.Drawing.Point(30, 18);
			this.Mset_File.Name = "Mset_File";
			this.Mset_File.Size = new System.Drawing.Size(130, 37);
			this.Mset_File.TabIndex = 1;
			this.Mset_File.Text = "Open Mset...";
			this.Mset_File.UseVisualStyleBackColor = true;
			this.Mset_File.Click += new System.EventHandler(this.Mset_FileClick);
			this.Mset_File.DragDrop += new System.Windows.Forms.DragEventHandler(this.Mset_FileDragDrop);
			this.Mset_File.DragOver += new System.Windows.Forms.DragEventHandler(this.Mset_FileDragOver);
			// 
			// OpenMsetFileDialog
			// 
			this.OpenMsetFileDialog.FileName = "*.mset";
			this.OpenMsetFileDialog.Filter = "Mset files|*.mset";
			// 
			// moves_list
			// 
			this.moves_list.AllowDrop = true;
			this.moves_list.ContextMenuStrip = this.Moves_listMenuStrip;
			this.moves_list.Dock = System.Windows.Forms.DockStyle.Top;
			this.moves_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.moves_list.Enabled = false;
			this.moves_list.FormattingEnabled = true;
			this.moves_list.Location = new System.Drawing.Point(10, 23);
			this.moves_list.Name = "moves_list";
			this.moves_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.moves_list.Size = new System.Drawing.Size(162, 212);
			this.moves_list.TabIndex = 0;
			this.moves_list.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Moves_listDrawItem);
			this.moves_list.SelectedIndexChanged += new System.EventHandler(this.Moves_listSelectedIndexChanged);
			this.moves_list.DragDrop += new System.Windows.Forms.DragEventHandler(this.Moves_listDragDrop);
			this.moves_list.DragOver += new System.Windows.Forms.DragEventHandler(this.Moves_listDragOver);
			this.moves_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Moves_listKeyDown);
			this.moves_list.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Moves_listMouseDown);
			// 
			// Moves_listMenuStrip
			// 
			this.Moves_listMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ChangePointer,
									this.copyHeader,
									this.extractPointed,
									this.deletePointed,
									this.gotoToolStripMenuItem});
			this.Moves_listMenuStrip.Name = "Moves_listMenuStrip";
			this.Moves_listMenuStrip.Size = new System.Drawing.Size(182, 114);
			// 
			// ChangePointer
			// 
			this.ChangePointer.Name = "ChangePointer";
			this.ChangePointer.Size = new System.Drawing.Size(181, 22);
			this.ChangePointer.Text = "Fix this pointer...";
			this.ChangePointer.Click += new System.EventHandler(this.ChangedPointerClick);
			// 
			// copyHeader
			// 
			this.copyHeader.Name = "copyHeader";
			this.copyHeader.Size = new System.Drawing.Size(181, 22);
			this.copyHeader.Text = "Duplicate Bar slot...";
			this.copyHeader.Click += new System.EventHandler(this.CopyHeaderClick);
			// 
			// extractPointed
			// 
			this.extractPointed.Name = "extractPointed";
			this.extractPointed.Size = new System.Drawing.Size(181, 22);
			this.extractPointed.Text = "Extract pointed file...";
			this.extractPointed.Click += new System.EventHandler(this.ExtractClick);
			// 
			// deletePointed
			// 
			this.deletePointed.Name = "deletePointed";
			this.deletePointed.Size = new System.Drawing.Size(181, 22);
			this.deletePointed.Text = "Delete pointed file...";
			this.deletePointed.Click += new System.EventHandler(this.DeletePointedClick);
			// 
			// gotoToolStripMenuItem
			// 
			this.gotoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.driveStartAnimationSlotToolStripMenuItem,
									this.startMenuAnimtionSlotToolStripMenuItem,
									this.effectCasterSpecialSlotToolStripMenuItem});
			this.gotoToolStripMenuItem.Name = "gotoToolStripMenuItem";
			this.gotoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.gotoToolStripMenuItem.Text = "Goto...";
			// 
			// driveStartAnimationSlotToolStripMenuItem
			// 
			this.driveStartAnimationSlotToolStripMenuItem.Name = "driveStartAnimationSlotToolStripMenuItem";
			this.driveStartAnimationSlotToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.driveStartAnimationSlotToolStripMenuItem.Text = "Drive start animation slot";
			this.driveStartAnimationSlotToolStripMenuItem.Click += new System.EventHandler(this.DriveStartAnimationSlotToolStripMenuItemClick);
			// 
			// startMenuAnimtionSlotToolStripMenuItem
			// 
			this.startMenuAnimtionSlotToolStripMenuItem.Name = "startMenuAnimtionSlotToolStripMenuItem";
			this.startMenuAnimtionSlotToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.startMenuAnimtionSlotToolStripMenuItem.Text = "Start menu animtion slot";
			this.startMenuAnimtionSlotToolStripMenuItem.Click += new System.EventHandler(this.StartMenuAnimtionSlotToolStripMenuItemClick);
			// 
			// effectCasterSpecialSlotToolStripMenuItem
			// 
			this.effectCasterSpecialSlotToolStripMenuItem.Name = "effectCasterSpecialSlotToolStripMenuItem";
			this.effectCasterSpecialSlotToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.effectCasterSpecialSlotToolStripMenuItem.Text = "Effect Caster special slot";
			this.effectCasterSpecialSlotToolStripMenuItem.Click += new System.EventHandler(this.EffectCasterSpecialSlotToolStripMenuItemClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3_);
			this.groupBox1.Controls.Add(this.label0__);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label0_);
			this.groupBox1.Controls.Add(this.label0);
			this.groupBox1.Controls.Add(this.label2_);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1_);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(200, 213);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(245, 151);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pointed ANB Infos";
			// 
			// label3_
			// 
			this.label3_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3_.Enabled = false;
			this.label3_.Location = new System.Drawing.Point(98, 115);
			this.label3_.MaxLength = 4;
			this.label3_.Name = "label3_";
			this.label3_.Size = new System.Drawing.Size(137, 20);
			this.label3_.TabIndex = 14;
			this.label3_.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label3_.Enter += new System.EventHandler(this.Label3_Enter);
			this.label3_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Label3_KeyDown);
			this.label3_.Leave += new System.EventHandler(this.Label3_Leave);
			// 
			// label0__
			// 
			this.label0__.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label0__.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label0__.Location = new System.Drawing.Point(169, 22);
			this.label0__.Name = "label0__";
			this.label0__.Size = new System.Drawing.Size(66, 23);
			this.label0__.TabIndex = 8;
			this.label0__.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Location = new System.Drawing.Point(11, 114);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "ANB Name";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label0_
			// 
			this.label0_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label0_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label0_.Location = new System.Drawing.Point(98, 22);
			this.label0_.Name = "label0_";
			this.label0_.Size = new System.Drawing.Size(66, 23);
			this.label0_.TabIndex = 5;
			this.label0_.Text = "0";
			this.label0_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label0
			// 
			this.label0.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label0.Location = new System.Drawing.Point(11, 22);
			this.label0.Name = "label0";
			this.label0.Size = new System.Drawing.Size(81, 23);
			this.label0.TabIndex = 4;
			this.label0.Text = "BAR Index";
			this.label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2_
			// 
			this.label2_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label2_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2_.Location = new System.Drawing.Point(98, 84);
			this.label2_.Name = "label2_";
			this.label2_.Size = new System.Drawing.Size(137, 23);
			this.label2_.TabIndex = 3;
			this.label2_.Text = "0";
			this.label2_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Location = new System.Drawing.Point(11, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Length";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1_
			// 
			this.label1_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label1_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1_.Location = new System.Drawing.Point(98, 54);
			this.label1_.Name = "label1_";
			this.label1_.Size = new System.Drawing.Size(137, 23);
			this.label1_.TabIndex = 1;
			this.label1_.Text = "0x00";
			this.label1_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new System.Drawing.Point(11, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Location";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox0
			// 
			this.groupBox0.Controls.Add(this.label9_);
			this.groupBox0.Controls.Add(this.label9);
			this.groupBox0.Controls.Add(this.label5_);
			this.groupBox0.Controls.Add(this.label5);
			this.groupBox0.Controls.Add(this.label4_);
			this.groupBox0.Controls.Add(this.label4);
			this.groupBox0.Location = new System.Drawing.Point(200, 80);
			this.groupBox0.Name = "groupBox0";
			this.groupBox0.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.groupBox0.Size = new System.Drawing.Size(245, 107);
			this.groupBox0.TabIndex = 3;
			this.groupBox0.TabStop = false;
			this.groupBox0.Text = "Mset Infos";
			// 
			// label9_
			// 
			this.label9_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label9_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label9_.Location = new System.Drawing.Point(98, 45);
			this.label9_.Name = "label9_";
			this.label9_.Size = new System.Drawing.Size(137, 23);
			this.label9_.TabIndex = 14;
			this.label9_.Text = "0x00";
			this.label9_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label9.Location = new System.Drawing.Point(11, 45);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(81, 23);
			this.label9.TabIndex = 13;
			this.label9.Text = "Size (New)";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5_
			// 
			this.label5_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label5_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5_.Location = new System.Drawing.Point(98, 74);
			this.label5_.Name = "label5_";
			this.label5_.Size = new System.Drawing.Size(137, 23);
			this.label5_.TabIndex = 12;
			this.label5_.Text = "0";
			this.label5_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new System.Drawing.Point(11, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "Moves";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4_
			// 
			this.label4_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label4_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4_.Location = new System.Drawing.Point(98, 17);
			this.label4_.Name = "label4_";
			this.label4_.Size = new System.Drawing.Size(137, 23);
			this.label4_.TabIndex = 10;
			this.label4_.Text = "0x00";
			this.label4_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Location = new System.Drawing.Point(11, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(81, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Size";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Add
			// 
			this.Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Add.BackgroundImage")));
			this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Add.Enabled = false;
			this.Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Add.Location = new System.Drawing.Point(21, 16);
			this.Add.Name = "Add";
			this.Add.Size = new System.Drawing.Size(40, 40);
			this.Add.TabIndex = 3;
			this.Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Add.UseVisualStyleBackColor = true;
			this.Add.Click += new System.EventHandler(this.AddClick);
			// 
			// Delete
			// 
			this.Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Delete.BackgroundImage")));
			this.Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Delete.Enabled = false;
			this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Delete.Location = new System.Drawing.Point(21, 61);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(40, 40);
			this.Delete.TabIndex = 4;
			this.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Click += new System.EventHandler(this.DeleteClick);
			// 
			// Up
			// 
			this.Up.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Up.BackgroundImage")));
			this.Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Up.Enabled = false;
			this.Up.Location = new System.Drawing.Point(50, 16);
			this.Up.Name = "Up";
			this.Up.Size = new System.Drawing.Size(40, 40);
			this.Up.TabIndex = 5;
			this.Up.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Up.UseVisualStyleBackColor = true;
			this.Up.Click += new System.EventHandler(this.UpClick);
			// 
			// Down
			// 
			this.Down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Down.BackgroundImage")));
			this.Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Down.Enabled = false;
			this.Down.Location = new System.Drawing.Point(50, 61);
			this.Down.Name = "Down";
			this.Down.Size = new System.Drawing.Size(40, 40);
			this.Down.TabIndex = 6;
			this.Down.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Down.UseVisualStyleBackColor = true;
			this.Down.Click += new System.EventHandler(this.DownClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.Clean);
			this.groupBox3.Controls.Add(this.Down);
			this.groupBox3.Controls.Add(this.Edit);
			this.groupBox3.Controls.Add(this.Up);
			this.groupBox3.Location = new System.Drawing.Point(99, 388);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(95, 107);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Navigate";
			// 
			// Clean
			// 
			this.Clean.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Clean.BackgroundImage")));
			this.Clean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Clean.Enabled = false;
			this.Clean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Clean.Location = new System.Drawing.Point(6, 61);
			this.Clean.Name = "Clean";
			this.Clean.Size = new System.Drawing.Size(40, 40);
			this.Clean.TabIndex = 4;
			this.Clean.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Clean.UseVisualStyleBackColor = true;
			this.Clean.Click += new System.EventHandler(this.CleanClick);
			// 
			// Edit
			// 
			this.Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Edit.BackgroundImage")));
			this.Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Edit.Enabled = false;
			this.Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Edit.Location = new System.Drawing.Point(6, 16);
			this.Edit.Name = "Edit";
			this.Edit.Size = new System.Drawing.Size(40, 40);
			this.Edit.TabIndex = 3;
			this.Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Edit.UseVisualStyleBackColor = true;
			this.Edit.Click += new System.EventHandler(this.EditClick);
			// 
			// OpenANBFileDialog
			// 
			this.OpenANBFileDialog.FileName = "*.anb";
			this.OpenANBFileDialog.Filter = "Anb File|*.anb";
			// 
			// SaveButton
			// 
			this.SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.SaveButton.Enabled = false;
			this.SaveButton.Location = new System.Drawing.Point(170, 18);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(130, 37);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Save Mset...";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveClick);
			// 
			// Open_Save_group
			// 
			this.Open_Save_group.Controls.Add(this.SaveButton);
			this.Open_Save_group.Controls.Add(this.Mset_File);
			this.Open_Save_group.Location = new System.Drawing.Point(12, 9);
			this.Open_Save_group.Name = "Open_Save_group";
			this.Open_Save_group.Padding = new System.Windows.Forms.Padding(30, 5, 30, 10);
			this.Open_Save_group.Size = new System.Drawing.Size(330, 65);
			this.Open_Save_group.TabIndex = 11;
			this.Open_Save_group.TabStop = false;
			this.Open_Save_group.Text = "I/O";
			// 
			// list_group
			// 
			this.list_group.Controls.Add(this.label_orange);
			this.list_group.Controls.Add(this.panel5);
			this.list_group.Controls.Add(this.label_red);
			this.list_group.Controls.Add(this.panel4);
			this.list_group.Controls.Add(this.label_dark_gray);
			this.list_group.Controls.Add(this.panel3);
			this.list_group.Controls.Add(this.label_gray);
			this.list_group.Controls.Add(this.panel2);
			this.list_group.Controls.Add(this.label_white);
			this.list_group.Controls.Add(this.panel1);
			this.list_group.Controls.Add(this.moves_list);
			this.list_group.Location = new System.Drawing.Point(12, 80);
			this.list_group.Name = "list_group";
			this.list_group.Padding = new System.Windows.Forms.Padding(10);
			this.list_group.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.list_group.Size = new System.Drawing.Size(182, 302);
			this.list_group.TabIndex = 12;
			this.list_group.TabStop = false;
			this.list_group.Text = "BAR list";
			// 
			// label_orange
			// 
			this.label_orange.BackColor = System.Drawing.Color.Transparent;
			this.label_orange.Cursor = System.Windows.Forms.Cursors.Help;
			this.label_orange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label_orange.Location = new System.Drawing.Point(90, 261);
			this.label_orange.Name = "label_orange";
			this.label_orange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label_orange.Size = new System.Drawing.Size(155, 12);
			this.label_orange.TabIndex = 11;
			this.label_orange.Text = "Pointer Error slot";
			this.label_orange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label_orange.Click += new System.EventHandler(this.Label_orangeClick);
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.Orange;
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Location = new System.Drawing.Point(79, 262);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(10, 10);
			this.panel5.TabIndex = 10;
			// 
			// label_red
			// 
			this.label_red.BackColor = System.Drawing.Color.Transparent;
			this.label_red.Cursor = System.Windows.Forms.Cursors.Help;
			this.label_red.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label_red.Location = new System.Drawing.Point(90, 245);
			this.label_red.Name = "label_red";
			this.label_red.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label_red.Size = new System.Drawing.Size(155, 12);
			this.label_red.TabIndex = 9;
			this.label_red.Text = "Duplicating slot";
			this.label_red.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label_red.Click += new System.EventHandler(this.Label_redClick);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Red;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Location = new System.Drawing.Point(79, 246);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(10, 10);
			this.panel4.TabIndex = 8;
			// 
			// label_dark_gray
			// 
			this.label_dark_gray.BackColor = System.Drawing.Color.Transparent;
			this.label_dark_gray.Cursor = System.Windows.Forms.Cursors.Help;
			this.label_dark_gray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label_dark_gray.Location = new System.Drawing.Point(21, 280);
			this.label_dark_gray.Name = "label_dark_gray";
			this.label_dark_gray.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label_dark_gray.Size = new System.Drawing.Size(155, 12);
			this.label_dark_gray.TabIndex = 7;
			this.label_dark_gray.Text = "Second MSET";
			this.label_dark_gray.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label_dark_gray.Click += new System.EventHandler(this.Label_dark_grayClick);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Gray;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(10, 281);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(10, 10);
			this.panel3.TabIndex = 6;
			// 
			// label_gray
			// 
			this.label_gray.BackColor = System.Drawing.Color.Transparent;
			this.label_gray.Cursor = System.Windows.Forms.Cursors.Help;
			this.label_gray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label_gray.Location = new System.Drawing.Point(21, 263);
			this.label_gray.Name = "label_gray";
			this.label_gray.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label_gray.Size = new System.Drawing.Size(155, 12);
			this.label_gray.TabIndex = 5;
			this.label_gray.Text = "ANB slot";
			this.label_gray.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label_gray.Click += new System.EventHandler(this.Label_grayClick);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(10, 263);
			this.panel2.Name = "panel2";
			this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.panel2.Size = new System.Drawing.Size(10, 10);
			this.panel2.TabIndex = 4;
			// 
			// label_white
			// 
			this.label_white.BackColor = System.Drawing.Color.Transparent;
			this.label_white.Cursor = System.Windows.Forms.Cursors.Help;
			this.label_white.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label_white.Location = new System.Drawing.Point(21, 245);
			this.label_white.Name = "label_white";
			this.label_white.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label_white.Size = new System.Drawing.Size(155, 12);
			this.label_white.TabIndex = 3;
			this.label_white.Text = "Unused slot";
			this.label_white.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label_white.Click += new System.EventHandler(this.Label_whiteClick);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(10, 246);
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.panel1.Size = new System.Drawing.Size(10, 10);
			this.panel1.TabIndex = 2;
			// 
			// SaveMsetFileDialog
			// 
			this.SaveMsetFileDialog.Filter = "Mset Files|*.mset";
			// 
			// CopyBlink
			// 
			this.CopyBlink.Interval = 500;
			this.CopyBlink.Tick += new System.EventHandler(this.CopyBlinkTick);
			// 
			// SaveANBFileDialog
			// 
			this.SaveANBFileDialog.Filter = "Anb Files|*.anb";
			// 
			// EC_group
			// 
			this.EC_group.Controls.Add(this.EC_label_info);
			this.EC_group.Controls.Add(this.EC_label);
			this.EC_group.Controls.Add(this.flowLayoutPanel1);
			this.EC_group.Controls.Add(this.EC1_2_group);
			this.EC_group.Location = new System.Drawing.Point(451, 80);
			this.EC_group.Name = "EC_group";
			this.EC_group.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.EC_group.Size = new System.Drawing.Size(664, 417);
			this.EC_group.TabIndex = 13;
			this.EC_group.TabStop = false;
			this.EC_group.Text = "Effects Caster";
			// 
			// EC_label_info
			// 
			this.EC_label_info.Location = new System.Drawing.Point(329, 362);
			this.EC_label_info.Name = "EC_label_info";
			this.EC_label_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC_label_info.Size = new System.Drawing.Size(328, 47);
			this.EC_label_info.TabIndex = 18;
			this.EC_label_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EC_label
			// 
			this.EC_label.Location = new System.Drawing.Point(329, 337);
			this.EC_label.Name = "EC_label";
			this.EC_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC_label.Size = new System.Drawing.Size(328, 20);
			this.EC_label.TabIndex = 16;
			this.EC_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.EC1_00);
			this.flowLayoutPanel1.Controls.Add(this.EC1_03);
			this.flowLayoutPanel1.Controls.Add(this.EC1_0A);
			this.flowLayoutPanel1.Controls.Add(this.EC1_0B);
			this.flowLayoutPanel1.Controls.Add(this.EC1_0C);
			this.flowLayoutPanel1.Controls.Add(this.EC1_10);
			this.flowLayoutPanel1.Controls.Add(this.EC1_11);
			this.flowLayoutPanel1.Controls.Add(this.EC1_14);
			this.flowLayoutPanel1.Controls.Add(this.EC1_17);
			this.flowLayoutPanel1.Controls.Add(this.EC1_1C);
			this.flowLayoutPanel1.Controls.Add(this.EC1_1D);
			this.flowLayoutPanel1.Controls.Add(this.EC2_01);
			this.flowLayoutPanel1.Controls.Add(this.EC2_02);
			this.flowLayoutPanel1.Controls.Add(this.EC2_06);
			this.flowLayoutPanel1.Controls.Add(this.EC2_07);
			this.flowLayoutPanel1.Controls.Add(this.EC2_08);
			this.flowLayoutPanel1.Controls.Add(this.EC2_0E);
			this.flowLayoutPanel1.Controls.Add(this.EC2_13);
			this.flowLayoutPanel1.Controls.Add(this.EC2_16);
			this.flowLayoutPanel1.Controls.Add(this.EC2_17);
			this.flowLayoutPanel1.Controls.Add(this.EC2_18);
			this.flowLayoutPanel1.Controls.Add(this.EC2_1A);
			this.flowLayoutPanel1.Controls.Add(this.EC2_1B);
			this.flowLayoutPanel1.Controls.Add(this.EC2_1D);
			this.flowLayoutPanel1.Controls.Add(this.Unregistred);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(329, 19);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 315);
			this.flowLayoutPanel1.TabIndex = 17;
			// 
			// EC1_00
			// 
			this.EC1_00.BackColor = System.Drawing.Color.Transparent;
			this.EC1_00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_00.Enabled = false;
			this.EC1_00.FlatAppearance.BorderSize = 0;
			this.EC1_00.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_00.Image = ((System.Drawing.Image)(resources.GetObject("EC1_00.Image")));
			this.EC1_00.Location = new System.Drawing.Point(3, 3);
			this.EC1_00.Name = "EC1_00";
			this.EC1_00.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_00.Size = new System.Drawing.Size(57, 57);
			this.EC1_00.TabIndex = 18;
			this.EC1_00.UseVisualStyleBackColor = false;
			this.EC1_00.Click += new System.EventHandler(this.EC1_00Click);
			// 
			// EC1_03
			// 
			this.EC1_03.BackColor = System.Drawing.Color.Transparent;
			this.EC1_03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_03.Enabled = false;
			this.EC1_03.FlatAppearance.BorderSize = 0;
			this.EC1_03.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_03.Image = ((System.Drawing.Image)(resources.GetObject("EC1_03.Image")));
			this.EC1_03.Location = new System.Drawing.Point(66, 3);
			this.EC1_03.Name = "EC1_03";
			this.EC1_03.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_03.Size = new System.Drawing.Size(57, 57);
			this.EC1_03.TabIndex = 35;
			this.EC1_03.UseVisualStyleBackColor = false;
			this.EC1_03.Click += new System.EventHandler(this.EC1_03Click);
			// 
			// EC1_0A
			// 
			this.EC1_0A.BackColor = System.Drawing.Color.Transparent;
			this.EC1_0A.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_0A.Enabled = false;
			this.EC1_0A.FlatAppearance.BorderSize = 0;
			this.EC1_0A.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_0A.Image = ((System.Drawing.Image)(resources.GetObject("EC1_0A.Image")));
			this.EC1_0A.Location = new System.Drawing.Point(129, 3);
			this.EC1_0A.Name = "EC1_0A";
			this.EC1_0A.Size = new System.Drawing.Size(57, 57);
			this.EC1_0A.TabIndex = 24;
			this.EC1_0A.UseVisualStyleBackColor = false;
			this.EC1_0A.Click += new System.EventHandler(this.EC1_0AClick);
			// 
			// EC1_0B
			// 
			this.EC1_0B.BackColor = System.Drawing.Color.Transparent;
			this.EC1_0B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_0B.Enabled = false;
			this.EC1_0B.FlatAppearance.BorderSize = 0;
			this.EC1_0B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_0B.Image = ((System.Drawing.Image)(resources.GetObject("EC1_0B.Image")));
			this.EC1_0B.Location = new System.Drawing.Point(192, 3);
			this.EC1_0B.Name = "EC1_0B";
			this.EC1_0B.Size = new System.Drawing.Size(57, 57);
			this.EC1_0B.TabIndex = 37;
			this.EC1_0B.UseVisualStyleBackColor = false;
			this.EC1_0B.Click += new System.EventHandler(this.EC1_0BClick);
			// 
			// EC1_0C
			// 
			this.EC1_0C.BackColor = System.Drawing.Color.Transparent;
			this.EC1_0C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_0C.Enabled = false;
			this.EC1_0C.FlatAppearance.BorderSize = 0;
			this.EC1_0C.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_0C.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.EC1_0C.Image = ((System.Drawing.Image)(resources.GetObject("EC1_0C.Image")));
			this.EC1_0C.Location = new System.Drawing.Point(255, 3);
			this.EC1_0C.Name = "EC1_0C";
			this.EC1_0C.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_0C.Size = new System.Drawing.Size(57, 57);
			this.EC1_0C.TabIndex = 41;
			this.EC1_0C.Text = "Other";
			this.EC1_0C.UseVisualStyleBackColor = false;
			this.EC1_0C.Click += new System.EventHandler(this.EC1_0CClick);
			// 
			// EC1_10
			// 
			this.EC1_10.BackColor = System.Drawing.Color.Transparent;
			this.EC1_10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_10.Enabled = false;
			this.EC1_10.FlatAppearance.BorderSize = 0;
			this.EC1_10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.EC1_10.Image = ((System.Drawing.Image)(resources.GetObject("EC1_10.Image")));
			this.EC1_10.Location = new System.Drawing.Point(3, 66);
			this.EC1_10.Name = "EC1_10";
			this.EC1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_10.Size = new System.Drawing.Size(57, 57);
			this.EC1_10.TabIndex = 38;
			this.EC1_10.UseVisualStyleBackColor = false;
			this.EC1_10.Click += new System.EventHandler(this.EC1_10Click);
			// 
			// EC1_11
			// 
			this.EC1_11.BackColor = System.Drawing.Color.Transparent;
			this.EC1_11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_11.Enabled = false;
			this.EC1_11.FlatAppearance.BorderSize = 0;
			this.EC1_11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.EC1_11.Image = ((System.Drawing.Image)(resources.GetObject("EC1_11.Image")));
			this.EC1_11.Location = new System.Drawing.Point(66, 66);
			this.EC1_11.Name = "EC1_11";
			this.EC1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_11.Size = new System.Drawing.Size(57, 57);
			this.EC1_11.TabIndex = 39;
			this.EC1_11.UseVisualStyleBackColor = false;
			this.EC1_11.Click += new System.EventHandler(this.EC1_11Click);
			// 
			// EC1_14
			// 
			this.EC1_14.BackColor = System.Drawing.Color.Transparent;
			this.EC1_14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_14.Enabled = false;
			this.EC1_14.FlatAppearance.BorderSize = 0;
			this.EC1_14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_14.Image = ((System.Drawing.Image)(resources.GetObject("EC1_14.Image")));
			this.EC1_14.Location = new System.Drawing.Point(129, 66);
			this.EC1_14.Name = "EC1_14";
			this.EC1_14.Size = new System.Drawing.Size(57, 57);
			this.EC1_14.TabIndex = 32;
			this.EC1_14.UseVisualStyleBackColor = false;
			this.EC1_14.Click += new System.EventHandler(this.EC1_14Click);
			// 
			// EC1_17
			// 
			this.EC1_17.BackColor = System.Drawing.Color.Transparent;
			this.EC1_17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_17.Enabled = false;
			this.EC1_17.FlatAppearance.BorderSize = 0;
			this.EC1_17.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_17.Image = ((System.Drawing.Image)(resources.GetObject("EC1_17.Image")));
			this.EC1_17.Location = new System.Drawing.Point(192, 66);
			this.EC1_17.Name = "EC1_17";
			this.EC1_17.Size = new System.Drawing.Size(57, 57);
			this.EC1_17.TabIndex = 26;
			this.EC1_17.UseVisualStyleBackColor = false;
			this.EC1_17.Click += new System.EventHandler(this.EC1_17Click);
			// 
			// EC1_1C
			// 
			this.EC1_1C.BackColor = System.Drawing.Color.Transparent;
			this.EC1_1C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_1C.Enabled = false;
			this.EC1_1C.FlatAppearance.BorderSize = 0;
			this.EC1_1C.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_1C.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.EC1_1C.Image = ((System.Drawing.Image)(resources.GetObject("EC1_1C.Image")));
			this.EC1_1C.Location = new System.Drawing.Point(255, 66);
			this.EC1_1C.Name = "EC1_1C";
			this.EC1_1C.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_1C.Size = new System.Drawing.Size(57, 57);
			this.EC1_1C.TabIndex = 34;
			this.EC1_1C.UseVisualStyleBackColor = false;
			this.EC1_1C.Click += new System.EventHandler(this.EC1_1CClick);
			// 
			// EC1_1D
			// 
			this.EC1_1D.BackColor = System.Drawing.Color.Transparent;
			this.EC1_1D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC1_1D.Enabled = false;
			this.EC1_1D.FlatAppearance.BorderSize = 0;
			this.EC1_1D.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC1_1D.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.EC1_1D.Image = ((System.Drawing.Image)(resources.GetObject("EC1_1D.Image")));
			this.EC1_1D.Location = new System.Drawing.Point(3, 129);
			this.EC1_1D.Name = "EC1_1D";
			this.EC1_1D.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_1D.Size = new System.Drawing.Size(57, 57);
			this.EC1_1D.TabIndex = 40;
			this.EC1_1D.UseVisualStyleBackColor = false;
			this.EC1_1D.Click += new System.EventHandler(this.EC1_1DClick);
			// 
			// EC2_01
			// 
			this.EC2_01.BackColor = System.Drawing.Color.Transparent;
			this.EC2_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_01.Enabled = false;
			this.EC2_01.FlatAppearance.BorderSize = 0;
			this.EC2_01.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_01.Image = ((System.Drawing.Image)(resources.GetObject("EC2_01.Image")));
			this.EC2_01.Location = new System.Drawing.Point(66, 129);
			this.EC2_01.Name = "EC2_01";
			this.EC2_01.Size = new System.Drawing.Size(57, 57);
			this.EC2_01.TabIndex = 19;
			this.EC2_01.UseVisualStyleBackColor = false;
			this.EC2_01.Click += new System.EventHandler(this.EC2_01Click);
			// 
			// EC2_02
			// 
			this.EC2_02.BackColor = System.Drawing.Color.Transparent;
			this.EC2_02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_02.Enabled = false;
			this.EC2_02.FlatAppearance.BorderSize = 0;
			this.EC2_02.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_02.Image = ((System.Drawing.Image)(resources.GetObject("EC2_02.Image")));
			this.EC2_02.Location = new System.Drawing.Point(129, 129);
			this.EC2_02.Name = "EC2_02";
			this.EC2_02.Size = new System.Drawing.Size(57, 57);
			this.EC2_02.TabIndex = 20;
			this.EC2_02.UseVisualStyleBackColor = false;
			this.EC2_02.Click += new System.EventHandler(this.EC2_02Click);
			// 
			// EC2_06
			// 
			this.EC2_06.BackColor = System.Drawing.Color.Transparent;
			this.EC2_06.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_06.Enabled = false;
			this.EC2_06.FlatAppearance.BorderSize = 0;
			this.EC2_06.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_06.Image = ((System.Drawing.Image)(resources.GetObject("EC2_06.Image")));
			this.EC2_06.Location = new System.Drawing.Point(192, 129);
			this.EC2_06.Name = "EC2_06";
			this.EC2_06.Size = new System.Drawing.Size(57, 57);
			this.EC2_06.TabIndex = 21;
			this.EC2_06.UseVisualStyleBackColor = false;
			this.EC2_06.Click += new System.EventHandler(this.EC2_06Click);
			// 
			// EC2_07
			// 
			this.EC2_07.BackColor = System.Drawing.Color.Transparent;
			this.EC2_07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_07.Enabled = false;
			this.EC2_07.FlatAppearance.BorderSize = 0;
			this.EC2_07.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_07.Image = ((System.Drawing.Image)(resources.GetObject("EC2_07.Image")));
			this.EC2_07.Location = new System.Drawing.Point(255, 129);
			this.EC2_07.Name = "EC2_07";
			this.EC2_07.Size = new System.Drawing.Size(57, 57);
			this.EC2_07.TabIndex = 22;
			this.EC2_07.UseVisualStyleBackColor = false;
			this.EC2_07.Click += new System.EventHandler(this.EC2_07Click);
			// 
			// EC2_08
			// 
			this.EC2_08.BackColor = System.Drawing.Color.Transparent;
			this.EC2_08.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_08.Enabled = false;
			this.EC2_08.FlatAppearance.BorderSize = 0;
			this.EC2_08.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_08.Image = ((System.Drawing.Image)(resources.GetObject("EC2_08.Image")));
			this.EC2_08.Location = new System.Drawing.Point(3, 192);
			this.EC2_08.Name = "EC2_08";
			this.EC2_08.Size = new System.Drawing.Size(57, 57);
			this.EC2_08.TabIndex = 23;
			this.EC2_08.UseVisualStyleBackColor = false;
			this.EC2_08.Click += new System.EventHandler(this.EC2_08Click);
			// 
			// EC2_0E
			// 
			this.EC2_0E.BackColor = System.Drawing.Color.Transparent;
			this.EC2_0E.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_0E.Enabled = false;
			this.EC2_0E.FlatAppearance.BorderSize = 0;
			this.EC2_0E.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_0E.Image = ((System.Drawing.Image)(resources.GetObject("EC2_0E.Image")));
			this.EC2_0E.Location = new System.Drawing.Point(66, 192);
			this.EC2_0E.Name = "EC2_0E";
			this.EC2_0E.Size = new System.Drawing.Size(57, 57);
			this.EC2_0E.TabIndex = 25;
			this.EC2_0E.UseVisualStyleBackColor = false;
			this.EC2_0E.Click += new System.EventHandler(this.EC2_0EClick);
			// 
			// EC2_13
			// 
			this.EC2_13.BackColor = System.Drawing.Color.Transparent;
			this.EC2_13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_13.Enabled = false;
			this.EC2_13.FlatAppearance.BorderSize = 0;
			this.EC2_13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_13.Image = ((System.Drawing.Image)(resources.GetObject("EC2_13.Image")));
			this.EC2_13.Location = new System.Drawing.Point(129, 192);
			this.EC2_13.Name = "EC2_13";
			this.EC2_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC2_13.Size = new System.Drawing.Size(57, 57);
			this.EC2_13.TabIndex = 32;
			this.EC2_13.UseVisualStyleBackColor = false;
			this.EC2_13.Click += new System.EventHandler(this.EC2_13Click);
			// 
			// EC2_16
			// 
			this.EC2_16.BackColor = System.Drawing.Color.Transparent;
			this.EC2_16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_16.Enabled = false;
			this.EC2_16.FlatAppearance.BorderSize = 0;
			this.EC2_16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_16.Image = ((System.Drawing.Image)(resources.GetObject("EC2_16.Image")));
			this.EC2_16.Location = new System.Drawing.Point(192, 192);
			this.EC2_16.Name = "EC2_16";
			this.EC2_16.Size = new System.Drawing.Size(57, 57);
			this.EC2_16.TabIndex = 36;
			this.EC2_16.UseVisualStyleBackColor = false;
			this.EC2_16.Click += new System.EventHandler(this.EC2_16Click);
			// 
			// EC2_17
			// 
			this.EC2_17.BackColor = System.Drawing.Color.Transparent;
			this.EC2_17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_17.Enabled = false;
			this.EC2_17.FlatAppearance.BorderSize = 0;
			this.EC2_17.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_17.Image = ((System.Drawing.Image)(resources.GetObject("EC2_17.Image")));
			this.EC2_17.Location = new System.Drawing.Point(255, 192);
			this.EC2_17.Name = "EC2_17";
			this.EC2_17.Size = new System.Drawing.Size(57, 57);
			this.EC2_17.TabIndex = 28;
			this.EC2_17.UseVisualStyleBackColor = false;
			this.EC2_17.Click += new System.EventHandler(this.EC2_17Click);
			// 
			// EC2_18
			// 
			this.EC2_18.BackColor = System.Drawing.Color.Transparent;
			this.EC2_18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_18.Enabled = false;
			this.EC2_18.FlatAppearance.BorderSize = 0;
			this.EC2_18.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_18.Image = ((System.Drawing.Image)(resources.GetObject("EC2_18.Image")));
			this.EC2_18.Location = new System.Drawing.Point(3, 255);
			this.EC2_18.Name = "EC2_18";
			this.EC2_18.Size = new System.Drawing.Size(57, 57);
			this.EC2_18.TabIndex = 29;
			this.EC2_18.UseVisualStyleBackColor = false;
			this.EC2_18.Click += new System.EventHandler(this.EC2_18Click);
			// 
			// EC2_1A
			// 
			this.EC2_1A.BackColor = System.Drawing.Color.Transparent;
			this.EC2_1A.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_1A.Enabled = false;
			this.EC2_1A.FlatAppearance.BorderSize = 0;
			this.EC2_1A.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_1A.Image = ((System.Drawing.Image)(resources.GetObject("EC2_1A.Image")));
			this.EC2_1A.Location = new System.Drawing.Point(66, 255);
			this.EC2_1A.Name = "EC2_1A";
			this.EC2_1A.Size = new System.Drawing.Size(57, 57);
			this.EC2_1A.TabIndex = 30;
			this.EC2_1A.UseVisualStyleBackColor = false;
			this.EC2_1A.Click += new System.EventHandler(this.EC2_1AClick);
			// 
			// EC2_1B
			// 
			this.EC2_1B.BackColor = System.Drawing.Color.Transparent;
			this.EC2_1B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_1B.Enabled = false;
			this.EC2_1B.FlatAppearance.BorderSize = 0;
			this.EC2_1B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_1B.Image = ((System.Drawing.Image)(resources.GetObject("EC2_1B.Image")));
			this.EC2_1B.Location = new System.Drawing.Point(129, 255);
			this.EC2_1B.Name = "EC2_1B";
			this.EC2_1B.Size = new System.Drawing.Size(57, 57);
			this.EC2_1B.TabIndex = 31;
			this.EC2_1B.UseVisualStyleBackColor = false;
			this.EC2_1B.Click += new System.EventHandler(this.EC2_1BClick);
			// 
			// EC2_1D
			// 
			this.EC2_1D.BackColor = System.Drawing.Color.Transparent;
			this.EC2_1D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EC2_1D.Enabled = false;
			this.EC2_1D.FlatAppearance.BorderSize = 0;
			this.EC2_1D.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.EC2_1D.Image = ((System.Drawing.Image)(resources.GetObject("EC2_1D.Image")));
			this.EC2_1D.Location = new System.Drawing.Point(192, 255);
			this.EC2_1D.Name = "EC2_1D";
			this.EC2_1D.Size = new System.Drawing.Size(57, 57);
			this.EC2_1D.TabIndex = 27;
			this.EC2_1D.UseVisualStyleBackColor = false;
			this.EC2_1D.Click += new System.EventHandler(this.EC2_1DClick);
			// 
			// Unregistred
			// 
			this.Unregistred.BackColor = System.Drawing.Color.Transparent;
			this.Unregistred.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Unregistred.Enabled = false;
			this.Unregistred.FlatAppearance.BorderSize = 0;
			this.Unregistred.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.Unregistred.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Unregistred.Location = new System.Drawing.Point(255, 255);
			this.Unregistred.Name = "Unregistred";
			this.Unregistred.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Unregistred.Size = new System.Drawing.Size(57, 57);
			this.Unregistred.TabIndex = 33;
			this.Unregistred.Text = "Other";
			this.Unregistred.UseVisualStyleBackColor = false;
			this.Unregistred.Click += new System.EventHandler(this.UnregistredClick);
			// 
			// EC1_2_group
			// 
			this.EC1_2_group.Controls.Add(this.paneltime);
			this.EC1_2_group.Controls.Add(this.paneltime_ingame);
			this.EC1_2_group.Controls.Add(this.time_label_middle);
			this.EC1_2_group.Controls.Add(this.blink_preview);
			this.EC1_2_group.Controls.Add(this.time_label_curr);
			this.EC1_2_group.Controls.Add(this.time_label_end);
			this.EC1_2_group.Controls.Add(this.time_label_start);
			this.EC1_2_group.Controls.Add(this.EC_splitter);
			this.EC1_2_group.Location = new System.Drawing.Point(7, 12);
			this.EC1_2_group.Name = "EC1_2_group";
			this.EC1_2_group.Padding = new System.Windows.Forms.Padding(5);
			this.EC1_2_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_2_group.Size = new System.Drawing.Size(317, 397);
			this.EC1_2_group.TabIndex = 4;
			this.EC1_2_group.TabStop = false;
			this.EC1_2_group.Text = "EC Groups";
			// 
			// paneltime
			// 
			this.paneltime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.paneltime.Location = new System.Drawing.Point(8, 35);
			this.paneltime.Name = "paneltime";
			this.paneltime.Size = new System.Drawing.Size(300, 18);
			this.paneltime.TabIndex = 43;
			this.paneltime.TabStop = false;
			this.paneltime.Paint += new System.Windows.Forms.PaintEventHandler(this.PaneltimePaint);
			// 
			// paneltime_ingame
			// 
			this.paneltime_ingame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.paneltime_ingame.Location = new System.Drawing.Point(8, 54);
			this.paneltime_ingame.Name = "paneltime_ingame";
			this.paneltime_ingame.Size = new System.Drawing.Size(300, 6);
			this.paneltime_ingame.TabIndex = 42;
			this.paneltime_ingame.TabStop = false;
			this.paneltime_ingame.Paint += new System.Windows.Forms.PaintEventHandler(this.Paneltime_ingamePaint);
			// 
			// time_label_middle
			// 
			this.time_label_middle.Location = new System.Drawing.Point(106, 61);
			this.time_label_middle.Name = "time_label_middle";
			this.time_label_middle.Size = new System.Drawing.Size(102, 17);
			this.time_label_middle.TabIndex = 41;
			this.time_label_middle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// blink_preview
			// 
			this.blink_preview.BackColor = System.Drawing.Color.Red;
			this.blink_preview.Cursor = System.Windows.Forms.Cursors.VSplit;
			this.blink_preview.Location = new System.Drawing.Point(159, 81);
			this.blink_preview.Name = "blink_preview";
			this.blink_preview.Size = new System.Drawing.Size(2, 311);
			this.blink_preview.TabIndex = 40;
			this.blink_preview.MouseEnter += new System.EventHandler(this.Blink_previewMouseEnter);
			// 
			// time_label_curr
			// 
			this.time_label_curr.Location = new System.Drawing.Point(98, 21);
			this.time_label_curr.Name = "time_label_curr";
			this.time_label_curr.Size = new System.Drawing.Size(100, 15);
			this.time_label_curr.TabIndex = 39;
			this.time_label_curr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// time_label_end
			// 
			this.time_label_end.Location = new System.Drawing.Point(205, 61);
			this.time_label_end.Name = "time_label_end";
			this.time_label_end.Size = new System.Drawing.Size(102, 17);
			this.time_label_end.TabIndex = 38;
			this.time_label_end.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// time_label_start
			// 
			this.time_label_start.Location = new System.Drawing.Point(7, 61);
			this.time_label_start.Name = "time_label_start";
			this.time_label_start.Size = new System.Drawing.Size(102, 17);
			this.time_label_start.TabIndex = 37;
			this.time_label_start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EC_splitter
			// 
			this.EC_splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EC_splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.EC_splitter.Location = new System.Drawing.Point(5, 81);
			this.EC_splitter.Name = "EC_splitter";
			// 
			// EC_splitter.Panel1
			// 
			this.EC_splitter.Panel1.Controls.Add(this.Add_G1);
			this.EC_splitter.Panel1.Controls.Add(this.Del_G1);
			this.EC_splitter.Panel1.Controls.Add(this.G1_Flow);
			this.EC_splitter.Panel1.Controls.Add(this.EC1_list);
			this.EC_splitter.Panel1.Padding = new System.Windows.Forms.Padding(5);
			this.EC_splitter.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC_splitter.Panel1MinSize = 0;
			// 
			// EC_splitter.Panel2
			// 
			this.EC_splitter.Panel2.Controls.Add(this.Add_G2);
			this.EC_splitter.Panel2.Controls.Add(this.Del_G2);
			this.EC_splitter.Panel2.Controls.Add(this.EC2_list);
			this.EC_splitter.Panel2.Controls.Add(this.G2_flow);
			this.EC_splitter.Panel2.Padding = new System.Windows.Forms.Padding(5);
			this.EC_splitter.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC_splitter.Panel2MinSize = 0;
			this.EC_splitter.Size = new System.Drawing.Size(307, 311);
			this.EC_splitter.SplitterDistance = 153;
			this.EC_splitter.SplitterWidth = 5;
			this.EC_splitter.TabIndex = 34;
			this.EC_splitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.EC_splitterSplitterMoved);
			// 
			// Add_G1
			// 
			this.Add_G1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Add_G1.BackgroundImage")));
			this.Add_G1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Add_G1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Add_G1.Location = new System.Drawing.Point(8, 254);
			this.Add_G1.Name = "Add_G1";
			this.Add_G1.Size = new System.Drawing.Size(64, 42);
			this.Add_G1.TabIndex = 7;
			this.Add_G1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Add_G1.UseVisualStyleBackColor = true;
			this.Add_G1.Click += new System.EventHandler(this.Add_G1Click);
			// 
			// Del_G1
			// 
			this.Del_G1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Del_G1.BackgroundImage")));
			this.Del_G1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Del_G1.Location = new System.Drawing.Point(78, 254);
			this.Del_G1.Name = "Del_G1";
			this.Del_G1.Size = new System.Drawing.Size(64, 42);
			this.Del_G1.TabIndex = 15;
			this.Del_G1.UseVisualStyleBackColor = true;
			this.Del_G1.Click += new System.EventHandler(this.Del_G1Click);
			// 
			// G1_Flow
			// 
			this.G1_Flow.AutoSize = true;
			this.G1_Flow.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.G1_Flow.Location = new System.Drawing.Point(5, 304);
			this.G1_Flow.Name = "G1_Flow";
			this.G1_Flow.Size = new System.Drawing.Size(141, 0);
			this.G1_Flow.TabIndex = 9;
			// 
			// EC1_list
			// 
			this.EC1_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EC1_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.FrameSEC1,
									this.FrameEEC1,
									this.TypeEC1,
									this.IndexEC1});
			this.EC1_list.Cursor = System.Windows.Forms.Cursors.Default;
			this.EC1_list.Dock = System.Windows.Forms.DockStyle.Top;
			this.EC1_list.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.EC1_list.FullRowSelect = true;
			this.EC1_list.GridLines = true;
			this.EC1_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EC1_list.Location = new System.Drawing.Point(5, 5);
			this.EC1_list.MultiSelect = false;
			this.EC1_list.Name = "EC1_list";
			this.EC1_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC1_list.ShowGroups = false;
			this.EC1_list.Size = new System.Drawing.Size(141, 231);
			this.EC1_list.TabIndex = 7;
			this.KeysTip.SetToolTip(this.EC1_list, resources.GetString("EC1_list.ToolTip"));
			this.EC1_list.UseCompatibleStateImageBehavior = false;
			this.EC1_list.View = System.Windows.Forms.View.Details;
			this.EC1_list.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.EC_listColumnWidthChanged);
			this.EC1_list.SelectedIndexChanged += new System.EventHandler(this.EC1_listSelectedIndexChanged);
			this.EC1_list.DoubleClick += new System.EventHandler(this.EC1_listDoubleClick);
			this.EC1_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EC1_listKeyDown);
			this.EC1_list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EC1_listMouseClick);
			this.EC1_list.MouseEnter += new System.EventHandler(this.EC1_listMouseEnter);
			// 
			// FrameSEC1
			// 
			this.FrameSEC1.Text = " Start";
			this.FrameSEC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FrameSEC1.Width = 70;
			// 
			// FrameEEC1
			// 
			this.FrameEEC1.Text = "End";
			this.FrameEEC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FrameEEC1.Width = 70;
			// 
			// TypeEC1
			// 
			this.TypeEC1.Text = "Effect";
			this.TypeEC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TypeEC1.Width = 70;
			// 
			// IndexEC1
			// 
			this.IndexEC1.Text = "Value";
			this.IndexEC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.IndexEC1.Width = 70;
			// 
			// Add_G2
			// 
			this.Add_G2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Add_G2.BackgroundImage")));
			this.Add_G2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Add_G2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Add_G2.Location = new System.Drawing.Point(8, 254);
			this.Add_G2.Name = "Add_G2";
			this.Add_G2.Size = new System.Drawing.Size(62, 42);
			this.Add_G2.TabIndex = 7;
			this.Add_G2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Add_G2.UseVisualStyleBackColor = true;
			this.Add_G2.Click += new System.EventHandler(this.Add_G2Click);
			// 
			// Del_G2
			// 
			this.Del_G2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Del_G2.BackgroundImage")));
			this.Del_G2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Del_G2.Location = new System.Drawing.Point(77, 254);
			this.Del_G2.Name = "Del_G2";
			this.Del_G2.Size = new System.Drawing.Size(62, 42);
			this.Del_G2.TabIndex = 15;
			this.Del_G2.UseVisualStyleBackColor = true;
			this.Del_G2.Click += new System.EventHandler(this.Del_G2Click);
			// 
			// EC2_list
			// 
			this.EC2_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EC2_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.FrameSEC2,
									this.FrameEEC2,
									this.TypeEC2,
									this.IndexEC2});
			this.EC2_list.Cursor = System.Windows.Forms.Cursors.Default;
			this.EC2_list.Dock = System.Windows.Forms.DockStyle.Top;
			this.EC2_list.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.EC2_list.FullRowSelect = true;
			this.EC2_list.GridLines = true;
			this.EC2_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EC2_list.Location = new System.Drawing.Point(5, 5);
			this.EC2_list.MultiSelect = false;
			this.EC2_list.Name = "EC2_list";
			this.EC2_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EC2_list.ShowGroups = false;
			this.EC2_list.Size = new System.Drawing.Size(137, 231);
			this.EC2_list.TabIndex = 8;
			this.KeysTip.SetToolTip(this.EC2_list, resources.GetString("EC2_list.ToolTip"));
			this.EC2_list.UseCompatibleStateImageBehavior = false;
			this.EC2_list.View = System.Windows.Forms.View.Details;
			this.EC2_list.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.EC_listColumnWidthChanged);
			this.EC2_list.SelectedIndexChanged += new System.EventHandler(this.EC2_listSelectedIndexChanged);
			this.EC2_list.DoubleClick += new System.EventHandler(this.EC2_listDoubleClick);
			this.EC2_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EC2_listKeyDown);
			this.EC2_list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EC2_listMouseClick);
			this.EC2_list.MouseEnter += new System.EventHandler(this.EC2_listMouseEnter);
			// 
			// FrameSEC2
			// 
			this.FrameSEC2.Text = " Start";
			this.FrameSEC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FrameSEC2.Width = 70;
			// 
			// FrameEEC2
			// 
			this.FrameEEC2.Text = "End";
			this.FrameEEC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FrameEEC2.Width = 70;
			// 
			// TypeEC2
			// 
			this.TypeEC2.Text = "Effect";
			this.TypeEC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TypeEC2.Width = 70;
			// 
			// IndexEC2
			// 
			this.IndexEC2.Text = "Value";
			this.IndexEC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.IndexEC2.Width = 70;
			// 
			// G2_flow
			// 
			this.G2_flow.AutoSize = true;
			this.G2_flow.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.G2_flow.Location = new System.Drawing.Point(5, 304);
			this.G2_flow.Name = "G2_flow";
			this.G2_flow.Size = new System.Drawing.Size(137, 0);
			this.G2_flow.TabIndex = 16;
			// 
			// Debugger
			// 
			this.Debugger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Debugger.Location = new System.Drawing.Point(852, 56);
			this.Debugger.Name = "Debugger";
			this.Debugger.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Debugger.Size = new System.Drawing.Size(263, 292);
			this.Debugger.TabIndex = 19;
			this.Debugger.Visible = false;
			// 
			// GameAccess
			// 
			this.GameAccess.Interval = 1;
			this.GameAccess.Tick += new System.EventHandler(this.GameAccessTick);
			// 
			// label7_
			// 
			this.label7_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label7_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7_.Location = new System.Drawing.Point(98, 46);
			this.label7_.Name = "label7_";
			this.label7_.Size = new System.Drawing.Size(137, 23);
			this.label7_.TabIndex = 3;
			this.label7_.Text = "0";
			this.label7_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Location = new System.Drawing.Point(11, 46);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 23);
			this.label7.TabIndex = 2;
			this.label7.Text = "Length";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.Location = new System.Drawing.Point(11, 76);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(81, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "EC Name";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6_
			// 
			this.label6_.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label6_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6_.Location = new System.Drawing.Point(98, 16);
			this.label6_.Name = "label6_";
			this.label6_.Size = new System.Drawing.Size(137, 23);
			this.label6_.TabIndex = 1;
			this.label6_.Text = "0x00";
			this.label6_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.Location = new System.Drawing.Point(11, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Location";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8_
			// 
			this.label8_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8_.Enabled = false;
			this.label8_.Location = new System.Drawing.Point(98, 77);
			this.label8_.MaxLength = 4;
			this.label8_.Name = "label8_";
			this.label8_.Size = new System.Drawing.Size(137, 20);
			this.label8_.TabIndex = 15;
			this.label8_.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label8_.Enter += new System.EventHandler(this.Label8_Enter);
			this.label8_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Label8_KeyDown);
			this.label8_.Leave += new System.EventHandler(this.Label8_Leave);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label8_);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label6_);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label7_);
			this.groupBox2.Location = new System.Drawing.Point(200, 385);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(245, 111);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pointed Effects Caster Infos";
			// 
			// Split_blink
			// 
			this.Split_blink.Enabled = true;
			this.Split_blink.Interval = 1;
			this.Split_blink.Tick += new System.EventHandler(this.Split_blinkTick);
			// 
			// ListFocus
			// 
			this.ListFocus.Interval = 1;
			this.ListFocus.Tick += new System.EventHandler(this.ListFocusTick);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.EC_SaveButton);
			this.groupBox4.Controls.Add(this.EC_File);
			this.groupBox4.Location = new System.Drawing.Point(451, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(30, 5, 30, 10);
			this.groupBox4.Size = new System.Drawing.Size(330, 65);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "I/O";
			// 
			// EC_SaveButton
			// 
			this.EC_SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.EC_SaveButton.Enabled = false;
			this.EC_SaveButton.Location = new System.Drawing.Point(170, 18);
			this.EC_SaveButton.Name = "EC_SaveButton";
			this.EC_SaveButton.Size = new System.Drawing.Size(130, 37);
			this.EC_SaveButton.TabIndex = 2;
			this.EC_SaveButton.Text = "Save Effect Caster...";
			this.EC_SaveButton.UseVisualStyleBackColor = true;
			this.EC_SaveButton.Click += new System.EventHandler(this.EC_SaveButtonClick);
			// 
			// EC_File
			// 
			this.EC_File.AllowDrop = true;
			this.EC_File.Dock = System.Windows.Forms.DockStyle.Left;
			this.EC_File.Enabled = false;
			this.EC_File.Location = new System.Drawing.Point(30, 18);
			this.EC_File.Name = "EC_File";
			this.EC_File.Size = new System.Drawing.Size(130, 37);
			this.EC_File.TabIndex = 1;
			this.EC_File.Text = "Replace Effect Caster...";
			this.EC_File.UseVisualStyleBackColor = true;
			this.EC_File.Click += new System.EventHandler(this.EC_FileClick);
			this.EC_File.DragDrop += new System.Windows.Forms.DragEventHandler(this.EC_FileDragDrop);
			this.EC_File.DragOver += new System.Windows.Forms.DragEventHandler(this.EC_FileDragOver);
			// 
			// OpenECFileDialog
			// 
			this.OpenECFileDialog.FileName = "*.ec";
			this.OpenECFileDialog.Filter = "EC files|*.ec";
			// 
			// SaveECFileDialog
			// 
			this.SaveECFileDialog.Filter = "EC files|*.ec";
			// 
			// Ingame_test_checkbox
			// 
			this.Ingame_test_checkbox.Location = new System.Drawing.Point(787, 12);
			this.Ingame_test_checkbox.Name = "Ingame_test_checkbox";
			this.Ingame_test_checkbox.Size = new System.Drawing.Size(209, 18);
			this.Ingame_test_checkbox.TabIndex = 14;
			this.Ingame_test_checkbox.Text = "Test Ingame";
			this.Ingame_test_checkbox.UseVisualStyleBackColor = true;
			this.Ingame_test_checkbox.CheckedChanged += new System.EventHandler(this.Ingame_test_checkboxCheckedChanged);
			// 
			// Ingame_label
			// 
			this.Ingame_label.Location = new System.Drawing.Point(787, 65);
			this.Ingame_label.Name = "Ingame_label";
			this.Ingame_label.Size = new System.Drawing.Size(209, 18);
			this.Ingame_label.TabIndex = 15;
			this.Ingame_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AutoRefreshIndex
			// 
			this.AutoRefreshIndex.Enabled = false;
			this.AutoRefreshIndex.Location = new System.Drawing.Point(787, 30);
			this.AutoRefreshIndex.Name = "AutoRefreshIndex";
			this.AutoRefreshIndex.Size = new System.Drawing.Size(209, 18);
			this.AutoRefreshIndex.TabIndex = 16;
			this.AutoRefreshIndex.Text = "Auto refresh animation index";
			this.AutoRefreshIndex.UseVisualStyleBackColor = true;
			this.AutoRefreshIndex.CheckedChanged += new System.EventHandler(this.AutoRefreshIndexCheckedChanged);
			// 
			// Update_Focus
			// 
			this.Update_Focus.Interval = 1;
			this.Update_Focus.Tick += new System.EventHandler(this.Update_FocusTick);
			// 
			// AutoRefreshEC
			// 
			this.AutoRefreshEC.Enabled = false;
			this.AutoRefreshEC.Location = new System.Drawing.Point(787, 49);
			this.AutoRefreshEC.Name = "AutoRefreshEC";
			this.AutoRefreshEC.Size = new System.Drawing.Size(209, 18);
			this.AutoRefreshEC.TabIndex = 17;
			this.AutoRefreshEC.Text = "Auto refresh Effect Caster index";
			this.AutoRefreshEC.UseVisualStyleBackColor = true;
			this.AutoRefreshEC.CheckedChanged += new System.EventHandler(this.AutoRefreshECCheckedChanged);
			// 
			// KeysTip
			// 
			this.KeysTip.AutoPopDelay = 5000;
			this.KeysTip.InitialDelay = 1000;
			this.KeysTip.ReshowDelay = 0;
			this.KeysTip.ToolTipTitle = "Hotkeys";
			// 
			// DebugTimer
			// 
			this.DebugTimer.Enabled = true;
			this.DebugTimer.Interval = 1;
			this.DebugTimer.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.Add);
			this.groupBox5.Controls.Add(this.Delete);
			this.groupBox5.Location = new System.Drawing.Point(12, 388);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(81, 107);
			this.groupBox5.TabIndex = 18;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "BAR count";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1125, 508);
			this.Controls.Add(this.Debugger);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.AutoRefreshEC);
			this.Controls.Add(this.Ingame_label);
			this.Controls.Add(this.AutoRefreshIndex);
			this.Controls.Add(this.Ingame_test_checkbox);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.EC_group);
			this.Controls.Add(this.list_group);
			this.Controls.Add(this.Open_Save_group);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox0);
			this.MaximumSize = new System.Drawing.Size(1141, 547);
			this.MinimumSize = new System.Drawing.Size(1141, 547);
			this.Name = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Moves_listMenuStrip.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox0.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.Open_Save_group.ResumeLayout(false);
			this.list_group.ResumeLayout(false);
			this.EC_group.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.EC1_2_group.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.paneltime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paneltime_ingame)).EndInit();
			this.EC_splitter.Panel1.ResumeLayout(false);
			this.EC_splitter.Panel1.PerformLayout();
			this.EC_splitter.Panel2.ResumeLayout(false);
			this.EC_splitter.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.EC_splitter)).EndInit();
			this.EC_splitter.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);
		}
}
}
