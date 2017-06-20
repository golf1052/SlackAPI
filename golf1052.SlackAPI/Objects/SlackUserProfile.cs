using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI.Objects
{
    public class SlackUserProfile
    {
        [JsonProperty("first_name")]
        public string FirstName { get; private set; }

        [JsonProperty("last_name")]
        public string LastName { get; private set; }

        [JsonIgnore]
        public Dictionary<string, Uri> Images { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("real_name")]
        public string RealName { get; private set; }

        [JsonProperty("real_name_normalized")]
        public string RealNameNormalized { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("skype")]
        public string Skype { get; private set; }

        [JsonProperty("phone")]
        public string Phone { get; private set; }

        [JsonProperty("status_emoji")]
        public string StatusEmoji { get; private set; }

        [JsonProperty("status_text")]
        public string StatusText { get; private set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; private set; }
        
        public SlackUserProfile()
        {
            Images = new Dictionary<string, Uri>();
        } 

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            foreach (KeyValuePair<string, JToken> rest in AdditionalData)
            {
                if (rest.Key.StartsWith("image"))
                {
                    Images.Add(rest.Key, new Uri((string)rest.Value));
                }
            }
        }
    }
}