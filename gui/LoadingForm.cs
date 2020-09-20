using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.Models;

namespace gui
{
    public partial class LoadingForm : Form
    {
        MainForm mainForm;
        ProxyServer proxyServer;
        ExplicitProxyEndPoint explicitEndpoint = null;

        public LoadingForm()
        {
            InitializeComponent();

            internalSetupLbl.CurrentStatus =
                detourLabel.CurrentStatus =
                certLabel.CurrentStatus =
                startProxyLbl.CurrentStatus =
                proxyStopLbl.CurrentStatus =
                listenLbl.CurrentStatus =
                certRemoveLbl.CurrentStatus = StatusLabel.Status.Disabled;
        }

        private void LoadingForm_Shown(object sender, EventArgs e)
        {
            internalSetupLbl.CurrentStatus = StatusLabel.Status.Current;
            mainForm = new MainForm();
            //explicitEndpoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true);
            explicitEndpoint = new ExplicitProxyEndPoint(IPAddress.Parse("127.0.0.1"), 8000, true);
            proxyServer = new ProxyServer("Test cert", "Test cert issuer");
            proxyServer.ForwardToUpstreamGateway = true;
            mainForm.proxyServer = proxyServer;
            proxyServer.AddEndPoint(explicitEndpoint);

            proxyServer.BeforeRequest += mainForm.ProxyServer_BeforeRequest;
            proxyServer.BeforeResponse += mainForm.ProxyServer_BeforeResponse;
            proxyServer.AfterResponse += mainForm.ProxyServer_AfterResponse;
            explicitEndpoint.BeforeTunnelConnectRequest += mainForm.ExplicitEndpoint_BeforeTunnelConnectRequest;
            explicitEndpoint.BeforeTunnelConnectResponse += mainForm.ExplicitEndpoint_BeforeTunnelConnectResponse;
            proxyServer.ClientConnectionCountChanged += mainForm.ProxyServer_ClientConnectionCountChanged;
            proxyServer.ServerConnectionCountChanged += mainForm.ProxyServer_ServerConnectionCountChanged;

            internalSetupLbl.CurrentStatus = StatusLabel.Status.Done;

            injectDetour();
        }

        private void injectDetour()
        {
            detourLabel.CurrentStatus = StatusLabel.Status.Current;
            bool status = false;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                string injector = Path.Combine(path, "Injector.exe");
                string dll = Path.Combine(path, "MessageBoxHook.dll");
                int pid = Process.GetCurrentProcess().Id;
                ProcessStartInfo process = new ProcessStartInfo(injector, pid + " \"" + dll + "\"");
                process.CreateNoWindow = true;
                process.WindowStyle = ProcessWindowStyle.Hidden;
                process.UseShellExecute = true;
                var proc = Process.Start(process);
                proc.WaitForExit();
            }
            catch { }
            status = MessageBox.Show("If everything is fine, you should not see this message box.", "Detour test", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question) == DialogResult.Yes;
            if (status)
                detourLabel.CurrentStatus = StatusLabel.Status.Success;
            else detourLabel.CurrentStatus = StatusLabel.Status.Danger;

            installCerts();
        }

        private void installCerts()
        {
            certLabel.CurrentStatus = StatusLabel.Status.Current;
            proxyServer.CertificateManager.EnsureRootCertificate(true, false);
            certLabel.CurrentStatus = StatusLabel.Status.Done;

            startProxy();
        }

        private void startProxy()
        {
            startProxyLbl.CurrentStatus = StatusLabel.Status.Current;
            proxyServer.Start();
            proxyServer.SetAsSystemProxy(explicitEndpoint, ProxyProtocolType.AllHttp);
            startProxyLbl.CurrentStatus = StatusLabel.Status.Done;

            listen();
        }

        private void listen()
        {
            listenLbl.CurrentStatus = StatusLabel.Status.Current;

            TopMost = false;
            mainForm.Show();
            mainForm.FormClosed += (s, e) =>
            {
                TopMost = true;
                listenLbl.CurrentStatus = StatusLabel.Status.Done;
                stopProxy();
            };
        }
        private void stopProxy()
        {
            proxyStopLbl.CurrentStatus = StatusLabel.Status.Current;
            proxyServer.RestoreOriginalProxySettings();
            proxyServer.Stop();
            proxyStopLbl.CurrentStatus = StatusLabel.Status.Done;
            removeCertificates();
        }

        private void removeCertificates()
        {
            certRemoveLbl.CurrentStatus = StatusLabel.Status.Current;
            proxyServer.CertificateManager.RemoveTrustedRootCertificate();
            certRemoveLbl.CurrentStatus = StatusLabel.Status.Done;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 100;
            ControlBox = true;
        }

        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ControlBox;
        }
    }
}
