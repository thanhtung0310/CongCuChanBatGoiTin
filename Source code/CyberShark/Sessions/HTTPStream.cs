using PacketDotNet;
using PacketDotNet.Connections;
using PacketDotNet.Connections.Http;
using SharpPcap;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace CyberShark
{
    public partial class HTTPStream : Form
    {
        private static HTTPStream frmReference;
        private static TcpConnectionManager tcpConnectionManager = new TcpConnectionManager();
        public Dictionary<int, RawCapture> capturedPackets_list1 = new Dictionary<int, RawCapture>();
        int key = 0;
        //public Dictionary<int, TcpPacket> tcpPacketStream = new Dictionary<int, TcpPacket>();

        public HTTPStream(int key, Dictionary<int,RawCapture> rawPacket_list)
        {
            InitializeComponent();
            frmReference = this;
            tcpConnectionManager.OnConnectionFound += HandleTcpConnectionManagerOnConnectionFound;
            this.capturedPackets_list1 = rawPacket_list;
            this.key = key;
            GetListTcpPacketStream();
            richTextBox1.SelectionStart = 0;
            richTextBox1.Focus();

        }
        public HTTPStream()
        {
            InitializeComponent();
        }
        
        public void GetListTcpPacketStream()
        {
            RawCapture rawPacket;
            bool b = capturedPackets_list1.TryGetValue(key, out rawPacket);
            if (b)
            {
                var tcpPacket = rawPacket.GetPacket().Extract<TcpPacket>();
                RawCapture tempPacket;
                bool b1;
                int index = 1;
                do
                {
                    b1 = capturedPackets_list1.TryGetValue(index, out tempPacket);
                    if (b1)
                    {
                        var time = tempPacket.Timeval;
                        var tcpPacket1 = tempPacket.GetPacket().Extract<TcpPacket>();
                        if (tcpPacket1 != null)
                        {
                            //tcpConnectionManager.ProcessPacket(time, tcpPacket1);
                            if (Equal(tcpPacket, tcpPacket1))
                            {
                                tcpConnectionManager.ProcessPacket(time, tcpPacket1);
                            }
                        }
                        index++;
                    }
                } while (b1);   

            }
        }

        static void HandleTcpConnectionManagerOnConnectionFound(TcpConnection c)
        {
            var httpSessionWatcher = new HttpSessionWatcher(c,
                                                            OnHttpRequestFound,
                                                            OnHttpStatusFound,
                                                            OnHttpWatcherError);
            frmReference.richTextBox1.SelectionStart = 0;
        }

        public static void OnHttpRequestFound(HttpSessionWatcherRequestEventArgs e)
        {
            frmReference.richTextBox1.SelectionStart = frmReference.richTextBox1.TextLength;
            frmReference.richTextBox1.SelectionLength = 0;
            frmReference.richTextBox1.SelectionColor = Color.Red;
            if ((e.Request.ContentEncoding == HttpMessage.ContentEncodings.Deflate) ||
               (e.Request.ContentEncoding == HttpMessage.ContentEncodings.Gzip))
            {
                frmReference.richTextBox1.AppendText(e.Request.ToString());
            }
            else
            {
                frmReference.richTextBox1.AppendText(e.Request.ToString());
            }
            //frmReference.richTextBox1.SelectionLength = e.Request.ToString().Length;
            frmReference.richTextBox1.SelectionColor = frmReference.richTextBox1.ForeColor;

        }

        private static void OnHttpStatusFound(HttpSessionWatcherStatusEventArgs e)
        {
            frmReference.richTextBox1.SelectionStart = frmReference.richTextBox1.TextLength;
            frmReference.richTextBox1.SelectionLength = 0;
            frmReference.richTextBox1.SelectionColor = Color.Blue;
            if ((e.Status.ContentEncoding == HttpMessage.ContentEncodings.Deflate) ||
               (e.Status.ContentEncoding == HttpMessage.ContentEncodings.Gzip))
            {
                frmReference.richTextBox1.AppendText(e.Status.ToString());
            }
            else
            {
                frmReference.richTextBox1.AppendText(e.Status.ToString());
            }
            frmReference.richTextBox1.SelectionColor = frmReference.richTextBox1.ForeColor;
        }

        private static void OnHttpWatcherError(string errorString)
        {
            System.Diagnostics.Debug.WriteLine("errorString " + errorString);
        }


        private bool Equal(TcpPacket packet1,TcpPacket packet2 )
        {
            if (packet1 == null || packet2 == null) 
            {
                return false;
            }

            var ippacket1 = packet1.ParentPacket.Extract<IPPacket>();
            var ippacket2 = packet2.ParentPacket.Extract<IPPacket>();

            return (ippacket1.SourceAddress.ToString() == ippacket2.SourceAddress.ToString() &&
            ippacket1.DestinationAddress.ToString() == ippacket2.DestinationAddress.ToString() &&
            packet1.SourcePort.ToString() == packet2.SourcePort.ToString() &&
            packet1.DestinationPort.ToString() == packet2.DestinationPort.ToString()) ||
            (ippacket1.SourceAddress.ToString() == ippacket2.DestinationAddress.ToString() &&
            ippacket1.DestinationAddress.ToString() == ippacket2.SourceAddress.ToString() &&
            packet1.SourcePort.ToString() == packet2.DestinationPort.ToString() &&
            packet1.DestinationPort.ToString() == packet2.SourcePort.ToString());
        }

        private void HTTPStream_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmReference.Dispose();
            //tcpConnectionManager.OnConnectionFound -= HandleTcpConnectionManagerOnConnectionFound;
            //tcpConnectionManager = null;
            //capturedPackets_list1.Clear();
        }
    }
}
