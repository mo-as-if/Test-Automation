using System;
using System.Collections.Generic;
using System.Text;
using static FrameworkLib.Base.Browsers;

namespace FrameworkLib.Configuration
{
    public class SystemSetting
    {
        public static string USPSURL { get; set; }
        public static string ReportPath { get; set; }
        public static BrowserType BrowserType { get; set; }
    }
}
