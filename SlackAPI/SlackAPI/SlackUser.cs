using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace golf1052.SlackAPI
{
    public class SlackUser
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool Deleted { get; private set; }
        public string Color { get; private set; }
        public SlackUserProfile Profile { get; private set; }
        public bool Admin { get; private set; }
        public bool Owner { get; private set; }
        public bool PrimaryOwner { get; private set; }
        public bool Restricted { get; private set; }
        public bool UltraRestricted { get; private set; }
        public bool Bot { get; private set; }
        public bool TwoFactorAuth { get; private set; }
        public SlackConstants.TwoFactorTypes? TwoFactorType { get; private set; }
        public bool Files { get; private set; }
        public SlackConstants.Presence? Presence { get; private set; }

        public SlackUser(JObject o)
        {
            Id = (string)o["id"];
            if (o["name"] != null)
            {
                Name = (string)o["name"];
            }
            if (o["deleted"] != null)
            {
                Deleted = (bool)o["deleted"];
            }
            if (o["color"] != null)
            {
                Color = (string)o["color"];
            }
            Profile = new SlackUserProfile((JObject)o["profile"]);
            if (o["is_admin"] != null)
            {
                Admin = (bool)o["is_admin"];
            }
            if (o["is_owner"] != null)
            {
                Owner = (bool)o["is_owner"];
            }
            if (o["is_primary_owner"] != null)
            {
                PrimaryOwner = (bool)o["is_primary_owner"];
            }
            if (o["is_restricted"] != null)
            {
                Restricted = (bool)o["is_restricted"];
            }
            if (o["is_ultra_restricted"] != null)
            {
                UltraRestricted = (bool)o["is_ultra_restricted"];
            }
            TwoFactorType = null;
            if (o["has_2fa"] != null)
            {
                TwoFactorAuth = (bool)o["has_2fa"];
                if (TwoFactorAuth)
                {
                    if (o["two_factor_type"] != null)
                    {
                        string tfa = (string)o["two_factor_type"];
                        if (tfa == "sms")
                        {
                            TwoFactorType = SlackConstants.TwoFactorTypes.Sms;
                        }
                        else if (tfa == "app")
                        {
                            TwoFactorType = SlackConstants.TwoFactorTypes.App;
                        }
                    }
                }
            }
            if (o["has_files"] != null)
            {
                Files = (bool)o["has_files"];
            }
            Presence = null;
            if (o["presence"] != null)
            {
                string presence = (string)o["presence"];
                if (presence == "active")
                {
                    Presence = SlackConstants.Presence.Active;
                }
                else if (presence == "away")
                {
                    Presence = SlackConstants.Presence.Away;
                }
            }
        }
    }
}
