using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static readonly TcpListener Listener = new TcpListener(IPAddress.Any, 8000);
        static void Main(string[] args)
        {
            Console.WriteLine("Starting proxy");
            Listener.Start();
            new Task(() =>
            {
                while (true)
                {
                    var client = Listener.AcceptTcpClient();
                    new Task(() => ProcessClient(client)).Start();
                }
            }).Start();
            Console.WriteLine("Server listening on port 8000. Press enter to exit.");
            Console.ReadLine();
            Listener.Stop();
        }

        static void ProcessClient(TcpClient client)
        {
        }
    }
}
