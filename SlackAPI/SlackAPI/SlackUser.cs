using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golf1052.SlackAPI
{
    public class SlackUser
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool Deleted { get; private set; }
        public string Color { get; private set; }
        public bool Admin { get; private set; }
        public bool Owner { get; private set; }
        public bool PrimaryOwner { get; private set; }
        public bool Restricted { get; private set; }
        public bool UltraRestricted { get; private set; }
        public bool TwoFactorAuth { get; private set; }
        public SlackConstants.TwoFactorTypes TwoFactorType { get; private set; }
        public bool Files { get; private set; }
    }
}
