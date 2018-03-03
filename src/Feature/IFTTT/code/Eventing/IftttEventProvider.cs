using Community.Feature.IFTTT.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Configuration;
using Sitecore.Eventing;
using System;

/// <summary>
/// This only seems to run for remote events... from the event queue
/// </summary>
namespace Community.Feature.IFTTT.Eventing
{
    public class IftttEventProvider : EventProvider
    {
        public override void RaiseEvent(object @event, Type eventType, EventContext context)
        {
            if (Settings.GetBoolSetting("IFTTT.Enable.RemoteEventTriggers", true))
            {
                var rules = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IRulesService>();
                rules.RunEventRules(eventType.ToString());
            }
            base.RaiseEvent(@event, eventType, context);
        }
        
    }
}