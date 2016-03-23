using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace golf1052.SlackAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> responseTask = client.GetAsync("https://slack.com/api/groups.list?token=" + Secrets.Token);
            responseTask.Wait();
            HttpResponseMessage response = responseTask.Result;
            Task<string> responseStringTask = response.Content.ReadAsStringAsync();
            responseStringTask.Wait();
            string responseString = responseStringTask.Result;
            JObject responseObject = JObject.Parse(responseString);
            JArray channelsA = (JArray)responseObject["groups"];
            SlackCore core = new SlackCore();
            Debug.WriteLine("");
        }
    }
}
