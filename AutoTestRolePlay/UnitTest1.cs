using NUnit.Framework;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using AutoTestRolePlay.Exception;
using AutoTestRolePlay.Helpers;
using AutoTestRolePlay.Models;
using AutoTestRolePlay.Pages;

namespace AutoTestRolePlay
{
    public class Tests
    {
        private IWebDriver driver;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()//до теста инициализация дравйера
        {
            driver = new ChromeDriver("/Users/irinaperesypkina/RiderProjects/WebTest/WebTest/bin/Debug/netcoreapp3.0/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()//после теста закрытие драйвера
        {
            driver.Quit();
        }
        
        [Test]
        public void FailedRegistration() //проверка валидации
        {
            RecordPage recordPage = new RecordPage(driver);
            User user = User.GetRandomUser();
            user.Firstname = "";
            user.Mailing = true;
            try
            {
                recordPage.Navigate().FillUser(user).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Firstname is empty",e.Message);
            }

            user.Firstname = TextHelper.GetRandomWord(10);
            user.LastName = TextHelper.GetRandomWord(10);
            user.Phone = "592900378596";
            try
            {
                recordPage.Navigate().FillUser(user).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Phone is incorrect",e.Message);
            }
        }
    }
}