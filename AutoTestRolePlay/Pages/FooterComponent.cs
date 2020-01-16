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
        
        private static readonly string VK_FOOTER = "/html/body/div[9]/div/div/div[1]/div[2]/div/div/div[1]/div[1]";
        private static readonly string INSTAGRAM_FOOTER = "/html/body/div[1]/section/nav/div[2]/div/div/div[1]";
        private static readonly string TWITTER_FOOTER = "/html/body/div[2]/div[1]/div/div/div/ul";
        private static readonly string GOOGLE_FOOTER = "/html/body/div[1]/div[1]/div[2]";
        
        public FooterComponent(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver,this);
        }
        
        public string ToVk()
        {
            vkButton.Click();
            if (ElementHelper.HasElement(driver, By.XPath(VK_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return driver.Title;
            }
            return "dashboard";
        }
        public string ToInstagram()
        {
            instagramButton.Click();
            if (ElementHelper.HasElement(driver, By.XPath(INSTAGRAM_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return driver.Title;
            }
            return "dashboard";
        }
        public string ToTwitter()
        {
            twitterButton.Click();
            if (ElementHelper.HasElement(driver, By.XPath(TWITTER_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return driver.Title;
            }
            return "dashboard";
        }
        public string ToGoogle()
        {
            googleButton.Click();
            if (ElementHelper.HasElement(driver, By.XPath(GOOGLE_FOOTER), TimeSpan.FromSeconds(1)))
            {
                return driver.Title;
            }
            return "dashboard";
        }
    }
}