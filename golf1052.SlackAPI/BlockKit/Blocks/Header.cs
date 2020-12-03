using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class Header : IBlock
    {
        public string Type { get; private set; }
        public TextObject Text { get; set; }
        public string BlockId { get; set; }

        public Header(string text, string blockId)
        {
            if (text.Length > 150)
            {
                throw new ArgumentException($"{nameof(text)} must be 150 characters or less.");
            }

            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            Type = "header";
            Text = TextObject.CreatePlainTextObject(text);
            BlockId = blockId;
        }

        public Header(string text) : this(text, null)
        {
        }
    }
}
