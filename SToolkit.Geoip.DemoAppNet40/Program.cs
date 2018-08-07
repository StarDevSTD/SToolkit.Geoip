using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SToolkit.Geoip.DemoAppNet40
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = Geoip.Request("github.com");
            Console.WriteLine(o.Country);
        }
    }
}
