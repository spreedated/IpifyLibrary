using System;
using System.Net;
using Newtonsoft.Json;

namespace neXn.IpifyWrapper
{
    public class Ipify
    {
        private const string ipifyAdress = "http://api.ipify.org";
        private const string ipifyAdressSecure = "https://api.ipify.org";
        private const string ipifyAdressv6 = "http://api6.ipify.org";
        private const string ipifyAdressv6Secure = "https://api6.ipify.org";

        /// <summary>
        /// Get public IPv4 Address as System.Net.IPAddress
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>System.Net.IPAddress</returns>
        public static IPAddress GetPublicIPAddress(bool useHttps = true)
        {
            IPAddress GetPublicIPAddressRet = default;
            using (var wC = new WebClient())
            {
                GetPublicIPAddressRet = IPAddress.Parse(wC.DownloadString(useHttps ? ipifyAdressSecure : ipifyAdress));
            }

            return GetPublicIPAddressRet;
        }

        /// <summary>
        /// Get public IPv4 Address as String
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>ex. 127.0.0.1</returns>
        public static string GetPublicAddress(bool useHttps = true)
        {
            string GetPublicAddressRet = default;
            using (var wC = new WebClient())
            {
                GetPublicAddressRet = wC.DownloadString(useHttps ? ipifyAdressSecure : ipifyAdress);
            }

            return GetPublicAddressRet;
        }

        /// <summary>
        /// Get public IPv6 Address as System.Net.IPAddress
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>System.Net.IPAddress</returns>
        public static IPAddress GetPublicIPv6Address(bool useHttps = true)
        {
            IPAddress GetPublicIPv6AddressRet = default;
            using (var wC = new WebClient())
            {
                GetPublicIPv6AddressRet = IPAddress.Parse(wC.DownloadString(useHttps ? ipifyAdressv6Secure : ipifyAdressv6));
            }

            return GetPublicIPv6AddressRet;
        }

        /// <summary>
        /// Get public IPv6 Address as String
        /// </summary>
        /// <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
        /// <returns>ex. fe80::1</returns>
        public static string GetPublicv6Address(bool useHttps = true)
        {
            string GetPublicv6AddressRet = default;
            using (var wC = new WebClient())
            {
                GetPublicv6AddressRet = wC.DownloadString(useHttps ? ipifyAdressv6Secure : ipifyAdressv6);
            }

            return GetPublicv6AddressRet;
        }

        /// <summary>
        /// Main Class of Geolocation Informmation <br/>
        /// Instance this with APIKey as String
        /// </summary>
        public class GeoIPLocation
        {
            /// <summary>
            /// Main Class of Geolocation Informmation <br/>
            /// Instance this with APIKey as String
            /// </summary>
            /// <returns></returns>
            public string APIKey { get; set; } = null;

            private const string ipifyAddress = "https://geo.ipify.org/api/v1?apiKey={0}&{1}={2}";

            public enum QueryType
            {
                ipAddress,
                email,
                domain
            }

            /// <summary>
            /// Main Function <br/>
            /// Be sure to set your API-Key first!
            /// </summary>
            /// <param name="QueryValue">What you want to query, usually an IP address</param>
            /// <param name="[QueryType]">Typically an ipaddress, but also able to query a domain or email</param>
            /// <returns></returns>
            public IpifyGeoInformation GetInformation(string QueryValue, QueryType QueryType = QueryType.ipAddress)
            {
                var acc = new IpifyGeoInformation();
                using (var wC = new WebClient())
                {
                    acc = JsonConvert.DeserializeObject<IpifyGeoInformation>(wC.DownloadString(string.Format(ipifyAddress, APIKey, Enum.GetName(typeof(QueryType), QueryType), QueryValue)));
                }

                return acc;
            }

            /// <summary>
            /// Object of JSON deserialization
            /// </summary>
            public class IpifyGeoInformation
            {
                public IpifyLocation Location { get; set; }
                public string[] Domains { get; set; }
                public IpifyAs As { get; set; }
                public string ISP { get; set; }

                public class IpifyLocation
                {
                    public string Country { get; set; }
                    public string Region { get; set; }
                    public string City { get; set; }
                    public double Lat { get; set; }
                    public double Lng { get; set; }
                    public string Postalcode { get; set; }
                    public string Timezone { get; set; }
                    public long GeonameID { get; set; }
                }

                public class IpifyAs
                {
                    public int Asn { get; set; }
                    public string Name { get; set; }
                    public string Route { get; set; }
                    public string Domain { get; set; }
                    public string Type { get; set; }
                }
            }
        }
    }
}
