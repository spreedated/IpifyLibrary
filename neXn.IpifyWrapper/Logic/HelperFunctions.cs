using System.Net.Http;
using static neXn.IpifyWrapper.Constants;

namespace neXn.IpifyWrapper.Logic
{
    internal static class HelperFunctions
    {
        internal static string IpifiyString(string addr)
        {
            using (HttpClient hc = new HttpClient())
            {
                //Fake that we are a real browser
                hc.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                hc.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
                hc.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                return hc.GetStringAsync(addr).Result;
            }
        }

        internal static string GetFormattedGeoAddress(string apikey, string identifier, string value)
        {
            return string.Format(IPIFYGEOADDRESS, apikey, identifier, value);
        }
    }
}
