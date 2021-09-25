using Newtonsoft.Json;

namespace neXn.IpifyWrapper.Models
{
    /// <summary>
    /// Object of JSON deserialization
    /// </summary>
    public class IpifyGeoInformation
    {
        [JsonProperty("location")]
        public IpifyLocation Location { get; internal set; }
        [JsonProperty("domains")]
        public string[] Domains { get; internal set; }
        [JsonProperty("as")]
        public IpifyAs As { get; internal set; }
        [JsonProperty("isp")]
        public string ISP { get; internal set; }
        [JsonProperty("proxy")]
        public IpifyProxy Proxy { get; internal set; }

        public class IpifyLocation
        {
            [JsonProperty("country")]
            public string Country { get; internal set; }
            [JsonProperty("region")]
            public string Region { get; internal set; }
            [JsonProperty("city")]
            public string City { get; internal set; }
            [JsonProperty("lat")]
            public double Latitude { get; internal set; }
            [JsonProperty("lng")]
            public double Longitude { get; internal set; }
            [JsonProperty("postalCode")]
            public string Postalcode { get; internal set; }
            [JsonProperty("timezone")]
            public string Timezone { get; internal set; }
            [JsonProperty("geonameId")]
            public long GeonameID { get; internal set; }
        }

        public class IpifyAs
        {
            [JsonProperty("asn")]
            public int Asn { get; internal set; }
            [JsonProperty("name")]
            public string Name { get; internal set; }
            [JsonProperty("route")]
            public string Route { get; internal set; }
            [JsonProperty("domain")]
            public string Domain { get; internal set; }
            [JsonProperty("type")]
            public string Type { get; internal set; }
        }

        public class IpifyProxy
        {
            [JsonProperty("proxy")]
            public bool IsProxy { get; internal set; }
            [JsonProperty("vpn")]
            public bool IsVPN { get; internal set; }
            [JsonProperty("tor")]
            public bool IsTor { get; internal set; }
        }
    }
}
