using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using golf1052.SlackAPI.Converters;
using golf1052.SlackAPI.Other;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI.Events
{
    public class SlackMessage : SlackEvent
    {
        public enum Subtypes
        {
            BotMessage,
            MeMessage,
            MessageChanged,
            MessageDeleted,
            ChannelJoin,
            ChannelLeave,
            ChannelTopic,
            ChannelPurpose,
            ChannelName,
            ChannelArchive,
            ChannelUnarchive,
            GroupJoin,
            GroupLeave,
            GroupTopic,
            GroupPurpose,
            GroupName,
            GroupArchive,
            GroupUnarchive,
            FileShare,
            FileComment,
            FileMention,
            PinnedItem,
            UnpinnedItem,
            Unknown
        }

        public override SlackEventType Type { get { return SlackEventType.Message; } }

        [JsonProperty("channel")]
        public string Channel { get; private set; }

        [JsonProperty("user")]
        public string User { get; private set; }

        [JsonProperty("bot_id")]
        public string BotId { get; private set; }

        [JsonProperty("text")]
        public string Text { get; private set; }

        [JsonProperty("ts")]
        public string Timestamp { get; private set; }

        [JsonProperty("thread_ts")]
        public string ThreadTimestamp { get; private set; }

        [JsonProperty("subtype")]
        public string Subtype { get; private set; }

        public Subtypes SubtypeEnum { get; private set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; private set; }

        [JsonProperty("is_starred")]
        public bool Starred { get; private set; }

        [JsonProperty("pinned_to")]
        public List<string> PinnedTo { get; private set; }

        [JsonProperty("reactions")]
        public List<Reaction> Reactions { get; private set; }

        [JsonProperty("message")]
        public SlackMessage Message { get; private set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; private set; }

        public SlackMessage()
        {
            Reactions = new List<Reaction>();
            Attachments = new List<Attachment>();
        }

        public static Subtypes StringToMessageSubtype(string subtype)
        {
            if (subtype == "bot_message")
            {
                return Subtypes.BotMessage;
            }
            else if (subtype == "me_message")
            {
                return Subtypes.MeMessage;
            }
            else if (subtype == "message_changed")
            {
                return Subtypes.MessageChanged;
            }
            else if (subtype == "message_deleted")
            {
                return Subtypes.MessageDeleted;
            }
            else if (subtype == "channel_join")
            {
                return Subtypes.ChannelJoin;
            }
            else if (subtype == "channel_leave")
            {
                return Subtypes.ChannelLeave;
            }
            else if (subtype == "channel_topic")
            {
                return Subtypes.ChannelTopic;
            }
            else if (subtype == "channel_purpose")
            {
                return Subtypes.ChannelPurpose;
            }
            else if (subtype == "channel_name")
            {
                return Subtypes.ChannelName;
            }
            else if (subtype == "channel_archive")
            {
                return Subtypes.ChannelArchive;
            }
            else if (subtype == "channel_unarchive")
            {
                return Subtypes.ChannelUnarchive;
            }
            else if (subtype == "group_join")
            {
                return Subtypes.GroupJoin;
            }
            else if (subtype == "group_leave")
            {
                return Subtypes.GroupLeave;
            }
            else if (subtype == "group_topic")
            {
                return Subtypes.GroupTopic;
            }
            else if (subtype == "group_purpose")
            {
                return Subtypes.GroupPurpose;
            }
            else if (subtype == "group_name")
            {
                return Subtypes.GroupName;
            }
            else if (subtype == "group_archive")
            {
                return Subtypes.GroupArchive;
            }
            else if (subtype == "group_unarchive")
            {
                return Subtypes.GroupUnarchive;
            }
            else if (subtype == "file_share")
            {
                return Subtypes.FileShare;
            }
            else if (subtype == "file_comment")
            {
                return Subtypes.FileComment;
            }
            else if (subtype == "file_mention")
            {
                return Subtypes.FileMention;
            }
            else if (subtype == "pinned_item")
            {
                return Subtypes.PinnedItem;
            }
            else if (subtype == "unpinned_item")
            {
                return Subtypes.UnpinnedItem;
            }
            else
            {
                return Subtypes.Unknown;
            }
        }
    }
}
