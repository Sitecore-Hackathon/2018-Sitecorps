using Community.Feature.IFTTT.Constants;
using Community.Feature.IFTTT.Rules;
using Community.Feature.IFTTT.Utils;
using Sitecore.Configuration;
using Sitecore.Eventing;
using Sitecore.Rules;
using Sitecore.SecurityModel;
using System;

namespace Community.Feature.IFTTT.Eventing
{
    public class IftttEventProvider : EventProvider
    {

        public override void RaiseEvent(object @event, Type eventType, EventContext context)
        {
            if (Settings.GetBoolSetting("IFTTT.Enable.RemoteEventTriggers", true))
            {
                RunRules(new EventRuleContext()
                    {
                        Event = @event,
                        EventType = eventType,
                        EventContext = context
                    }
                );
            }
            base.RaiseEvent(@event, eventType, context);
        }

        protected void RunRules(EventRuleContext ruleContext)
        {
            using (new SecurityDisabler())
            {
                var root = ItemUtil.GetItemById(ItemIds.GlobalRules.EventRules);
                if (root == null)
                    return; // no root, exit

                RuleList<EventRuleContext> rules = RuleFactory.GetRules<EventRuleContext>(root, "Rule");
                if (rules != null)
                {
                    rules.Run(ruleContext);
                }
            }
        }
    }
}