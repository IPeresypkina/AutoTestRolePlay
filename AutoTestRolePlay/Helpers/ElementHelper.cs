using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTestRolePlay.Helpers
{
    public class ElementHelper
    {
        public static bool HasElement(IWebDriver driver, By selector, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            try
            {
                if (wait.Until(d =>
                    driver.FindElements(selector).Count > 0))
                {
                    return true;
                }
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
            return false;
        }
        
        // public static void WaitForPageToLoad(IWebDriver driver, int seconds = 30)
        // {
        //     var timeout = TimeSpan.FromSeconds(seconds);
        //     var wait = new WebDriverWait(driver, timeout);
        //
        //     var javascript = driver as IJavaScriptExecutor;
        //     if (javascript == null)
        //     {
        //         throw new ArgumentException("Driver must support javascript execution", nameof(driver));
        //     }
        //
        //     wait.Until(d =>
        //     {
        //         try
        //         {
        //             var readyState =
        //                 javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
        //             return readyState.ToLower() == "complete";
        //         }
        //         catch (InvalidOperationException e)
        //         {
        //             // Window is no longer available
        //             return e.Message.ToLower().Contains("unable to get browser");
        //         }
        //         catch (WebDriverException e)
        //         {
        //             // Browser is no longer available
        //             return e.Message.ToLower().Contains("unable to connect");
        //         }
        //         catch (System.Exception)
        //         {
        //             return false;
        //         }
        //     });
        // }
    }
}