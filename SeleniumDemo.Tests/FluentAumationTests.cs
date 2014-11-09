using FluentAutomation;
using NUnit.Framework;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    internal class FluentAumationTests : FluentTest
    {
        [Test]
        public void Can_Register()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);

            I.Open(@"G:\meetup\sample\register.html")
                .Enter("pete").In("#username")
                .Enter("123456").In("#password")
                .Select(Option.Value, "Mr").From("#title")
                .Click(":radio[value='2']")
                .Click(":checkbox[value='C++']")
                .Click(":checkbox[value='C#']").Wait(3)
                .Click("#register")
                .Assert.Exists("#done").Text("Registration Completed!");
        }

        [Test]
        public void Can_Register_And_Take_Screenshot()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
            Config.ScreenshotPath(".");

            I.Open(@"G:\meetup\sample\register.html")
                .Enter("pete").In("#username")
                .Enter("123456").In("#password")
                .Select(Option.Value, "Mr").From("#title")
                .Click(":radio[value='2']")
                .Click(":checkbox[value='C++']")
                .Click(":checkbox[value='C#']")
                .Click("#register")
                .TakeScreenshot("complete")
                .Assert.Exists("#done").Text("Registration Completed!");
        }

        [Test]
        public void Can_Register_Using_PhantomJS()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.PhantomJs);

            I.Open(@"G:\meetup\sample\register.html")
                .Enter("pete").In("#username")
                .Enter("123456").In("#password")
                .Select(Option.Value, "Mr").From("#title")
                .Click(":radio[value='2']")
                .Click(":checkbox[value='C++']")
                .Click(":checkbox[value='C#']").Wait(3)
                .Click("#register")
                .Assert.Exists("#done").Text("Registration Completed!");
        }
    }
}