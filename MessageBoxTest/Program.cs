using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace MessageBoxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Initializing hook..");
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string injector = Path.Combine(path, "Injector.exe");
            //string dll = Path.Combine(path, "MessageBoxHook.dll");
            //int pid = Process.GetCurrentProcess().Id;
            //ProcessStartInfo process = new ProcessStartInfo(injector, pid + " \"" + dll + "\"");
            //process.CreateNoWindow = true;
            //process.WindowStyle = ProcessWindowStyle.Hidden;
            //process.UseShellExecute = true;
            //var proc = Process.Start(process);
            //proc.WaitForExit();
            //Console.WriteLine("Hook created.");
            Console.ReadLine();
            DialogResult result = MessageBox.Show("Text", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
    }
}
