using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using golf1052.SlackAPI.BlockKit.Blocks;
using golf1052.SlackAPI.BlockKit.BlockElements;

namespace golf1052.SlackAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //HttpClient client = new HttpClient();
            //Task<HttpResponseMessage> responseTask = client.GetAsync("https://slack.com/api/groups.list?token=" + Secrets.Token);
            //responseTask.Wait();
            //HttpResponseMessage response = responseTask.Result;
            //Task<string> responseStringTask = response.Content.ReadAsStringAsync();
            //responseStringTask.Wait();
            //string responseString = responseStringTask.Result;
            //JObject responseObject = JObject.Parse(responseString);
            //JArray channelsA = (JArray)responseObject["groups"];

            List<object> blocks = new List<object>();
            blocks.Add(new Section("Alfred charged you $5.33 for Netflix December | ID: 3153490504352531397\n/venmo complete accept 3153490504352531397"));
            blocks.Add(new Actions(
                new Button("Accept", "acceptAction"),
                new Button("Reject", "rejectAction")));

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore
            };

            string blocksJson = JsonConvert.SerializeObject(blocks, jsonSerializerSettings);
            Debug.WriteLine("");
        }
    }
}
