using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class File
    {
        public string Type { get; private set; }
        public string ExternalId { get; set; }
        public string Source { get; set; }
        public string BlockId { get; set; }

        public File(string externalId, string source, string blockId)
        {
            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            Type = "file";
            ExternalId = externalId;
            Source = source;
            BlockId = blockId;
        }

        public File(string externalId, string source) : this(externalId, source, null)
        {
        }
    }
}
