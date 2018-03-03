using Community.Feature.IFTTT.Constants;
using Community.Feature.IFTTT.Services;
using Community.Feature.IFTTT.Utils;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data;
using Sitecore.Rules.Actions;
using Sitecore.SecurityModel;

namespace Community.Feature.IFTTT.Rules.Actions
{
    public class Trigger<T> : RuleAction<T> where T : EventRuleContext
    {
        public ID MakerKey { get; set; }
        public ID Event { get; set; }
        public string Threshold { get; set; }

        public override void Apply(T ruleContext)
        {
            using (new SecurityDisabler())
            { 
                var makerKey = ItemUtil.GetItemById(MakerKey)?[Templates.Account.Fields.MakerKey];
                var eventName = ItemUtil.GetItemById(Event)?[Templates.Event.Fields.EventName];

                if (MeetsThreshold(this.UniqueId, int.TryParse(Threshold, out int threshold) ? threshold : 0))
                { 
                    var iftttService = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IIftttService>();
                    iftttService.Trigger(makerKey, eventName, ruleContext.Value1, ruleContext.Value2, ruleContext.Value3);
                }
            }
        }

        protected bool MeetsThreshold(string uniqueId, int threshold)
        {
            if (threshold <= 1)
                return true;
            
            var _threshold = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IThresholdService>();
            return _threshold.IsMet(threshold, $"RuleAction_{uniqueId}");
        }
    }
}

