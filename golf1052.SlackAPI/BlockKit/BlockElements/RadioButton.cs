using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class RadioButton : IBlockElement
    {
        public string Type { get; private set; }
        public string ActionId { get; set; }
        public List<OptionObject> Options { get; set; }
        public OptionObject InitialOption { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        public RadioButton(string actionId, List<OptionObject> options, OptionObject initialOption, ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (options.Count > 10)
            {
                throw new ArgumentException($"{nameof(options)} must have 10 items or less.");
            }

            Type = "radio_buttons";
            ActionId = actionId;
            Options = options;
            InitialOption = initialOption;
            Confirm = confirm;
        }

        public RadioButton(string actionId, params OptionObject[] options) : this(actionId, new List<OptionObject>(options), null, null)
        {
        }
    }
}
