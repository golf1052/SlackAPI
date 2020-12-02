using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.CompositionObjects;

namespace golf1052.SlackAPI.BlockKit.BlockElements
{
    internal class ConversationsSelect
    {
        public string InitialConversation { get; set; }
        public bool DefaultToCurrentConversation { get; set; }
        public ConfirmationDialogObject Confirm { get; set; }
        public bool ResponseUrlEnabled { get; set; }
        // TODO: Implement filter object https://api.slack.com/reference/block-kit/composition-objects#filter_conversations
        //public object Filter { get; set; }
    }
}
