using Community.Feature.IFTTT.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.Rules.Conditions;
using System;

namespace Community.Feature.IFTTT.Rules.Conditions
{
    public class OnEvent<T> : StringOperatorCondition<T> where T : EventRuleContext
    {
        public string Value { get; set; }
        public string Threshold { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");

            var eventName = ruleContext?.EventType?.Name;
            if (String.IsNullOrEmpty(eventName))
                return false;

            return Compare(eventName, Value) && MeetsThreshold(ruleContext.EventType.Name, int.TryParse(Threshold, out int threshold)? threshold : 0);            
        }

        protected bool MeetsThreshold(string uniqueId, int threshold)
        {
            if (threshold <= 1)
                return true;
            
            // TODO: fix issue of multiple conditions incrementing each time

            var _threshold = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IThresholdService>();
            return _threshold.IsMet(threshold, $"RuleCondition_OnEvent_{uniqueId}");
        }
    }
}