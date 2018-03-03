using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Feature.IFTTT.Logging
{
    /// <summary>
    /// This is a static class that holds Logs threshold values for each condition
    /// </summary>
    public static class Variables
    {
        public static Dictionary<string,int> LogsThreshold { get; set; }
    }
}