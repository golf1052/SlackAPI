using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Flurl;
using golf1052.SlackAPI.Objects;
using golf1052.SlackAPI.Events;

namespace golf1052.SlackAPI
{
    public class SlackCore
    {
        private string AccessToken { get; set; }

        public SlackCore(string accessToken)
        {
            AccessToken = accessToken;
        }

        public async Task ApiTest(string error = null, params string[] properties)
        {
            JObject response = await DoSlackCall("api.test");
        }

        public async Task<List<SlackEvent>> ReactionsList(string user = null, bool full = false, int count = 100, int page = 1, bool allItems = false)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("reactions.list");
            if (!string.IsNullOrEmpty(user))
            {
                url.SetQueryParam("user", user);
            }
            url.SetQueryParams(new Dictionary<string, object>()
            {
                { "full", full },
                { "count", count },
                { "page", page }
            });
            JObject response = await DoAuthSlackCall(new Uri(url), allItems);
            List<SlackEvent> reactions = new List<SlackEvent>();
            foreach (JObject item in (JArray)response["items"])
            {
                if ((string)item["type"] == "message")
                {
                    Message message = JsonConvert.DeserializeObject<Message>(item["message"].ToString());
                    reactions.Add(message);
                }
            }
            return reactions;
        }
        
        public async Task ReactionsAdd(string name, string file = null, string fileComment = null, string channel = null, string timestamp = null)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("reactions.add");
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("required", nameof(name));
            }
            if (string.IsNullOrEmpty(file) && string.IsNullOrEmpty(fileComment) && (string.IsNullOrEmpty(channel) || string.IsNullOrEmpty(timestamp)))
            {
                throw new ArgumentException($"One of {nameof(file)}, {nameof(fileComment)}, or the combination of {nameof(channel)} and {nameof(timestamp)} must be specified.");
            }

            url.SetQueryParam("name", name);
            if (file != null)
            {
                url.SetQueryParam("file", file);
            }
            else if (fileComment != null)
            {
                url.SetQueryParam("file_comment", fileComment);
            }
            else
            {
                url.SetQueryParam("channel", channel)
                .SetQueryParam("timestamp", timestamp);
            }
            await DoAuthSlackCall(new Uri(url));
        }

        [Obsolete]
        public async Task<List<SlackChannel>> ChannelsList(int excludeArchived = 0)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("channels.list").SetQueryParam("exclude_archived", excludeArchived);
            JObject response = await DoAuthSlackCall(new Uri(url));
            List<SlackChannel> channels = new List<SlackChannel>();
            foreach (JObject item in (JArray) response["channels"])
            {
                channels.Add(JsonConvert.DeserializeObject<SlackChannel>(item.ToString()));
            }
            return channels;
        }

        public async Task<List<SlackChannel>> ConversationsList(bool excludeArchived = false, string types = "public_channel")
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("conversations.list")
                .SetQueryParam("exclude_archived", excludeArchived)
                .SetQueryParam("types", types);
            JObject response = await DoAuthSlackCall(new Uri(url));
            List<SlackChannel> channels = new List<SlackChannel>();
            foreach (JObject item in (JArray)response["channels"])
            {
                channels.Add(JsonConvert.DeserializeObject<SlackChannel>(item.ToString()));
            }
            return channels;
        }

        public async Task<string> ConversationsOpen(string channel = null, bool returnIm = false, List<string> users = null)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("conversations.open");
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("return_im", returnIm.ToString());
            if (!string.IsNullOrEmpty(channel))
            {
                args.Add("channel", channel);
            }
            if (users != null && users.Count > 0)
            {
                args.Add("users", string.Join(",", users));
            }
            JObject response = await DoAuthSlackCall(new Uri(url), false, HttpMethod.Post, args);
            return (string)response["channel"]["id"];
        }

        public async Task<List<SlackUser>> UsersList(int presence = 0)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("users.list").SetQueryParam("presence", presence);
            JObject response = await DoAuthSlackCall(new Uri(url));
            List<SlackUser> users = new List<SlackUser>();
            foreach (JObject item in (JArray)response["members"])
            {
                users.Add(JsonConvert.DeserializeObject<SlackUser>(item.ToString()));
            }
            return users;
        }

        public async Task<List<SlackConversation>> UsersConversations(string cursor = null,
            string types = null,
            int limit = 100,
            string user = null)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("users.conversations")
                .SetQueryParam("cursor", cursor)
                .SetQueryParam("types", types)
                .SetQueryParam("user", user);
            if (limit != 100)
            {
                url.SetQueryParam("limit", limit);
            }
            JObject response = await DoAuthSlackCall(new Uri(url));
            List<SlackConversation> conversations = new List<SlackConversation>();
            foreach (JObject item in (JArray)response["channels"])
            {
                conversations.Add(JsonConvert.DeserializeObject<SlackConversation>(item.ToString()));
            }
            return conversations;
        }

        public static Uri StartOAuth(string clientId, List<SlackConstants.SlackScope> scopes, Uri redirectUri = null, string state = null, string team = null)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegments("oauth", "authorize");
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentException("required", nameof(clientId));
            }
            url.SetQueryParam("client_id", clientId);
            
            if (scopes == null || scopes.Count == 0)
            {
                throw new ArgumentException("Must set at least 1 scope", nameof(scopes));
            }
            string scopesString = string.Empty;
            for (int i = 0; i < scopes.Count; i++)
            {
                if (i != scopes.Count - 1)
                {
                    scopesString += scopes[i].SlackScopeToString() + " ";
                }
                else
                {
                    scopesString += scopes[i].SlackScopeToString();
                }
            }
            url.SetQueryParam("scope", scopesString);
            if (redirectUri != null)
            {
                url.SetQueryParam("redirect_uri", redirectUri.ToString());
            }
            if (!string.IsNullOrEmpty(state))
            {
                url.SetQueryParam("state", state);
            }
            if (!string.IsNullOrEmpty(team))
            {
                url.SetQueryParam("team", team);
            }
            return new Uri(url);
        }

        public static async Task<SlackCore> CompleteOAuth(string clientId, string clientSecret, string code, Uri redirectUri = null)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentException("required", nameof(clientId));
            }
            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentException("required", nameof(clientSecret));
            }
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException("required", nameof(code));
            }

            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("oauth.access").SetQueryParams(new Dictionary<string, object>()
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "code", code }
            });
            if (redirectUri != null)
            {
                url.SetQueryParam("redirect_uri", redirectUri.ToString());
            }
            JObject response = await SlackCore.DoSlackCall(new Uri(url));
            string accessToken = (string)response["access_token"];
            return new SlackCore(accessToken);
        }

        public static async Task<JObject> DoSlackCall(string endpoint, bool all = false, HttpMethod method = null, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment(endpoint);
            return await SlackCore.DoSlackCall(url, all, method, args);
        }

        public async Task<JObject> DoAuthSlackCall(Uri uri, bool all = false, HttpMethod method = null, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            Url url = new Url(uri.ToString());
            url.SetQueryParam("token", AccessToken);
            return await SlackCore.DoSlackCall(new Uri(url), all, method, args);
        }

        public static async Task<JObject> DoSlackCall(Uri uri, bool all = false, HttpMethod method = null, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = null;
            if (method == null)
            {
                method = HttpMethod.Get;
            }
            if (method == HttpMethod.Get)
            {
                response = await httpClient.GetAsync(uri);
            }
            else if (method == HttpMethod.Post)
            {
                response = await httpClient.PostAsync(uri, new FormUrlEncodedContent(args));
            }
            else
            {
                throw new ArgumentException("Can only use GET and POST", nameof(method));
            }
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            bool ok = (bool)responseObject["ok"];
            if (ok)
            {
                if (all)
                {
                    JObject paging = (JObject)responseObject["paging"];
                    int pages = (int)paging["pages"];
                    int page = (int)paging["page"];
                    for (int i = 1; i < pages; i++)
                    {
                        Url url = new Url(uri.ToString());
                        page++;
                        url.SetQueryParam("page", page);
                        JObject pageResponse = await DoSlackCall(new Uri(url), false, method, args);
                        string array = null;
                        foreach (KeyValuePair<string, JToken> token in pageResponse)
                        {
                            if (token.Value.Type == JTokenType.Array)
                            {
                                array = token.Key;
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(array))
                        {
                            throw new Exception("Couldn't find array");
                        }
                        foreach (JToken item in pageResponse[array])
                        {
                            ((JArray)responseObject[array]).Add(item);
                        }
                    }
                    responseObject.Remove("paging");
                }
                return responseObject;
            }
            else
            {
                throw new Exception("not ok");
            }
        }
    }
}
