[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=35WE5NU48AUMA&source=url)

IpifyLibrary
============
An easy to use library/wrapper/api-link library for your .NET projects.

### Enjoying this?
Just star the repo or make a donation.

[![Donate0](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=35WE5NU48AUMA&source=url)

Your help is valuable since this is a hobby project for all of us: we do development during out-of-office hours.

### Class Construct

![](/Screenshots/GeoInformationClass.png)

### Usage (Code sample)
C#
``` chsarp
//Get IPv4
string myIPv4 = ipifyWrapper.Ipify.GetPublicAddress();
IPAddress myIPv4Address = ipifyWrapper.Ipify.GetPublicIPAddress();
//Get IPv6
string myIPv6 = ipifyWrapper.Ipify.GetPublicv6Address();
IPAddress myIPv6Address = ipifyWrapper.Ipify.GetPublicIPv6Address();

//Get Geolocation Information of an IP
ipifyWrapper.Ipify.GeoIPLocation acc = new ipifyWrapper.Ipify.GeoIPLocation
{
	APIKey = "<YOUR-API-KEY>"
};

ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation ipInformation = acc.GetInformation("<QUERY IP>");
//Get Geolocation Information of Type (ipAddress, email, domain)
ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation ipInformationDomain = acc.GetInformation("<QUERY IP>", ipifyWrapper.Ipify.GeoIPLocation.QueryType.domain);
ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation ipInformationEmail = acc.GetInformation("<QUERY IP>", ipifyWrapper.Ipify.GeoIPLocation.QueryType.email);
ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation ipInformationIpAddress = acc.GetInformation("<QUERY IP>", ipifyWrapper.Ipify.GeoIPLocation.QueryType.ipAddress);
```

Visual Basic .NET
``` visualbasic
'Get IPv4
Dim myIPv4 As String = ipifyWrapper.Ipify.GetPublicAddress()
Dim myIPv4IP As IPAddress = ipifyWrapper.Ipify.GetPublicIPAddress()
'Get IPv6
Dim myIPv6 As String = ipifyWrapper.Ipify.GetPublicv6Address()
Dim myIPv6IP As IPAddress = ipifyWrapper.Ipify.GetPublicIPv6Address()

'Get Geolocation Information of an IP
Dim acc As ipifyWrapper.Ipify.GeoIPLocation = New ipifyWrapper.Ipify.GeoIPLocation With {.APIKey = "<YOUR-API-KEY>"}

Dim ipInformation As ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation = acc.GetInformation("<QUERY IP>")
'Get Geolocation Information of Type (ipAddress, email, domain)
Dim ipInformationDomain As ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation = acc.GetInformation("<QUERY IP>", ipifyWrapper.Ipify.GeoIPLocation.QueryType.domain)
Dim ipInformationEmail As ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation = acc.GetInformation("<QUERY IP>", ipifyWrapper.Ipify.GeoIPLocation.QueryType.email)
Dim ipInformationipAddress As ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation = acc.GetInformation("<QUERY IP>", ipifyWrapper.Ipify.GeoIPLocation.QueryType.ipAddress)
```

### Contribution
Pull requests are very welcome.

### Copyrights
IpifyLibrary was initially written by **Markus Karl Wackermann**.
