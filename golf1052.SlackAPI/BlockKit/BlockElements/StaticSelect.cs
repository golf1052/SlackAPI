using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class StaticSelect : Select
    {
        public List<OptionObject> Options { get; set; }
        public List<OptionGroupObject> OptionGroups { get; set; }
        public object InitialOption { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        private StaticSelect(string actionId,
            string placeholder,
            List<OptionObject> options,
            List<OptionGroupObject> optionGroups,
            object initialOption,
            ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (placeholder.Length > 150)
            {
                throw new ArgumentException($"{nameof(placeholder)} must be 150 characters or less.");
            }

            if (options != null && options.Count > 100)
            {
                throw new ArgumentException($"{nameof(options)} must be 100 items or less.");
            }

            if (optionGroups != null && optionGroups.Count > 100)
            {
                throw new ArgumentException($"{nameof(optionGroups)} must be 100 items or less.");
            }

            if (initialOption != null && !(initialOption is OptionObject) && !(initialOption is OptionGroupObject))
            {
                throw new ArgumentException($"{nameof(initialOption)} must be type {typeof(OptionObject)} or {typeof(OptionGroupObject)}");
            }

            Type = "static_select";
            ActionId = actionId;
            Placeholder = TextObject.CreatePlainTextObject(placeholder);
            Options = options;
            OptionGroups = optionGroups;
            InitialOption = initialOption;
            Confirm = confirm;
        }

        public StaticSelect(string actionId,
            string placeholder,
            List<OptionObject> options,
            OptionObject initialOption,
            ConfirmationDialogObject confirm) :
            this(actionId, placeholder, options, null, initialOption, confirm)
        {
        }

        public StaticSelect(string actionId,
            string placeholder,
            List<OptionGroupObject> optionGroups,
            OptionGroupObject initialOption,
            ConfirmationDialogObject confirm) :
            this(actionId, placeholder, null, optionGroups, initialOption, confirm)
        {
        }

        public StaticSelect(string actionId, string placeholder, params OptionObject[] options) :
            this(actionId, placeholder, new List<OptionObject>(options), null, null)
        {
        }

        public StaticSelect(string actionId, string placeholder, params OptionGroupObject[] optionGroups) :
            this(actionId, placeholder, new List<OptionGroupObject>(optionGroups), null, null)
        {
        }
    }
}
