using System;
using System.Windows.Forms;
using PacketDotNet;
using PacketDotNet.Utils;

namespace CyberShark.Utility
{
    public static class AddtoTreeView
    {
        public static bool AddTreeViewUDP(TreeView treeView1,Packet packet)
        {
            treeView1.BeginUpdate();
            bool result = false;
            var udpPacket = packet.Extract<UdpPacket>();
            var ipPacket = packet.Extract<IPPacket>();
            treeView1.Nodes.Clear();
            TreeNode node11 = new TreeNode("Destination Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).DestinationHardwareAddress));
            TreeNode node12 = new TreeNode("Source Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).SourceHardwareAddress));
            TreeNode node13 = new TreeNode("Type: " + ipPacket.Version.ToString());
            TreeNode root1 = new TreeNode("Ethernet Header", new TreeNode[] { node11, node12, node13 });

            TreeNode node21 = new TreeNode("Version: " + ipPacket.Version);
            TreeNode node22 = new TreeNode("HeaderLength: " + ipPacket.HeaderLength);
            TreeNode node23 = new TreeNode("TotalLength: " + ipPacket.TotalLength);
            TreeNode node24 = new TreeNode("Time to live: " + ipPacket.TimeToLive);
            TreeNode node25 = new TreeNode("Protocol: " + ipPacket.Protocol);
            TreeNode node26 = new TreeNode("Source IP Address: " + ipPacket.SourceAddress);
            TreeNode node27 = new TreeNode("Destination IP Address: " + ipPacket.DestinationAddress);
            TreeNode root2 = new TreeNode("IP(Internet Protocol)" + ipPacket.Version + "Header", new TreeNode[] { node21, node22, node23, node24, node25, node26, node27 });

            TreeNode node31 = new TreeNode("Source Port: " + udpPacket.SourcePort);
            TreeNode node32 = new TreeNode("Destiantion Port: " + udpPacket.DestinationPort);
            TreeNode node33 = new TreeNode("Length: " + udpPacket.Length);
            TreeNode node34 = new TreeNode("CheckSum: 0x" + udpPacket.Checksum.ToString("X2"));
            TreeNode root3 = new TreeNode("UDP (User Datagram Protocol) Header", new TreeNode[] { node31, node32, node33, node34 });
            treeView1.Nodes.AddRange(new TreeNode[] { root1, root2, root3 });
            treeView1.ExpandAll();
            treeView1.Nodes[0].EnsureVisible();
            treeView1.EndUpdate();
            result = true;
            return result;
        }

        public static bool AddTreeViewTCP(TreeView treeView1, Packet packet)
        {
            treeView1.BeginUpdate();
            bool result = false;
            var tcpPacket = packet.Extract<TcpPacket>();
            var ipPacket = packet.Extract<IPPacket>();
            treeView1.Nodes.Clear();
            TreeNode node11 = new TreeNode("Destination Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).DestinationHardwareAddress));
            TreeNode node12 = new TreeNode("Source Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).SourceHardwareAddress));
            TreeNode node13 = new TreeNode("Type: " + ipPacket.Version.ToString());
            TreeNode root1 = new TreeNode("Ethernet Header", new TreeNode[] { node11, node12, node13 });

            TreeNode node21 = new TreeNode("Version: " + ipPacket.Version);
            TreeNode node22 = new TreeNode("HeaderLength: " + ipPacket.HeaderLength);
            TreeNode node23 = new TreeNode("TotalLength: " + ipPacket.TotalLength);
            TreeNode node24 = new TreeNode("Time to live: " + ipPacket.TimeToLive);
            TreeNode node25 = new TreeNode("Protocol: " + ipPacket.Protocol);
            TreeNode node26 = new TreeNode("Source IP Address: " + ipPacket.SourceAddress);
            TreeNode node27 = new TreeNode("Destination IP Address: " + ipPacket.DestinationAddress);
            TreeNode root2 = new TreeNode("IP(Internet Protocol)" + ipPacket.Version + "Header", new TreeNode[] { node21, node22, node23, node24, node25, node26, node27 });

            TreeNode node31 = new TreeNode("Source Port: " + tcpPacket.SourcePort);
            TreeNode node32 = new TreeNode("Destiantion Port: " + tcpPacket.DestinationPort);
            TreeNode node33 = new TreeNode("Sequence Number: " + tcpPacket.SequenceNumber);
            TreeNode node34 = new TreeNode("Acknowledgment Number: " + tcpPacket.AcknowledgmentNumber);
            TreeNode node35 = new TreeNode("Flag: 0x" + tcpPacket.Flags.ToString("X2"));
            node35.Nodes.Add("CWR: " + Convert.ToInt32(tcpPacket.CongestionWindowReduced).ToString());
            node35.Nodes.Add("ECN: " + Convert.ToInt32(tcpPacket.ExplicitCongestionNotificationEcho).ToString());
            node35.Nodes.Add("URG: " + Convert.ToInt32(tcpPacket.Urgent).ToString());
            node35.Nodes.Add("ACK: " + Convert.ToInt32(tcpPacket.Acknowledgment).ToString());
            node35.Nodes.Add("PSH: " + Convert.ToInt32(tcpPacket.Push).ToString());
            node35.Nodes.Add("RST: " + Convert.ToInt32(tcpPacket.Reset).ToString());
            node35.Nodes.Add("SYN: " + Convert.ToInt32(tcpPacket.Synchronize).ToString());
            node35.Nodes.Add("FIN: " + Convert.ToInt32(tcpPacket.Finished).ToString());
            TreeNode node36 = new TreeNode("Windows Size: " + tcpPacket.WindowSize);
            TreeNode node37 = new TreeNode("CheckSum: 0x" + tcpPacket.Checksum.ToString("X4"));
            TreeNode root3 = new TreeNode("TCP (Transmission Control Protocol) Header", new TreeNode[] { node31, node32, node33, node34, node35, node36, node37 });

            treeView1.Nodes.AddRange(new TreeNode[] { root1, root2, root3 });
            treeView1.ExpandAll();
            treeView1.Nodes[0].EnsureVisible();
            treeView1.EndUpdate();
            result = true;
            return result;
        }

        public static bool AddTreeViewICMPv4(TreeView treeView1, Packet packet)
        {
            treeView1.BeginUpdate();
            bool result = false;
            var ipPacket = packet.Extract<IPPacket>();
            var icmpPacket = packet.Extract<IcmpV4Packet>();
            treeView1.Nodes.Clear();
            TreeNode node11 = new TreeNode("Destination Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).DestinationHardwareAddress));
            TreeNode node12 = new TreeNode("Source Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).SourceHardwareAddress));
            TreeNode node13 = new TreeNode("Type: " + ipPacket.Version.ToString());
            TreeNode root1 = new TreeNode("Ethernet Header", new TreeNode[] { node11, node12, node13 });

            TreeNode node21 = new TreeNode("Version: " + ipPacket.Version);
            TreeNode node22 = new TreeNode("HeaderLength: " + ipPacket.HeaderLength);
            TreeNode node23 = new TreeNode("TotalLength: " + ipPacket.TotalLength);
            TreeNode node24 = new TreeNode("Time to live: " + ipPacket.TimeToLive);
            TreeNode node25 = new TreeNode("Protocol: " + ipPacket.Protocol);
            TreeNode node26 = new TreeNode("Source IP Address: " + ipPacket.SourceAddress);
            TreeNode node27 = new TreeNode("Destination IP Address: " + ipPacket.DestinationAddress);
            TreeNode root2 = new TreeNode("IP(Internet Protocol)" + ipPacket.Version + "Header", new TreeNode[] { node21, node22, node23, node24, node25, node26, node27 });

            TreeNode node31 = new TreeNode("Type: " + icmpPacket.TypeCode);
            //TreeNode node32 = new TreeNode("Code: " + icmpPacket.);
            TreeNode node33 = new TreeNode("CheckSum: 0x" + icmpPacket.Checksum.ToString("X2"));
            TreeNode node34 = new TreeNode("Identifer: " + icmpPacket.Id.ToString("X4"));
            TreeNode node35 = new TreeNode("Sequence Number: " + icmpPacket.Sequence);
            TreeNode root3 = new TreeNode("ICMP (Internet Control Message Protoco) v4", new TreeNode[] { node31, node33, node34, node35 });
            treeView1.Nodes.AddRange(new TreeNode[] { root1, root2, root3 });
            treeView1.ExpandAll();
            treeView1.Nodes[0].EnsureVisible();
            treeView1.EndUpdate();
            result = true;
            return result;
        }

        public static bool AddTreeViewICMPv6(TreeView treeView1, Packet packet)
        {
            treeView1.BeginUpdate();
            bool result = false;
            var ipPacket = packet.Extract<IPPacket>();
            var icmpPacket = packet.Extract<IcmpV6Packet>();
            treeView1.Nodes.Clear();
            TreeNode node11 = new TreeNode("Destination Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).DestinationHardwareAddress));
            TreeNode node12 = new TreeNode("Source Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).SourceHardwareAddress));
            TreeNode node13 = new TreeNode("Type: " + ipPacket.Version.ToString());
            TreeNode root1 = new TreeNode("Ethernet Header", new TreeNode[] { node11, node12, node13 });

            TreeNode node21 = new TreeNode("Version: " + ipPacket.Version);
            TreeNode node22 = new TreeNode("HeaderLength: " + ipPacket.HeaderLength);
            TreeNode node23 = new TreeNode("TotalLength: " + ipPacket.TotalLength);
            TreeNode node24 = new TreeNode("Time to live: " + ipPacket.TimeToLive);
            TreeNode node25 = new TreeNode("Protocol: " + ipPacket.Protocol);
            TreeNode node26 = new TreeNode("Source IP Address: " + ipPacket.SourceAddress);
            TreeNode node27 = new TreeNode("Destination IP Address: " + ipPacket.DestinationAddress);
            TreeNode root2 = new TreeNode("IP(Internet Protocol)" + ipPacket.Version + "Header", new TreeNode[] { node21, node22, node23, node24, node25, node26, node27 });

            TreeNode node31 = new TreeNode("Type: " + icmpPacket.Type);
            TreeNode node32 = new TreeNode("Code: " + icmpPacket.Code);
            TreeNode node33 = new TreeNode("CheckSum: 0x" + icmpPacket.Checksum.ToString("X2"));
            TreeNode root3 = new TreeNode("ICMP (Internet Control Message Protoco) v6", new TreeNode[] { node31, node32, node33 });

            treeView1.Nodes.AddRange(new TreeNode[] { root1, root2, root3 });
            treeView1.ExpandAll();
            treeView1.Nodes[0].EnsureVisible();
            treeView1.EndUpdate();
            result = true;
            return result;
        }

        public static bool AddTreeViewARP(TreeView treeView1, Packet packet)
        {
            treeView1.BeginUpdate();
            bool result = false;
            var arpPacket = packet.Extract<ArpPacket>();
            treeView1.Nodes.Clear();
            TreeNode node11 = new TreeNode("Destination Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).DestinationHardwareAddress));
            TreeNode node12 = new TreeNode("Source Address: " + HexPrinter.PrintMACAddress(((EthernetPacket)packet).SourceHardwareAddress));
            TreeNode node13 = new TreeNode("Type: ARP");
            TreeNode root1 = new TreeNode("Ethernet Header", new TreeNode[] { node11, node12, node13 });  

            TreeNode node31 = new TreeNode("Hardware Type: " + arpPacket.HardwareAddressType);
            TreeNode node32 = new TreeNode("Protocol Type: " + arpPacket.ProtocolAddressType);
            TreeNode node33 = new TreeNode("Hardware Size: " + arpPacket.HardwareAddressLength);
            TreeNode node34 = new TreeNode("Protocol Size: " + arpPacket.ProtocolAddressLength);
            TreeNode node35 = new TreeNode("Opcode: " + arpPacket.Operation);
            TreeNode node36 = new TreeNode("Sender MAC Address: " + HexPrinter.PrintMACAddress(arpPacket.SenderHardwareAddress));
            TreeNode node37 = new TreeNode("Sender IP Address: " + arpPacket.SenderProtocolAddress);
            TreeNode node38 = new TreeNode("Target MAC Address: " + HexPrinter.PrintMACAddress(arpPacket.TargetHardwareAddress));
            TreeNode node39 = new TreeNode("Sender IP Address: " + arpPacket.TargetProtocolAddress);
            TreeNode root3 = new TreeNode("Address Resolution Protocol", new TreeNode[] { node31, node32, node33, node34, node35, node36, node37, node38, node39 });

            treeView1.Nodes.AddRange(new TreeNode[] { root1, root3 });
            treeView1.ExpandAll();
            treeView1.Nodes[0].EnsureVisible();
            treeView1.EndUpdate();
            result = true;
            return result;
        }
    }
}
