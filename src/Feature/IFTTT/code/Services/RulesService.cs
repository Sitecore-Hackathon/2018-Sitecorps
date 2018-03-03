using Newtonsoft.Json.Linq;
using Sitecore.Diagnostics;
using Sitecore.Eventing;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Community.Feature.IFTTT.Services
{
    public interface IRulesService
    {
        /// <summary>
        /// Send Trigger to IFTTT
        /// </summary>
        /// <param name="makerKey">Account Key</param>
        /// <param name="eventName">Custom event name</param>
        /// <param name="values">Optional, Only first 3 values are sent (ifttt limit)</param>
        void ProcessEvent(object @event, Type eventType, EventContext context);
    }

    public class RulesService : IRulesService
    { 

        public void ProcessEvent(object @event, Type eventType, EventContext context) {

           
        }
        
    }
}