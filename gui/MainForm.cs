using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Http;
using Titanium.Web.Proxy.Models;

namespace gui
{
    public partial class MainForm : Form
    {
        private SessionListItem selectedSession;
        private int lastSessionNumber;
        private readonly Dictionary<HttpWebClient, SessionListItem> sessionDictionary = new Dictionary<HttpWebClient, SessionListItem>();

        public ProxyServer proxyServer;

        public MainForm()
        {
            InitializeComponent();

            //proxyServer = new ProxyServer("Test cert", "Test cert issuer");
            //proxyServer.ForwardToUpstreamGateway = true;
            //proxyServer.CertificateManager.EnsureRootCertificate(true, false);
            //var explicitEndpoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true);
            //proxyServer.AddEndPoint(explicitEndpoint);

            //proxyServer.BeforeRequest += ProxyServer_BeforeRequest;
            //proxyServer.BeforeResponse += ProxyServer_BeforeResponse;
            //proxyServer.AfterResponse += ProxyServer_AfterResponse;
            //explicitEndpoint.BeforeTunnelConnectRequest += ExplicitEndpoint_BeforeTunnelConnectRequest;
            //explicitEndpoint.BeforeTunnelConnectResponse += ExplicitEndpoint_BeforeTunnelConnectResponse;
            //proxyServer.ClientConnectionCountChanged += ProxyServer_ClientConnectionCountChanged;
            //proxyServer.ServerConnectionCountChanged += ProxyServer_ServerConnectionCountChanged;

            //proxyServer.Start();
            //proxyServer.SetAsSystemProxy(explicitEndpoint, ProxyProtocolType.AllHttp);
        }
        public ObservableCollectionEx<SessionListItem> Sessions { get; } = new ObservableCollectionEx<SessionListItem>();

        public void ProxyServer_ServerConnectionCountChanged(object sender, EventArgs e)
        {
            ServerConnectionCount = proxyServer.ServerConnectionCount;
        }

        public void ProxyServer_ClientConnectionCountChanged(object sender, EventArgs e)
        {
            ClientConnectionCount = proxyServer.ClientConnectionCount;
        }

        public async Task ExplicitEndpoint_BeforeTunnelConnectResponse(object sender, Titanium.Web.Proxy.EventArguments.TunnelConnectSessionEventArgs e)
        {
            await Task.Run(() =>
            {
                if (sessionDictionary.TryGetValue(e.HttpClient, out var item))
                {
                    item.Update(e);
                }
            });
        }

        public async Task ExplicitEndpoint_BeforeTunnelConnectRequest(object sender, Titanium.Web.Proxy.EventArguments.TunnelConnectSessionEventArgs e)
        {
            await Task.Run(() =>
            {
                addSession(e);
            });
        }

        public async Task ProxyServer_AfterResponse(object sender, Titanium.Web.Proxy.EventArguments.SessionEventArgs e)
        {
            await Task.Run(() =>
            {
                if (sessionDictionary.TryGetValue(e.HttpClient, out var item))
                {
                    item.Exception = e.Exception;
                }
            });
        }

        public async Task ProxyServer_BeforeResponse(object sender, Titanium.Web.Proxy.EventArguments.SessionEventArgs e)
        {
            SessionListItem item = null;
            if (sessionDictionary.TryGetValue(e.HttpClient, out item))
            {
                item.Update(e);
            }
            if (item != null)
            {
                if (e.HttpClient.Request.HasBody)
                {
                    e.HttpClient.Response.KeepBody = true;
                    await e.GetResponseBody();
                    item.Update(e);

                    if (item == SelectedSession)
                        selectedSessionChanged();
                }
            }
        }

        public async Task ProxyServer_BeforeRequest(object sender, Titanium.Web.Proxy.EventArguments.SessionEventArgs e)
        {
            SessionListItem item = addSession(e);

            if (e.HttpClient.Request.HasBody)
            {
                e.HttpClient.Request.KeepBody = true;
                byte[] data = await e.GetRequestBody();
                //if (e.HttpClient.Request.Url.Contains("vk.com"))
                //{
                //    var str = Encoding.UTF8.GetString(data);
                //    if (str.Contains("привет"))
                //    {
                //        str = str.Replace("привет", "пока");
                //        data = Encoding.UTF8.GetBytes(str);
                //        e.SetRequestBody(data);
                //    }
                //}

                item.Update(e);

                if (item == SelectedSession)
                    selectedSessionChanged();
            }
        }


        private int _clientConnectionCount = 0;
        public int ClientConnectionCount
        {
            get
            {
                return _clientConnectionCount;
            }
            set
            {
                _clientConnectionCount = value;
                clientConnectionCountLbl.Text = "Client connections: " + value;
            }
        }

        private int _serverConnectionCount = 0;
        public int ServerConnectionCount
        {
            get
            {
                return _serverConnectionCount;
            }
            set
            {
                _serverConnectionCount = value;
                serverConnectionCountLbl.Text = "Server connections: " + value;
            }
        }
        public SessionListItem SelectedSession
        {
            get => selectedSession;
            set
            {
                if (value != selectedSession)
                {
                    selectedSession = value;
                    selectedSessionChanged();
                }
            }
        }

        private void selectedSessionChanged()
        {
            if (SelectedSession == null)
            {
                requestTextbox.Text = string.Empty;
                responseTextbox.Text = string.Empty;
                return;
            }

            const int truncateLimit = 1024;

            var session = SelectedSession.HttpClient;
            var request = session.Request;
            var fullData = (request.IsBodyRead ? request.Body : null) ?? Array.Empty<byte>();
            var data = fullData;
            bool truncated = data.Length > truncateLimit;
            if (truncated)
            {
                data = data.Take(truncateLimit).ToArray();
            }

            //string hexStr = string.Join(" ", data.Select(x => x.ToString("X2")));
            var sb = new StringBuilder();
            sb.AppendLine("URI: " + request.RequestUri);
            sb.Append(request.HeaderText);
            sb.Append(request.Encoding.GetString(data));
            if (truncated)
            {
                sb.AppendLine();
                sb.Append($"Data is truncated after {truncateLimit} bytes");
            }

            sb.Append((request as ConnectRequest)?.ClientHelloInfo);
            requestTextbox.Text = sb.ToString();

            var response = session.Response;
            fullData = (response.IsBodyRead ? response.Body : null) ?? Array.Empty<byte>();
            data = fullData;
            truncated = data.Length > truncateLimit;
            if (truncated)
            {
                data = data.Take(truncateLimit).ToArray();
            }

            //hexStr = string.Join(" ", data.Select(x => x.ToString("X2")));
            sb = new StringBuilder();
            sb.Append(response.HeaderText);
            sb.Append(response.Encoding.GetString(data));
            if (truncated)
            {
                sb.AppendLine();
                sb.Append($"Data is truncated after {truncateLimit} bytes");
            }

            sb.Append((response as ConnectResponse)?.ServerHelloInfo);
            if (SelectedSession.Exception != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append(SelectedSession.Exception);
            }

            responseTextbox.Text = sb.ToString();
        }
        private SessionListItem addSession(SessionEventArgsBase e)
        {
            var item = createSessionListItem(e);
            Sessions.Add(item);
            Invoke((Action)(() => {
                dataGridView.Rows.Add(item.Number, item.StatusCode, item.Protocol, item.Host, item.Url, item.BodySize, item.Process);
            }));
            sessionDictionary.Add(e.HttpClient, item);
            return item;
        }

        private SessionListItem createSessionListItem(SessionEventArgsBase e)
        {
            lastSessionNumber++;
            bool isTunnelConnect = e is TunnelConnectSessionEventArgs;
            var item = new SessionListItem
            {
                Number = lastSessionNumber,
                ClientConnectionId = e.ClientConnectionId,
                ServerConnectionId = e.ServerConnectionId,
                HttpClient = e.HttpClient,
                ClientRemoteEndPoint = e.ClientRemoteEndPoint,
                ClientLocalEndPoint = e.ClientLocalEndPoint,
                IsTunnelConnect = isTunnelConnect
            };

            //if (isTunnelConnect || e.HttpClient.Request.UpgradeToWebSocket)
            e.DataReceived += (sender, args) =>
            {
                var session = (SessionEventArgsBase)sender;
                if (sessionDictionary.TryGetValue(session.HttpClient, out var li))
                {
                    var connectRequest = session.HttpClient.ConnectRequest;
                    var tunnelType = connectRequest?.TunnelType ?? TunnelType.Unknown;
                    if (tunnelType != TunnelType.Unknown)
                    {
                        li.Protocol = TunnelTypeToString(tunnelType);
                    }

                    li.ReceivedDataCount += args.Count;

                    //if (tunnelType == TunnelType.Http2)
                    //AppendTransferLog(session.GetHashCode() + (isTunnelConnect ? "_tunnel" : "") + "_received",
                        //args.Buffer, args.Offset, args.Count);
                }
            };

            e.DataSent += (sender, args) =>
            {
                var session = (SessionEventArgsBase)sender;
                if (sessionDictionary.TryGetValue(session.HttpClient, out var li))
                {
                    var connectRequest = session.HttpClient.ConnectRequest;
                    var tunnelType = connectRequest?.TunnelType ?? TunnelType.Unknown;
                    if (tunnelType != TunnelType.Unknown)
                    {
                        li.Protocol = TunnelTypeToString(tunnelType);
                    }

                    li.SentDataCount += args.Count;

                    //if (tunnelType == TunnelType.Http2)
                    //AppendTransferLog(session.GetHashCode() + (isTunnelConnect ? "_tunnel" : "") + "_sent",
                    //    args.Buffer, args.Offset, args.Count);
                }
            };

            if (e is TunnelConnectSessionEventArgs te)
            {
                te.DecryptedDataReceived += (sender, args) =>
                {
                    var session = (SessionEventArgsBase)sender;
                    //var tunnelType = session.HttpClient.ConnectRequest?.TunnelType ?? TunnelType.Unknown;
                    //if (tunnelType == TunnelType.Http2)
                    //AppendTransferLog(session.GetHashCode() + "_decrypted_received", args.Buffer, args.Offset,
                    //    args.Count);
                };

                te.DecryptedDataSent += (sender, args) =>
                {
                    var session = (SessionEventArgsBase)sender;
                    //var tunnelType = session.HttpClient.ConnectRequest?.TunnelType ?? TunnelType.Unknown;
                    //if (tunnelType == TunnelType.Http2)
                    //AppendTransferLog(session.GetHashCode() + "_decrypted_sent", args.Buffer, args.Offset, args.Count);
                };
            }

            item.Update(e);
            return item;
        }

        private string TunnelTypeToString(TunnelType tunnelType)
        {
            switch (tunnelType)
            {
                case TunnelType.Https:
                    return "https";
                case TunnelType.Websocket:
                    return "websocket";
                case TunnelType.Http2:
                    return "http2";
            }

            return null;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            SelectedSession = Sessions[dataGridView.SelectedRows[0].Index];
        }
    }
}
