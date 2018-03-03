using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Feature.IFTTT.Forms.Templates
{
    public class Templates
    {
        public struct Event
        {
            // public static readonly ID Id = new ID("{F858854C-9273-48F1-B7EB-6DF94FCEFE14}");

            public struct Fields
            {
                public static readonly ID EventName = new ID("{514E2D42-262C-48B1-BDFA-E6244DA96D1E}");
            }
        }

        public struct Account
        {
            // public static readonly ID Id = new ID("{5D2AF9C0-FC34-428D-A0B1-62DF4ECE58DB}");

            public struct Fields
            {
                public static readonly ID MakerKey = new ID("{7AE5C19B-3D61-4860-9DC2-737A9668E41C}");
            }
        }
    }
}