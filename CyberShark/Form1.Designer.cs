
using System.Reflection;

namespace CyberShark
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bytePerSecondBBSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetPerSecondPPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturefiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnStartCapturin = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnStopCap = new System.Windows.Forms.ToolStripButton();
            this.toolStripCaptureOpt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripbtnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnReloadFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripbtnPreviusPacket = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnNextPacket = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnFirstPacket = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnLastPacket = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripTbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripBtnFillter = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListViewEx();
            this.Number = new System.Windows.Forms.ColumnHeader();
            this.Time = new System.Windows.Forms.ColumnHeader();
            this.Source = new System.Windows.Forms.ColumnHeader();
            this.Destination = new System.Windows.Forms.ColumnHeader();
            this.Protocal = new System.Windows.Forms.ColumnHeader();
            this.Length = new System.Windows.Forms.ColumnHeader();
            this.Info = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hTTPStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.hexbox1 = new Be.Windows.Forms.HexBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.goToolStripMenuItem,
            this.captureToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(995, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.toolStripbtnOpenFile_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.toolStripbtnSaveFile_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // goToolStripMenuItem
            // 
            this.goToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bytePerSecondBBSToolStripMenuItem,
            this.packetPerSecondPPSToolStripMenuItem});
            this.goToolStripMenuItem.Name = "goToolStripMenuItem";
            this.goToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.goToolStripMenuItem.Text = "Statistics";
            // 
            // bytePerSecondBBSToolStripMenuItem
            // 
            this.bytePerSecondBBSToolStripMenuItem.Name = "bytePerSecondBBSToolStripMenuItem";
            this.bytePerSecondBBSToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.bytePerSecondBBSToolStripMenuItem.Text = "Byte Per Second (BPS)";
            this.bytePerSecondBBSToolStripMenuItem.Click += new System.EventHandler(this.bytePerSecondBBSToolStripMenuItem_Click);
            // 
            // packetPerSecondPPSToolStripMenuItem
            // 
            this.packetPerSecondPPSToolStripMenuItem.Name = "packetPerSecondPPSToolStripMenuItem";
            this.packetPerSecondPPSToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.packetPerSecondPPSToolStripMenuItem.Text = "Packet Per Second (PPS)";
            this.packetPerSecondPPSToolStripMenuItem.Click += new System.EventHandler(this.packetPerSecondPPSToolStripMenuItem_Click);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.capturefiToolStripMenuItem});
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.captureToolStripMenuItem.Text = "Capture";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.toolStripBtnStartCapturin_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.restartToolStripMenuItem.Text = "Restart";
            // 
            // capturefiToolStripMenuItem
            // 
            this.capturefiToolStripMenuItem.Name = "capturefiToolStripMenuItem";
            this.capturefiToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.capturefiToolStripMenuItem.Text = "Capture Filters";
            this.capturefiToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnStartCapturin,
            this.toolStripbtnStopCap,
            this.toolStripCaptureOpt,
            this.toolStripSeparator1,
            this.toolStripbtnOpenFile,
            this.toolStripbtnSaveFile,
            this.toolStripButton7,
            this.toolStripbtnReloadFile,
            this.toolStripSeparator2,
            this.toolStripbtnPreviusPacket,
            this.toolStripbtnNextPacket,
            this.toolStripBtnFirstPacket,
            this.toolStripbtnLastPacket});
            this.toolStrip1.Location = new System.Drawing.Point(3, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(995, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnStartCapturin
            // 
            this.toolStripBtnStartCapturin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnStartCapturin.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnStartCapturin.Image")));
            this.toolStripBtnStartCapturin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnStartCapturin.Name = "toolStripBtnStartCapturin";
            this.toolStripBtnStartCapturin.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnStartCapturin.Text = "Start capturing packets";
            this.toolStripBtnStartCapturin.Click += new System.EventHandler(this.toolStripBtnStartCapturin_Click);
            // 
            // toolStripbtnStopCap
            // 
            this.toolStripbtnStopCap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnStopCap.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnStopCap.Image")));
            this.toolStripbtnStopCap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnStopCap.Name = "toolStripbtnStopCap";
            this.toolStripbtnStopCap.Size = new System.Drawing.Size(29, 24);
            this.toolStripbtnStopCap.Text = "Stop capturing packets";
            this.toolStripbtnStopCap.ToolTipText = "Stop capturing packets";
            this.toolStripbtnStopCap.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripCaptureOpt
            // 
            this.toolStripCaptureOpt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCaptureOpt.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCaptureOpt.Image")));
            this.toolStripCaptureOpt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCaptureOpt.Name = "toolStripCaptureOpt";
            this.toolStripCaptureOpt.Size = new System.Drawing.Size(29, 24);
            this.toolStripCaptureOpt.Text = "Capture options";
            this.toolStripCaptureOpt.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripbtnOpenFile
            // 
            this.toolStripbtnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnOpenFile.Image")));
            this.toolStripbtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnOpenFile.Name = "toolStripbtnOpenFile";
            this.toolStripbtnOpenFile.Size = new System.Drawing.Size(29, 24);
            this.toolStripbtnOpenFile.Text = "Open a capture file";
            this.toolStripbtnOpenFile.Click += new System.EventHandler(this.toolStripbtnOpenFile_Click);
            // 
            // toolStripbtnSaveFile
            // 
            this.toolStripbtnSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnSaveFile.Image")));
            this.toolStripbtnSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnSaveFile.Name = "toolStripbtnSaveFile";
            this.toolStripbtnSaveFile.Size = new System.Drawing.Size(29, 24);
            this.toolStripbtnSaveFile.Text = "Save this capture file";
            this.toolStripbtnSaveFile.Click += new System.EventHandler(this.toolStripbtnSaveFile_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton7.Text = "Close this capture file";
            // 
            // toolStripbtnReloadFile
            // 
            this.toolStripbtnReloadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnReloadFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnReloadFile.Image")));
            this.toolStripbtnReloadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnReloadFile.Name = "toolStripbtnReloadFile";
            this.toolStripbtnReloadFile.Size = new System.Drawing.Size(29, 24);
            this.toolStripbtnReloadFile.Text = "Close this file";
            this.toolStripbtnReloadFile.Click += new System.EventHandler(this.toolStripbtnReloadFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripbtnPreviusPacket
            // 
            this.toolStripbtnPreviusPacket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnPreviusPacket.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnPreviusPacket.Image")));
            this.toolStripbtnPreviusPacket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnPreviusPacket.Name = "toolStripbtnPreviusPacket";
            this.toolStripbtnPreviusPacket.Size = new System.Drawing.Size(29, 24);
            this.toolStripbtnPreviusPacket.Text = "Go to the previous packet";
            this.toolStripbtnPreviusPacket.Click += new System.EventHandler(this.toolStripbtnPreviusPacket_Click);
            // 
            // toolStripbtnNextPacket
            // 
            this.toolStripbtnNextPacket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnNextPacket.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnNextPacket.Image")));
            this.toolStripbtnNextPacket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnNextPacket.Name = "toolStripbtnNextPacket";
            this.toolStripbtnNextPacket.Size = new System.Drawing.Size(29, 24);
            this.toolStripbtnNextPacket.Text = "Go to the next packet";
            this.toolStripbtnNextPacket.Click += new System.EventHandler(this.toolStripbtnNextPacket_Click);
            // 
            // toolStripBtnFirstPacket
            // 
            this.toolStripBtnFirstPacket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFirstPacket.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFirstPacket.Image")));
            this.toolStripBtnFirstPacket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFirstPacket.Name = "toolStripBtnFirstPacket";
            this.toolStripBtnFirstPacket.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnFirstPacket.Text = "Go to the first packet";
            this.toolStripBtnFirstPacket.Click += new System.EventHandler(this.toolStripBtnFirstPacket_Click);
            // 
            // toolStripbtnLastPacket
            // 
            this.toolStripbtnLastPacket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnLastPacket.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnLastPacket.Image")));
            this.toolStripbtnLastPacket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnLastPacket.Name = "toolStripbtnLastPacket";
            this.toolStripbtnLastPacket.Size = new System.Drawing.Size(29, 24);
            this.toolStripbtnLastPacket.Text = "Go to the last packet";
            this.toolStripbtnLastPacket.Click += new System.EventHandler(this.toolStripbtnLastPacket_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripTbFilter,
            this.toolStripBtnFillter});
            this.toolStrip2.Location = new System.Drawing.Point(3, 55);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(995, 34);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 31);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripTbFilter
            // 
            this.toolStripTbFilter.AutoSize = false;
            this.toolStripTbFilter.AutoToolTip = true;
            this.toolStripTbFilter.Name = "toolStripTbFilter";
            this.toolStripTbFilter.Size = new System.Drawing.Size(800, 27);
            // 
            // toolStripBtnFillter
            // 
            this.toolStripBtnFillter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnFillter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFillter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFillter.Image")));
            this.toolStripBtnFillter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFillter.Name = "toolStripBtnFillter";
            this.toolStripBtnFillter.Size = new System.Drawing.Size(29, 31);
            this.toolStripBtnFillter.Text = "toolStripButton13";
            this.toolStripBtnFillter.Click += new System.EventHandler(this.toolStripBtnFillter_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 89);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.hexbox1);
            this.splitContainer2.Size = new System.Drawing.Size(995, 937);
            this.splitContainer2.SplitterDistance = 611;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 17;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(995, 611);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 17;
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.Time,
            this.Source,
            this.Destination,
            this.Protocal,
            this.Length,
            this.Info});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(993, 297);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Number
            // 
            this.Number.Text = "No.";
            this.Number.Width = 70;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 120;
            // 
            // Source
            // 
            this.Source.Text = "Source";
            this.Source.Width = 150;
            // 
            // Destination
            // 
            this.Destination.Text = "Destination";
            this.Destination.Width = 150;
            // 
            // Protocal
            // 
            this.Protocal.Text = "Protocal";
            this.Protocal.Width = 100;
            // 
            // Length
            // 
            this.Length.Text = "Length";
            this.Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Length.Width = 100;
            // 
            // Info
            // 
            this.Info.Text = "Info";
            this.Info.Width = 309;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hTTPStreamToolStripMenuItem,
            this.tCPStreamToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 52);
            // 
            // hTTPStreamToolStripMenuItem
            // 
            this.hTTPStreamToolStripMenuItem.Name = "hTTPStreamToolStripMenuItem";
            this.hTTPStreamToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.hTTPStreamToolStripMenuItem.Text = "HTTP Stream";
            this.hTTPStreamToolStripMenuItem.Click += new System.EventHandler(this.hTTPStreamToolStripMenuItem_Click);
            // 
            // tCPStreamToolStripMenuItem
            // 
            this.tCPStreamToolStripMenuItem.Name = "tCPStreamToolStripMenuItem";
            this.tCPStreamToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.tCPStreamToolStripMenuItem.Text = "TCP Stream";
            this.tCPStreamToolStripMenuItem.Click += new System.EventHandler(this.tCPStreamToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(993, 305);
            this.treeView1.TabIndex = 16;
            // 
            // hexbox1
            // 
            this.hexbox1.ColumnInfoVisible = true;
            this.hexbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexbox1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hexbox1.LineInfoVisible = true;
            this.hexbox1.Location = new System.Drawing.Point(0, 0);
            this.hexbox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hexbox1.Name = "hexbox1";
            this.hexbox1.ReadOnly = true;
            this.hexbox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexbox1.Size = new System.Drawing.Size(993, 319);
            this.hexbox1.StringViewVisible = true;
            this.hexbox1.TabIndex = 2;
            this.hexbox1.UseFixedBytesPerLine = true;
            this.hexbox1.VScrollBarVisible = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(4, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(738, 160);
            this.textBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 1028);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.Text = "CyberShark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturefiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnStartCapturin;
        private System.Windows.Forms.ToolStripButton toolStripbtnStopCap;
        private System.Windows.Forms.ToolStripButton toolStripCaptureOpt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripbtnOpenFile;
        private System.Windows.Forms.ToolStripButton toolStripbtnSaveFile;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripbtnReloadFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripbtnPreviusPacket;
        private System.Windows.Forms.ToolStripButton toolStripbtnNextPacket;
        private System.Windows.Forms.ToolStripButton toolStripBtnFirstPacket;
        private System.Windows.Forms.ToolStripButton toolStripbtnLastPacket;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripTextBox toolStripTbFilter;
        private System.Windows.Forms.ToolStripButton toolStripBtnFillter;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Source;
        private System.Windows.Forms.ColumnHeader Destination;
        private System.Windows.Forms.ColumnHeader Protocal;
        private System.Windows.Forms.ColumnHeader Length;
        private System.Windows.Forms.ColumnHeader Info;
        private System.Windows.Forms.TreeView treeView1;
        //private System.ComponentModel.Design.ByteViewer byteView;
        private System.Windows.Forms.TextBox textBox1;
        private Be.Windows.Forms.HexBox hexbox1;
        private System.Windows.Forms.ListViewEx listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hTTPStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bytePerSecondBBSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packetPerSecondPPSToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

