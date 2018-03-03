using Community.Feature.IFTTT.Constants;
using Community.Feature.IFTTT.Services;
using Community.Feature.IFTTT.Utils;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data;
using Sitecore.Rules.Actions;

namespace Community.Feature.IFTTT.Rules.Actions
{
    public class Trigger<T> : RuleAction<T> where T : EventRuleContext
    {
        public ID MakerKey { get; set; }
        public ID Event { get; set; }

        public override void Apply(T ruleContext)
        {            
            var makerKey = ItemUtil.GetItemById(MakerKey)?[Templates.Account.Fields.MakerKey];
            var eventName = ItemUtil.GetItemById(Event)?[Templates.Event.Fields.EventName];
            var value1 = ruleContext?.EventType?.Name;
            
            var iftttService = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IIftttService>();
            iftttService.Trigger(makerKey, eventName, value1);
        }
    }
}

