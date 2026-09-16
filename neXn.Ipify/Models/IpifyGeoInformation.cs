using System.Text.Json.Serialization;

namespace neXn.Ipify.Models
{
    public sealed record IpifyGeoInformation
    {
        [JsonPropertyName("as")]
        public IpifyAs As { get; internal set; }

        [JsonPropertyName("domains")]
        public string[] Domains { get; internal set; }

        [JsonPropertyName("isp")]
        public string ISP { get; internal set; }

        [JsonPropertyName("location")]
        public IpifyLocation Location { get; internal set; }
        [JsonPropertyName("proxy")]
        public IpifyProxy Proxy { get; internal set; }
    }
}
