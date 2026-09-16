using System.Text.Json.Serialization;

namespace neXn.Ipify.Models
{
    public sealed record IpifyProxy
    {
        [JsonPropertyName("proxy")]
        public bool IsProxy { get; internal set; }
        [JsonPropertyName("tor")]
        public bool IsTor { get; internal set; }

        [JsonPropertyName("vpn")]
        public bool IsVPN { get; internal set; }
    }
}
