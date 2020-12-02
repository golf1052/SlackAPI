using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class ExternalSelect : Select
    {
        public object InitialOption { get; set; }
        public int? MinQueryLength { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        private ExternalSelect(string actionId, string placeholder, object initialOption, int? minQueryLength, ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (placeholder.Length > 150)
            {
                throw new ArgumentException($"{nameof(placeholder)} must be 150 characters or less.");
            }

            Type = "external_select";
            ActionId = actionId;
            Placeholder = TextObject.CreatePlainTextObject(placeholder);
            InitialOption = initialOption;
            MinQueryLength = minQueryLength;
            Confirm = confirm;
        }

        public ExternalSelect(string actionId, string placeholder, OptionObject initialOption, int? minQueryLength, ConfirmationDialogObject confirm) :
            this(actionId, placeholder, (object)initialOption, minQueryLength, confirm)
        {
        }

        public ExternalSelect(string actionId, string placeholder, OptionGroupObject initialOption, int? minQueryLength, ConfirmationDialogObject confirm) :
            this(actionId, placeholder, (object)initialOption, minQueryLength, confirm)
        {
        }

        public ExternalSelect(string actionId, string placeholder) : this(actionId, placeholder, (object)null, null, null)
        {
        }
    }
}
