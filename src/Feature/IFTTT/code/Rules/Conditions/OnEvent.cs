using Community.Feature.IFTTT.Utils;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Rules.Conditions;
using System;

namespace Community.Feature.IFTTT.Rules.Conditions
{
    /// <summary>
    /// Condition to listen for Event Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OnEvent<T> : WhenCondition<T> where T : EventRuleContext
    {
        public ID Value { get; set; } // Supported Event ID

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");

            var supportedEvent = ItemUtil.GetItemById(Value);
            var eventName = supportedEvent?.DisplayName; // Convention of using display name for full event name

            if (String.IsNullOrEmpty(eventName))
                return false;

            return (ruleContext?.EventName == eventName);            
        }
        
    }
}