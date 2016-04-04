using System.Collections.Generic;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.Other
{
    public class Reaction
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("count")]
        public int Count { get; private set; }

        [JsonProperty("users")]
        public List<string> Users { get; private set; }
    }
}
