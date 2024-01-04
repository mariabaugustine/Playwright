using Amazon_04_01_2024.PWTests.Pages;
using Amazon_04_01_2024.Test_Helper_Class;
using Amazon_04_01_2024.Utilities;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_04_01_2024.PWTests.Tests
{
    internal class AmazonTests:PageTest
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
        public async Task SearchTest()
        {
            HomePage homePage = new HomePage(Page);
            string? excelFilePath = currdir + "/Test Data/AmazonData.xlsx";
            string? sheetName = "Product";

            List<SearchData> excelDataList = DataRead.ReadSearchData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? name = excelData.ProductName;
                homePage.SearchProduct(name);
                await Console.Out.WriteLineAsync(Page.Url);
            }
        }   
    }
}
