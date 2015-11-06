using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI
{
    public class SlackUserProfile
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string RealName { get; private set; }
        public string Email { get; private set; }
        public string Skype { get; private set; }
        public string Phone { get; private set; }
        public string Title { get; private set; }
        public Dictionary<string, Uri> Images { get; private set; }

        // Fields?

        public SlackUserProfile(JObject o)
        {
            Images = new Dictionary<string, Uri>();
            if (o["first_name"] != null)
            {
                FirstName = (string)o["first_name"];
            }
            if (o["last_name"] != null)
            {
                LastName = (string)o["last_name"];
            }
            if (o["real_name"] != null)
            {
                RealName = (string)o["real_name"];
            }
            if (o["email"] != null)
            {
                Email = (string)o["email"];
            }
            if (o["skype"] != null)
            {
                Skype = (string)o["skype"];
            }
            if (o["phone"] != null)
            {
                Phone = (string)o["phone"];
            }
            if (o["title"] != null)
            {
                Title = (string)o["title"];
            }
            foreach (KeyValuePair<string, JToken> rest in o)
            {
                if (rest.Key.StartsWith("image"))
                {
                    Images.Add(rest.Key, new Uri((string)rest.Value));
                }
            }
        }
    }
}
