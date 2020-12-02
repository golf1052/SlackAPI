using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public abstract class Select
    {
        public string Type { get; protected set; }
        public string ActionId { get; set; }
        public TextObject Placeholder { get; set; }
    }
}
