using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlayWrightPOM.PWTests.Pages;

namespace PlayWrightPOM.PWTests.Tests
{
    public class LoginPageTest:PageTest
    {
        Dictionary<string, string> Properties;
        private void ReadConfigSettings()
        {
            Properties = new Dictionary<string, string>();
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string fileName = currdir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }
        }
        [SetUp]
        public async Task Setup()
        {
            ReadConfigSettings();
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync(Properties["baseUrl"]);
            Console.WriteLine("Page Loaded");
        }

        [Test]
        [TestCase("admin","password")]
        [TestCase("admin", "xxxxx")]
        public async Task  LoginTest(string username,string password)
        {
            NewLoginPage loginPage = new(Page);
            //LoginPage loginPage=new (Page);
            await loginPage.ClickLoginLink();
            await loginPage.Login(username,password);
            Assert.IsTrue(await loginPage.CheckWelcomeMessage());

        }
    }
}