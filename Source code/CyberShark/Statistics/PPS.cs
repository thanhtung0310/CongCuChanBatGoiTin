using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.Statistics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CyberShark
{
    public partial class PPS : Form
    {
        List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
        StatisticsDevice device;
        public PPS()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (combo_interface.SelectedIndex >= 0 && combo_interface.SelectedIndex < interfaceList.Count)
            {
                var devices = LibPcapLiveDeviceList.Instance;
                device = new StatisticsDevice(devices[combo_interface.SelectedIndex].Interface);
                device.OnPcapStatistics += device_OnPcapStatistics;
                device.Open();
                device.Filter = "tcp";
                if (System.Environment.OSVersion.Platform != PlatformID.Win32NT)
                {
                    MessageBox.Show("Your platform is unsupported for this example as it relies on npcap specific functionality only present in Windows.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                device.StartCapture();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            device.StopCapture();
            MessageBox.Show(device.Statistics.ToString(), "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PPS_Load(object sender, EventArgs e)
        {
            var devices = LibPcapLiveDeviceList.Instance;
            foreach (var device in devices)
            {
                var devInterface = device.Interface;
                var description = devInterface.Description;

                interfaceList.Add(device);
                combo_interface.Items.Add(description);
            }
        }
        static ulong oldSec = 0;
        static ulong oldUsec = 0;
        static ulong count = 0;
        /// <summary>
        /// Gets a pcap stat object and calculate bps and pps
        /// </summary>
        private void device_OnPcapStatistics(object sender, StatisticsEventArgs e)
        {
            ulong delay = (e.Timeval.Seconds - oldSec) * 1000000 - oldUsec + e.Timeval.MicroSeconds;
            ulong bps = ((ulong)e.ReceivedBytes * 8 * 1000000) / delay;
            ulong pps = ((ulong)e.ReceivedPackets * 1000000) / delay;
            var ts = e.Timeval.Date.ToLongTimeString();
            ListViewItem listViewItem = new ListViewItem(count.ToString());
            listViewItem.SubItems.Add(ts);
            listViewItem.SubItems.Add(pps.ToString());
            if (listView1.InvokeRequired)
            {
                listView1.Invoke((MethodInvoker)delegate ()
                {
                    listView1.Items.Add(listViewItem);
                });
            }

            //store current timestamp
            oldSec = e.Timeval.Seconds;
            oldUsec = e.Timeval.MicroSeconds;
            count++;
        }

    }
}
