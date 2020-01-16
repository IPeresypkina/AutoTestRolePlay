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
    public class WastelandPage : IPage
    {
        private readonly IWebDriver _driver;
        private HeaderComponent header;
        private FooterComponent footer;
        private readonly string _url = @"http://127.0.0.1:8080/wasteland";
        
        //для проверки
        private static readonly string WASTELAND = "wastelandWorld";

        public WastelandPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
            header = new HeaderComponent(driver);
            footer = new FooterComponent(driver);
        }
        
        public WastelandPage Navigate()
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

        public bool AreEqual()
        {
            return ElementHelper.HasElement(_driver, By.Id(WASTELAND), TimeSpan.FromSeconds(1));
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
    }
}