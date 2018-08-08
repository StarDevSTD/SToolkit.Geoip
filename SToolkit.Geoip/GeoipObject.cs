namespace SToolkit.Geoip
{
    public class GeoipObject
    {
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

        public string ErrorText
        {
            get
            {
                switch (Status)
                {
                    case RequestState.FailedBadIp:
                        return "Invalid IP address or domain name";
                    case RequestState.FailedPrivateIp:
                        return "IP address is part of a private range";
                    case RequestState.FailedReservedIp:
                        return "IP address is part of a reserved range";
                    case RequestState.FailedQuota:
                        return "Over quota (150 req per min), for unlock your ip visit - http://ip-api.com/docs/unban";
                    default:
                        return "Unknown error";
                }
            }
        }

        public static RequestState StateByError(string text)
        {
            text = text.ToLower();
            switch (text)
            {
                case string s when s.Contains("invalid"):
                    return RequestState.FailedBadIp;
                case string s when s.Contains("private range"):
                    return RequestState.FailedPrivateIp;
                case string s when s.Contains("reserved range"):
                    return RequestState.FailedReservedIp;
                case string s when s.Contains("quota"):
                    return RequestState.FailedQuota;
                default:
                    return RequestState.Success;
            }
        }

        public static GeoipObject Deserialize(string data)
        {
            string[] array = data.Split(',');
            if (data.StartsWith("success") && array.Length > 10)
            {
                return new GeoipObject()
                {
                    Status = RequestState.Success,
                    Country = array[1],
                    CountryCode = array[2],
                    Region = array[3],
                    RegionName = array[4],
                    City = array[5],
                    Zip = array[6].Length > 0 ? int.Parse(array[6]) : 0,
                    Lat = array[7].Length > 0 ? float.Parse(array[7].Replace(".", ",")) : 0,
                    Lot = array[8].Length > 0 ? float.Parse(array[8].Replace(".", ",")) : 0,
                    Timezone = array[9],
                    Isp = array[10],
                    Org = array[11],
                    As = array[12],
                    IP = array[13]
                };
            }
            else
            {
                return new GeoipObject()
                {
                    Status = StateByError(array[1]),
                    IP = array[2]
                };
            }
        }
    }
}
