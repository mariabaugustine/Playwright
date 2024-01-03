using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PWNunit
{
    internal class GHPTest:PageTest
    {
        [SetUp]
        public void SetUp() 
        {

        }
        //[Test]
        //public async Task Test1()
        //{


        //    //playwright startup

        //    using var playwright = await Playwright.CreateAsync();
        //    //Launch browser

        //    await using var browser = await playwright.Chromium.LaunchAsync(
        //        new BrowserTypeLaunchOptions
        //        {
        //            Headless=false
        //        } );

        //    //Page instance
        //    var context = await browser.NewContextAsync();
        //    var page = await context.NewPageAsync();
        //    Console.WriteLine("Opened Browser");
        //    await page.GotoAsync("https://www.google.com");
        //    Console.WriteLine("Page Loaded");

        //    string title = await page.TitleAsync();
        //    Console.WriteLine(title);
        //    //await page.GetByTitle("Search").FillAsync("hp laptop");
        //    await page.Locator("#APjFqb").FillAsync("Selenium");
        //    Console.WriteLine("Typed Search Text");

        //    await page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
        //    Console.WriteLine("Clicked");
        //    title = await page.TitleAsync();
        //    Console.WriteLine(title);
        //}
        [Test]
        public async Task Test2()
        {



            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("https://www.google.com");
            Console.WriteLine("Page Loaded");

            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            //await page.GetByTitle("Search").FillAsync("hp laptop");
            await Page.Locator("#APjFqb").FillAsync("Selenium");
            Console.WriteLine("Typed Search Text");

            await Page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
            Console.WriteLine("Clicked");
            title = await Page.TitleAsync();
            Console.WriteLine(title);
            Assert.That(title, Does.Contain("Selenium"));
            await Expect(Page).ToHaveTitleAsync("Selenium - Google Search");

        }
    }
}
