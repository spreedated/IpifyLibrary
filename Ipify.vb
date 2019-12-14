﻿Imports System.Net
Imports Newtonsoft.Json
Public Class Ipify
    Private Const ipifyAdress As String = "http://api.ipify.org"
    Private Const ipifyAdressSecure As String = "https://api.ipify.org"
    Private Const ipifyAdressv6 As String = "http://api6.ipify.org"
    Private Const ipifyAdressv6Secure As String = "https://api6.ipify.org"

    ''' <summary>
    ''' Get public IPv4 Address as System.Net.IPAddress
    ''' </summary>
    ''' <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
    ''' <returns>System.Net.IPAddress</returns>
    Public Shared Function GetPublicIPAddress(ByVal Optional useHttps As Boolean = True) As System.Net.IPAddress
        Using wC As WebClient = New WebClient
            GetPublicIPAddress = IPAddress.Parse(wC.DownloadString(If(useHttps, ipifyAdressSecure, ipifyAdress)))
        End Using
    End Function

    ''' <summary>
    ''' Get public IPv4 Address as String
    ''' </summary>
    ''' <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
    ''' <returns>ex. 127.0.0.1</returns>
    Public Shared Function GetPublicAddress(ByVal Optional useHttps As Boolean = True) As String
        Using wC As WebClient = New WebClient
            GetPublicAddress = wC.DownloadString(If(useHttps, ipifyAdressSecure, ipifyAdress))
        End Using
    End Function

    ''' <summary>
    ''' Get public IPv6 Address as System.Net.IPAddress
    ''' </summary>
    ''' <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
    ''' <returns>System.Net.IPAddress</returns>
    Public Shared Function GetPublicIPv6Address(ByVal Optional useHttps As Boolean = True) As System.Net.IPAddress
        Using wC As WebClient = New WebClient
            GetPublicIPv6Address = IPAddress.Parse(wC.DownloadString(If(useHttps, ipifyAdressv6Secure, ipifyAdressv6)))
        End Using
    End Function

    ''' <summary>
    ''' Get public IPv6 Address as String
    ''' </summary>
    ''' <param name="useHttps">Using SSL path of ipify.org (HTTPS)</param>
    ''' <returns>ex. fe80::1</returns>
    Public Shared Function GetPublicv6Address(ByVal Optional useHttps As Boolean = True) As String
        Using wC As WebClient = New WebClient
            GetPublicv6Address = wC.DownloadString(If(useHttps, ipifyAdressv6Secure, ipifyAdressv6))
        End Using
    End Function

    ''' <summary>
    ''' Main Class of Geolocation Informmation <br/>
    ''' Instance this with APIKey as String
    ''' </summary>
    Public Class GeoIPLocation
        ''' <summary>
        ''' Main Class of Geolocation Informmation <br/>
        ''' Instance this with APIKey as String
        ''' </summary>
        ''' <returns></returns>
        Public Property APIKey As String = Nothing
        Private Const ipifyAddress As String = "https://geo.ipify.org/api/v1?apiKey={0}&{1}={2}"

        Public Enum QueryType
            ipAddress
            email
            domain
        End Enum

        ''' <summary>
        ''' Main Function <br/>
        ''' Be sure to set your API-Key first!
        ''' </summary>
        ''' <param name="QueryValue">What you want to query, usually an IP address</param>
        ''' <param name="[QueryType]">Typically an ipaddress, but also able to query a domain or email</param>
        ''' <returns></returns>
        Public Function GetInformation(ByVal QueryValue As String, ByVal Optional [QueryType] As QueryType = QueryType.ipAddress) As IpifyGeoInformation
            Dim acc As IpifyGeoInformation = New IpifyGeoInformation
            Using wC As WebClient = New WebClient
                acc = JsonConvert.DeserializeObject(Of IpifyGeoInformation)(wC.DownloadString(String.Format(ipifyAddress, APIKey, [Enum].GetName(GetType(QueryType), QueryType), QueryValue)))
            End Using

            Return acc
        End Function

        ''' <summary>
        ''' Object of JSON deserialization
        ''' </summary>
        Public Class IpifyGeoInformation
            Public Property Location As IpifyLocation
            Public Property Domains As String()
            Public Property [As] As IpifyAs
            Public Property ISP As String

            Public Class IpifyLocation
                Public Property Country As String
                Public Property Region As String
                Public Property City As String
                Public Property Lat As Double
                Public Property Lng As Double
                Public Property Postalcode As String
                Public Property Timezone As String
                Public Property GeonameID As Long
            End Class
            Public Class IpifyAs
                Public Property Asn As Integer
                Public Property Name As String
                Public Property Route As String
                Public Property Domain As String
                Public Property Type As String
            End Class
        End Class
    End Class
End Class