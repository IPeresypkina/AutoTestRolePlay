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
    public class FantasyPage : IPage
    {
        private readonly IWebDriver _driver;
        private HeaderComponent header;
        private readonly string _url = @"http://127.0.0.1:8080/fantasy";
        
        [FindsBy(How = How.Id, Using = "historyF")] 
        private IWebElement historyButton;
        
        [FindsBy(How = How.Id, Using = "worldviewF")] 
        private IWebElement worldviewButton;
        
        [FindsBy(How = How.Id, Using = "nationsF")] 
        private IWebElement nationsButton;
        
        private static readonly string HISTORY = "history";
        private static readonly string WORLDVIEW = "worldview";
        private static readonly string NATIONS = "nations";
        //для проверки
        private static readonly string FANTASY = "fantasyWorld";
        
        
        public FantasyPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
            header = new HeaderComponent(driver);
        }
        
        public FantasyPage Navigate()
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
        
        public FantasyPage SubmitHistory()
        {
            historyButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(HISTORY), TimeSpan.FromMilliseconds(50)))
            {
                return new FantasyPage(_driver);
            }
            return null;
        }
        public FantasyPage SubmitWorldview()
        {
            worldviewButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(WORLDVIEW), TimeSpan.FromMilliseconds(50)))
            {
                return new FantasyPage(_driver);
            }
            return null;
        }
        public FantasyPage SubmitNations()
        {
            nationsButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(NATIONS), TimeSpan.FromMilliseconds(50)))
            {
                return new FantasyPage(_driver);
            }
            return null;
        }

        public bool AreEqual()
        {
            return ElementHelper.HasElement(_driver, By.Id(FANTASY), TimeSpan.FromMilliseconds(50));
        }   
    }
}