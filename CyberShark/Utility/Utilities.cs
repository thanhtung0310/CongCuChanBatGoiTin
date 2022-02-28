using SharpPcap;
using SharpPcap.LibPcap;

namespace CyberShark.Utility
{
    public enum FileType
    {
        Pcap,
        PcapNG
    }
    public class Utilities
    {
        public FileType GetFileType(string filePath)
        {
            if (IsPcapFile(filePath))
            {
                return FileType.Pcap;
            }
            else
            {
                return FileType.PcapNG;
            }
        }

        //need install Haukcode.PcapngUtils
        public bool IsPcapFile(string filename)
        {
            //using (var reader = IReaderFactory.GetReader(filename))
            //{
            //    return reader.GetType() != typeof(Haukcode.PcapngUtils.PcapNG.PcapNGReader);
            //}
            return true;
        }

        private void ReadPcapNGFile(string filepath)
        {
            //using (var reader = IReaderFactory.GetReader(filepath))
            //{
            //    reader.OnReadPacketEvent += ConvertPacket;
            //    reader.ReadPackets(new CancellationToken());
            //}
        }

        private void ReadPcapFile(string filepath)
        {
            // Get an offline device, handle packets registering for the Packet 
            // Arrival event and start capturing from that file.
            // NOTE: the capture function is blocking.
            ICaptureDevice device = new CaptureFileReaderDevice(filepath);
            //device.OnPacketArrival += new PacketArrivalEventHandler(ProcessPcapPacket);
            device.Open();
            device.Capture();
        }
    }
}
