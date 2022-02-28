using PacketDotNet;
using PacketDotNet.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TCPSessions;

namespace CyberShark.Utility
{
    public class ParsePacket
    {
        //public delegate void UdpSessionArrivedEventHandler(object sender, UdpSessionArrivedEventArgs e);
        //public event UdpSessionArrivedEventHandler UdpSessionArrived;
        public delegate void TcpSessionArivedEventHandler(object sender, TcpSessionArivedEventArgs e);
        public event TcpSessionArivedEventHandler TcpSessionArrived;

        //private UdpStreamBuilder _udpStreamBuilder;
        private TcpSessionsBuilder _tcpSessionsBuilder;
        public ParsePacket()
        {
            _tcpSessionsBuilder = new TcpSessionsBuilder();
            _tcpSessionsBuilder.IsLiveCapture = true;
            //_udpStreamBuilder = new UdpStreamBuilder();
        }
        public ListViewItem parsePacket(Packet p, string time_str)
        {
            string source = "";
            string destination = "";
            string protocol = "";
            var len = p.BytesSegment.Length.ToString();
            string info = "";
            Color colorProtocol = Color.White;
            if (p.PayloadPacket is ArpPacket)
            {
                var arpPacket = p.Extract<ArpPacket>();
                source = HexPrinter.PrintMACAddress(arpPacket.SenderHardwareAddress);
                destination = HexPrinter.PrintMACAddress(arpPacket.TargetHardwareAddress);
                try
                {
                    if (Int32.Parse(arpPacket.TargetHardwareAddress.ToString()) == 0)
                    {
                        destination = "Broadcast";
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                var srIP = (arpPacket.SenderProtocolAddress as System.Net.IPAddress).ToString();
                var desIP = (arpPacket.TargetProtocolAddress as System.Net.IPAddress).ToString();
                if (arpPacket.Operation is ArpOperation.Request)
                {
                    info = "(" + arpPacket.Operation.ToString() + ") Who has " + desIP + " ? Tell " + srIP;
                }
                else if (arpPacket.Operation is ArpOperation.Response)
                {
                    info = srIP + " is at " + source;
                }
                protocol = "ARP";
                colorProtocol = Color.SpringGreen;
            }
            else if (p.PayloadPacket is IPPacket)
            {
                var Packet = p.Extract<IPPacket>();
                System.Net.IPAddress srcIp = Packet.SourceAddress;
                System.Net.IPAddress dstIp = Packet.DestinationAddress;
                var protocol_type = Packet.Protocol.ToString();
                source = srcIp.ToString();
                destination = dstIp.ToString();
                var protocolPacket = Packet.PayloadPacket;
                protocol = protocol_type.ToUpper();
                if (protocol_type.ToUpper() == "UDP")
                {
                    var udpPacket = protocolPacket.Extract<UdpPacket>();
                    info = udpPacket.ToString(StringOutputType.Normal);
                    colorProtocol = Color.Wheat;

                    //this._udpStreamBuilder.HandlePacket(udpPacket);
                }
                else if (protocol_type.ToUpper() == "TCP")
                {
                    var tcpPacket = p.Extract<TcpPacket>();
                    info = tcpPacket.ToString(StringOutputType.Normal);
                    colorProtocol = Color.PaleTurquoise;

                    this._tcpSessionsBuilder.HandlePacket(tcpPacket);
                    _tcpSessionsBuilder.completedSessions.AsParallel().ForAll((session) =>
                    {
                        TcpSessionArrived?.Invoke(this, new TcpSessionArivedEventArgs()
                        {
                            TcpSession = session
                        });
                        _tcpSessionsBuilder.completedSessions.Remove(session);
                    });
                }
                else if (protocol_type.ToUpper() == "ICMP")
                {
                    var icmp4Packet = protocolPacket.Extract<IcmpV4Packet>();
                    info = icmp4Packet.TypeCode.ToString() + "\t,  id=0x" + icmp4Packet.Id.ToString("X4") + ",\t  seq=" + icmp4Packet.Sequence.ToString() + ",\t  ttl=" + Packet.TimeToLive.ToString();
                    colorProtocol = Color.LightPink;
                }
                else if (protocol_type.ToUpper() == "ICMPV6")
                {
                    var icmp6Packet = protocolPacket.Extract<IcmpV6Packet>();
                    info = icmp6Packet.Type.ToString();
                    colorProtocol = Color.LightPink;
                }
                else if (protocol_type.ToUpper() == "IGMP")
                {
                    var igmpPacket = protocolPacket.Extract<IgmpV2Packet>();
                    info = igmpPacket.Type.ToString();
                    colorProtocol = Color.AliceBlue;
                }
            }
            ListViewItem item = new ListViewItem("0");
            item.SubItems.Add(time_str);
            item.SubItems.Add(source);
            item.SubItems.Add(destination);
            item.SubItems.Add(protocol);
            item.SubItems.Add(len);
            item.SubItems.Add(info);
            item.BackColor = colorProtocol;
            return item;
        }
        public TcpSession GetTcpStream(TcpPacket tcpPacket)
        {
            var ippacket = tcpPacket.ParentPacket.Extract<IPPacket>();
            foreach (var session in this._tcpSessionsBuilder.Sessions)
            {
                bool b = (ippacket.SourceAddress.ToString() == session.SourceIp &&
                    ippacket.DestinationAddress.ToString() == session.DestinationIp &&
                    tcpPacket.SourcePort == session.SourcePort &&
                    tcpPacket.DestinationPort == session.DestinationPort) ||
                    (ippacket.SourceAddress.ToString() == session.DestinationIp &&
                    ippacket.DestinationAddress.ToString() == session.SourceIp &&
                    tcpPacket.SourcePort == session.DestinationPort &&
                    tcpPacket.DestinationPort == session.SourcePort);
                if (b)
                {
                    return session;
                }
            }
            return null;
        }
        //public void test()
        //{
        //    foreach(var s in _udpStreamBuilder.Sessions)
        //    {
        //        foreach(var p in s.Packets)
        //        {
        //            System.Diagnostics.Debug.WriteLine(p.Data.ToString());
        //        }
        //    }
        //}
    }
}
