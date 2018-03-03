using Community.Feature.IFTTT.Constants;
using Community.Feature.IFTTT.Services;
using Community.Feature.IFTTT.Utils;
using System.Web.Mvc;

namespace Community.Feature.IFTTT.Controllers
{
    public class TriggerController : Controller
    {
        private IIftttService Ifttt;
        private IThresholdService Threshold;

        public TriggerController(IIftttService ifttt, IThresholdService threshold)
        {
            Ifttt = ifttt;
            Threshold = threshold;
        }

        public ActionResult Send()
        {
            var rendering = Sitecore.Mvc.Presentation.RenderingContext.CurrentOrNull?.Rendering;
            var parameters = rendering?.Parameters;
            var makerKey = ItemUtil.GetItemById( parameters?[Templates.Parameters.MakerKey] )?[Templates.Account.Fields.MakerKey];
            var eventName = ItemUtil.GetItemById( parameters?[Templates.Parameters.Event] )?[Templates.Event.Fields.EventName];
            var threshold = int.TryParse( parameters?[Templates.Parameters.Threshold], out int num)? num : -1;
            var value1 = parameters?[Templates.Parameters.Value1];
            var value2 = parameters?[Templates.Parameters.Value2];
            var value3 = parameters?[Templates.Parameters.Value3];

            if(threshold > 1)
            {
                var thresholdKey = KeyUtil.MakeKey(
                    $"{nameof(TriggerController)}_{nameof(Send)}_", 
                    Sitecore.Context.Item?.ID.ToGuid().ToString(), 
                    rendering?.UniqueId
                );

                if (Threshold.IsMet(threshold, thresholdKey))
                {
                    Ifttt.Trigger(makerKey, eventName, value1, value2, value3);
                    return Content($"<p>Threshold met, trigger '{eventName}' sent!</p>");
                }
                else {
                    return Content("<p>Threshold incremented</p>");
                }
            }

            Ifttt.Trigger(makerKey, eventName, value1, value2, value3);
            return Content($"<p>Trigger '{eventName}' sent!</p>");
        }
    }
}