using System;
using System.Collections.Generic;
using System.Text;
using golf1052.SlackAPI.BlockKit.Blocks;

namespace golf1052.SlackAPI.Objects.Requests
{
    public class SlackMessage
    {
        public string Text { get; set; }
        public List<IBlock> Blocks { get; set; }
        // legacy
        //public object Attachments { get; set; }
        public string ThreadTs { get; set; }
        public bool Mrkdwn { get; set; }

        public SlackMessage(string text, List<IBlock> blocks, string threadTs, bool mrkdwn)
        {
            Text = text;
            Blocks = blocks;
            ThreadTs = threadTs;
            Mrkdwn = mrkdwn;
        }

        public SlackMessage(string text) : this(text, null, null, true)
        {
        }

        public SlackMessage(string text, List<IBlock> blocks) : this(text, blocks, null, true)
        {
        }

        public SlackMessage(string text, params IBlock[] blocks) : this(text, new List<IBlock>(blocks), null, true)
        {
        }
    }
}
