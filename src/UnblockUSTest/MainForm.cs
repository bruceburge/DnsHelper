using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnblockUSTest.WindowsFormsApplication_CS;

namespace UnblockUSTest
{
    public partial class MainForm : Form
    {
        private NetflixForm _netflixForm;

        /// <summary>
        /// The currently selected Network interface card
        /// </summary>
        public string CurrentNic { get { return btnSelectedNic.Text; } set { btnSelectedNic.Text = value; } }

        public MainForm()
        {
            InitializeComponent();

            // Discover the current nic, just naively select the first one 
            // (this will not work on systems with multiple enabled NIC's)
            CurrentNic = NetworkManagement.GetAllNicDescriptions().FirstOrDefault();

            // Update the DNS values to the currently applied ones
            var dnsServers = RefreshDNSValues();
            SetDnsTextBoxValues(dnsServers != null && dnsServers.Length > 0 ? dnsServers[0] : string.Empty,
                                dnsServers != null && dnsServers.Length > 1 ? dnsServers[1] : string.Empty);
        }

        private string[] RefreshDNSValues()
        {
            var dnsServers = NetworkManagement.GetNameservers(CurrentNic);
            UpdateCurrentDNSLabelValues(dnsServers);
            return dnsServers;
        }

        private void primarySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDnsTextBoxValues("208.122.23.23", "208.122.23.22");
        }

        private void secondarySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDnsTextBoxValues("64.145.73.5", "209.107.219.5");
        }

        private void SetDnsTextBoxValues(string dns01, string dns02)
        {
            tbDns01.Text = dns01;
            tbDns02.Text = dns02;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDNSValues();
        }

        private void UpdateCurrentDNSLabelValues( string[] dnsServers)
        {
            // First reset them
            lblDns01Current.Text = lblDns02Current.Text = "(Auto)";
            if (dnsServers != null)
            {
                if(dnsServers.Length > 0 && !dnsServers[0].EndsWith("1.1"))
                    lblDns01Current.Text = dnsServers[0];
                if (dnsServers.Length > 1 && !dnsServers[1].EndsWith("1.1"))
                    lblDns02Current.Text = dnsServers[1];
            }
        }

        private void btnClearDns_Click(object sender, EventArgs e)
        {
            UpdateCurrentDNSLabelValues(new[] { "(Waiting)", "(Waiting)"});
            NetworkManagement.SetNameservers(CurrentNic, null, restart: true);
            RefreshDNSValues();
        }

        private void btnApplyDns_Click(object sender, EventArgs e)
        {
            string dns01 = tbDns01.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(dns01) && !IsValidIPv4(dns01))
            {
                MessageBox.Show(this, "DNS 1 is not a valid IPv4 address", "Invalid IPv4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dns02 = tbDns02.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(dns02) && !IsValidIPv4(dns02))
            {
                MessageBox.Show(this, "DNS 2 is not a valid IPv4 address", "Invalid IPv4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateCurrentDNSLabelValues(new[] { "(Waiting)", "(Waiting)" });
            NetworkManagement.SetNameservers(CurrentNic, new []{dns01, dns02}, restart: true);
            RefreshDNSValues();
        }

        public static bool IsValidIPv4(string value)
        {
            // First check to see if there are at least three periods in the value
            if (value.Count(x => x == '.') != 3)
                return false;

            IPAddress address;
            return IPAddress.TryParse(value, out address) && address.AddressFamily == AddressFamily.InterNetwork;
        }

        private void btnGoToWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.unblock-us.com/");
        }

        private void btnNetflixSettings_Click(object sender, EventArgs e)
        {
            if(_netflixForm == null || _netflixForm.IsDisposed)
                this._netflixForm = new NetflixForm();

            if( !this._netflixForm.Visible )
                this._netflixForm.Show(this);

            this._netflixForm.BringToFront();
        }

        private void btnSelectedNic_Click(object sender, EventArgs e)
        {
            // Open the network connections window
            Process.Start("ncpa.cpl");
        }
    }
}
