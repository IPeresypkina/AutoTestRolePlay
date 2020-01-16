using System;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using AutoTestRolePlay.Models;
using AutoTestRolePlay.Helpers;
using AutoTestRolePlay.Exception;

namespace AutoTestRolePlay.Pages
{
    public class StalkerPage : IPage
    {
        private readonly IWebDriver _driver;
        private HeaderComponent header;
        private FooterComponent footer;
        private readonly string _url = @"http://127.0.0.1:8080/stalker";
        
        [FindsBy(How = How.Id, Using = "historyS")] 
        private IWebElement historyButton;
        
        [FindsBy(How = How.Id, Using = "groupS")] 
        private IWebElement groupButton;
        
        [FindsBy(How = How.Id, Using = "anomaliesS")] 
        private IWebElement anomaliesButton;
        
        [FindsBy(How = How.Id, Using = "mutantsS")] 
        private IWebElement mutantButton;
        
        private static readonly string HISTORY = "history";
        private static readonly string GROUP = "groupings";
        private static readonly string ANOMALIES = "anomalies";
        private static readonly string MUTANT = "mutants";
        //для проверки
        private static readonly string STALKER = "stalkerWorld";
        private static readonly string CHECK = "checkPage";
        
        
        public StalkerPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
            header = new HeaderComponent(driver);
            footer = new FooterComponent(driver);
        }
        
        public StalkerPage Navigate()
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
        
        public StalkerPage SubmitHistory()
        {
            historyButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(HISTORY), TimeSpan.FromSeconds(1)))
            {
                return new StalkerPage(_driver);
            }
            return null;
        }
        
        public StalkerPage SubmitGroup()
        {
            groupButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(GROUP), TimeSpan.FromSeconds(1)))
            {
                return new StalkerPage(_driver);
            }
            return null;
        }
        public StalkerPage SubmitAnomalies()
        {
            anomaliesButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(ANOMALIES), TimeSpan.FromSeconds(1)))
            {
                return new StalkerPage(_driver);
            }
            return null;
        }
        public StalkerPage SubmitMutant()
        {
            mutantButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(MUTANT), TimeSpan.FromSeconds(1)))
            {
                return new StalkerPage(_driver);
            }
            return null;
        }
        
        public string ToVk()
        {
            return footer.ToVk();
        }
        public string ToTwitter()
        {
            return footer.ToTwitter();
        }
        public string ToInstagram()
        {
            return footer.ToInstagram();
        }
        public string ToGoogle()
        {
            return footer.ToGoogle();
        }

        public bool AreEqual()
        {
            return ElementHelper.HasElement(_driver, By.Id(STALKER), TimeSpan.FromSeconds(2));
        }   
    }
}