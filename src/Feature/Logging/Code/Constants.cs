using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Feature.IFTTT.Logging
{
    public static class Constants
    {
        public static class IDs
        {
            public static readonly ID RulesRootFolderId = new ID("{9C3BBE7E-DA75-43B6-9EAE-E0678CEF6E2C}");
        }
        public static class Templates
        {
            public static readonly ID LoggingRule = new ID("{11D160CF-D33E-4343-B7B8-83BD7A5D4657}");
        }
        public static class Fields
        {
            public static readonly string Rule = "Rule";
        }
    }
}