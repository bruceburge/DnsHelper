using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnblockUSTest
{
    // From: http://json2csharp.com/
    public class UnblockUsConfig
    {   
            public string email { get; set; }
            public bool is_known { get; set; }
            public bool is_active { get; set; }
            public string ip { get; set; }
            public bool our_dns { get; set; }
            public bool locked { get; set; }
            public string eguess { get; set; }
            public string status { get; set; }
            public bool ip_changed { get; set; }
            public bool reactivated { get; set; }
            public string secure { get; set; }
            public bool accepted { get; set; }
            public string current { get; set; }
            public bool cc_disabled { get; set; }
            public string country { get; set; }
            public string expiresOn { get; set; }
            public bool dragon { get; set; }
            public bool old_dns { get; set; }
            public int secret { get; set; }
        
    }
}
