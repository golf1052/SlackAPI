using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class Divider
    {
        public string Type { get; private set; }
        public string BlockId { get; set; }

        public Divider(string blockId)
        {
            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            Type = "divider";
            BlockId = blockId;
        }

        public Divider() : this(null)
        {
        }
    }
}
