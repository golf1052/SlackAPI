using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Flurl;
using golf1052.SlackAPI.Objects;
using golf1052.SlackAPI.Events;
using golf1052.SlackAPI.BlockKit.Blocks;
using System.Threading;

namespace golf1052.SlackAPI
{
    public class SlackCore
    {
        private string AccessToken { get; set; }
        private readonly HttpClient httpClient;
        private readonly JsonSerializerSettings jsonSerializerSettings;
        private readonly Dictionary<string, SemaphoreSlim> apiRateLimits;

        public SlackCore(string accessToken) : this(accessToken, new HttpClient(), new Dictionary<string, SemaphoreSlim>())
        {
        }

        public SlackCore(string accessToken, HttpClient httpClient, Dictionary<string, SemaphoreSlim> apiRateLimits)
        {
            AccessToken = accessToken;
            this.httpClient = httpClient;
            jsonSerializerSettings = new HelperMethods().GetBlockKitSerializer();
            this.apiRateLimits = apiRateLimits;
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
                    SlackMessage message = JsonConvert.DeserializeObject<SlackMessage>(item["message"].ToString(), jsonSerializerSettings);
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

        public async Task ChatPostMessage(string text, string channel, bool? asUser = null, JObject attachments = null,
            List<IBlock> blocks = null, string iconEmoji = null, string iconUrl = null, bool? linkNames = null,
            bool? mrkdwn = null, string parse = null, bool? replyBroadcast = null, string threadTs = null,
            bool? unfurlLinks = null, bool? unfurlMedia = null, string username = null)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("chat.postMessage");
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("text", text);
            args.Add("channel", channel);
            if (asUser != null)
            {
                args.Add("as_user", asUser.Value.ToString());
            }
            if (attachments != null)
            {
                args.Add("attachments", attachments.ToString(Formatting.None));
            }
            if (blocks != null)
            {
                args.Add("blocks", JsonConvert.SerializeObject(blocks, Formatting.None, jsonSerializerSettings));
            }
            if (iconEmoji != null)
            {
                args.Add("icon_emoji", iconEmoji);
            }
            if (iconUrl != null)
            {
                args.Add("icon_url", iconUrl);
            }
            if (linkNames != null)
            {
                args.Add("link_names", linkNames.Value.ToString());
            }
            if (mrkdwn != null)
            {
                args.Add("mrkdwn", mrkdwn.Value.ToString());
            }
            if (parse != null)
            {
                args.Add("parse", parse);
            }
            if (replyBroadcast != null)
            {
                args.Add("reply_broadcast", replyBroadcast.Value.ToString());
            }
            if (threadTs != null)
            {
                args.Add("thread_ts", threadTs);
            }
            if (unfurlLinks != null)
            {
                args.Add("unfurl_links", unfurlLinks.Value.ToString());
            }
            if (unfurlMedia != null)
            {
                args.Add("unfurl_media", unfurlMedia.Value.ToString());
            }
            if (username != null)
            {
                args.Add("username", username);
            }
            await DoAuthSlackCall(new Uri(url), false, HttpMethod.Post, args);
        }

        public async Task ViewsPublish(string userId, SlackViewObject view)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment("views.publish");
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("user_id", userId);
            args.Add("view", JsonConvert.SerializeObject(view, Formatting.None, jsonSerializerSettings));
            await DoAuthSlackCall(new Uri(url), false, HttpMethod.Post, args);
        }

        public Uri StartOAuth(string clientId, List<SlackConstants.SlackScope> scopes, Uri redirectUri = null, string state = null, string team = null)
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

        public async Task<SlackCore> CompleteOAuth(string clientId, string clientSecret, string code, Uri redirectUri = null)
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
            JObject response = await DoSlackCall(new Uri(url));
            string accessToken = (string)response["access_token"];
            return new SlackCore(accessToken);
        }

        public async Task<JObject> DoSlackCall(string endpoint, bool all = false, HttpMethod method = null, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            Url url = new Url(SlackConstants.BaseUrl).AppendPathSegment(endpoint);
            return await DoSlackCall(url, all, method, args);
        }

        public async Task<JObject> DoAuthSlackCall(Uri uri, bool all = false, HttpMethod method = null, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            Url url = new Url(uri.ToString());
            url.SetQueryParam("token", AccessToken);
            return await DoSlackCall(new Uri(url), all, method, args);
        }

        public async Task<JObject> DoSlackCall(Uri uri, bool all = false, HttpMethod method = null, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            Func<HttpRequestMessage> requestFactory;
            if (method == null)
            {
                method = HttpMethod.Get;
            }
            if (method == HttpMethod.Get)
            {
                requestFactory = () => new HttpRequestMessage(method, uri);
            }
            else if (method == HttpMethod.Post)
            {
                requestFactory = () =>
                {
                    HttpRequestMessage request = new HttpRequestMessage(method, uri);
                    request.Content = new FormUrlEncodedContent(args);
                    return request;
                };
            }
            else
            {
                throw new ArgumentException("Can only use GET and POST", nameof(method));
            }

            HttpResponseMessage response = await DoSlackCall(requestFactory);
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
                string argsString = string.Empty;
                if (args != null)
                {
                    foreach (KeyValuePair<string, string> arg in args)
                    {
                        argsString += arg.Key + "=" + arg.Value + " ";
                    }
                }
                throw new Exception($"Error: {(string)responseObject["error"]}\nURL: {uri.ToString()}\nMethod: {method.ToString()}\nArgs: {argsString}");
            }
        }

        private async Task<HttpResponseMessage> DoSlackCall(Func<HttpRequestMessage> requestFactory)
        {
            HttpRequestMessage request = requestFactory();
            string path = request.RequestUri.AbsolutePath;
            if (!apiRateLimits.ContainsKey(path))
            {
                apiRateLimits.Add(path, new SemaphoreSlim(1));
            }

            // We want API calls to only be blocked once a rate limit is hit on a API, so if the semaphore count for
            // a API is 0 then don't call the API until we're no longer rate limited on that API
            if (apiRateLimits[path].CurrentCount == 0)
            {
                await apiRateLimits[path].WaitAsync();
                // When we call Wait and pass it we decrement the semaphore count, however we don't actually need to
                // block other threads so immediately release it
                apiRateLimits[path].Release();
            }
            else if (apiRateLimits[path].CurrentCount > 1)
            {
                throw new Exception($"Semaphore count for {path} is greater than 1");
            }
            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                if ((int)response.StatusCode == 429)
                {
                    TimeSpan? timeToWait = response.Headers.RetryAfter.Delta;
                    if (timeToWait.HasValue)
                    {
                        System.Diagnostics.Debug.WriteLine($"Hit rate limit. Waiting {timeToWait}");
                        await apiRateLimits[path].WaitAsync();
                        await Task.Delay(timeToWait.Value);
                        apiRateLimits[path].Release();
                        return await DoSlackCall(requestFactory);
                    }
                    else
                    {
                        throw new Exception("Slack did not return Retry-After header");
                    }
                }
                else
                {
                    return response;
                }
            }
        }
    }
}
