using Community.Feature.IFTTT.Services;
using Community.Feature.IFTTT.Utils;
using Sitecore.Analytics.Pipelines.RegisterPageEvent;
using Sitecore.Diagnostics;

namespace Community.Feature.IFTTT.Pipelines.RegisterPageEvent
{
    public class RunIftttRules : RegisterPageEventProcessor
    {
        protected IRulesService Rules;
        public RunIftttRules(IRulesService rules)
        {
            Rules = rules;
        }
        
        public override void Process(RegisterPageEventArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (args.PageEvent == null)
                return;

            var pageItem = ItemUtil.GetItemById(args.PageEvent.ItemId);

            Rules.RunEventRules(args.PageEvent?.Name,
                pageItem,
                args.PageEvent.DataKey,
                args.PageEvent.IsGoal? "is goal":"not goal",
                args.PageEvent.Value.ToString()
            );

        }
    }
}