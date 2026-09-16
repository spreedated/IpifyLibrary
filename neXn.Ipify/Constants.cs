#pragma warning disable S1075 // URIs should not be hardcoded

namespace neXn.Ipify
{
    internal static class Constants
    {
        public const string IPIFY_URL_GEOADDRESS = "https://geo.ipify.org/api/v1?apiKey=";
        /// <summary>
        /// Universal: IPv4/IPv6<br/>
        /// 98.207.254.136 or 2a00:1450:400f:80d::200e
        /// </summary>
        public const string IPIFY_URL_UNIVERSAL = "http://api64.ipify.org?format=json";
    }
}
