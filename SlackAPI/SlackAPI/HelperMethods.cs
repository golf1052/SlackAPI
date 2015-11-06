using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI
{
    public class HelperMethods
    {
        public static async Task<JObject> GetWebData(Uri uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            string responseString;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseString = await response.Content.ReadAsStringAsync();
                return JObject.Parse(responseString);
            }
            else
            {
                throw new SlackException();
            }
        }

        public static DateTime EpochToDateTime(long date)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(date);
        }
    }
}
