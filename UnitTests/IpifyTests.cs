using neXn.IpifyWrapper;
using neXn.IpifyWrapper.Models;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace UnitTests
{
    public class IpifyTests
    {
        private const string validateIPv4RegEx = "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        private const string validateIPv6RegEx = "(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))";
        [SetUp]
        public void SetUp()
        {

        }

        [Test(Description = "Need Internet Connection")]
        public void StaticIPv4_6()
        {
            //IPv4
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicAddress(), validateIPv4RegEx));
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicIPAddress().ToString(), validateIPv4RegEx));

            //IPv6
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicv6Address(), validateIPv6RegEx));
            Assert.IsTrue(Regex.IsMatch(Ipify.GetPublicIPv6Address().ToString(), validateIPv6RegEx));
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