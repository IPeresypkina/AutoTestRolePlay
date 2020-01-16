using System;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using AutoTestRolePlay.Models;
using AutoTestRolePlay.Helpers;
using AutoTestRolePlay.Exception;
namespace AutoTestRolePlay.Pages
{
    public class IndexPage : IPage
    {
        private readonly IWebDriver _driver;
        private HeaderComponent header;
        private FooterComponent footer;
        private readonly string _url = @"http://127.0.0.1:8080";
        
        [FindsBy(How = How.Id, Using = "fantasy")] 
        private IWebElement fantazyButton;
        
        [FindsBy(How = How.Id, Using = "wasteland")] 
        private IWebElement wastelandButton;
        
        [FindsBy(How = How.Id, Using = "stalker")] 
        private IWebElement stalkerButton;
        
        [FindsBy(How = How.ClassName, Using = "footerP")] 
        private IWebElement recordButton;
        
        private static readonly string RECORD = "recordHeader";
        private static readonly string FANTASY = "fantasyHeader";
        private static readonly string WASTELAND = "wastelandHeader";
        private static readonly string STALKER = "stalkerHeader";
        //для проверки
        private static readonly string LOGO = "header";
        
        
        public IndexPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
            header = new HeaderComponent(driver);
            footer = new FooterComponent(driver);
        }
        
        public IndexPage Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }
        
        public IndexPage ToIndex()
        {
            return header.ToIndex();
        }
        public FantasyPage ToFantasy()
        {
            return header.ToFantasy();
        }
        public WastelandPage ToWasteland()
        {
            return header.ToWasteland();
        }
        public StalkerPage ToStalker()
        {
            return header.ToStalker();
        }
        public RecordPage ToRecord()
        {
            return header.ToRecord();
        }

        public bool ToVk()
        {
            return footer.ToVk();
        }
        public bool ToTwitter()
        {
            return footer.ToTwitter();
        }
        public bool ToInstagram()
        {
            return footer.ToInstagram();
        }
        public bool ToGoogle()
        {
            return footer.ToGoogle();
        }

        public RecordPage SubmitRecord()
        {
            recordButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(RECORD), TimeSpan.FromSeconds(1)))
            {
                return new RecordPage(_driver);
            }
            return null;
        }
        
        public FantasyPage SubmitFantasy()
        {
            fantazyButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(FANTASY), TimeSpan.FromSeconds(1)))
            {
                return new FantasyPage(_driver);
            }
            return null;
        }
        
        public WastelandPage SubmitWasteland()
        {
            wastelandButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(WASTELAND), TimeSpan.FromSeconds(1)))
            {
                return new WastelandPage(_driver);
            }
            return null;
        }
        
        public StalkerPage SubmitStalker()
        {
            stalkerButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(STALKER), TimeSpan.FromSeconds(1)))
            {
                return new StalkerPage(_driver);
            }
            return null;
        }

        public bool AreEqual()
        {
            return ElementHelper.HasElement(_driver, By.ClassName(LOGO), TimeSpan.FromSeconds(1));
        }
    }
}