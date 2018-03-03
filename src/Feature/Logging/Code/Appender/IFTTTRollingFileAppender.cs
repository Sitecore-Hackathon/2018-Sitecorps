using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net.spi;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Community.Feature.IFTTT.Logging.Rules;
using Sitecore.Data;
using Sitecore.SecurityModel;

namespace Community.Feature.IFTTT.Logging.Appender
{
    public class IFTTTRollingFileAppender: log4net.Appender.RollingFileAppender
    {
        static Database webDb = Sitecore.Configuration.Factory.GetDatabase("web");
        protected override void Append(LoggingEvent loggingEvent)
        {
            if(Sitecore.Configuration.Settings.GetBoolSetting("IFTTT.Logging.Enabled", false))
            {
                LoggerRuleContext ruleContext = new LoggerRuleContext();
                ruleContext.LogLevel = loggingEvent.Level.Name;
                ruleContext.LogText = loggingEvent.MessageObject.ToString();
                RunRules(ruleContext);
            }
            base.Append(loggingEvent);
        }

        ///<summary>
        /// runs the set of rules and checks for any matches, if it finds a match it will run the rule's associated action
        /// </summary>
        /// <param name="Root">Item which holds the field</param>
        /// <param name="Field">the rule field name</param>
        /// <returns></returns>
        public static void RunRules(LoggerRuleContext ruleContext)
        {
            using (new SecurityDisabler())
            {
                Item rootRulesFolder = webDb.GetItem(Constants.IDs.RulesRootFolderId);
                if (rootRulesFolder == null)
                    return;
                var rulesItems = rootRulesFolder.Children.Where(i => i.TemplateID.Equals(Constants.Templates.LoggingRule));
                if (!rulesItems.Any())
                    return;
                foreach (var ruleItem in rulesItems)
                {
                    foreach (Rule<LoggerRuleContext> rule in RuleFactory.GetRules<LoggerRuleContext>(new[] { ruleItem }, Constants.Fields.Rule).Rules)
                    {
                        ruleContext.ItemId = ruleItem.ID;
                        if (rule.Condition != null)
                        {
                            var stack = new RuleStack();
                            rule.Condition.Evaluate(ruleContext, stack);

                            if (ruleContext.IsAborted)
                            {
                                continue;
                            }
                            if ((stack.Count != 0) && ((bool)stack.Pop()))
                            {
                                rule.Execute(ruleContext);
                            }
                        }
                        else
                            rule.Execute(ruleContext);
                    }
                }
            }

        }
    }
}