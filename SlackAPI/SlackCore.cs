using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using golf1052.Trexler;

namespace golf1052.SlackAPI
{
    public class SlackCore
    {
        private HttpClient httpClient;

        public SlackCore()
        {
            httpClient = new HttpClient();
        }

        public async Task ApiTest(string error = null, params string[] properties)
        {
            JObject response = await DoSlackCall("api.test");
        }

        public static Uri StartOAuth(string clientId, List<SlackConstants.SlackScope> scopes, Uri redirectUri = null, string state = null, string team = null)
        {
            TrexUri url = new TrexUri(SlackConstants.BaseUrl).AppendPathSegments("oauth", "authorize");
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

        public static SlackCore CompleteOAuth(string clientId, string clientSecret, string code, Uri redirectUri = null)
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

            TrexUri url = new TrexUri(SlackConstants.BaseUrl).AppendPathSegment("oauth.access").SetQueryParams(new Dictionary<string, object>()
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "code", code }
            });
            if (redirectUri != null)
            {
                url.SetQueryParam("redirect_uri", redirectUri.ToString());
            }
            SlackCore slack = new SlackCore();
        }

        public async Task<JObject> DoSlackCall(string endpoint, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            TrexUri url = new TrexUri(SlackConstants.BaseUrl).AppendPathSegment(endpoint);
            if (args == null)
            {
                args = new Dictionary<string, string>();
            }
            FormUrlEncodedContent formContent = new FormUrlEncodedContent(args);
            HttpResponseMessage response = await httpClient.PostAsync(url, formContent);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            bool ok = (bool)responseObject["ok"];
            if (ok)
            {
                return responseObject;
            }
            else
            {
                throw new Exception("not ok");
            }
        }

        public async Task<JObject> DoSlackCall(Uri uri, HttpMethod method, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            HttpResponseMessage response = null;
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
                return responseObject;
            }
            else
            {
                throw new Exception("not ok");
            }
        }
    }
}
