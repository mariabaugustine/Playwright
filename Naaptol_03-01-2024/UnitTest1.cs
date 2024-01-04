using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Naaptol_03_01_2024
{
    public class Tests :PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://eaapp.somee.com/");
            Console.WriteLine("Page Loaded");
        }

        [Test]
        public async Task SearchProduct()
        {
            
        }
    }
}