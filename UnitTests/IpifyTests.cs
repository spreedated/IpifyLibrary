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
            Assert.That(Regex.IsMatch(Ipify.GetPublicAddress(), VALIDATEIPV4REGEX), Is.True);
            Assert.That(Regex.IsMatch(Ipify.GetPublicIPAddress().ToString(), VALIDATEIPV4REGEX), Is.True);

            //IPv6
            Assert.That(Regex.IsMatch(Ipify.GetPublicv6Address(), VALIDATEIPV6REGEX), Is.True);
            Assert.That(Regex.IsMatch(Ipify.GetPublicIPv6Address().ToString(), VALIDATEIPV6REGEX), Is.True);
        }

        [Test(Description = "Need Internet Connection")]
        [Ignore("Provide API Key")]
        public void GeoLocation()
        {
            GeoIPLocation g = new("<yourAPIKeyHere>");
            IpifyGeoInformation u = null;

            Assert.DoesNotThrow(() => { g.Get("46.114.106.243", GeoIPLocation.QueryType.IP_Address); });
            Assert.That(u, Is.Not.Null);
        }

        [Test]
        public void FormatTests()
        {
            string t = string.Format(neXn.IpifyWrapper.Constants.IPIFYGEOADDRESS, "hello", "world", "one");
            Assert.That(t, Is.EqualTo("https://geo.ipify.org/api/v1?apiKey=hello&world=one"));
            Assert.That(neXn.IpifyWrapper.Logic.HelperFunctions.GetFormattedGeoAddress("hello", "world", "one"), Is.EqualTo("https://geo.ipify.org/api/v1?apiKey=hello&world=one"));
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}