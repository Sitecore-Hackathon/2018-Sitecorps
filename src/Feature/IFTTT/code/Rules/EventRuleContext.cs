using Sitecore.Eventing;
using Sitecore.Rules;
using System;

namespace Community.Feature.IFTTT.Rules
{
    public class EventRuleContext : RuleContext
    {
        public object Event { get; set; }
        public Type EventType { get; set; }
        public EventContext EventContext { get; set; }
    }
}