using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PWNunit
{
    internal class EATest:PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://eaapp.somee.com/",new PageGotoOptions()
            {
                Timeout=3000,WaitUntil=WaitUntilState.DOMContentLoaded
            });
            Console.WriteLine("Page Loaded");

        }
        [Test]
        public async Task LoginTest()
        {
           
            // await Page.GetByText("Login").ClickAsync();

            //var linkLogin = Page.Locator(selector: "text=Login");
            //await linkLogin.ClickAsync();

            await Page.ClickAsync(selector: "text=Login",new PageClickOptions
            { Timeout=1000});
            await Console.Out.WriteLineAsync("Link Clcked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");

            //await Page.GetByLabel("UserName").FillAsync(value: "admin");
            //await Page.GetByLabel("Password").FillAsync(value: "password");

            await Page.FillAsync(selector: "#UserName", "admin");
            await Page.FillAsync(selector: "#Password", "password");
            await Console.Out.WriteLineAsync("Values Typed");

            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input",
            new PageLocatorOptions
            {
                HasTextString = "Log in"
            });
            await btnLogin.ClickAsync();
            // await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");
            await Task.WhenAll(
           Expect(Page.Locator(selector: "text='Hello admin!'")).ToBeVisibleAsync(),
           Expect(Page.Locator(selector: "text=Log off")).ToBeVisibleAsync()
           );
        }
    }
}
