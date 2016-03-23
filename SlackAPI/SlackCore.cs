using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI
{
    public class SlackCore
    {
        HttpClient httpClient;

        public SlackCore()
        {
            httpClient = new HttpClient();
        }

        public async Task ApiTest(string error = null, params string[] properties)
        {
            JObject response = await DoSlackCall("api.test");
        }

        public async Task<JObject> DoSlackCall(string endpoint, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            Uri url = new Uri(SlackConstants.BaseUrl + endpoint);
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
    }
}
