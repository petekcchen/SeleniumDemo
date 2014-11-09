using System;
using System.Collections.ObjectModel;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    internal class WebDriverTests
    {
        [SetUp]
        public void BeforeEachTest()
        {
        }

        [TearDown]
        public void AfterEachTest()
        {
        }

        [Test]
        public void Can_Navigate()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(@"http://localhost:57536/");
            driver.Quit();
        }

        [Test]
        public void Can_Find_An_Element_By_Id()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(@"http://localhost:57536/Account/Login");

            IWebElement element = driver.FindElement(By.Id("UserName"));

            Assert.True(element.Displayed);

            driver.Quit();
        }

        [Test]
        public void Can_Click_A_Button()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\button.html"));

            IWebElement element = driver.FindElement(By.Id("confirm"));
            element.Click();
            driver.Quit();
        }

        [Test]
        public void Can_Select_Radio_Buton()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\radio.html"));

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Name("sex"));
            elements[1].Click();

            driver.Quit();
        }

        [Test]
        public void Can_Select_Drop_Down_List()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\select.html"));

            new SelectElement(driver.FindElement(By.Id("month"))).SelectByText("Mar");

            driver.Quit();
        }

        [Test]
        public void Can_Select_Check_Box()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\checkbox.html"));

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Name("lang"));
            elements[1].Click();
            elements[2].Click();

            driver.Quit();
        }

        [Test]
        public void Can_Enter_Name()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\sendkeys.html"));

            IWebElement element = driver.FindElement(By.Id("name"));
            element.SendKeys("pete");

            driver.Quit();
        }

        [Test]
        public void Can_Register()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl(Path.Combine(Environment.CurrentDirectory, @"..\..\sample\register.html"));

            driver.FindElement(By.Id("username")).SendKeys("pete");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            new SelectElement(driver.FindElement(By.Id("title"))).SelectByText("Mr");
            driver.FindElements(By.Name("sex"))[1].Click();
            driver.FindElements(By.Name("lang"))[1].Click();
            driver.FindElements(By.Name("lang"))[2].Click();
            driver.FindElement(By.Id("register")).Click();

            Assert.True(driver.FindElement(By.Id("done")).Text == "Registration Completed!");

            driver.Quit();
        }
    }
}