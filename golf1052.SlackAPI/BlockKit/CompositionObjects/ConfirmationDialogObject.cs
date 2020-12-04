using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.BlockKit.CompositionObjects
{
    public class ConfirmationDialogObject
    {
        public TextObject Title { get; set; }
        public TextObject Text { get; set; }
        public TextObject Confirm { get; set; }
        public TextObject Deny { get; set; }
        public string Style { get; set; }

        [JsonConstructor]
        public ConfirmationDialogObject(string title, TextObject text, string confirm, string deny, string style)
        {
            if (title.Length > 100)
            {
                throw new ArgumentException($"{nameof(title)} must be 100 characters or less.");
            }

            if (text.Text.Length > 300)
            {
                throw new ArgumentException($"{nameof(text)} must be 300 characters or less.");
            }

            if (confirm.Length > 30)
            {
                throw new ArgumentException($"{nameof(confirm)} must be 30 characters or less.");
            }

            if (deny.Length > 30)
            {
                throw new ArgumentException($"{nameof(deny)} must be 30 characters or less.");
            }

            if (!string.IsNullOrEmpty(style) && style != "primary" && style != "danger")
            {
                throw new ArgumentException($"{nameof(style)} must be primary or danger.");
            }

            Title = TextObject.CreatePlainTextObject(title);
            Text = text;
            Confirm = TextObject.CreatePlainTextObject(confirm);
            Deny = TextObject.CreatePlainTextObject(deny);
            Style = style;
        }

        public ConfirmationDialogObject(string title, TextObject text, string confirm, string deny) : this(title, text, confirm, deny, null)
        {
        }

        public ConfirmationDialogObject(string title, string text, string confirm, string deny) : this(title, TextObject.CreatePlainTextObject(text), confirm, deny)
        {
        }
    }
}
