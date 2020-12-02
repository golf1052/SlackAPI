using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class ChannelSelect : Select
    {
        public string InitialChannel { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }
        public bool ResponseUrlEnabled { get; set; }

        public ChannelSelect(string actionId, string placeholder, string initialChannel, ConfirmationDialogObject confirm, bool responseUrlEnabled)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (placeholder.Length > 150)
            {
                throw new ArgumentException($"{nameof(placeholder)} must be 150 characters or less.");
            }

            Type = "channels_select";
            ActionId = actionId;
            Placeholder = TextObject.CreatePlainTextObject(placeholder);
            InitialChannel = initialChannel;
            Confirm = confirm;
            ResponseUrlEnabled = responseUrlEnabled;
        }

        public ChannelSelect(string actionId, string placeholder) : this(actionId, placeholder, null, null, false)
        {
        }
    }
}
