using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.BlockElements;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class Actions : IBlock
    {
        public string Type { get; private set; }
        public List<object> Elements { get; set; }
        public string BlockId { get; set; }

        public Actions(List<object> elements, string blockId)
        {
            if (elements.Count > 5)
            {
                throw new ArgumentException($"{nameof(elements)} must be 5 items or less.");
            }

            foreach (var element in elements)
            {
                if (!(element is Button) && !(element is Select) && !(element is Overflow) && !(element is DatePicker))
                {
                    throw new ArgumentException($"{nameof(elements)} must be type {typeof(Button)}, {typeof(Select)}, {typeof(Overflow)}, or {typeof(DatePicker)}.");
                }
            }

            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            Type = "actions";
            Elements = elements;
            BlockId = blockId;
        }

        public Actions(List<object> elements) : this(elements, null)
        {
        }

        public Actions(params object[] elements) : this(new List<object>(elements))
        {
        }
    }
}
