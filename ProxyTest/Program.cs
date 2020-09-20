using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProxyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create("https://duos.apphb.com/tomtom/add?q=test");
                r.Proxy = new WebProxy("127.0.0.1", 8081);
                r.GetResponse();
                Console.WriteLine("Sent");
                Console.ReadLine();
            }
        }
    }
}
