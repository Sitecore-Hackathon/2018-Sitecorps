using Community.Feature.IFTTT.Constants;
using Sitecore.Diagnostics;
using Sitecore.Rules.Conditions;
using System;

namespace Community.Feature.IFTTT.Rules.Conditions
{
    /// <summary>
    /// Condition to string compare against one of the provided event values.
    /// This allows conditional filtering before sending IFTTT trigger.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OnEventValue<T> : StringOperatorCondition<T> where T : EventRuleContext
    {
        public string ValueOption { get; set; } // ID as string for simpler switch case below
        public string Value { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");

            var eventValue = GetEventValue(ValueOption, ruleContext);
            
            if (String.IsNullOrEmpty(eventValue))
                return false;

            return Compare(eventValue, Value);
        }

        protected virtual string GetEventValue(string optionId, EventRuleContext ruleContext)
        {
            switch (optionId)
            {
                case ItemIds.ValueOptions.Value1:
                    return ruleContext.Value1;
                case ItemIds.ValueOptions.Value2:
                    return ruleContext.Value2;
                case ItemIds.ValueOptions.Value3:
                    return ruleContext.Value3;
            }
            return null;
        }
        
    }
}