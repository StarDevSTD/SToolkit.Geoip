# SToolkit.Geoip
Easy usage geo ip api provided by ip-api.com

### Why ip-api.com?
* Free
* No api key needed
* Good limitations (150 requests rep seconds), more info about limits [here](http://ip-api.com/docs/#usage_limits)

[![NuGet](https://img.shields.io/nuget/v/SToolkit.Geoip.svg)](https://www.nuget.org/packages/SToolkit.Geoip/)
# Install
[Nuget Package](https://www.nuget.org/packages/SToolkit.Geoip/)

Or Nuget console
```
Install-Package SToolkit.Geoip
```
# Examples
[#1](https://github.com/StarDevSTD/SToolkit.Geoip/blob/master/SToolkit.Geoip.DemoAppNet40/Program.cs)
[#2](https://github.com/StarDevSTD/SToolkit.Geoip/blob/master/SToolkit.Geoip.DemoAppNet45/Program.cs)

# Usage
Including
```C#
using SToolkit.Geoip;
```
Query domain
```C#
GeoipObject o = Geoip.RequestAsync("github.com");
```
or ip
```C#
GeoipObject o = Geoip.RequestAsync("192.30.253.112");
```
All ```GeoipObject``` fields, more info about this you can find in [ip-api.com help](http://ip-api.com/docs/api:returned_values#successful_query)
```C#
public string Country { get; set; }
public string CountryCode { get; set; }
public string Region { get; set; }
public string RegionName { get; set; }
public string City { get; set; }
public int Zip { get; set; }
public float Lat { get; set; }
public float Lot { get; set; }
public string Timezone { get; set; }
public string Isp { get; set; }
public string Org { get; set; }
public string As { get; set; }
public string IP { get; set; }
public RequestState Status { get; set; }
public ErrorText { get; }
```
