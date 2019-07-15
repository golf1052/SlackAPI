using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.Converters;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.Objects
{
    public class SlackConversation
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("user")]
        public string User { get; private set; }

        [JsonProperty("is_channel")]
        public bool IsChannel { get; private set; }

        [JsonProperty("is_group")]
        public bool IsGroup { get; private set; }

        [JsonProperty("is_im")]
        public bool IsIm { get; private set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Created { get; private set; }

        [JsonProperty("creator")]
        public string Creator { get; private set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; private set; }

        [JsonProperty("is_general")]
        public bool IsGeneral { get; private set; }

        [JsonProperty("unlinked")]
        public int Unlinked { get; private set; }

        [JsonProperty("name_normalized")]
        public string NameNormalized { get; private set; }

        [JsonProperty("is_read_only")]
        public bool IsReadOnly { get; private set; }

        [JsonProperty("is_shared")]
        public bool IsShared { get; private set; }

        [JsonProperty("is_ext_shared")]
        public bool IsExtShared { get; private set; }

        [JsonProperty("is_org_shared")]
        public bool IsOrgShared { get; private set; }

        [JsonProperty("is_member")]
        public bool IsMember { get; private set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; private set; }

        [JsonProperty("is_mpim")]
        public bool IsMpim { get; private set; }

        [JsonProperty("last_read")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime LastRead { get; private set; }

        [JsonProperty("num_members")]
        public int NumMembers { get; private set; }

        [JsonProperty("locale")]
        public string Locale { get; private set; }
    }
}
