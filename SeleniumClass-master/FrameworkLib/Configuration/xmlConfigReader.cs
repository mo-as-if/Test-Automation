using FrameworkLib.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.XPath;

namespace FrameworkLib.Configuration
{
    public class xmlConfigReader
    {

        /*Get FullPath from Current SLN*/
        public static void AUTAppSettingsReader(string AppConfigName)
        {
            try
            {

                /*Properties of AUTConfigs.xml*/
                //XPathItem AUTMortageCalculator;
                //XPathItem AUTAmazon;
                XPathItem AUTUSPS;
                XPathItem Browser;
                XPathItem ReportPath;

                /*Get FullPath from Current SLN*/

                string projectpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
                //string strFileName = projectpath + "FrameworkLib\\Configuration\\AppAUTConfig.xml";
                if (AppConfigName == "AppAUTConfig.xml")
                {
                    string strFileName = projectpath + AppConfigName;
                    /*Open the File*/
                    FileStream stream = new FileStream(strFileName, FileMode.Open);
                    XPathDocument document = new XPathDocument(stream);
                    XPathNavigator navigator = document.CreateNavigator();

                    /*Get XML Details and pass it in xpathItem type Variables*/
                    AUTUSPS = navigator.SelectSingleNode("FrameworkLib/RunSettings/AUTUSPS");
                    Browser = navigator.SelectSingleNode("FrameworkLib/ RunSettings/ Browser");
                    ReportPath = navigator.SelectSingleNode("FrameworkLib/RunSettings/ReportPath");

                    /*Set XML details in the property to be used accross framwork*/

                    SystemSetting.ReportPath = ReportPath.Value.ToString();
                    SystemSetting.USPSURL = AUTUSPS.Value.ToString();
                    //  SystemSetting.BrowserType = Browser.Value.ToString();
                }
                //   SystemSetting.BrowserType = Browser.ValueType.ToString();





            }
            catch (Exception e)
            {
                LogHelper.Write($"Something went wrong while reading xml file; {e}");
            }
        }
    }


}

