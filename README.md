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
```csharp
//Get IPv4
string myIPv4 = Ipify.GetPublicAddress();
IPAddress myIPv4Address = Ipify.GetPublicIPAddress()();
//Get IPv6
string myIPv6 = Ipify.GetPublicv6Address();
IPAddress myIPv6Address = Ipify.GetPublicIPv6Address();

//Get Geolocation Information of an IP
GeoIPLocation g = new("<yourAPIKeyHere>")

ipifyWrapper.Ipify.GeoIPLocation.IpifyGeoInformation ipInformation = acc.GetInformation("<QUERY IP>");
var response = g.Get("46.114.106.243", GeoIPLocation.QueryType.IP_Address);
```

### Contribution
Pull requests are very welcome.

### Copyrights
IpifyLibrary was initially written by **Markus Karl Wackermann**.
