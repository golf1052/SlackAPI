using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace golf1052.SlackAPI
{
    public static class SlackConstants
    {
        public const string BaseUrl = "https://slack.com/api/";

        public enum SlackScope
        {
            ChannelsWrite,
            ChannelsHistory,
            ChannelsRead,
            ChatWriteUser,
            ChatWriteBot,
            DndWrite,
            DndRead,
            EmojiRead,
            FilesWriteUser,
            FilesRead,
            GroupsWrite,
            GroupsHistory,
            GroupsRead,
            ImWrite,
            ImHistory,
            ImRead,
            MpimWrite,
            MpimHistory,
            MpimRead,
            PinsWrite,
            PinsRead,
            ReactionsWrite,
            ReactionsRead,
            SearchRead,
            StarsWrite,
            StarsRead,
            TeamRead,
            UsergroupsWrite,
            UsergroupsRead,
            UsersRead,
            UsersWrite,
            Unknown
        }

        public static string SlackScopeToString(this SlackScope slackScope)
        {
            if (slackScope == SlackScope.ChannelsWrite)
            {
                return "channels:write";
            }
            else if (slackScope == SlackScope.ChannelsHistory)
            {
                return "channels:history";
            }
            else if (slackScope == SlackScope.ChannelsRead)
            {
                return "channels:read";
            }
            else if (slackScope == SlackScope.ChatWriteUser)
            {
                return "chat:write:user";
            }
            else if (slackScope == SlackScope.ChatWriteBot)
            {
                return "chat:write:bot";
            }
            else if (slackScope == SlackScope.DndWrite)
            {
                return "dnd:write";
            }
            else if (slackScope == SlackScope.DndRead)
            {
                return "dnd:read";
            }
            else if (slackScope == SlackScope.EmojiRead)
            {
                return "emoji:read";
            }
            else if (slackScope == SlackScope.FilesWriteUser)
            {
                return "files:write:user";
            }
            else if (slackScope == SlackScope.FilesRead)
            {
                return "files:read";
            }
            else if (slackScope == SlackScope.GroupsWrite)
            {
                return "groups:write";
            }
            else if (slackScope == SlackScope.GroupsHistory)
            {
                return "groups:history";
            }
            else if (slackScope == SlackScope.GroupsRead)
            {
                return "groups:read";
            }
            else if (slackScope == SlackScope.ImWrite)
            {
                return "im:write";
            }
            else if (slackScope == SlackScope.ImHistory)
            {
                return "im:history";
            }
            else if (slackScope == SlackScope.ImRead)
            {
                return "im:read";
            }
            else if (slackScope == SlackScope.MpimWrite)
            {
                return "mpim:write";
            }
            else if (slackScope == SlackScope.MpimHistory)
            {
                return "mpim:history";
            }
            else if (slackScope == SlackScope.MpimRead)
            {
                return "mpim:read";
            }
            else if (slackScope == SlackScope.PinsWrite)
            {
                return "pins:write";
            }
            else if (slackScope == SlackScope.PinsRead)
            {
                return "pins:read";
            }
            else if (slackScope == SlackScope.ReactionsWrite)
            {
                return "reactions:write";
            }
            else if (slackScope == SlackScope.ReactionsRead)
            {
                return "reactions:read";
            }
            else if (slackScope == SlackScope.SearchRead)
            {
                return "search:read";
            }
            else if (slackScope == SlackScope.StarsWrite)
            {
                return "stars:write";
            }
            else if (slackScope == SlackScope.StarsRead)
            {
                return "stars:read";
            }
            else if (slackScope == SlackScope.TeamRead)
            {
                return "team:read";
            }
            else if (slackScope == SlackScope.UsergroupsWrite)
            {
                return "usergroups:write";
            }
            else if (slackScope == SlackScope.UsergroupsRead)
            {
                return "usergroups:read";
            }
            else if (slackScope == SlackScope.UsersRead)
            {
                return "users:read";
            }
            else if (slackScope == SlackScope.UsersWrite)
            {
                return "users:write";
            }
            else
            {
                return "unknown";
            }
        }

        public static SlackScope StringToSlackScope(string slackScope)
        {
            if (slackScope == "channels:write")
            {
                return SlackScope.ChannelsWrite;
            }
            else if (slackScope == "channels:history")
            {
                return SlackScope.ChannelsHistory;
            }
            else if (slackScope == "channels:read")
            {
                return SlackScope.ChannelsRead;
            }
            else if (slackScope == "chat:write:user")
            {
                return SlackScope.ChatWriteUser;
            }
            else if (slackScope == "chat:write:bot")
            {
                return SlackScope.ChatWriteBot;
            }
            else if (slackScope == "dnd:write")
            {
                return SlackScope.DndWrite;
            }
            else if (slackScope == "dnd:read")
            {
                return SlackScope.DndRead;
            }
            else if (slackScope == "emoji:read")
            {
                return SlackScope.EmojiRead;
            }
            else if (slackScope == "files:write:user")
            {
                return SlackScope.FilesWriteUser;
            }
            else if (slackScope == "files:read")
            {
                return SlackScope.FilesRead;
            }
            else if (slackScope == "groups:write")
            {
                return SlackScope.GroupsWrite;
            }
            else if (slackScope == "groups:history")
            {
                return SlackScope.GroupsHistory;
            }
            else if (slackScope == "groups:read")
            {
                return SlackScope.GroupsRead;
            }
            else if (slackScope == "im:write")
            {
                return SlackScope.ImWrite;
            }
            else if (slackScope == "im:history")
            {
                return SlackScope.ImHistory;
            }
            else if (slackScope == "im:read")
            {
                return SlackScope.ImRead;
            }
            else if (slackScope == "mpim:write")
            {
                return SlackScope.MpimWrite;
            }
            else if (slackScope == "mpim:history")
            {
                return SlackScope.MpimHistory;
            }
            else if (slackScope == "mpim:read")
            {
                return SlackScope.MpimRead;
            }
            else if (slackScope == "pins:write")
            {
                return SlackScope.PinsWrite;
            }
            else if (slackScope == "pins:read")
            {
                return SlackScope.PinsRead;
            }
            else if (slackScope == "reactions:write")
            {
                return SlackScope.ReactionsWrite;
            }
            else if (slackScope == "reactions:read")
            {
                return SlackScope.ReactionsRead;
            }
            else if (slackScope == "search:read")
            {
                return SlackScope.SearchRead;
            }
            else if (slackScope == "stars:write")
            {
                return SlackScope.StarsWrite;
            }
            else if (slackScope == "stars:read")
            {
                return SlackScope.StarsRead;
            }
            else if (slackScope == "team:read")
            {
                return SlackScope.TeamRead;
            }
            else if (slackScope == "usergroups:write")
            {
                return SlackScope.UsergroupsWrite;
            }
            else if (slackScope == "usergroups:read")
            {
                return SlackScope.UsergroupsRead;
            }
            else if (slackScope == "users:read")
            {
                return SlackScope.UsersRead;
            }
            else if (slackScope == "users:write")
            {
                return SlackScope.UsersWrite;
            }
            else
            {
                return SlackScope.Unknown;
            }
        }
    }
}
