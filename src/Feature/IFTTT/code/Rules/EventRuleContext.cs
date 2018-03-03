using Sitecore.Eventing;
using Sitecore.Rules;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Community.Feature.IFTTT.Services;

namespace Community.Feature.IFTTT.Rules
{
    public class EventRuleContext : RuleContext
    {
        public string EventName { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
                
    }
}