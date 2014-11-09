using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    internal class PageFactoryTests
    {
        [Test]
        public void Can_Register()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\register.html"));
            PageFactory.InitElements(driver, this);

            _username.SendKeys("pete");
            _password.SendKeys("123456");
            new SelectElement(_title).SelectByValue("Mr");
            _sex[1].Click();
            _language[1].Click();
            _language[2].Click();
            _register.Click();

            Assert.True(_done.Text == "Registration Completed!");

            driver.Quit();
        }

#pragma warning disable 649

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement _username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _password;

        [FindsBy(How = How.Id, Using = "title")]
        private IWebElement _title;

        [FindsBy(How = How.Name, Using = "sex")]
        private IList<IWebElement> _sex;

        [FindsBy(How = How.Name, Using = "lang")]
        private IList<IWebElement> _language;

        [FindsBy(How = How.Id, Using = "register")]
        private IWebElement _register;

        [FindsBy(How = How.Id, Using = "done")]
        private IWebElement _done;

#pragma warning restore 649
    }
}