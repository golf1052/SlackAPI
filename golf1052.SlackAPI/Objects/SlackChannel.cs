using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using golf1052.SlackAPI.Converters;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.Objects
{
    public class SlackChannel
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("is_channel")]
        public bool Channel { get; private set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Created { get; private set; }

        [JsonProperty("creator")]
        public string Creator { get; private set; }

        [JsonProperty("is_archived")]
        public bool Archived { get; private set; }

        [JsonProperty("is_general")]
        public bool General { get; private set; }

        [JsonProperty("members")]
        public List<string> Members { get; private set; }

        [JsonProperty("topic")]
        public SlackChannelTopic Topic { get; private set; }

        [JsonProperty("purpose")]
        public SlackChannelPurpose Purpose { get; private set; }

        [JsonProperty("num_members")]
        public int NumMembers { get; private set; }

        [JsonProperty("user")]
        public string User { get; private set; }
    }
}
