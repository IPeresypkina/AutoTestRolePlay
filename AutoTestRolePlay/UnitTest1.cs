using NUnit.Framework;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;


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
        
    }
}