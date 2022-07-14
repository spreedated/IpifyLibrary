using System.Net.Http;

namespace neXn.IpifyWrapper
{
    internal static class Download
    {
        internal static string IpifiyString(string addr)
        {
            using (HttpClient hc = new HttpClient())
            {
                //Fake that we are a real browser
                hc.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                hc.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                hc.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                return hc.GetStringAsync(addr).Result;
            }
        }
    }
}
