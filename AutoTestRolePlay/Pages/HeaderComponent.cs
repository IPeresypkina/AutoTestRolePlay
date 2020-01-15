using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using AutoTestRolePlay.Models;
using AutoTestRolePlay.Helpers;
using AutoTestRolePlay.Exception;
namespace AutoTestRolePlay.Pages
{
    public class HeaderComponent
    {
        private readonly IWebDriver driver;
        
        [FindsBy(How = How.Id, Using = "fantasyHeader")] 
        private IWebElement fantasyButton;
        
        [FindsBy(How = How.Id, Using = "wastelandHeader")] 
        private IWebElement wastelandButton;
        
        [FindsBy(How = How.Id, Using = "stalkerHeader")] 
        private IWebElement stalkerButton;
        
        [FindsBy(How = How.Id, Using = "indexHeader")] 
        private IWebElement indexButton;
        
        [FindsBy(How = How.Id, Using = "recordHeader")] 
        private IWebElement recordButton;
        
        private static readonly string INDEX_HEADER = "indexHeader";
        private static readonly string FANTASY_HEADER = "fantasyHeader";
        private static readonly string WASTELAND_HEADER = "wastelandHeader";
        private static readonly string STALKER_HEADER = "stalkerHeader";
        private static readonly string RECORD_HEADER = "recordHeader";

        public HeaderComponent(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver,this);
        }
        
        public IndexPage ToIndex()
        {
            indexButton.Click();
            if (ElementHelper.HasElement(driver, By.Id(INDEX_HEADER), TimeSpan.FromMilliseconds(50)))
            {
                return new IndexPage(driver);
            }
            return null;
        }
        
        public FantasyPage ToFantasy()
        {
            fantasyButton.Click();
            if (ElementHelper.HasElement(driver, By.Id(FANTASY_HEADER), TimeSpan.FromSeconds(1)))
            {
                return new FantasyPage(driver);
            }
            return null;
        }
        
        public WastelandPage ToWasteland()
        {
            wastelandButton.Click();
            if (ElementHelper.HasElement(driver, By.Id(WASTELAND_HEADER), TimeSpan.FromSeconds(1)))
            {
                return new WastelandPage(driver);
            }
            return null;
        }
        
        public StalkerPage ToStalker()
        {
            stalkerButton.Click();
            if (ElementHelper.HasElement(driver, By.Id(STALKER_HEADER), TimeSpan.FromSeconds(1)))
            {
                return new StalkerPage(driver);
            }
            return null;
        }
        
        public RecordPage ToRecord()
        {
            recordButton.Click();
            if (ElementHelper.HasElement(driver, By.Id(RECORD_HEADER), TimeSpan.FromSeconds(1)))
            {
                return new RecordPage(driver);
            }
            return null;
        }
    }
}