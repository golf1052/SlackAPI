using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Windows.Networking.Sockets;

namespace golf1052.SlackAPI.Universal
{
    public class SlackRTMClient : SlackRTMClientBase
    {
        private MessageWebSocket webSocket;

        public SlackRTMClient() : base()
        {
        }
        protected override async Task ConnectSocket(string socketUrl)
        {
            webSocket = new MessageWebSocket();
            webSocket.Control.MessageType = SocketMessageType.Utf8;
            webSocket.MessageReceived += WebSocket_MessageReceived;
            await webSocket.ConnectAsync(new Uri(socketUrl));
            Writer = new StreamWriter(webSocket.OutputStream.AsStreamForWrite(), System.Text.Encoding.UTF8);
        }

        private async void WebSocket_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
        {
            StreamReader reader = new StreamReader(args.GetDataStream().AsStreamForRead(), System.Text.Encoding.UTF8);
            SocketMessageRecieved(await reader.ReadToEndAsync());
        }

        public override Task Disconnect()
        {
            throw new NotImplementedException();
        }

        
    }
}
