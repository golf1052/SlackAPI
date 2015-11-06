using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golf1052.SlackAPI
{
    public class SlackConstants
    {
        public const string SlackBaseUrl = "https://slack.com/api/";
        
        public enum TwoFactorTypes
        {
            Sms,
            App
        }

        public enum Presence
        {
            Active,
            Away
        }
    }
}
