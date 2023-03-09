using neXn.IpifyWrapper;
using neXn.IpifyWrapper.Models;
using NUnit.Framework;
using System.Text.RegularExpressions;
using static UnitTests.Constants;

namespace UnitTests
{
    public class IpifyTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        [Ignore("Need Internet Connection")]
        public void StaticIPv4_6()
        {
            //IPv4
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicAddress(), VALIDATEIPV4REGEX));
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicIPAddress().ToString(), VALIDATEIPV4REGEX));

            //IPv6
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicv6Address(), VALIDATEIPV6REGEX));
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicIPv6Address().ToString(), VALIDATEIPV6REGEX));
        }

        [Test(Description = "Need Internet Connection")]
        [Ignore("Provide API Key")]
        public void GeoLocation()
        {
            GeoIPLocation g = new("<yourAPIKeyHere>");
            IpifyGeoInformation u = null;

            Assert.DoesNotThrow(() => { g.Get("46.114.106.243", GeoIPLocation.QueryType.IP_Address); });
            Assert.IsNotNull(u);
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}