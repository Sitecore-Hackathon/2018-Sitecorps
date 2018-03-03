using Community.Feature.IFTTT.Utils;
using System.Net.Http;
using System.Threading.Tasks;

namespace Community.Feature.IFTTT.Services
{
    public struct EventTypes {
        public const string Test = "sitecore_event";
    }

    public interface IIftttService
    {
        /// <summary>
        /// Send Trigger to IFTTT
        /// </summary>
        /// <param name="makerKey">Account Key</param>
        /// <param name="eventName">Custom event name</param>
        /// <param name="values">Optional, Only first 3 values are sent (ifttt limit)</param>
        void Trigger(string makerKey, string eventName, params string[] values);
    }

    public class IftttService : IIftttService
    { 

        public void Trigger(string makerKey, string eventName, params string[] values) {

            //Assert.IsNotNullOrEmpty(makerKey, $"{nameof(IftttService)}.{nameof(Trigger)} parameter {nameof(makerKey)} is required");
            //Assert.IsNotNullOrEmpty(eventName, $"{nameof(IftttService)}.{nameof(Trigger)} parameter {nameof(eventName)} is required");

            // TODO: Add proper queue for scaling
            // TODO: Add governance? - block too many requests?

            using (var client = new HttpClient())
            {
                // Handle optional ifttt data values
                var value1 = ParamUtil.GetValue(1, values);
                var value2 = ParamUtil.GetValue(2, values);
                var value3 = ParamUtil.GetValue(3, values);
                
                var url = $"https://maker.ifttt.com/trigger/{eventName}/with/key/{makerKey}?value1={value1}&value2={value2}&value3={value3}";

                // Log.Info($"IFTTT Trigger service: {url}", this);
                var response = Task.Run(()=> client.GetAsync(url)).Result;
                // Log.Info($"IFTTT Trigger response: {response?.StatusCode} - {response?.ReasonPhrase}", this);
            }
        }
        
    }
}