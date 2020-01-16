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
    public class RecordPage : IPage
    {
        private readonly IWebDriver _driver;
        private HeaderComponent header;
        private FooterComponent footer;
        private readonly string _url = @"http://127.0.0.1:8080/record";
        
        [FindsBy(How = How.Id, Using = "firstname")] 
        private IWebElement firstnameInput;
        
        [FindsBy(How = How.Id, Using = "lastName")] 
        private IWebElement lastNameInput;
        
        [FindsBy(How = How.Id, Using = "email")] 
        private IWebElement emailInput;
        
        [FindsBy(How = How.Id, Using = "phone")] 
        private IWebElement phoneInput;
        
        [FindsBy(How = How.Id, Using = "game")] 
        private IWebElement gameSelect;
        
        [FindsBy(How = How.Id, Using = "plot")] 
        private IWebElement plotSelect;
        
        [FindsBy(How = How.Id, Using = "session")] 
        private IWebElement sessionSelect;
        
        [FindsBy(How = How.Id, Using = "message")] 
        private IWebElement messageTextArea;
        
        [FindsBy(How = How.Id, Using = "mailing")] 
        private IWebElement mailingRadio;
        
        [FindsBy(How = How.Id, Using = "buy")] 
        private IWebElement submitButton;
        
        //здесь будет дата
        
        private static readonly string FIRSTNAME_EMPTY = "firstnameEmpty";
        private static readonly string FIRSTNAME_MORE_CHARACTER = "firstnameMoreCharacters";
        private static readonly string LASTNAME_EMPTY = "lastnameEmpty";
        private static readonly string LASTNAME_MORE_CHARACTER = "lastnameMoreCharacters";
        private static readonly string EMAIL_EMPTY = "emailEmpty";
        private static readonly string EMAIL_INCORRECT = "emailIncorrect";
        private static readonly string PHONE_EMPTY = "phoneEmpty";
        private static readonly string PHONE_INCORRECT = "phoneIncorrect";
        private static readonly string GAME_EMPTY = "gameEmpty";
        private static readonly string PLOT_EMPTY = "plotEmpty";
        private static readonly string SESSION_EMPTY = "sessionEmpty";
        private static readonly string MAILING_EMPTY = "mailingEmpty"; 
        
        private static readonly string SBERBANK = "sberbank"; 
        private static readonly string REGISTER_PAGE_RECORD = "record";
        
        private static readonly string SUBMITBUTTON = "buy";
        
        public RecordPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
            header = new HeaderComponent(driver);
            footer = new FooterComponent(driver);
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
        
        public RecordPage Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }
        
        public RecordPage FillUser(User user)//заполнение полей
        {
            firstnameInput.SendKeys(user.Firstname);
            lastNameInput.SendKeys(user.LastName);
            emailInput.SendKeys(user.Email);
            phoneInput.SendKeys(user.Phone);
            messageTextArea.SendKeys(user.Message);
            SelectElement selectElement = new SelectElement(gameSelect);
            selectElement.SelectByText(user.GetGame());
            selectElement = new SelectElement(plotSelect);
            selectElement.SelectByText(user.GetPlot());
            selectElement = new SelectElement(sessionSelect);
            selectElement.SelectByText(user.GetSession());
            if (user.Mailing)
            {
                IWebElement testClick = _driver.FindElement(By.Id("mailing"));
                testClick.Click();
            }
                
            mailingRadio.Selected.Equals("checked");
            return this;
        }
        
        public RecordPage Submit()
        {
            submitButton.Click();
            if (ElementHelper.HasElement(_driver, By.Id(FIRSTNAME_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Firstname is empty");
            }

            if (ElementHelper.HasElement(_driver, By.Id(FIRSTNAME_MORE_CHARACTER), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Firstname is long");
            }
            
            if (ElementHelper.HasElement(_driver, By.Id(LASTNAME_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("LastName is empty");
            }

            if (ElementHelper.HasElement(_driver, By.Id(LASTNAME_MORE_CHARACTER), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("LastName is long");
            }
            
            if (ElementHelper.HasElement(_driver, By.Id(PHONE_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Phone is empty");
            }

            if (ElementHelper.HasElement(_driver, By.Id(PHONE_INCORRECT), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Phone is incorrect");
            }

            if (ElementHelper.HasElement(_driver, By.Id(EMAIL_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Email is empty");
            }

            if (ElementHelper.HasElement(_driver, By.Id(EMAIL_INCORRECT), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Email is incorrect");
            }

            if (ElementHelper.HasElement(_driver, By.Id(GAME_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Game is empty");
            }
            
            if (ElementHelper.HasElement(_driver, By.Id(PLOT_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Plot is empty");
            }
            
            if (ElementHelper.HasElement(_driver, By.Id(SESSION_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Session is empty");
            }
            
            if (ElementHelper.HasElement(_driver, By.Id(MAILING_EMPTY), TimeSpan.FromMilliseconds(50)))
            {
                throw new MessageException("Mailing is empty");
            }
            
            if (ElementHelper.HasElement(_driver, By.Id(SBERBANK), TimeSpan.FromMilliseconds(50)))
            {
                return new RecordPage(_driver);
            }

            return null;
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
        public bool AreEqual()
        {
            return ElementHelper.HasElement(_driver, By.Id(SUBMITBUTTON), TimeSpan.FromMilliseconds(50));
        }   
    }
}