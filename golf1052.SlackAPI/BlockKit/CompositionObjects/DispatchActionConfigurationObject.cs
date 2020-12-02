using System;
using System.Collections.Generic;
using System.Text;

namespace golf1052.SlackAPI.BlockKit.CompositionObjects
{
    public class DispatchActionConfigurationObject
    {
        public List<string> TriggerActionsOn { get; set; }

        public DispatchActionConfigurationObject()
        {
        }

        public DispatchActionConfigurationObject(List<string> triggerActionsOn)
        {
            TriggerActionsOn = triggerActionsOn;
        }
    }
}
