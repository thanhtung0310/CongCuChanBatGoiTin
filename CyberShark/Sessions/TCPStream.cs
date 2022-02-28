using PacketDotNet;
using PacketDotNet.Connections;
using PacketDotNet.Connections.Http;
using PacketDotNet.Utils;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CyberShark
{
    public partial class TCPStream : Form
    {
        public TCPStream(TCPSessions.TcpSession session,bool isTCP)
        {
            InitializeComponent();
            foreach(var p in session.Packets)
            {
                StringBuilder sb = new StringBuilder();
                if (isTCP)
                {
                    foreach (var b in p.Data)
                    {
                        sb.Append(ToChar(b));
                    }
                }
                else
                {
                    sb.Append(System.Text.Encoding.ASCII.GetString(p.Data));
                }
                
                SetSessionData(
                    this.richTextBox1,
                    sb.ToString(),
                    p.SourceIp == session.SourceIp ? Color.Red : Color.Blue);

                richTextBox1.SelectionStart = 0;
                richTextBox1.Focus();
            }
        }
        public TCPStream()
        {
            InitializeComponent();
        }

        public void SetSessionData(RichTextBox richTextBox, string text, Color color)
        { 
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionColor = color;
            richTextBox.AppendText(text);
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.SelectionColor = richTextBox.ForeColor;
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

        public virtual char ToChar(byte b)
        {
            return b > 0x1F && !(b > 0x7E && b < 0xA0) ? (char)b : '.';
        }
    }
}
