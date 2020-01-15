using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebTest.Helpers
{
    public class ElementHelper
    {
        public static bool HasElement(IWebDriver driver, By selector, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            try
            {
                if (wait.Until(d => driver.FindElements(selector).Count > 0))
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
    }
}