using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace golf1052.SlackAPI.Events
{
    public abstract class SlackEvent
    {
        public enum SlackEventType
        {
            Hello,
            Message,
            UserTyping,
            ChannelMarked,
            ChannelCreated,
            ChannelJoined,
            ChannelLeft,
            ChannelDeleted,
            ChannelRenamed,
            ChannelArchive,
            ChannelUnarchive,
            ChannelHistoryChanged,
            DndUpdated,
            DndUpdatedUser,
            ImCreated,
            ImOpen,
            ImClose,
            ImMarked,
            ImHistoryChanged,
            GroupJoined,
            GroupLeft,
            GroupOpen,
            GroupClose,
            GroupArchive,
            GroupUnarchive,
            GroupRename,
            GroupMarked,
            GroupHistoryChanged,
            FileCreated,
            FileShared,
            FileUnshared,
            FilePublic,
            FilePrivate,
            FileChange,
            FileDeleted,
            FileCommentAdded,
            FileCommentEdited,
            FileCommentDeleted,
            PinAdded,
            PinRemoved,
            PresenceChange,
            ManualPresenceChange,
            PrefChange,
            UserChange,
            TeamJoin,
            StarAdded,
            StarRemoved,
            ReactionAdded,
            ReactionRemoved,
            EmojiChanged,
            CommandsChanged,
            TeamPlanChange,
            TeamPrefChange,
            TeamRename,
            TeamDomainChange,
            EmailDomainChanged,
            TeamProfileChange,
            TeamProfileDelete,
            TeamProfileReorder,
            BotAdded,
            BotChanged,
            AccountsChanged,
            TeamMigrationStarted,
            ReconnectUrl,
            SubteamCreated,
            SubteamSelfAdded,
            SubteamSelfRemoved
        }

        public abstract SlackEventType Type { get; }
    }
}
