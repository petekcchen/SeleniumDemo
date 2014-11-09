using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo.Tests
{
    internal class ComplexPageObjectTests
    {
        [Test]
        public void Can_Deposit()
        {
            IWebDriver driver = new ChromeDriver("../../");

            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.Navigate();

            LoginPage loginPage = registrationPage.Register("pete", "123456", "Pete");
            loginPage.LogIn("pete", "123456");

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.Navigate();

            ThirdPartyPage thirdPartyPage = paymentPage.Deposit("41523365", 10);

            DepositCompletedPage depositCompletedPage = thirdPartyPage.Verify("pete", "123456");

            Assert.True(depositCompletedPage.Succeeded());
        }

        internal class RegistrationPage
        {
            private readonly IWebDriver _driver;

            public RegistrationPage(IWebDriver driver)
            {
                _driver = driver;
            }

            public void Navigate()
            {
                Console.WriteLine("User goes to the registration page.");
            }

            public LoginPage Register(string username, string password, string name)
            {
                Console.WriteLine("User {0} registered.", username);
                return new LoginPage(_driver);
            }
        }

        internal class PaymentPage
        {
            private readonly IWebDriver _driver;

            public PaymentPage(IWebDriver driver)
            {
                _driver = driver;
            }

            public void Navigate()
            {
                Console.WriteLine("User goes to the payment page.");
            }

            public ThirdPartyPage Deposit(string account, decimal amount)
            {
                Console.WriteLine("User deposited ${0} with {1}.", amount, account);
                return new ThirdPartyPage(_driver);
            }
        }

        internal class ThirdPartyPage
        {
            private readonly IWebDriver _driver;

            public ThirdPartyPage(IWebDriver driver)
            {
                _driver = driver;
            }

            public DepositCompletedPage Verify(string username, string password)
            {
                Console.WriteLine("User verified in the third party page.");
                return new DepositCompletedPage(_driver);
            }
        }

        internal class DepositCompletedPage
        {
            private readonly IWebDriver _driver;

            public DepositCompletedPage(IWebDriver driver)
            {
                _driver = driver;
            }

            public bool Succeeded()
            {
                Console.WriteLine("Deposit succeeded.");
                return true;
            }
        }

        internal class LoginPage
        {
            private readonly IWebDriver _driver;

            public LoginPage(IWebDriver driver)
            {
                _driver = driver;
            }

            public void LogIn(string username, string password)
            {
                Console.WriteLine("User {0} logged in.", username);
            }
        }
    }
}