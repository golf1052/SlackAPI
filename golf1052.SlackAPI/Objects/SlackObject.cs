using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.Objects
{
    public abstract class SlackObject
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
    }
}
