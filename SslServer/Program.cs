using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MITMProxy
{
    class Program
    {

        static readonly TcpListener Listener = new TcpListener(IPAddress.Any, 4520);
        const int BufferSize = 4096;

        static void Main()
        {
            Listener.Start();
            new Task(() =>
            {
                while (true)
                {
                    var client = Listener.AcceptTcpClient();
                    new Task(() => AcceptConnection(client)).Start();
                }
            }).Start();
            Debug.WriteLine("Server listening on port 4502.  Press enter to exit.");
            Console.ReadLine();
            Listener.Stop();
        }

        private static void AcceptConnection(TcpClient client)
        {
            try
            {
                var certificate = new X509Certificate("SslServer.cer", "123");
                var clientStream = new SslStream(client.GetStream(), false);
                clientStream.AuthenticateAsServer(certificate, false, System.Security.Authentication.SslProtocols.Default, false);

                var server = new TcpClient("200.26.205.63", 4520);
                var serverSslStream = new SslStream(server.GetStream(), false, SslValidationCallback, null);
                serverSslStream.AuthenticateAsClient("lb3.playdata.co.uk");

                new Task(() => ReadFromClient(client, clientStream, serverSslStream)).Start();
                new Task(() => ReadFromServer(serverSslStream, clientStream)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        private static bool SslValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            return true;
        }

        private static void ReadFromServer(Stream serverStream, Stream clientStream)
        {
            var message = new byte[BufferSize];
            while (true)
            {
                int serverBytes;
                try
                {
                    serverBytes = serverStream.Read(message, 0, BufferSize);
                    clientStream.Write(message, 0, serverBytes);
                }
                catch
                {
                    break;
                }
                if (serverBytes == 0)
                {
                    break;
                }
            }
        }

        private static void ReadFromClient(TcpClient client, Stream clientStream, Stream serverStream)
        {
            var message = new byte[BufferSize];
            var fileInfo = new FileInfo("client");
            if (!fileInfo.Exists)
                fileInfo.Create().Dispose();
            using (var stream = fileInfo.OpenWrite())
            {
                while (true)
                {
                    int clientBytes;
                    try
                    {
                        clientBytes = clientStream.Read(message, 0, BufferSize);
                    }
                    catch
                    {
                        break;
                    }
                    if (clientBytes == 0)
                    {
                        break;
                    }
                    serverStream.Write(message, 0, clientBytes);
                    //memoryStream.Write(message, 0, clientBytes);
                    stream.Write(message, 0, clientBytes);

                }
                client.Close();
            }
        }
    }
}
