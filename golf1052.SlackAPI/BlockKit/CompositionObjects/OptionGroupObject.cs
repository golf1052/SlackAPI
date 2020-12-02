using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.BlockKit.CompositionObjects
{
    public class OptionGroupObject
    {
        public TextObject Label { get; set; }
        public List<OptionObject> Options { get; set; }

        public OptionGroupObject(string label, List<OptionObject> options)
        {
            if (label.Length > 75)
            {
                throw new ArgumentException($"{nameof(label)} must be 75 characters or less.");
            }

            if (options.Count > 100)
            {
                throw new ArgumentException($"{nameof(options)} must be 100 items or less.");
            }

            Label = TextObject.CreatePlainTextObject(label);
            Options = options;
        }

        public OptionGroupObject(string label, params OptionObject[] options) : this(label, new List<OptionObject>(options))
        {
        }
    }
}
