using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    internal class PageObjectTests
    {
        [Test]
        public void Can_Register()
        {
            IWebDriver driver = new ChromeDriver("../../");

            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.Navigate();

            RegistrationCompletedPage completedPage = registrationPage.Register();
            Assert.True(completedPage.Exists());

            driver.Quit();
        }

        public class RegistrationPage
        {
            private readonly IWebDriver _driver;

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

#pragma warning restore 649

            public RegistrationPage(IWebDriver driver)
            {
                _driver = driver;
                PageFactory.InitElements(driver, this);
            }

            public void Navigate()
            {
                _driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\register.html"));
            }

            public RegistrationCompletedPage Register()
            {
                _username.SendKeys("pete");
                _password.SendKeys("123456");
                new SelectElement(_title).SelectByValue("Mr");
                _sex.ElementAt(1).Click();
                _language.ElementAt(1).Click();
                _language.ElementAt(2).Click();
                _register.Click();

                return new RegistrationCompletedPage(_driver);
            }
        }

        public class RegistrationCompletedPage
        {
            [FindsBy(How = How.Id, Using = "done")]
#pragma warning disable 649
            private IWebElement _done;

#pragma warning restore 649

            public RegistrationCompletedPage(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

            public bool Exists()
            {
                return _done.Displayed;
                //Assert.True(_done.Text == "Registration Completed!");
            }
        }
    }
}