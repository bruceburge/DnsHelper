using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DnsHelperUI
{
    public class DnsProvider
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]   
        public string Website { get; set; }

        [JsonProperty("servers")]
        public List<DnsServers> Servers { get; set; }
    }

    public class DnsServers
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("dns1")]
        public string Dns1 { get; set; }

        [JsonProperty("dns2")]
        public string Dns2 { get; set; }
    }
}
