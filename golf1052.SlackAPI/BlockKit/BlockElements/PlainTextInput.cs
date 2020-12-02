using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class PlainTextInput
    {
        public string Type { get; private set; }
        public string ActionId { get; set; }
        public TextObject Placeholder { get; set; }
        public string InitialValue { get; set; }
        public bool Multiline { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public DispatchActionConfigurationObject DispatchActionConfig { get; set; }

        public PlainTextInput(string actionId,
            string placeholder,
            string initialValue,
            bool multiline,
            int? minLength,
            int? maxLength,
            DispatchActionConfigurationObject dispatchActionConfig)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (!string.IsNullOrEmpty(placeholder) && placeholder.Length > 150)
            {
                throw new ArgumentException($"{nameof(placeholder)} must be 150 characters or less.");
            }

            Type = "plain_text_input";
            ActionId = actionId;
            if (!string.IsNullOrEmpty(placeholder))
            {
                Placeholder = TextObject.CreatePlainTextObject(placeholder);
            }
            InitialValue = initialValue;
            Multiline = multiline;
            MinLength = minLength;
            MaxLength = maxLength;
            DispatchActionConfig = dispatchActionConfig;
        }

        public PlainTextInput(string actionId) : this(actionId, null, null, false, null, null, null)
        {
        }
    }
}
