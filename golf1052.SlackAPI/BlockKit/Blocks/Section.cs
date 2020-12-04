using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.BlockElements;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.Blocks
{
    public class Section : IBlock
    {
        public string Type { get; private set; }
        public TextObject Text { get; set; }
        public string BlockId { get; set; }
        public List<TextObject> Fields { get; set; }
        public IBlockElement Accessory { get; set; }

        public Section(TextObject text, string blockId, List<TextObject> fields, IBlockElement accessory)
        {
            if (text != null && text.Text.Length > 3000)
            {
                throw new ArgumentException($"{nameof(text)} must be 3000 characters or less.");
            }

            if (!string.IsNullOrEmpty(blockId) && blockId.Length > 255)
            {
                throw new ArgumentException($"{nameof(blockId)} must be 255 characters or less.");
            }

            if (fields != null)
            {
                if (fields.Count > 10)
                {
                    throw new ArgumentException($"{nameof(fields)} must be 10 items or less.");
                }
                
                foreach (var field in fields)
                {
                    if (field.Text.Length > 2000)
                    {
                        throw new ArgumentException($"{nameof(fields)} must contain text objects with 2000 characters or less.");
                    }
                }
            }

            if (accessory != null && !(accessory is Button) && !(accessory is Checkbox) && !(accessory is DatePicker) &&
                !(accessory is BlockElements.Image) && !(accessory is Overflow) && !(accessory is Select) &&
                !(accessory is PlainTextInput) && !(accessory is RadioButton) && !(accessory is TimePicker))
            {
                throw new ArgumentException($"{nameof(accessory)} must be type {typeof(Button)}, {typeof(Checkbox)}, {typeof(DatePicker)}, {typeof(BlockElements.Image)}, {typeof(Overflow)}, {typeof(Select)}, {typeof(PlainTextInput)}, {typeof(RadioButton)}, or {typeof(TimePicker)}");
            }

            Type = "section";
            Text = text;
            BlockId = blockId;
            Fields = fields;
            Accessory = accessory;
        }

        public Section(TextObject text) : this(text, null, null, null)
        {
        }

        public Section(string text) : this(TextObject.CreatePlainTextObject(text))
        {
        }
    }
}
