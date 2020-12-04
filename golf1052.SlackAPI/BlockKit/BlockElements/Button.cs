using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class Button : IBlockElement
    {
        public string Type { get; private set; }
        public TextObject Text { get; set; }
        public string ActionId { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
        public string Style { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        [JsonConstructor]
        private Button(TextObject text, string actionId, string url, string value, string style, ConfirmationDialogObject confirm)
        {
            Type = "button";
            Text = text;
            ActionId = actionId;
            Url = url;
            Value = value;
            Style = style;
            Confirm = confirm;
        }

        
        public Button(string text, string actionId, string url, string value, string style, ConfirmationDialogObject confirm)
        {
            if (text.Length > 75)
            {
                throw new ArgumentException($"{nameof(text)} must be 75 characters or less.");
            }

            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (!string.IsNullOrEmpty(url) && url.Length > 3000)
            {
                throw new ArgumentException($"{nameof(url)} must be 3000 characters or less.");
            }

            if (!string.IsNullOrEmpty(value) && value.Length > 2000)
            {
                throw new ArgumentException($"{nameof(value)} must be 2000 characters or less.");
            }

            if (!string.IsNullOrEmpty(style) && style != "primary" && style != "danger")
            {
                throw new ArgumentException($"{nameof(style)} must be null, primary, or danger.");
            }

            Type = "button";
            Text = TextObject.CreatePlainTextObject(text);
            ActionId = actionId;
            Url = url;
            Value = value;
            Style = style;
            Confirm = confirm;
        }

        public Button(string text, string actionId) : this(text, actionId, null, null, null, null)
        {
        }
    }
}
