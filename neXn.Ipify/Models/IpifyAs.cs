using System.Text.Json.Serialization;

namespace neXn.Ipify.Models
{
    public sealed record IpifyAs
    {
        [JsonPropertyName("asn")]
        public int Asn { get; internal set; }
        [JsonPropertyName("domain")]
        public string Domain { get; internal set; }

        [JsonPropertyName("name")]
        public string Name { get; internal set; }
        [JsonPropertyName("route")]
        public string Route { get; internal set; }
        [JsonPropertyName("type")]
        public string Type { get; internal set; }
    }
}
