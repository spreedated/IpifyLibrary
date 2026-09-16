using neXn.Ipify.Attributes;
using neXn.Ipify.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace neXn.Ipify
{
    public class IpifyClient : IDisposable
    {
        internal HttpClient _client;

        /// <summary>
        /// Your ipify.org API Key
        /// </summary>
        public string ApiKey { get; internal set; }

        public enum QueryType
        {
            [QueryName("ipAddress")]
            IpAddress,
            [QueryName("email")]
            Email,
            [QueryName("domain")]
            Domain
        }

        #region Ctor
        public IpifyClient()
        {
            this._client = new();
        }

        public IpifyClient(string apikey) : this()
        {
            if (string.IsNullOrEmpty(apikey))
            {
                throw new ArgumentNullException(nameof(apikey));
            }

            if (apikey.Length < 30)
            {
                throw new ArgumentException("Provided api key seems invalid", nameof(apikey));
            }

            this.ApiKey = apikey;
        }
        #endregion

        private async Task<string> DownloadJson(string url, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _client.GetAsync(url, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }

        private string BuildGeoLocationQueryUrl(string queryValue, QueryType queryType)
        {
            string url = $"{Constants.IPIFY_URL_GEOADDRESS}{Uri.EscapeDataString(this.ApiKey)}";

            if (string.IsNullOrWhiteSpace(queryValue))
            {
                return url;
            }

            string queryName = queryType switch
            {
                QueryType.IpAddress => "ipAddress",
                QueryType.Email => "email",
                QueryType.Domain => "domain",
                _ => throw new ArgumentOutOfRangeException(nameof(queryType))
            };

            return $"{url}&{queryName}={Uri.EscapeDataString(queryValue)}";
        }

        /// <summary>
        /// Get public IPv4 or IPv6<br/>
        /// 98.207.254.136 or 2a00:1450:400f:80d::200e
        /// </summary>
        /// <returns>null on error</returns>
        public async Task<IPAddress> GetPublicIPAddressAsync(CancellationToken cancellationToken = default)
        {
            string json = await this.DownloadJson(Constants.IPIFY_URL_UNIVERSAL, cancellationToken);

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            JsonElement jsonElement = JsonDocument.Parse(json).RootElement;

            if (!jsonElement.TryGetProperty("ip", out JsonElement ip))
            {
                return null;
            }

            return IPAddress.TryParse(ip.GetString(), out IPAddress address) ? address : null;
        }


        public async Task<IpifyGeoInformation> GetGeoInformationAsync(string query = null, QueryType queryType = QueryType.IpAddress, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(this.ApiKey))
            {
                throw new InvalidOperationException("An ipify API key is required for geolocation requests.");
            }

            string queryUrl = this.BuildGeoLocationQueryUrl(query, queryType);
            string json = await this.DownloadJson(queryUrl, cancellationToken);

            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            return JsonSerializer.Deserialize<IpifyGeoInformation>(json);
        }

        #region Dispose
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client?.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
