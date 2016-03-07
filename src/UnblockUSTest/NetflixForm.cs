using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnblockUSTest.Properties;

namespace UnblockUSTest
{
    public partial class NetflixForm : Form
    {
        private static class ResourceStream
        {
            public static Bitmap GetImage(string name)
            {
                var stream = Assembly.GetEntryAssembly().GetManifestResourceStream($"UnblockUSTest.img.{name}");
                return stream == null ? null : new Bitmap(stream);
            }

            public static Bitmap GetFlag(string countryCode)
            {
                var stream = Assembly.GetEntryAssembly().GetManifestResourceStream($"UnblockUSTest.img.flags.{countryCode}.png");
                return stream == null ? null : new Bitmap(stream);
            }
        }

        #region Country Codes

        private class CountryCode
        {
            public string Code { get; private set; }
            public string Name { get; private set; }
            public string FlagCode { get; private set; }

            public CountryCode(string code, string name)
            {
                Code = code;
                FlagCode = code;
                Name = name;
            }

            public CountryCode(string code, string flagCode, string name)
            {
                Code = code;
                FlagCode = flagCode;
                Name = name;
            }
        }

        private static readonly CountryCode[] CountryCodes = new CountryCode[]
        {
            new CountryCode("us", "USA"),
            new CountryCode("ar", "Argentina"),
            new CountryCode("au", "Australia"),
            new CountryCode("at", "Austria"),
            new CountryCode("be", "Belgium"),
            new CountryCode("br", "Brazil"),
            new CountryCode("ca", "Canada"),
            new CountryCode("co", "Columbia"),
            new CountryCode("dk", "Denmark"),
            new CountryCode("fi", "Finland"),
            new CountryCode("fr", "France"),
            new CountryCode("de", "Germany"),
            new CountryCode("in", "India"),
            new CountryCode("ie", "Ireland"),
            new CountryCode("it", "Italy"),
            new CountryCode("jp", "Japan"),
            new CountryCode("lu", "Luxembourg"),
            new CountryCode("mx", "Mexico"),
            new CountryCode("nl", "Netherlands"),
            new CountryCode("nz", "New Zealand"),
            new CountryCode("no", "Norway"),
            new CountryCode("pt", "Portugal"),
            new CountryCode("sa", "Saudi Arabia"),
            new CountryCode("es", "Spain"),
            new CountryCode("se", "Sweden"),
            new CountryCode("ch", "Switzerland"),
            new CountryCode("uk", "gb", "UK")
        };

        #endregion
        
        private NetflixStatusChecker _netflixStatusChecker;
        private Bitmap _imageOK = ResourceStream.GetImage("ok-16.png");
        private Bitmap _imageError = ResourceStream.GetImage("error-16.png");


        public NetflixForm()
        {
            InitializeComponent();
        }

        private void NetflixForm_Load(object sender, EventArgs e)
        {
            // Populate the combobox
            cmbNetflixRegionPicker.Items.Clear();
            cmbNetflixRegionPicker.Items.AddRange(CountryCodes);
            cmbNetflixRegionPicker.ValueMember = "Code";
            cmbNetflixRegionPicker.DisplayMember = "Name";

            // Populate the username
            tbUsername.Text = Settings.Default.UnblockUsUsername;
        }

        private void btnVerifyUsername_Click(object sender, EventArgs e)
        {
            var userName = tbUsername.Text?.Trim();

            if (string.IsNullOrWhiteSpace(userName))
                return;

            Settings.Default.UnblockUsUsername = userName;
            Settings.Default.Save();

            ResetForm();
            this._netflixStatusChecker = new NetflixStatusChecker(userName);
            this._netflixStatusChecker.NetflixStatus += _netflixStatusChecker_NetflixStatus;
            this._netflixStatusChecker.UnblockUsStatus += _netflixStatusChecker_UnblockUsStatus;
            this._netflixStatusChecker.Initialize();
        }

        private void _netflixStatusChecker_UnblockUsStatus(object sender, UnblockUsEventArgs e)
        {
            var lines = new List<string>();
            lines.Add(e.Action + " (" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")");
            lines.AddRange(new[]
                {
                    "CountryCode: "+e.CountryCode,
                    "DnsActive: "+e.DnsActive,
                    "New IP: "+e.Config?.ip_changed
                });
            lines.Add("--------------");

            foreach (var line in lines)
                tbUnblockLog.AppendText(line + Environment.NewLine);

            // Select the right country in the dropdown if it has changed
            cmbNetflixRegionPicker.SelectedItem = CountryCodes.FirstOrDefault(x => x.Code.Equals(e.CountryCode, StringComparison.OrdinalIgnoreCase));

            var selectedCountry = cmbNetflixRegionPicker.SelectedItem as CountryCode;
            if (selectedCountry == null || e.Config == null )
                return;

            btnVerifyUsername.Image = tbUsername.Text.Equals(e.Config.email, StringComparison.OrdinalIgnoreCase) ? _imageOK : _imageError;
            btnUnblockActive.Image = e.DnsActive ? _imageOK : _imageError;
            btnUnblockCountry.Image = selectedCountry.Code.Equals(e.CountryCode, StringComparison.OrdinalIgnoreCase) ? _imageOK : _imageError;
        }

        private void _netflixStatusChecker_NetflixStatus(object sender, NetflixEventArgs e)
        {
            var lines = new List<string>();
            lines.Add(e.Action + " ("+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+")");
            lines.AddRange(new[]
                {
                    "CountryCode: "+e.CountryCode,
                    "GeoLocation: "+e.GeoLocationCountry,
                });
            lines.Add("--------------");

            foreach (var line in lines)
                tbNetflixLog.AppendText(line + Environment.NewLine);

            var selectedCountry = cmbNetflixRegionPicker.SelectedItem as CountryCode;
            if (selectedCountry == null || e.Config == null)
                return;

            btnNetflixCountry.Image = selectedCountry.Code.Equals(e.CountryCode, StringComparison.OrdinalIgnoreCase) ?
                                        _imageOK : _imageError;
            btnNetflixGeoLocation.Image = selectedCountry.Code.Equals(e.GeoLocationCountry, StringComparison.OrdinalIgnoreCase) ?
                                        _imageOK : _imageError;
        }

        private void ResetForm()
        {
            tbNetflixLog.ResetText();
            tbUnblockLog.ResetText();

            cmbNetflixRegionPicker.ResetText();
            picNetflixRegionPicker.Image = null;

            btnVerifyUsername.Image = ResourceStream.GetImage("unknown-16.png");
            
            ResetStatusImages();
        }

        private void ResetStatusImages( )
        {
            Bitmap image = ResourceStream.GetImage("unknown-16.png");
            btnNetflixCountry.Image = image;
            btnNetflixGeoLocation.Image = image;
            btnUnblockCountry.Image = image;
            btnUnblockActive.Image = image;
        }
       

        private void cmbNetflixRegionPicker_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedCountry = cmbNetflixRegionPicker.SelectedItem as CountryCode;

            picNetflixRegionPicker.Image = selectedCountry == null? null : ResourceStream.GetFlag(selectedCountry.FlagCode);
        }

        private void btnRegionAssign_Click(object sender, EventArgs e)
        {
            var selectedCountry = cmbNetflixRegionPicker.SelectedItem as CountryCode;
            if (selectedCountry == null)
                return;

            // Reset all the buttons
            ResetStatusImages();

            _netflixStatusChecker?.SetUnblockUsRegion(selectedCountry.Code);
            _netflixStatusChecker?.GetNetflixStatus();
        }

        private void btnRefreshNetflix_Click(object sender, EventArgs e)
        {
            Bitmap image = ResourceStream.GetImage("unknown-16.png");
            btnNetflixCountry.Image = image;
            btnNetflixGeoLocation.Image = image;

            _netflixStatusChecker?.GetNetflixStatus();
        }

        private void btnRefreshUnblockUs_Click(object sender, EventArgs e)
        {
            Bitmap image = ResourceStream.GetImage("unknown-16.png");
            btnUnblockCountry.Image = image;
            btnUnblockActive.Image = image;

            _netflixStatusChecker?.GetUnblockUsStatus();
        }
    }
}
