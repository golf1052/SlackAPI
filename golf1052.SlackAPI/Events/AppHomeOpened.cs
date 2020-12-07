using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.Events
{
    public class AppHomeOpened
    {
        public const string Type = "app_home_opened";
        public string User { get; set; }
        public string Channel { get; set; }
        public string Tab { get; set; }
        public string EventTs { get; set; }
    }
}
