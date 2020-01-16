using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using AutoTestRolePlay.Models;
using AutoTestRolePlay.Helpers;
using AutoTestRolePlay.Exception;

namespace AutoTestRolePlay.Pages
{
    public class FooterComponent
    {
        private readonly IWebDriver driver;
        
        [FindsBy(How = How.ClassName, Using = "vk")] 
        private IWebElement vkButton;
        
        [FindsBy(How = How.ClassName, Using = "instagram")] 
        private IWebElement instagramButton;
        
        [FindsBy(How = How.ClassName, Using = "twitter")] 
        private IWebElement twitterButton;
        
        [FindsBy(How = How.ClassName, Using = "google")] 
        private IWebElement googleButton;
        
        private static readonly string VK_FOOTER = "page_name";
        private static readonly string INSTAGRAM_FOOTER = "nZSzR";
        private static readonly string TWITTER_FOOTER = "page_name";
        private static readonly string GOOGLE_FOOTER = "h-c-header__product-logo-text";
        
        public FooterComponent(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver,this);
        }
        
        public bool ToVk()
        {
            vkButton.Click();
            if (ElementHelper.HasElement(driver, By.ClassName(VK_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return true;
            }
            return false;
        }
        public bool ToInstagram()
        {
            instagramButton.Click();
            if (ElementHelper.HasElement(driver, By.ClassName(INSTAGRAM_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return true;
            }
            return false;
        }
        public bool ToTwitter()
        {
            twitterButton.Click();
            if (ElementHelper.HasElement(driver, By.ClassName(TWITTER_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return true;
            }
            return false;
        }
        public bool ToGoogle()
        {
            googleButton.Click();
            if (ElementHelper.HasElement(driver, By.ClassName(GOOGLE_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return true;
            }
            return false;
        }
    }
}