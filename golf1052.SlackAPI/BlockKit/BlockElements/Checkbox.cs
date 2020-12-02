using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class Checkbox
    {
        public string Type { get; private set; }
        public string ActionId { get; set; }
        public List<OptionObject> Options { get; set; }
        public List<OptionObject> InitialOptions { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        public Checkbox(string actionId, List<OptionObject> options, List<OptionObject> initialOptions, ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (options.Count > 10)
            {
                throw new ArgumentException($"{nameof(options)} must be 10 items or less.");
            }

            Type = "checkboxes";
            ActionId = actionId;
            Options = options;
            InitialOptions = initialOptions;
            Confirm = confirm;
        }

        public Checkbox(string actionId, params OptionObject[] options) : this(actionId, new List<OptionObject>(options), null, null)
        {
        }
    }
}
