using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.BlockKit.CompositionObjects
{
    public class OptionObject
    {
        public TextObject Text { get; set; }
        public string Value { get; set; }
        public TextObject Description { get; set; }
        public string Url { get; set; }

        public OptionObject(TextObject text, string value, string description, string url)
        {
            if (text.Text.Length > 75)
            {
                throw new ArgumentException($"{nameof(text)} must be 75 characters or less.");
            }

            if (value.Length > 75)
            {
                throw new ArgumentException($"{nameof(value)} must be 75 characters or less.");
            }

            if (!string.IsNullOrEmpty(description) && description.Length > 75)
            {
                throw new ArgumentException($"{nameof(description)} must be 75 characters or less.");
            }

            if (!string.IsNullOrEmpty(url) && url.Length > 3000)
            {
                throw new ArgumentException($"{nameof(url)} must be 3000 characters or less.");
            }

            Text = text;
            Value = value;
            if (!string.IsNullOrEmpty(description))
            {
                Description = TextObject.CreatePlainTextObject(description);
            }
            Url = url;
        }

        public OptionObject(TextObject text, string value) : this(text, value, null, null)
        {
        }

        public OptionObject(string text, string value) : this(TextObject.CreatePlainTextObject(text), value)
        {
        }
    }
}
