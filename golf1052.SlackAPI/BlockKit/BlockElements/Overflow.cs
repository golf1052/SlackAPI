using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class Overflow
    {
        public string Type { get; private set; }
        public string ActionId { get; set; }
        public List<OptionObject> Options { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        public Overflow(string actionId, List<OptionObject> options, ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (options.Count < 2 || options.Count > 5)
            {
                throw new ArgumentException($"{nameof(options)} must contain 2 or more items and 5 or less items.");
            }

            Type = "overflow";
            ActionId = actionId;
            Options = options;
            Confirm = confirm;
        }

        public Overflow(string actionId, params OptionObject[] options) : this(actionId, new List<OptionObject>(options), null)
        {
        }
    }
}
