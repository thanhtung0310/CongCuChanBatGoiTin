using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Be.Windows.Forms;
using CyberShark.Utility;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CyberShark
{
    public partial class Form1 : Form
    {
        LibPcapLiveDevice selectedDevice;
        Task capturing;
        private ParsePacket _parsePacket;
        Dictionary<int, RawCapture> capturedPackets_list1 = new Dictionary<int, RawCapture>();
        int packetNumber;
        CaptureFileWriterDevice captureFileWriter;
        ICaptureDevice readDevice;
        bool isReadFile = false;
        string messErr;
        private object QueueLock;
        private CancellationTokenSource cts;
        public Form1(List<LibPcapLiveDevice> interfaces, int selectedIndex)
        {
            InitializeComponent();
            _parsePacket = new ParsePacket();
            selectedDevice = interfaces[selectedIndex];
            toolStripCaptureOpt.Enabled = false;
            packetNumber = 1;
            cts = new CancellationTokenSource();
            QueueLock = new object();
        }
        public void FreeResource()
        {
            capturedPackets_list1.Clear();
            packetNumber = 1;
            _parsePacket = new ParsePacket();
            this.listView1.Items.Clear();
            //capturing.Dispose();
            //QueueLock = new object();
        }

        #region ToolStripMenuItem

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            if (selectedDevice.Opened)
            {
                selectedDevice.OnPacketArrival -= new PacketArrivalEventHandler(device_OnPacketArrival);
                if(selectedDevice.Started)
                    selectedDevice.StopCapture();
                selectedDevice.Close();
            }
            Application.Exit();
        }

        private void bytePerSecondBBSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BPS bPS = new BPS();
            bPS.Show();
        }

        private void packetPerSecondPPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            PPS pPS = new PPS();
            pPS.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Interface openInterfaceForm = new Interface();
            this.Hide();
            openInterfaceForm.Show();
        }

        //button stop capturing
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            selectedDevice.OnPacketArrival -= new PacketArrivalEventHandler(device_OnPacketArrival);
            selectedDevice.StopCapture();
            cts.Cancel();
            //capturing.ConfigureAwait(false);
            toolStripBtnStartCapturin.Enabled = true;
            toolStripbtnStopCap.Enabled = false;
        }

        private void toolStripBtnFirstPacket_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
                listView1.EnsureVisible(0);
            }
        }

        private void toolStripbtnLastPacket_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.Items.Count > 0)
            {
                listView1.Items[listView1.Items.Count - 1].Selected = true;
                listView1.EnsureVisible(listView1.Items.Count - 1);
            }
        }

        private void toolStripbtnPreviusPacket_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedIndices[0] > 0)
            {
                listView1.Items[listView1.SelectedIndices[0] - 1].Selected = true;
                listView1.EnsureVisible(listView1.SelectedIndices[0]);
            }
        }

        private void toolStripbtnNextPacket_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedIndices[0] < (listView1.Items.Count - 1))
            {
                listView1.Items[listView1.SelectedIndices[0] + 1].Selected = true;
                listView1.EnsureVisible(listView1.SelectedIndices[0]);
            }
        }

        #endregion

        #region Event

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            toolStripTbFilter.Width = toolStrip2.Width - toolStripDropDownButton1.Width - toolStripBtnFillter.Width - 3;

        }

        #endregion

        #region capture-parse packet
        private void toolStripBtnStartCapturin_Click(object sender, EventArgs e)
        {
            checkSaveFile(sender, e);
            FreeResource();
            selectedDevice.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
            int readTimeoutMilliseconds = 1000;
            selectedDevice.Open(DeviceModes.Promiscuous, readTimeoutMilliseconds);
            if (selectedDevice.Opened)
            {
                if (toolStripTbFilter.Text != "")
                {
                    if (PcapDevice.CheckFilter(toolStripTbFilter.Text, out messErr))
                    {
                        selectedDevice.Filter = toolStripTbFilter.Text;
                    }
                    else
                    {
                        MessageBox.Show(messErr);
                    }
                }
                selectedDevice.StartCapture();
            }
            isReadFile = false;
            toolStripBtnStartCapturin.Enabled = false;
            toolStripbtnStopCap.Enabled = true;
            cts.Dispose();
            cts = new CancellationTokenSource();
            var ct = cts.Token;
            capturing = new Task(()=>proccess_packet(ct));
            capturing.Start();
        }

        private void device_OnPacketArrival(object sender, PacketCapture e)
        {
            var rawPacket = e.GetPacket();
            var time = rawPacket.Timeval.Date;
            var time_str = (time.Hour + 1) + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
            var p = rawPacket.GetPacket();
            lock (QueueLock)
            {
                capturedPackets_list1.Add(packetNumber, rawPacket);
                packetNumber++;
            }
        }

        private void proccess_packet(CancellationToken cancellationToken)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            int _count = 1;
            while (true)
            {
                lock (QueueLock)
                {
                    if (_count < capturedPackets_list1.Count + 1)
                    {
                        RawCapture rawPacket;
                        bool b = capturedPackets_list1.TryGetValue(_count, out rawPacket);
                        var time = rawPacket.Timeval.Date;
                        var time_str = (time.Hour + 1) + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
                        var p = rawPacket.GetPacket();
                        ListViewItem item = _parsePacket.parsePacket(p, time_str);
                        if (item != null)
                        {
                            item.SubItems[0].Text = _count.ToString();
                            AddtoListView1(item);
                        }
                        _count++;
                    }
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }
                }
            }
        }

        private void AddtoListView1(ListViewItem item)
        {
            //item.SubItems[0].Text = packetNumber.ToString();
            listView1.Invoke((MethodInvoker)delegate {
                listView1.BeginUpdate();
                listView1.Items.Add(item);
                listView1.EndUpdate();
            });
        }

        #endregion

        #region view information packet
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.SubItems[4].Text == "UDP")
            {
                hTTPStreamToolStripMenuItem.Enabled = false;
                tCPStreamToolStripMenuItem.Enabled = false;
            }
            else if(e.Item.SubItems[4].Text == "TCP")
            {
                hTTPStreamToolStripMenuItem.Enabled = true;
                tCPStreamToolStripMenuItem.Enabled = true;
            }
            else
            {
                hTTPStreamToolStripMenuItem.Enabled = false;
                tCPStreamToolStripMenuItem.Enabled = false;
            }
            
            int key = Int32.Parse(e.Item.SubItems[0].Text);
            RawCapture rawPacket;
            bool b = capturedPackets_list1.TryGetValue(key, out rawPacket);
            if (!b)
                return;
            var packet = rawPacket.GetPacket();
            var ipPacket = packet.Extract<IPPacket>();
            string type = e.Item.SubItems[4].Text;
            if (type == "UDP")
            {
                AddtoTreeView.AddTreeViewUDP(this.treeView1, packet);
            }
            else if(type == "TCP")
            {
                AddtoTreeView.AddTreeViewTCP(this.treeView1, packet);
            }
            else if (type == "ICMP" )
            {
                AddtoTreeView.AddTreeViewICMPv4(this.treeView1, packet);
            }
            else if (type == "ICMPV6")
            {
                AddtoTreeView.AddTreeViewICMPv6(this.treeView1, packet);
            }
            else if(type == "ARP")
            {
                AddtoTreeView.AddTreeViewARP(this.treeView1, packet);
            }

            hexbox1.ByteProvider = new DynamicByteProvider(packet.Bytes);

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int key = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                string type = listView1.SelectedItems[0].SubItems[4].Text;
                RawCapture rawPacket;
                bool b = capturedPackets_list1.TryGetValue(key, out rawPacket);
                if (!b)
                    return;
                var packet = rawPacket.GetPacket();
                InformationPacket infoForm = new InformationPacket(packet,type);
                infoForm.ShowDialog();
            }

        }

        #endregion

        #region stream
        private void hTTPStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 1)
            {
                int key = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                RawCapture rawPacket;
                bool b = capturedPackets_list1.TryGetValue(key, out rawPacket);
                var p = rawPacket.GetPacket();
                var tcpPacket = p.Extract<TcpPacket>();
                if (tcpPacket != null)
                {
                    HTTPStream fmHttpStream = new HTTPStream(key, capturedPackets_list1);
                    fmHttpStream.Show();
                    //var session = _parsePacket.GetTcpStream(tcpPacket);
                    //TCPStream tcpSteamForm = new TCPStream(session, false);
                    //tcpSteamForm.Show();
                }
            }
            
        }

        private void tCPStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int key = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                RawCapture rawPacket;
                bool b = capturedPackets_list1.TryGetValue(key, out rawPacket);
                var p = rawPacket.GetPacket();
                var tcpPacket = p.Extract<TcpPacket>();
                if (tcpPacket != null)
                {
                    var session = _parsePacket.GetTcpStream(tcpPacket);
                    TCPStream tcpSteamForm = new TCPStream(session,true);
                    tcpSteamForm.Show();
                }
            }
        }

        #endregion

        #region Open&Save File

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                captureFileWriter = new CaptureFileWriterDevice(path + "\\cybershark.pcap");
                captureFileWriter.Open();
                foreach (var rawCapture in capturedPackets_list1)
                {
                    captureFileWriter.Write(rawCapture.Value);
                }
            }
            catch(IOException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw ex;
            }
            finally
            {
                captureFileWriter?.Close();
            }
        }

        private void toolStripbtnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = false;
            saveFileDialog1.Filter = "Pcap files (*.pcap)|*.pcap|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                try
                {
                    captureFileWriter = new CaptureFileWriterDevice(saveFileDialog1.FileName);
                    captureFileWriter.Open();
                    foreach (var rawCapture in capturedPackets_list1)
                    {
                        captureFileWriter.Write(rawCapture.Value);
                    }
                }
                finally
                {
                    captureFileWriter?.Close();
                }
            }
        }

        private void toolStripbtnOpenFile_Click(object sender, EventArgs e)
        {
            Stream st;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((st = openFileDialog1.OpenFile()) != null)
                {
                    checkSaveFile(sender, e);
                    if (selectedDevice.Started)
                    {
                        this.toolStripButton2_Click(sender, e);
                        this.saveToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        cts.Cancel();
                    }
                    FreeResource();
                    isReadFile = true;
                    using (readDevice = new CaptureFileReaderDevice(openFileDialog1.FileName))
                    {
                        readDevice.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
                        readDevice.Open();
                        readDevice.Capture();
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                        var ct = cts.Token;
                        capturing = new Task(() => proccess_packet(ct));
                        capturing.Start();
                    }
                }
            }
        }
        private void checkSaveFile(object sender, EventArgs e)
        {
            if (selectedDevice.Opened || capturedPackets_list1.Count > 0 && readDevice != null)
            {
                DialogResult result = MessageBox.Show("Do you want to save the captured packets before starting a new capture?",
                                                        "Unsaved packets...",
                                                        MessageBoxButtons.YesNoCancel,
                                                        MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    this.toolStripbtnSaveFile_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
        }
        #endregion

        private void toolStripbtnReloadFile_Click(object sender, EventArgs e)
        {
            //_parsePacket.test();
        }

        private void uDPStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_parsePacket.test();
        }

        private void toolStripBtnFillter_Click(object sender, EventArgs e)
        {
            if (PcapDevice.CheckFilter(toolStripTbFilter.Text, out messErr))
            {
                if (selectedDevice.Started || isReadFile)
                {
                    DialogResult result = MessageBox.Show("Do you want to stop capturing packets before apply filter?",
                                                            "Stop capturing",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.toolStripButton2_Click(sender, e);
                        this.saveToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    cts.Cancel();
                }
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\cybershark.pcap";
                FreeResource();
                isReadFile = false;
                using (readDevice = new CaptureFileReaderDevice(path))
                {
                    readDevice.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
                    readDevice.Open();
                    readDevice.Filter = toolStripTbFilter.Text;
                    readDevice.Capture();
                    cts.Dispose();
                    cts = new CancellationTokenSource();
                    var ct = cts.Token;
                    capturing = new Task(() => proccess_packet(ct));
                    capturing.Start();
                }
            }
            else
            {
                MessageBox.Show(messErr);
            }
            return;
        }

        private void toolStripbtnRestartCap_Click(object sender, EventArgs e)
        {

        }
    }
}
