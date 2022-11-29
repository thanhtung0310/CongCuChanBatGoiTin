using SharpPcap.LibPcap;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CyberShark
{
    public partial class Interface : Form
    {
        List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
        public List<string> AvailiableDevicesNames => CaptureDeviceList.Instance
                                                     .Select(d => (PcapDevice)d)
                                                     .Select(d => d.Interface.FriendlyName)
                                                     .Where(d => d != null)
                                                     .ToList();
        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            //LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;
            var dev = CaptureDeviceList.Instance;


            foreach (LibPcapLiveDevice device in dev)
            {
                if (!device.Interface.Addresses.Exists(a => a != null && a.Addr != null && a.Addr.ipAddress != null)) continue;
                var devInterface = device.Interface;
                var friendlyName = devInterface.FriendlyName ?? "Unknown interface...";
                var description = devInterface.Description;

                interfaceList.Add(device);
                mInterfaceCombo.Items.Add(friendlyName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mInterfaceCombo.SelectedIndex >= 0 && mInterfaceCombo.SelectedIndex < interfaceList.Count)
            {
                Form1 openMainForm = new Form1(interfaceList, mInterfaceCombo.SelectedIndex);
                this.Hide();
                openMainForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
