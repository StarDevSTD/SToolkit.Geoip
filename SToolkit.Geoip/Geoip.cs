using System;
using System.Net;
#if !NET35
using System.Threading.Tasks;
#endif

namespace SToolkit.Geoip
{
    public static class Geoip
    {
        public static string ProxyHost { get; set; }
        public static int ProxyPort { get; set; } = 0;
        public static string ProxyLogin { get; set; }
        public static string ProxyPass { get; set; }

        public static GeoipObject Request(string ip)
        {
            WebClient wc = CreateClient();
            string data = wc.DownloadString($"http://ip-api.com/csv/{ip}");
            return GeoipObject.Deserialize(data);
        }

#if !NET40 && !NET35
        public static async Task<GeoipObject> RequestAsync(string ip)
        {
            WebClient wc = CreateClient();
            string data = await wc.DownloadStringTaskAsync(new Uri($"http://ip-api.com/csv/{ip}"));
            return GeoipObject.Deserialize(data);
        }
#endif

        private static WebClient CreateClient()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 YaBrowser/18.6.1.770 Yowser/2.5 Safari/537.36");
            if (ProxyHost != null && ProxyPort != 0)
            {
                wc.Proxy = new WebProxy(ProxyHost, ProxyPort);
                if (ProxyLogin != null && ProxyPass != null)
                    wc.Proxy.Credentials = new NetworkCredential(ProxyLogin, ProxyPass);
            }
            return wc;
        }
    }
}
