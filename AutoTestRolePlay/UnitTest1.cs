using NUnit.Framework;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        
        [Test]
        public void SuccessRegistration()//положительный тест
        {
            RecordPage recordPage = new RecordPage(driver);
            User user = User.GetRandomUser();
            recordPage.Navigate().FillUser(user).Submit();
            Assert.True(recordPage.Navigate().AreEqual());
        }
        [Test]
        public void HeaderFromRecord()//проверка header со страницы Record
        {
            RecordPage recordPage = new RecordPage(driver);
            Assert.True(recordPage.Navigate().ToIndex().AreEqual());
            Assert.True(recordPage.Navigate().ToFantasy().AreEqual());
            Assert.True(recordPage.Navigate().ToWasteland().AreEqual());
            Assert.True(recordPage.Navigate().ToStalker().AreEqual());
            Assert.True(recordPage.Navigate().ToRecord().AreEqual());
        }
        [Test]
        public void HeaderFromIndex()//проверка header со страницы Index
        {
            IndexPage indexPage = new IndexPage(driver);
            Assert.True(indexPage.Navigate().ToIndex().AreEqual());
            Assert.True(indexPage.Navigate().ToFantasy().AreEqual());
            Assert.True(indexPage.Navigate().ToWasteland().AreEqual());
            Assert.True(indexPage.Navigate().ToStalker().AreEqual());
            Assert.True(indexPage.Navigate().ToRecord().AreEqual());
        }
        [Test]
        public void HeaderFromFantasy()//проверка header со страницы Fantasy
        {
            FantasyPage fantasyPage = new FantasyPage(driver);
            Assert.True(fantasyPage.Navigate().ToIndex().AreEqual());
            Assert.True(fantasyPage.Navigate().ToFantasy().AreEqual());
            Assert.True(fantasyPage.Navigate().ToWasteland().AreEqual());
            Assert.True(fantasyPage.Navigate().ToStalker().AreEqual());
            Assert.True(fantasyPage.Navigate().ToRecord().AreEqual());
        }
        [Test]
        public void HeaderFromWasteland()//проверка header со страницы Wasteland
        {
            WastelandPage wastelandPage = new WastelandPage(driver);
            Assert.True(wastelandPage.Navigate().ToIndex().AreEqual());
            Assert.True(wastelandPage.Navigate().ToFantasy().AreEqual());
            Assert.True(wastelandPage.Navigate().ToWasteland().AreEqual());
            Assert.True(wastelandPage.Navigate().ToStalker().AreEqual());
            Assert.True(wastelandPage.Navigate().ToRecord().AreEqual());
        }
        [Test]
        public void HeaderFromStalker()//проверка header со страницы Stalker
        {
            StalkerPage stalkerPage = new StalkerPage(driver);
            Assert.True(stalkerPage.Navigate().ToIndex().AreEqual());
            Assert.True(stalkerPage.Navigate().ToFantasy().AreEqual());
            Assert.True(stalkerPage.Navigate().ToWasteland().AreEqual());
            Assert.True(stalkerPage.Navigate().ToStalker().AreEqual());
            Assert.True(stalkerPage.Navigate().ToRecord().AreEqual());
        }
        [Test]
        public void CheckStalker()
        {
            StalkerPage stalkerPage = new StalkerPage(driver);
            Assert.NotNull(stalkerPage.Navigate().SubmitHistory());
            Assert.NotNull(stalkerPage.Navigate().SubmitGroup());
            Assert.NotNull(stalkerPage.Navigate().SubmitAnomalies());
            Assert.NotNull(stalkerPage.Navigate().SubmitMutant());
        }
        [Test]
        public void CheckIndex()
        {
            IndexPage indexPage = new IndexPage(driver);
            Assert.NotNull(indexPage.Navigate().SubmitRecord());
            Assert.NotNull(indexPage.Navigate().SubmitFantasy());
            Assert.NotNull(indexPage.Navigate().SubmitWasteland());
            Assert.NotNull(indexPage.Navigate().SubmitStalker());
        }
        [Test]
        public void CheckFantasy()
        {
            FantasyPage fantasyPage = new FantasyPage(driver);
            Assert.NotNull(fantasyPage.Navigate().SubmitHistory());
            Assert.NotNull(fantasyPage.Navigate().SubmitWorldview());
            Assert.NotNull(fantasyPage.Navigate().SubmitNations());
        }
        [Test]
        public void FooterFromIndex()
        {
            IndexPage indexPage = new IndexPage(driver);
            Assert.AreEqual(indexPage.Navigate().ToVk(), "Ирина Пересыпкина | ВКонтакте");
            Assert.AreEqual(indexPage.Navigate().ToInstagram(), "Irina Peresypkina (@_iracult) • Фото и видео в Instagram");
            Assert.AreEqual(indexPage.Navigate().ToTwitter(), "manaton (@irinka213) | Твиттер");
            Assert.AreEqual(indexPage.Navigate().ToGoogle(), "Gmail – электронная почта и бесплатное хранилище от Google");
        }
        [Test]
        public void FooterFromFantasy()
        {
            FantasyPage fantasyPage = new FantasyPage(driver);
            Assert.AreEqual(fantasyPage.Navigate().ToVk(), "Ирина Пересыпкина | ВКонтакте");
            Assert.AreEqual(fantasyPage.Navigate().ToInstagram(), "Irina Peresypkina (@_iracult) • Фото и видео в Instagram");
            Assert.AreEqual(fantasyPage.Navigate().ToTwitter(), "manaton (@irinka213) | Твиттер");
            Assert.AreEqual(fantasyPage.Navigate().ToGoogle(), "Gmail – электронная почта и бесплатное хранилище от Google");
        }
        [Test]
        public void FooterFromWasteland()
        {
            WastelandPage wastelandPage = new WastelandPage(driver);
            Assert.AreEqual(wastelandPage.Navigate().ToVk(), "Ирина Пересыпкина | ВКонтакте");
            Assert.AreEqual(wastelandPage.Navigate().ToInstagram(), "Irina Peresypkina (@_iracult) • Фото и видео в Instagram");
            Assert.AreEqual(wastelandPage.Navigate().ToTwitter(), "manaton (@irinka213) | Твиттер");
            Assert.AreEqual(wastelandPage.Navigate().ToGoogle(), "Gmail – электронная почта и бесплатное хранилище от Google");
        }
        [Test]
        public void FooterFromStalker()
        {
            StalkerPage stalkerPage = new StalkerPage(driver);
            Assert.AreEqual(stalkerPage.Navigate().ToVk(), "Ирина Пересыпкина | ВКонтакте");
            Assert.AreEqual(stalkerPage.Navigate().ToInstagram(), "Irina Peresypkina (@_iracult) • Фото и видео в Instagram");
            Assert.AreEqual(stalkerPage.Navigate().ToTwitter(), "manaton (@irinka213) | Твиттер");
            Assert.AreEqual(stalkerPage.Navigate().ToGoogle(), "Gmail – электронная почта и бесплатное хранилище от Google");
        }
        [Test]
        public void FooterFromRecord()
        {
            RecordPage recordPage = new RecordPage(driver);
            Assert.AreEqual(recordPage.Navigate().ToVk(), "Ирина Пересыпкина | ВКонтакте");
            Assert.AreEqual(recordPage.Navigate().ToInstagram(), "Irina Peresypkina (@_iracult) • Фото и видео в Instagram");
            Assert.AreEqual(recordPage.Navigate().ToTwitter(), "manaton (@irinka213) | Твиттер");
            Assert.AreEqual(recordPage.Navigate().ToGoogle(), "Gmail – электронная почта и бесплатное хранилище от Google");
        }
    }
}