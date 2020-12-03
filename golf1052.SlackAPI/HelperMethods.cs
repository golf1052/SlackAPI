using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.BlockElements;
using golf1052.SlackAPI.BlockKit.Blocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace golf1052.SlackAPI
{
    public class HelperMethods
    {
        /// <summary>
        /// Creates a new serializer used for serializing block kit objects. Should be saved locally and not called for every serialization/deserialization call.
        /// </summary>
        /// <returns></returns>
        public JsonSerializerSettings GetBlockKitSerializer()
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
