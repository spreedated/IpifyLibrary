using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace neXn.IpifyWrapper
{
    public class Ipify
    {
        internal const string ipifyAdress = "http://api.ipify.org";
        internal const string ipifyAdressSecure = "https://api.ipify.org";
        internal const string ipifyAdressv6 = "http://api6.ipify.org";
        internal const string ipifyAdressv6Secure = "https://api6.ipify.org";

        /// <summary>
        /// Get public IPv4 Address as System.Net.IPAddress
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>System.Net.IPAddress</returns>
        public static IPAddress GetPublicIPAddress(bool useHttps = true)
        {
            return IPAddress.Parse(Download.IpifiyString(useHttps ? ipifyAdressSecure : ipifyAdress));
        }
        /// <summary>
        /// Get public IPv4 Address as String
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>ex. 127.0.0.1</returns>
        public static string GetPublicAddress(bool useHttps = true)
        {
            return GetPublicIPAddress(useHttps).ToString();
        }
        /// <summary>
        /// Get public IPv6 Address as System.Net.IPAddress
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>System.Net.IPAddress</returns>
        public static IPAddress GetPublicIPv6Address(bool useHttps = true)
        {
            return IPAddress.Parse(Download.IpifiyString(useHttps ? ipifyAdressv6Secure : ipifyAdressv6));
        }
        /// <summary>
        /// Get public IPv6 Address as String
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>ex. fe80::1</returns>
        public static string GetPublicv6Address(bool useHttps = true)
        {
            return GetPublicIPv6Address(useHttps).ToString();
        }
    }
}
