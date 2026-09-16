[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=35WE5NU48AUMA&source=url)

[![NuGet](https://img.shields.io/nuget/v/neXn.Ipify?style=flat-square&logo=nuget&label=NuGet)](https://www.nuget.org/packages/neXn.Ipify)
[![NuGet Downloads](https://img.shields.io/nuget/dt/neXn.Ipify?style=flat-square&logo=nuget&label=Downloads)](https://www.nuget.org/packages/neXn.Ipify)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-13-512BD4?style=flat-square&logo=csharp)
[![License](https://img.shields.io/github/license/spreedated/IpifyLibrary?style=flat-square)](https://github.com/spreedated/IpifyLibrary/blob/master/LICENSE)

neXn.Ipify
---

A lightweight modern .NET client for the [ipify](https://www.ipify.org/) and [Geo IPify](https://geo.ipify.org/) APIs.

## Features

- Retrieve your public IPv4 or IPv6 address
- Query Geo IPify geolocation information
- Async-first API
- `CancellationToken` support
- Built on `HttpClient`
- Uses `System.Text.Json`
- No unnecessary third-party runtime dependencies
- Designed for .NET 10

## Public IP Address

```csharp
using System.Net;
using neXn.Ipify;

using IpifyClient client = new();

IPAddress address = await client.GetPublicIPAddressAsync();

Console.WriteLine(address);
```

The universal ipify endpoint automatically returns the public IPv4 or IPv6 address used for the request.

## Geo IPify

Geo IPify requires an API key.

```csharp
using neXn.Ipify;

using IpifyClient client = new("<YOUR_API_KEY>");

IpifyGeoInformation information =
    await client.GetGeoInformationAsync(
        "8.8.8.8",
        IpifyClient.QueryType.IpAddress);

Console.WriteLine(information);
```

Supported query types:

```csharp
IpifyClient.QueryType.IpAddress
IpifyClient.QueryType.Email
IpifyClient.QueryType.Domain
```

If no query value is supplied, Geo IPify returns information for the address making the request:

```csharp
IpifyGeoInformation information =
    await client.GetGeoInformationAsync();
```

## About ipify

[ipify](https://www.ipify.org/) provides a simple public IP address API.

[Geo IPify](https://geo.ipify.org/) extends it with IP geolocation and related information.


## License

Licensed under the [MIT License](LICENSE).

## Disclaimer

This is an independent open-source project and is not affiliated with, endorsed by, or sponsored by ipify.
