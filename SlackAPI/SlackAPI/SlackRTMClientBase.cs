using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI
{
    public abstract class SlackRTMClientBase
    {
        public enum ConnectionStates
        {
            Disconnected,
            Connecting,
            Connected
        }

        public ConnectionStates connectionState;
        public ConnectionStates ConnectionState
        {
            get
            {
                return connectionState;
            }
            protected internal set
            {
                if (connectionState != value)
                {
                    connectionState = value;
                    // some kind of event here
                }
                connectionState = value;
            }
        }
        protected internal StreamWriter Writer { get; set; }

        public SlackRTMClientBase()
        {
            connectionState = ConnectionStates.Disconnected;
        }

        public async Task Connect(string accessToken,
            bool simpleLatest = false,
            bool noUnreads = false,
            bool mpimAware = false)
        {
            ConnectionState = ConnectionStates.Connecting;
            string startString = SlackConstants.SlackBaseUrl + "rtm.start?token=" + accessToken;
            if (simpleLatest)
            {
                startString += "&simple_latest=true";
            }
            if (noUnreads)
            {
                startString += "&no_unreads=true";
            }
            if (mpimAware)
            {
                startString += "&mpim_aware=true";
            }
            Uri startUrl = new Uri(startString);
            DateTime initialConnectionTime = DateTime.UtcNow;
            bool connected = false;
            JObject responseObject = null;
            do
            {
                responseObject = await HelperMethods.GetWebData(startUrl);
                if ((bool)responseObject["ok"])
                {
                    connected = true;
                    break;
                }
                else
                {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
            }
            while (DateTime.UtcNow - initialConnectionTime < TimeSpan.FromSeconds(30));

            if (!connected)
            {
                throw new SlackException("Could not connect to Slack");
            }
            string socketUrl = (string)responseObject["url"];
            await ConnectSocket(socketUrl);
        }

        protected internal abstract Task ConnectSocket(string socketUrl);

        public abstract Task Disconnect();

        protected internal void SocketMessageRecieved(string responseString)
        {
            JObject responseObject = JObject.Parse(responseString);
        }
    }
}
