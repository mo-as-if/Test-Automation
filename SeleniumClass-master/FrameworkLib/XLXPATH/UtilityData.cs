using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkLib.XLXPATH
{
  public static  class UtilityData
    {
    
         public static string USPS = Environment.CurrentDirectory.ToString() + "\\TestData\\USPSTestData.xlsx";


        //public static string UPS = "UPS\\TestData\\";

        //  C:\Users\Faisal\Desktop\For QA Class\Automation\SeleniumTest\source\repos\seleniumTest\seleniumTest\TestData\mortgagecalculator.xlsx

        public static string getCurrentDataWithFormat(string value)
        {
            return DateTime.Now.ToString(value);
        }
    }
}
