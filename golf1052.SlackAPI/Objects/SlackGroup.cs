using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using golf1052.SlackAPI.Converters;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.Objects
{
    public class SlackGroup
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("is_group")]
        public bool Group { get; private set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Created { get; private set; }

        [JsonProperty("creator")]
        public string Creator { get; private set; }

        [JsonProperty("is_archived")]
        public bool Archived { get; private set; }

        [JsonProperty("is_mpim")]
        public bool Mpim { get; private set; }

        [JsonProperty("members")]
        public IList<string> Members { get; private set; }

        [JsonProperty("topic")]
        public SlackChannelTopic Topic { get; private set; }

        [JsonProperty("purpose")]
        public SlackChannelPurpose Purpose { get; private set; }

        [JsonProperty("last_read")]
        public DateTime? LastRead { get; private set; }

        // [JsonProperty("latest")]
        // public SlackMessage Latest { get; private set; }

        [JsonProperty("unread_count")]
        public int UnreadCount { get; private set; }

        [JsonProperty("unread_count_display")]
        public int UnreadCountDisplay { get; private set; }
    }
}
