using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.Events
{
    public class UrlVerification : ISlackEvent
    {
        public const string Type = "url_verification";
        public string Token { get; set; }
        public string Challenge { get; set; }
    }
}
