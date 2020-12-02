using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    public class UserSelect : Select
    {
        public string InitialUser { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }

        public UserSelect(string actionId, string placeholder, string initialUser, ConfirmationDialogObject confirm)
        {
            if (actionId.Length > 255)
            {
                throw new ArgumentException($"{nameof(actionId)} must be 255 characters or less.");
            }

            if (placeholder.Length > 150)
            {
                throw new ArgumentException($"{nameof(placeholder)} must be 150 characters or less.");
            }

            Type = "users_select";
            ActionId = actionId;
            Placeholder = TextObject.CreatePlainTextObject(placeholder);
            InitialUser = initialUser;
            Confirm = confirm;
        }

        public UserSelect(string actionId, string placeholder) : this(actionId, placeholder, null, null)
        {
        }
    }
}
