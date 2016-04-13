using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace UnblockUSTest
{
    public static class NativeMethods
    {
        [DllImport("WinInet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DeleteUrlCacheEntry(string url);
    }


    public class NetflixStatusChecker
    {
        private CookieContainer _unblockCookieJar = null;
        private readonly string _userName;

        private static string UrlUnblockLogin = "https://check.unblock-us.com/get-status.js?callback=callback&email={0}&rnd=%RAND%";
        private static string UrlUnblockStatus = "http://check.unblock-us.com/get-status.js?callback=callback&rnd=%RAND%";
        private static string UrlUnblockSetCountry = "http://check.unblock-us.com/set-country.js?callback=callback&code={0}&rnd=%RAND%";
        private static string UrlNetflixConfig = "http://api-global.netflix.com/apps/applefuji/config";
        private static string UrlUnblockActivateIP = "https://check.unblock-us.com/get-status.js?callback=callback&reactivate=1"; // Get a status back

        public event EventHandler<UnblockUsEventArgs> UnblockUsStatus;
        protected virtual void OnUnblockUsStatus(UnblockUsEventArgs e)
        {
            UnblockUsStatus?.Invoke(this, e);
        }

        public event EventHandler<NetflixEventArgs> NetflixStatus;
        protected virtual void OnNetflixStatus(NetflixEventArgs e)
        {
            NetflixStatus?.Invoke(this, e);
        }

        public NetflixStatusChecker(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException(nameof(userName));

            _userName = userName;
        }

        public void Initialize()
        {
            if (_unblockCookieJar != null)
                return;

            // Login and get status
            TryInitializeCookies(string.Format(UrlUnblockLogin, _userName), ref _unblockCookieJar);
            GetUnblockUsStatus();
            GetNetflixStatus();
        }

        public void SetUnblockUsRegion(string countryCode)
        {
            GetDataUsingSocket(string.Format(UrlUnblockSetCountry, countryCode), _unblockCookieJar);
            ParseUnblockUsStatus(GetDataUsingSocket(UrlUnblockStatus, _unblockCookieJar), $"Set Region '{countryCode}'");
        }

        public void GetUnblockUsStatus()
        {
            ParseUnblockUsStatus(GetDataUsingSocket(UrlUnblockStatus, _unblockCookieJar), "Status");
        }

        public void ActivateNewUnblockUsIp()
        {
            ParseUnblockUsStatus(GetDataUsingSocket(UrlUnblockActivateIP, _unblockCookieJar), "Activate IP");
        }

        public void GetNetflixStatus()
        {
            ParseNetflixStatus(GetDataUsingSocket(UrlNetflixConfig, _unblockCookieJar), "Status");
        }

        private void ParseUnblockUsStatus(string statusMessage, string action)
        {
            var e = new UnblockUsEventArgs
            {
                Action = action,
                Message = "Error"
            };

            if( !string.IsNullOrWhiteSpace(statusMessage) )
            {
                // Extract the actual data from the status message (it might be a raw message from a socket)
                var statusMessageClean = statusMessage.Substring(statusMessage.IndexOf("callback("));

                var msg = statusMessageClean.Substring(0, statusMessageClean.IndexOf('}')+1);
                msg = msg.Substring(msg.IndexOf('{'));
                e.Message = msg;

                e.Config = new JavaScriptSerializer().Deserialize<UnblockUsConfig>(msg);
                e.DnsActive = e.Config.our_dns;
                e.CountryCode = e.Config.current?.ToLower();
            }

            OnUnblockUsStatus(e);
        }

        private void ParseNetflixStatus(string statusMessage, string action)
        {
            var e = new NetflixEventArgs
            {
                Action = action,
                Message = statusMessage ?? "Error"
            };

            if (!string.IsNullOrWhiteSpace(statusMessage))
            {
                // Extract the actual data from the status message (it might be a raw message from a socket)
                var statusMessageClean = statusMessage.Substring(statusMessage.IndexOf("<?xml"));

                var xRoot = new XmlRootAttribute
                {
                    ElementName = "config",
                    IsNullable = true
                };

                var serializer = new XmlSerializer(typeof (NetflixConfig), xRoot);
                e.Config = ((NetflixConfig)serializer.Deserialize(new StringReader(statusMessageClean)));

                if (e.Config != null)
                {
                    e.CountryCode = e.Config.country?.ToLower();
                    e.GeoLocationCountry = e.Config.geolocationcountry?.ToLower();
                }
            }

            OnNetflixStatus(e);
        }

        private Socket ConnectSocket(Uri uri)
        {
            // Detect the correct port based on the protocol scheme
            int port = uri.Scheme.StartsWith("https", StringComparison.OrdinalIgnoreCase) ? 443 : 80;

            IPHostEntry hostEntry;
            Socket clientSocket = null;

            // Resolve the server name
            try
            {
                hostEntry = Dns.GetHostEntry(uri.Host);
            }
            catch (Exception)
            {
                return null;
            }

            // Attempt to connect on each address returned from DNS. Break out once successfully connected
            foreach (IPAddress address in hostEntry.AddressList)
            {
                try
                {
                    clientSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    var remoteEndPoint = new IPEndPoint(address, port);
                    clientSocket.Connect(remoteEndPoint);
                    break;
                }
                catch (SocketException ex)
                {
                    return null;
                }
            }

            return clientSocket;
        }

        private StringBuilder PerformGet(Uri uri, Socket clientSocket, CookieContainer cookieContainer)
        {
            // Create the cookie string if there is one
            string cookies = "";
            if (cookieContainer != null && cookieContainer.Count > 0)
            {
                cookies = "\r\nCookie: ";
                foreach (Cookie cookie in GetAllCookies(cookieContainer))
                {
                    cookies += cookie.Name + "=" + cookie.Value + "; ";
                }
            }

            // Format the HTTP GET request string
            string getRequest = "GET " + uri.PathAndQuery + " HTTP/1.1\r\nHost: " + uri.Host + "\r\nConnection: Close" + cookies + "\r\n\r\n";
            var getBuffer = Encoding.ASCII.GetBytes(getRequest);

            // Send the GET request to the connected server
            clientSocket.Send(getBuffer);
            
            // Create a buffer that is used to read the response
            byte[] responseData = new byte[1024];

            // Read the response and save the ASCII data in a string
            int bytesRead = clientSocket.Receive(responseData);

            var responseString = new StringBuilder();
            while (bytesRead != 0)
            {
                responseString.Append(Encoding.ASCII.GetChars(responseData), 0, bytesRead);
                bytesRead = clientSocket.Receive(responseData);
            }

            return responseString;
        }
        
        private string GetDataUsingSocket(string url, CookieContainer cookieContainer = null )
        {
            // Add a random element to the url, this is a shit hack but the only thing that will work!
            url = url.Replace("%RAND%", DateTime.Now.Ticks.ToString());

            // Structured uri to be able to extract components
            var uri = new Uri(url);

            // Create the socket and connect it
            var clientSocket = ConnectSocket(uri);
            if (clientSocket == null || !clientSocket.Connected)
                return null;

            try
            {
                return PerformGet(uri, clientSocket, cookieContainer)?.ToString();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                clientSocket.Close();
                clientSocket.Dispose();
            }
        }


        private bool TryInitializeCookies(string url, ref CookieContainer cookieContainer)
        {
            // Add a random element to the url, this is a shit hack but the only thing that will work!
            url = url.Replace("%RAND%", DateTime.Now.Ticks.ToString());

            // Default cache policy
            HttpWebRequest.DefaultCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            // If the cookie jar is empty then do a fake call to get a session cookie
            try
            {
                if (cookieContainer == null)
                {
                    cookieContainer = new CookieContainer();
                    var request = (HttpWebRequest)WebRequest.Create(url);

                    request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                    request.CookieContainer = cookieContainer;

                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        int cookieCount = cookieContainer.Count;
                        if (cookieCount <= 0)
                            throw new InvalidOperationException("Did not receive any valid session cookies form url '" + url + "'");
                    }
                }

                return true; // Success
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static CookieCollection GetAllCookies(CookieContainer cookieJar, string scheme = "https")
        {
            var cookieCollection = new CookieCollection();

            Hashtable table = (Hashtable)cookieJar.GetType().InvokeMember("m_domainTable",
                                                                          BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                                                                          null, cookieJar, new object[] { });
            foreach (string rawKey in table.Keys)
            {
                // Skip dots in the beginning, the key value is the domain name for the cookies
                var key = rawKey.TrimStart( '.' );

                // Invoke the private function to get the list of cookies
                var list = (SortedList)table[rawKey].GetType().InvokeMember("m_list",
                                                                            BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                                                                            null,
                                                                            table[key],
                                                                            new object[] { });

                foreach (var uri in list.Keys.Cast<string>()
                                             .Select( listkey => new Uri(scheme + "://" + key + listkey)))
                {
                    cookieCollection.Add(cookieJar.GetCookies(uri));
                }
            }

            return cookieCollection;
        }

        private string GetData(string url)
        {
            // Add a random element to the url, this is a shit hack but the only thing that will work!
            url = url.Replace("%RAND%", DateTime.Now.Ticks.ToString());

            // Default cache policy
            HttpWebRequest.DefaultCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            // If the cookie jar is empty then do a fake call to get a session cookie
            try
            {
                if (_unblockCookieJar == null)
                {
                    _unblockCookieJar = new CookieContainer();
                    var request = (HttpWebRequest) WebRequest.Create(url);

                    request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                    request.CookieContainer = _unblockCookieJar;

                    using (var response = (HttpWebResponse) request.GetResponse())
                    {
                        int cookieCount = _unblockCookieJar.Count;
                        if (cookieCount <= 0)
                            throw new InvalidOperationException("Did not receive any valid session cookies form url '" + url + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print( ex.ToString());
                return null;
            }

            // Construct HTTP request to get the file
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            
            // Invalidate caches, THIS DOES NOT WORK!!!
            httpRequest.KeepAlive = false;
            
            httpRequest.Accept = "text/html,application/xhtml+xml,application/xml";

            httpRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            /*httpRequest.Headers.Add("Cache-Control", "no-cache");
            httpRequest.Headers.Add("Pragma", "no-cache");*/
            httpRequest.Headers.Add("DNT", "1");
            httpRequest.Headers.Add("Upgrade-Insecure-Requests", "1");

            httpRequest.Method = WebRequestMethods.Http.Get;
            httpRequest.CookieContainer = _unblockCookieJar;

            httpRequest.AllowAutoRedirect = true;
            httpRequest.Credentials = CredentialCache.DefaultCredentials;

            // Some user agent
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36";
            
            try
            {
                // Get the response
                using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    if (httpResponse.IsFromCache)
                        Debug.Print("Cache Hit! Url: " + url);

                    using (Stream responseStream = httpResponse.GetResponseStream())
                    {
                        if (responseStream == null)
                            return null;

                        using (var sr = new StreamReader(responseStream, Encoding.GetEncoding("iso8859-1")))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return null;
            }
        }
    }

    public class NetflixEventArgs : EventArgs
    {
        public string Action { get; set; }
        public string Message { get; set; }
        public string CountryCode { get; set; }
        public string GeoLocationCountry { get; set; }
        public NetflixConfig Config { get; set; }
    }

    public class UnblockUsEventArgs : EventArgs
    {
        public string Action { get; set; }
        public string Message { get; set; }
        public bool DnsActive { get; set; }
        public string CountryCode { get; set; }
        public UnblockUsConfig Config { get; set; }
    }
}
