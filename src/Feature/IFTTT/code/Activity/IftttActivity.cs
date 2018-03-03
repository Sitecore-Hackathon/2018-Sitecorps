using Community.Feature.IFTTT.Services;
using Sitecore.Xdb.MarketingAutomation.Core.Activity;
using Sitecore.Xdb.MarketingAutomation.Core.Processing.Plan;

namespace Community.Feature.IFTTT.Activity
{
    public class IftttActivity : IActivity
    {
        public IActivityServices Services { get; set; }

        public IIftttService Ifttt { get; set; }

        public IftttActivity(IIftttService ifttt)
        {
            Ifttt = ifttt;
        }
        
        public ActivityResult Invoke(IContactProcessingContext context)
        {
            //   Log.Info("IftttActivity - TADA !!!!!!!", this);
            // Actually, can't call logging from xConnect

            // TODO: Pull inputs from Marketing Automation Instance (because we can't call sitecore databases from xConnect
            Ifttt.Trigger("nV4IGcOUNyGb8RG83PZz4ZclSfydE_eai5sg0golPZ9", "sitecore_event","Hard Coded Marketing Automation Value");

            return new SuccessMove("true");
        }
    }
}