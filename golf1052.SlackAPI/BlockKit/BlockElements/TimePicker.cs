using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class TimePicker
    {
        public string Type { get; private set; }
        public string ActionId { get; set; }
        public TextObject Placeholder { get; set; }
        public string InitialTime { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        public TimePicker(string actionId, string placeholder, string initialTime, ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (!string.IsNullOrEmpty(placeholder) && placeholder.Length > 150)
            {
                throw new ArgumentException($"{nameof(placeholder)} must be 150 characters or less.");
            }

            Type = "timepicker";
            ActionId = actionId;
            if (!string.IsNullOrEmpty(placeholder))
            {
                Placeholder = TextObject.CreatePlainTextObject(placeholder);
            }
            InitialTime = initialTime;
            Confirm = confirm;
        }

        public TimePicker(string actionId) : this(actionId, null, null, null)
        {
        }
    }
}
