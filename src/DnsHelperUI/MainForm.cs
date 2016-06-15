using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using DnsHelperUI.WindowsFormsApplication_CS;
using Newtonsoft.Json;

namespace DnsHelperUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The currently selected Network interface card
        /// </summary>
        public string CurrentNic { get { return btnSelectedNic.Text; } set { btnSelectedNic.Text = value; } }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Append the version number to the form title
            var version = typeof(MainForm).Assembly.GetName().Version;
            if (version != null)
                this.Text += $" | v{version}";

            // Load the DNS server config from the file
            ReloadContextMenuItems();

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
            tbDns01.Text = tbDns02.Text = "";
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

        private void btnSelectedNic_Click(object sender, EventArgs e)
        {
            // Open the network connections window
            Process.Start("ncpa.cpl");
        }

        private void btnChooseDns_Click(object sender, EventArgs e)
        {
            // Invoke the context menu on left mouse as well as right, needs a work-around due to bugs with the menu
            // not disappearing propertly when clicked outside of it, caching the method invocation first
            this.ctxMenuChooseDns.Show(btnChooseDns, 10, 10);
        }

        private void ctxMenuItemEditJSON_Click(object sender, EventArgs e)
        {
            EditJSONFile();
        }

        private void EditJSONFile()
        {
            //Process.Start(new ProcessStartInfo("dns.json") { Verb = "edit" });
            Process.Start("notepad", "dns.json");
        }

        private void ctxMenuItemReloadJSON_Click(object sender, EventArgs e)
        {
            ReloadContextMenuItems();
        }

        private void ReloadContextMenuItems()
        {
            try
            {
                var json = LoadJsonData("dns.json");
                if (json == null)
                    return;

                // Remove stuff from the context menu
                ctxMenuChooseDns.Items.Clear();
                
                foreach (var entry in json)
                {
                    ctxMenuChooseDns.Items.Add(CreateSubMenu(entry));
                }

                // Add the fixed items at the end
                ctxMenuChooseDns.Items.Add(ctxMenuItemSeparatorForReload);
                ctxMenuChooseDns.Items.Add(ctxMenuItemAdvanced);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                MessageBox.Show(this, "Error loading DNS information from dns.json: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ToolStripMenuItem CreateSubMenu(DnsProvider entry)
        {
            var sub = new ToolStripMenuItem(entry.Title);
            foreach (var server in entry.Servers)
            {
                var item = new ToolStripMenuItem(server.Title){ Tag = new Tuple<string, DnsServers>(entry.IpUpdateUrl, server) };
                item.Click += (sender, args) =>
                {
                    var data = ((ToolStripMenuItem)sender)?.Tag as Tuple<string, DnsServers>;
                    if (data != null)
                    {
                        SetDnsTextBoxValues(data.Item2.Dns1, data.Item2.Dns2);
                        // If there is a url specified in the string tuple item then it is a dns update url
                        // which should be visited right now

                    }
                };
                sub.DropDownItems.Add(item);
            }

            if (!string.IsNullOrWhiteSpace(entry.Website) && Uri.IsWellFormedUriString(entry.Website, UriKind.Absolute))
            { 
                // Add separator
                sub.DropDownItems.Add(new ToolStripSeparator());

                // Add website if available
                var web = new ToolStripMenuItem("Website") { Tag = entry.Website };
                web.Click += (sender, args) =>
                {
                    var data = ((ToolStripMenuItem)sender)?.Tag as string;
                    if (data != null)
                        Process.Start(data);  // TODO: Defensive coding around non URLs!!!!
                };
                sub.DropDownItems.Add(web);
            }

            return sub;
        }

        private List<DnsProvider> LoadJsonData(string jsonFilePath)
        {
            try
            {
                using (var sr = new StreamReader(jsonFilePath))
                {
                    return JsonConvert.DeserializeObject<List<DnsProvider>>(sr.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return null;
            }
        }

        
    }
}
