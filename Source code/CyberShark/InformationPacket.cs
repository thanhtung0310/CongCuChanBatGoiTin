using Be.Windows.Forms;
using PacketDotNet;
using System;
using System.Windows.Forms;

namespace CyberShark
{
    public partial class InformationPacket : Form
    {
        string Type;
        Packet P;
        public InformationPacket(Packet p, string type)
        {
            InitializeComponent();  
            this.Type = type;
            this.P = p;
        }

        private void InformationPacket_Load(object sender, EventArgs e)
        {
            if (Type == "ARP")
            {
                var p1 = P.Extract<EthernetPacket>();
                var Packet = P.Extract<ArpPacket>();
                richTextBox1.Text = p1.ToString(StringOutputType.VerboseColored) + Packet.ToString(StringOutputType.VerboseColored);
                //richTextBox1.Text = richTextBox1.Text + Packet.ToString(StringOutputType.VerboseColored);
                hexbox1.ByteProvider = new DynamicByteProvider(Packet.Bytes);
            }else
            {
                var Packet = P.Extract<IPPacket>();
                richTextBox1.Text = Packet.ToString(StringOutputType.VerboseColored);
                hexbox1.ByteProvider = new DynamicByteProvider(Packet.Bytes);
            }

        }
    }
}
