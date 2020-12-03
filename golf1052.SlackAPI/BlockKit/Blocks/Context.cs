using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.BlockElements;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class Context : IBlock
    {
        public string Type { get; private set; }
        public List<object> Elements { get; set; }
        public string BlockId { get; set; }

        public Context(List<object> elements, string blockId)
        {
            if (elements.Count > 10)
            {
                throw new ArgumentException($"{nameof(elements)} must be 10 items or less.");
            }

            foreach (var element in elements)
            {
                if (!(element is Image) && !(element is TextObject))
                {
                    throw new ArgumentException($"{nameof(elements)} must be type {typeof(Image)} or {typeof(TextObject)}");
                }
            }

            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            Type = "context";
            Elements = elements;
            BlockId = blockId;
        }

        public Context(List<object> elements) : this(elements, null)
        {
        }

        public Context(params object[] elements) : this(new List<object>(elements))
        {
        }
    }
}
