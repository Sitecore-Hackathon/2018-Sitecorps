using Sitecore.Data;
using Sitecore.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Feature.IFTTT.Logging.Rules
{
    public class LoggerRuleContext : RuleContext
    {
        public string LogLevel { get; set; }
        public string LogText { get; set; }
        public int Threshold { get; set; }
        public ID ItemId { get; set; }
    }
}