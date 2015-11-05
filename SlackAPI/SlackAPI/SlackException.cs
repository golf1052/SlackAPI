using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golf1052.SlackAPI
{
    public class SlackException : Exception
    {
        public SlackException()
        {
        }

        public SlackException(string message) : base(message)
        {
        }
    }
}
