using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlayWrightPOM.PWTests.Pages;

namespace PlayWrightPOM.PWTests.Tests
{
    public class LoginPageTest:PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://eaapp.somee.com/", new PageGotoOptions()
            {
                Timeout = 3000,
                WaitUntil = WaitUntilState.DOMContentLoaded
            });
            Console.WriteLine("Page Loaded");
        }

        [Test]
        [TestCase("admin","password")]
        [TestCase("admin", "xxxxx")]
        public async Task  LoginTest(string username,string password)
        {
            LoginPage loginPage=new (Page);
            await loginPage.ClickLoginLink();
            await loginPage.Login(username,password);
            Assert.IsTrue(await loginPage.CheckWelcomeMessage());

        }
    }
}