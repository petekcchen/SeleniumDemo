using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    public class TestLoginPage
    {
        [Test]
        public void Test_Login_Page_Using_Firefox()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:57536/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("pete");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            Assert.IsTrue(driver.FindElement(By.LinkText("Hello pete!")).Displayed);
            driver.Quit();
        }

        [Test]
        public void Test_Login_Page_Using_Chrome()
        {
            IWebDriver driver = new ChromeDriver("../../");
            driver.Navigate().GoToUrl("http://localhost:57536/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("pete");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            Assert.IsTrue(driver.FindElement(By.LinkText("Hello pete!")).Displayed);
            driver.Quit();
        }
    }
}