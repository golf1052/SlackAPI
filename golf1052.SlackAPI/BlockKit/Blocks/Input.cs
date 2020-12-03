using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.BlockElements;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class Input : IBlock
    {
        public string Type { get; private set; }
        public TextObject Label { get; set; }
        public object Element { get; set; }
        public bool DispatchAction { get; set; }
        public string BlockId { get; set; }
        public TextObject Hint { get; set; }
        public bool Optional { get; set; }
        
        public Input(string label, object element, bool dispatchAction, string blockId, string hint, bool optional)
        {
            if (label.Length > 2000)
            {
                throw new ArgumentException($"{nameof(label)} must be 2000 characters or less.");
            }

            if (!(element is TextObject) && !(element is Checkbox) && !(element is RadioButton) && !(element is Select) && !(element is DatePicker))
            {
                throw new ArgumentException($"{nameof(element)} must be type {typeof(TextObject)}, {typeof(Checkbox)}, {typeof(RadioButton)}, {typeof(Select)}, or {typeof(DatePicker)}.");
            }

            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            if (!string.IsNullOrEmpty(hint) && hint.Length > 2000)
            {
                throw new ArgumentException($"{nameof(hint)} must be 2000 characters or less.");
            }

            Type = "input";
            Label = TextObject.CreatePlainTextObject(label);
            Element = element;
            DispatchAction = dispatchAction;
            BlockId = blockId;
            if (!string.IsNullOrEmpty(hint))
            {
                Hint = TextObject.CreatePlainTextObject(hint);
            }
            Optional = optional;
        }

        public Input(string label, object element) : this(label, element, false, null, null, false)
        {
        }
    }
}
