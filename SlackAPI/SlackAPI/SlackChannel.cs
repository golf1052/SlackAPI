using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI
{
    public class SlackChannel
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool Channel { get; private set; }
        public DateTime Created { get; private set; }
        public SlackUser Creator { get; private set; }
        public bool Archived { get; private set; }
        public bool General { get; private set; }
        public bool Pins { get; private set; }
        public List<SlackUser> Members { get; private set; }
        public Tuple<string, SlackUser, DateTime> Topic { get; private set; }
        public Tuple<string, SlackUser, DateTime> Purpose { get; private set; }
        public bool Member { get; private set; }
        public DateTime LastRead { get; private set; }
        // Latest
        public int UnreadCount { get; private set; }
        public int UnreadCountDisplay { get; private set; }

        public SlackChannel(JObject o)
        {
            Id = (string)o["id"];
            Name = (string)o["name"];
            Channel = (bool)o["is_channel"];
            Created = HelperMethods.EpochToDateTime((long)o["created"]);
            // Creator
            Archived = (bool)o["is_archived"];
            General = (bool)o["is_general"];
            if (o["has_pins"] != null)
            {
                Pins = (bool)o["has_pins"];
            }
            // Members
        }
    }
}
