using System.Net;
using static neXn.IpifyWrapper.Constants;
using static neXn.IpifyWrapper.Logic.HelperFunctions;

namespace neXn.IpifyWrapper
{
    internal static class Ipify
    {
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
        /// Get public IPv4 Address as System.Net.IPAddress
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>System.Net.IPAddress</returns>
        public static IPAddress GetPublicIPAddress(bool useHttps = true)
        {
            return IPAddress.Parse(IpifiyString(useHttps ? IPIFYADRESSSECURE : IPIFYADRESS));
        }

        /// <summary>
        /// Get public IPv6 Address as System.Net.IPAddress
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>System.Net.IPAddress</returns>
        public static IPAddress GetPublicIPv6Address(bool useHttps = true)
        {
            return IPAddress.Parse(IpifiyString(useHttps ? IPIFYADRESSV6SECURE : IPIFYADRESSV6));
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
