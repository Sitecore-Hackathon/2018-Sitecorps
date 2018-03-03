using Community.Feature.IFTTT.Constants;
using Community.Feature.IFTTT.Services;
using Community.Feature.IFTTT.Utils;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data;
using Sitecore.Rules.Actions;

namespace Community.Feature.IFTTT.Logging.Rules
{
    /// <summary>
    /// Trigger IFTTT event action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TriggerAction<T> : RuleAction<T> where T : LoggerRuleContext
    {
        /// <summary>
        /// Maker Key
        /// </summary>
        public ID IftttAccountId { get; set; }
        /// <summary>
        /// Event name in IFTTT
        /// </summary>
        public ID IftttEventId { get; set; }

        public override void Apply(T ruleContext)
        {
            var makerKey = ItemUtil.GetItemById(IftttAccountId)?[Templates.Account.Fields.MakerKey];
            var eventName = ItemUtil.GetItemById(IftttEventId)?[Templates.Event.Fields.EventName];
            LoggerRuleContext loggerRuleContext = ruleContext as LoggerRuleContext;
            if (loggerRuleContext == null)
                return;
            var value1 = loggerRuleContext.LogText +" was written in logs "+ loggerRuleContext.Threshold +" times";

            var iftttService = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IIftttService>();
            iftttService.Trigger(makerKey, eventName, value1);
        }
    }
}