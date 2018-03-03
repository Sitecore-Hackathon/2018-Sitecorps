using Community.Feature.IFTTT.Constants;
using Sitecore.Diagnostics;
using Sitecore.Rules.Actions;

namespace Community.Feature.IFTTT.Rules.Actions
{
    /// <summary>
    /// Action to override the event data to be whatever your want!
    /// Just be sure to add the action before the trigger
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetValue<T> : RuleAction<T> where T : EventRuleContext
    {
        public string ValueOption { get; set; } // ID as string for simpler switch case below
        public string Value { get; set; }

        public override void Apply(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");

            if (!string.IsNullOrWhiteSpace(ValueOption)) {
                switch (ValueOption)
                {
                    case ItemIds.ValueOptions.Value1:
                        ruleContext.Value1 = Value;
                        break;
                    case ItemIds.ValueOptions.Value2:
                        ruleContext.Value2 = Value;
                        break;
                    case ItemIds.ValueOptions.Value3:
                        ruleContext.Value3 = Value;
                        break;
                }
            }
        }
        
    }
}

