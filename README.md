# SToolkit.Geoip
Easy usage api for ip-api.com

[![NuGet](https://img.shields.io/nuget/v/SToolkit.Geoip.svg)](https://www.nuget.org/packages/SToolkit.Geoip/)
## Why ip-api.com?
* Free
* No api key require
* Good limitations (150 requests per minute), more info about limitations [here](http://ip-api.com/docs/#usage_limits)

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
Set language
```C#
Geoip.Language = "ru";
```
Avalible languages
| en    | English (default)             |
|-------|-------------------------------|
| de    | Deutsch (German)              |
| es    | Español (Spanish)             |
| pt-BR | Español - Argentina (Spanish) |
| fr    | Français (French)             |
| ja    | 日本語 (Japanese)             |
| zh-CN | 中国 (Chinese)                |
| ru    | Русский (Russian)             |
Easy usage with domain
```C#
GeoipObject o = Geoip.Request("192.30.253.113");
```
or ip address
```C#
GeoipObject o = Geoip.Request("192.30.253.113");
```
or async method, if you using net 4.5+
```C#
var o = Geoip.RequestAsync("192.30.253.113");
```
Then if ```GeoipObject.Status == RequestState.Success``` we have all field in results, more info about field values [here](http://ip-api.com/docs/api:returned_values#successful_query)
```C#
string Country { get; set; }
string CountryCode { get; set; }
string Region { get; set; }
string RegionName { get; set; }
string City { get; set; }
int Zip { get; set; }
float Lat { get; set; }
float Lot { get; set; }
string Timezone { get; set; }
string Isp { get; set; }
string Org { get; set; }
string As { get; set; }
string IP { get; set; }
RequestState Status { get; set; }
string ErrorText { get; }
```
If you exceed limitations, you need manually unblock your ip [here](http://ip-api.com/docs/unban)
