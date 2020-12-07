using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI.BlockKit
{
    public class BlockActionResponse
    {
        public string Type { get; set; }
        public string ResponseUrl { get; set; }
        public BlockActionUser User { get; set; }
        public string ApiAppId { get; set; }
        public string Token { get; set; }
        public BlockActionContainer Container { get; set; }
        public string TriggerId { get; set; }
        public BlockActionTeam Team { get; set; }
        public BlockActionChannel Channel { get; set; }
        public JArray Actions { get; set; }
        public BlockActionView View { get; set; }
    }
}
