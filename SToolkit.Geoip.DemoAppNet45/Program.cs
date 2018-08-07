using System;

namespace SToolkit.Geoip.DemoAppNet45
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = Geoip.RequestAsync("192.30.253.112");
            if (o.Result.Status != RequestState.Success)
                Console.WriteLine(o.Result.ErrorText);
            Console.WriteLine(o.Result.Org);
            Console.WriteLine(o.Result.Country);
        }
    }
}
