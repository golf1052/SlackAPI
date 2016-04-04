using System;
using golf1052.SlackAPI.Converters;
using Newtonsoft.Json;

namespace golf1052.SlackAPI
{
    public class SlackChannelTopic
    {
        [JsonProperty("value")]
        public string Value { get; private set; }

        [JsonProperty("creator")]
        public string Creator { get; private set; }

        [JsonProperty("last_set")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime LastSet { get; private set; }
    }
}