using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlayWrightPOM.PWTests.Pages;
using PlayWrightPOM.Test_Helper_Class;
using PlayWrightPOM.Utilities;

namespace PlayWrightPOM.PWTests.Tests
{
    public class LoginPageTest:PageTest
    {
        Dictionary<string, string> Properties;
        string? currdir;
        private void ReadConfigSettings()
        {
            Properties = new Dictionary<string, string>();
            currdir = Directory.GetParent(@"../../../")?.FullName;
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
       
        public async Task  LoginTest()
        {
            NewLoginPage loginPage = new(Page);
            string? excelFilePath = currdir + "/TestData/EAData.xlsx";
            string? sheetName = "LoginData";

            List<EAText> excelDataList =LoginCredentialDataRead.ReadLoginData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? username = excelData.UserName;
                string? password = excelData.Password;

                //LoginPage loginPage=new (Page);
                await loginPage.ClickLoginLink();
                await loginPage.Login(username, password);
                await Page.ScreenshotAsync(new()
                {
                    Path =currdir+"/Screenshots/screenshot.png",
                   // FullPage = true,
                });
                Assert.IsTrue(await loginPage.CheckWelcomeMessage());
            }

        }
    }
}