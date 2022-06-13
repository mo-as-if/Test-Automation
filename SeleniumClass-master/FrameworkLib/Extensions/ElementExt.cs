using FrameworkLib.Base;
using FrameworkLib.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FrameworkLib.Extensions
{
  public  class ElementExt 
    {
        public static object JavaScriptExecutor { get; private set; }
        //  DriverContext.Driver Driver = new DriverContext.Driver();
      //  IWebDriver Driver = new DriverContext;

        public class RadioButtons
        {
          
            public RadioButtons(ReadOnlyCollection<IWebElement> webElements)
            {
               
                WebElements = webElements;
            }
            protected ReadOnlyCollection<IWebElement> WebElements { get; }
            public IWebElement SelectValue(string value)
            {

                return WebElements.Single(WebElement => WebElement.GetAttribute("value") == value);
                LogHelper.Write($"CLicked on Radio matching {value}");

            }

        }

        public static void DDSelectElem(IWebElement Item, string value)
        {
            SelectElement ddItem = new SelectElement(Item);
            ddItem.SelectByText(value);
            LogHelper.Write($" selected on {value} dropdown");
        }

        public static void SendValue(IWebElement Item, string value)
        {
            Item.SendKeys(value);
            Item.SendKeys(Keys.Enter);
            LogHelper.Write($"Sendkey on {Item.Text} and sent testdata {value}");

         
        }

        public static void ClickOnElemnt(IWebElement Item)
        {
            Item.Click();
        }

        public static void  DoubleClickElemnt(IWebElement Item)
        {
           
              new Actions(DriverContext.Driver).DoubleClick(Item).Build().Perform();
        }

        public static void DragAndDrop(IWebElement Item, IWebElement Target)
        {

            new Actions(DriverContext.Driver).DragAndDrop(Item, Target).Build().Perform();
        }
        public static void ClearElemnt(IWebElement Item)
        {
            Item.Clear();
        }

        public static IWebElement GetText(IWebElement Item)
        {
            string ItemText = Item.Text;
         return Item;
        }

    }
}
