using Sitecore.Diagnostics;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Feature.IFTTT.Logging.Rules
{
    public class LoggerCondition<T> : StringOperatorCondition<T> where T : LoggerRuleContext
    {
        public string logText { get; set; }
        public Int32 logCount { get; set; }
        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");
            LoggerRuleContext loggerRuleContext = ruleContext as LoggerRuleContext;
            if (loggerRuleContext == null)
                return false;
            return Compare(loggerRuleContext.LogText, logText) && MeetsThreshold(loggerRuleContext);
        }

        private bool MeetsThreshold(LoggerRuleContext loggerRuleContext)
        {
            string thresholdKey = loggerRuleContext.ItemId.ToString() + logCount;
            if (Variables.LogsThreshold == null)
                Variables.LogsThreshold = new Dictionary<string, int>();
            if (Variables.LogsThreshold.ContainsKey(thresholdKey))
            {
                if(Variables.LogsThreshold[thresholdKey] > logCount)
                {
                    Variables.LogsThreshold[thresholdKey] = 0;
                    loggerRuleContext.Threshold = logCount;
                    return true;
                }
                Variables.LogsThreshold[thresholdKey]++;
            }
            else
            {
                Variables.LogsThreshold.Add(thresholdKey, 1);
            }
            return false;
        }
    }
}