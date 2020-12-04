using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class DatePicker : IBlockElement
    {
        public string Type { get; private set; }
        public string ActionId { get; set; }
        public TextObject Placeholder { get; set; }
        public string InitialDate { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        public DatePicker(string actionId, string placeholder, string initialDate, ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (!string.IsNullOrEmpty(placeholder) && placeholder.Length > 150)
            {
                throw new ArgumentException($"{nameof(placeholder)} must be 150 characters or less.");
            }

            Type = "datepicker";
            ActionId = actionId;
            if (!string.IsNullOrEmpty(placeholder))
            {
                Placeholder = TextObject.CreatePlainTextObject(placeholder);
            }
            InitialDate = initialDate;
            Confirm = confirm;
        }

        public DatePicker(string actionId) : this(actionId, null, null, null)
        {
        }
    }
}
