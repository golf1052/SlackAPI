using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace golf1052.SlackAPI.Events
{
    public class Hello : SlackEvent
    {
        public override SlackEventType Type
        {
            get
            {
                return SlackEventType.Hello;
            }
        }
    }
}
