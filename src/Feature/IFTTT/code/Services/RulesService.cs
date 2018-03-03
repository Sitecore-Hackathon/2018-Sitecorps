using Community.Feature.IFTTT.Constants;
using Community.Feature.IFTTT.Rules;
using Community.Feature.IFTTT.Utils;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.SecurityModel;

namespace Community.Feature.IFTTT.Services
{

    public interface IRulesService
    {
        void RunEventRules(string eventName, Item pageItem = null, params string[] values);
    }

    public class RulesService : IRulesService
    { 

        public void RunEventRules(string eventName, Item pageItem = null, params string[] values) {
            
            Assert.IsNotNullOrEmpty(eventName, $"{nameof(RulesService)}.{nameof(RunEventRules)} parameter {nameof(eventName)} is required");
            
            var ruleContext = new EventRuleContext()
            {
                EventName = eventName,
                Item = pageItem,
                Value1 = ParamUtil.GetValue(1, values),
                Value2 = ParamUtil.GetValue(2, values),
                Value3 = ParamUtil.GetValue(3, values)
            };

            // Run Global Rules
            using (new SecurityDisabler())
            {
                var root = Utils.ItemUtil.GetItemById(ItemIds.GlobalRules.EventRules);
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