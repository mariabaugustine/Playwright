using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_04_01_2024.PWTests.Pages
{
    internal class HomePage
    {
        private IPage _page;
        private ILocator SearchInput => _page.Locator(selector: "#twotabsearchtextbox");
        private ILocator SearchButton => _page.Locator(selector: "#nav-search-submit-button");

        public HomePage(IPage page) => _page = page;
        
        public async Task SearchProduct(string productName)
        {
        await SearchInput.ClickAsync();
        await SearchInput.FillAsync(productName);
                
           
            
       // await SearchInput.PressAsync(key:"Enter");
         await SearchButton.ClickAsync();
        }
    }
}
