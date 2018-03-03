using Newtonsoft.Json.Linq;
using Sitecore.Diagnostics;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
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

            Assert.IsNotNullOrEmpty(makerKey, $"{nameof(IftttService)}.{nameof(Trigger)} parameter {nameof(makerKey)} is required");
            Assert.IsNotNullOrEmpty(eventName, $"{nameof(IftttService)}.{nameof(Trigger)} parameter {nameof(eventName)} is required");

            var url = $"https://maker.ifttt.com/trigger/{eventName}/with/key/{makerKey}";
            Log.Info($"IFTTT Trigger service: {url}",this);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaTypeFormatter.DefaultMediaType.MediaType));
                
                // Handle optional ifttt data values
                var data = (dynamic)new JObject();                
                if(values != null && values.Any())
                {
                    data.Value1 = GetValue(1, values);
                    data.Value2 = GetValue(2, values);
                    data.Value3 = GetValue(3, values);
                }
                var payload = new StringContent(data.ToString(), Encoding.UTF8, JsonMediaTypeFormatter.DefaultMediaType.MediaType);

                Log.Audit($"IFTTT Trigger/{eventName}/with/key/{makerKey} [{data.Value1},{data.Value2},{data.Value3}]", this);
                var response = Task.Run(()=> client.PostAsync(url, payload)).Result;
                Log.Audit($"IFTTT Trigger response: {response?.StatusCode} - {response?.ReasonPhrase}", this);
            }
        }

        /// <summary>
        /// Return value or null
        /// </summary>
        /// <param name="values">Array of values (or null)</param>
        /// <param name="n">1 based index</param>
        /// <returns></returns>
        private string GetValue(int n, string[] values) {
            if (values == null || values.Length < n)
                return null;
            return values[n-1];
        }
        
    }
}