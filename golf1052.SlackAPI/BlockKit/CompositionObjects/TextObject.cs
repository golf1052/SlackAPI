using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace golf1052.SlackAPI.BlockKit.CompositionObjects
{
    public class TextObject
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public bool? Emoji { get; set; }
        public bool? Verbatim { get; set; }

        [JsonConstructor]
        public TextObject(string type, string text, bool? emoji, bool? verbatim)
        {
            if (type != "plain_text" && type != "mrkdwn")
            {
                throw new ArgumentException($"{nameof(type)} must be plain_text or mrkdwn.");
            }

            if (type == "plain_text" && verbatim.HasValue)
            {
                throw new ArgumentException($"{nameof(verbatim)} is only usable when {nameof(type)} is mrkdwn.");
            }

            if (type == "mrkdwn" && emoji.HasValue)
            {
                throw new ArgumentException($"{nameof(emoji)} is only usable when {nameof(type)} is plain_text");
            }

            Type = type;
            Text = text;
            Emoji = emoji;
            Verbatim = verbatim;
        }

        public TextObject(string type, string text) : this(type, text, null, null)
        {
        }

        public static TextObject CreatePlainTextObject(string text)
        {
            return new TextObject("plain_text", text);
        }
    }
}
