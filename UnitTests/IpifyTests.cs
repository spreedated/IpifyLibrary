using neXn.Ipify;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System.Net;

namespace UnitTests
{
    public class IpifyTests
    {
        [Test]
        [TestCase("{\"ip\":\"127.0.0.1\"}")]
        [TestCase("{\"ip\":\"2001:0000:130F:0000:0000:09C0:876A:130B\"}")]
        public void RetrieveIpSuccessTests(string queryResponse)
        {
            MockHttpMessageHandler mockHttp = new();
            mockHttp.When(Constants.IPIFY_URL_UNIVERSAL).Respond(HttpStatusCode.OK, "application/json", queryResponse);

            IpifyClient ip = new()
            {
                _client = new(mockHttp)
            };

            IPAddress response = null;

            Assert.DoesNotThrowAsync(async () =>
            {
                response = await ip.GetPublicIPAddressAsync();
            });

            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.InstanceOf<IPAddress>());
            Assert.That(PreCompiledRegex.ValidateIp4().IsMatch(response.ToString()) || PreCompiledRegex.ValidateIp6().IsMatch(response.ToString()), Is.True);
        }

        [Test]
        [TestCase(HttpStatusCode.BadGateway, "error")]
        [TestCase(HttpStatusCode.OK, "{}")]
        [TestCase(HttpStatusCode.OK, "")]
        public void RetrieveIpFailTests(HttpStatusCode httpResponseCode, string httpResponse)
        {
            MockHttpMessageHandler mockHttp = new();
            mockHttp.When(Constants.IPIFY_URL_UNIVERSAL).Respond(httpResponseCode, "application/json", httpResponse);

            IpifyClient ip = new()
            {
                _client = new(mockHttp)
            };

            IPAddress response = null;

            Assert.DoesNotThrowAsync(async () =>
            {
                response = await ip.GetPublicIPAddressAsync();
            });

            Assert.That(response, Is.Null);
        }
    }
}