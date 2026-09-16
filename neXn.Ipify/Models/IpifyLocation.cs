using System.Text.Json.Serialization;

namespace neXn.Ipify.Models
{
    public sealed record IpifyLocation
    {
        [JsonPropertyName("city")]
        public string City { get; internal set; }

        [JsonPropertyName("country")]
        public string Country { get; internal set; }
        [JsonPropertyName("geonameId")]
        public long GeonameID { get; internal set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; internal set; }

        [JsonPropertyName("lng")]
        public double Longitude { get; internal set; }

        [JsonPropertyName("postalCode")]
        public string Postalcode { get; internal set; }

        [JsonPropertyName("region")]
        public string Region { get; internal set; }
        [JsonPropertyName("timezone")]
        public string Timezone { get; internal set; }
    }
}
