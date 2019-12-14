Imports System.Net
Imports Newtonsoft.Json
Public Class Ipify
    Private Const ipifyAdress As String = "http://api.ipify.org"
    Private Const ipifyAdressSecure As String = "https://api.ipify.org"
    Private Const ipifyAdressv6 As String = "http://api6.ipify.org"
    Private Const ipifyAdressv6Secure As String = "https://api6.ipify.org"
    Public Shared Function GetPublicIPAddress(ByVal Optional useHttps As Boolean = True) As System.Net.IPAddress
        Using wC As WebClient = New WebClient
            GetPublicIPAddress = IPAddress.Parse(wC.DownloadString(If(useHttps, ipifyAdressSecure, ipifyAdress)))
        End Using
    End Function
    Public Shared Function GetPublicAddress(ByVal Optional useHttps As Boolean = True) As String
        Using wC As WebClient = New WebClient
            GetPublicAddress = wC.DownloadString(If(useHttps, ipifyAdressSecure, ipifyAdress))
        End Using
    End Function

    Public Shared Function GetPublicIPv6Address(ByVal Optional useHttps As Boolean = True) As System.Net.IPAddress
        Using wC As WebClient = New WebClient
            GetPublicIPv6Address = IPAddress.Parse(wC.DownloadString(If(useHttps, ipifyAdressv6Secure, ipifyAdressv6)))
        End Using
    End Function
    Public Shared Function GetPublicv6Address(ByVal Optional useHttps As Boolean = True) As String
        Using wC As WebClient = New WebClient
            GetPublicv6Address = wC.DownloadString(If(useHttps, ipifyAdressv6Secure, ipifyAdressv6))
        End Using
    End Function

    Public Class GeoIPLocation
        Public Shared Property APIKey As String = Nothing
        Private Const ipifyAddress As String = "https://geo.ipify.org/api/v1?apiKey={0}&ipAddress={1}"
        Public Shared Function GetInformation(ByVal ipAddress As String) As IpifyGeoInformation
            Dim acc As IpifyGeoInformation = New IpifyGeoInformation
            Using wC As WebClient = New WebClient
                acc = JsonConvert.DeserializeObject(Of IpifyGeoInformation)(wC.DownloadString(String.Format(ipifyAddress, APIKey, ipAddress)))
            End Using

            Return acc
        End Function

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