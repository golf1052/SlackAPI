using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI.Events
{
    public class SlackEventWrapper
    {
        public string Token { get; set; }
        public string TeamId { get; set; }
        public string ApiAppId { get; set; }
        public JObject Event { get; set; }
        public string Type { get; set; }
        public string EventId { get; set; }
        public string EventTime { get; set; }
        public List<string> AuthedUsers { get; set; }
    }
}
