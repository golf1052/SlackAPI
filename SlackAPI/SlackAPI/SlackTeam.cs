using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI
{
    public class SlackTeam
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string EmailDomain { get; private set; }
        public string Domain { get; private set; }
        /// <summary>
        /// Amount of time (in minutes) users can edit messages after sending them.
        /// </summary>
        public int MessageEditWindow { get; private set; }
        public bool OverStorageLimit { get; private set; }
        public Dictionary<string, Uri> Icons { get; private set; }
        public string Plan { get; private set; }
        public bool OverIntegrationsLimit { get; private set; }

        public SlackTeam(JObject o)
        {
            Icons = new Dictionary<string, Uri>();
            Id = (string)o["id"];
            Name = (string)o["name"];
            if (o["email_domain"] != null)
            {
                EmailDomain = (string)o["email_domain"];
            }
            if (o["domain"] != null)
            {
                Domain = (string)o["domain"];
            }
            MessageEditWindow = (int)o["msg_edit_window_mins"];
            if (o["over_storage_limit"] != null)
            {
                OverStorageLimit = (bool)o["over_storage_limit"];
            }
            if (o["icon"] != null)
            {
                foreach (KeyValuePair<string, JToken> icon in (JObject)o["icon"])
                {
                    if (icon.Key != "image_default")
                    {
                        Icons.Add(icon.Key, new Uri((string)icon.Value));
                    }
                }
            }
            if (o["plan"] != null)
            {
                Plan = (string)o["plan"];
            }
            if (o["over_integration_limit"] != null)
            {
                OverIntegrationsLimit = (bool)o["over_integration_limit"];
            }
        }
    }
}
