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
        [Test]
        public async Task LoginTest()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://eaapp.somee.com/");
            Console.WriteLine("Page Loaded");
            
            await Page.GetByText("Login").ClickAsync();
            await Console.Out.WriteLineAsync("Link Clcked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");
            await Page.GetByLabel("UserName").FillAsync(value: "admin");
            await Page.GetByLabel("Password").FillAsync(value: "password");
            await Console.Out.WriteLineAsync("Values Typed");

            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input",
            new PageLocatorOptions
            {
                HasTextString = "Log in"
            });
            await btnLogin.ClickAsync();
            await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");
        }
    }
}
