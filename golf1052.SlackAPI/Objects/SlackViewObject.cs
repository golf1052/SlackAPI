using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.Blocks;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.Objects
{
    public class SlackViewObject
    {
        public string Type { get; set; }
        public TextObject Title { get; set; }
        public List<IBlock> Blocks { get; set; }
        public TextObject Close { get; set; }
        public TextObject Submit { get; set; }
        public string PrivateMetadata { get; set; }
        public string CallbackId { get; set; }
        public bool? ClearOnClose { get; set; }
        public bool? NotifyOnClose { get; set; }
        public string ExternalId { get; set; }

        public SlackViewObject(List<IBlock> blocks, string privateMetadata, string callbackId, string externalId)
        {
            Type = "home";
            Blocks = blocks;
            PrivateMetadata = privateMetadata;
            CallbackId = callbackId;
            ExternalId = externalId;
        }

        public SlackViewObject(List<IBlock> blocks) : this(blocks, null, null, null)
        {
        }
    }
}
