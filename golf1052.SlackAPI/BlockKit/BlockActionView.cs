using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI.BlockKit
{
    public class BlockActionView
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Type { get; set; }
        public JArray Blocks { get; set; }
        public string PrivateMetadata { get; set; }
        public string CallbackId { get; set; }
        public JObject State { get; set; }
        public string Hash { get; set; }
        public TextObject Title { get; set; }
        public bool ClearOnClose { get; set; }
        public bool NotifyOnClose { get; set; }
        public TextObject Close { get; set; }
        public TextObject Submit { get; set; }
        // not sure what type this is
        //public object PreviousViewId { get; set; }
        public string RootViewId { get; set; }
        public string AppId { get; set; }
        public string ExternalId { get; set; }
        public string AppInstalledTeamId { get; set; }
        public string BotId { get; set; }
    }
}
