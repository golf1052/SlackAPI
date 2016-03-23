using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI.Objects
{
    public class SlackUser
    {   
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("team_id")]
        public string TeamId { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("deleted")]
        public bool Deleted { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }
        
        [JsonProperty("color")]
        public string Color { get; private set; }
        
        [JsonProperty("real_name")]
        public string RealName { get; private set; }

        [JsonProperty("tz")]
        public string TimeZone { get; private set; }

        [JsonProperty("tz_label")]
        public string TimeZoneLabel { get; private set; }

        [JsonProperty("tz_offset")]
        public int TimeZoneOffset { get; private set; }
        
        [JsonProperty("profile")]
        public SlackUserProfile Profile { get; private set; }
        
        [JsonProperty("is_admin")]
        public bool Admin { get; private set; }
        
        [JsonProperty("is_owner")]
        public bool Owner { get; private set; }
        
        [JsonProperty("is_primary_owner")]
        public bool PrimaryOwner { get; private set; }
        
        [JsonProperty("is_restricted")]
        public bool Restricted { get; private set; }
        
        [JsonProperty("is_ultra_restricted")]
        public bool UltraRestricted { get; private set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; private set; }
    }
}