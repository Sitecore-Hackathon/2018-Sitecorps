using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Feature.IFTTT.Utils
{
    public static class KeyUtil
    {
        /// <summary>
        /// Generates a string based on any number of object inputs
        /// </summary>
        /// <param name="keyPrefix"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string MakeKey(String keyPrefix, params dynamic[] data)
        {
            if (data == null || data.Count() == 0)
                return keyPrefix;

            // collapse objects into a string
            var str = String.Empty;
            foreach (var d in data)
            {
                if (d == null)
                    continue;
                str += JsonConvert.SerializeObject(d);
            }

            if (String.IsNullOrWhiteSpace(str))
                return keyPrefix;

            // further condense into a base64 string
            var encoding = new System.Text.ASCIIEncoding();
            return keyPrefix + System.Convert.ToBase64String(encoding.GetBytes(str));

        }
    }
}