using Microsoft.Playwright;
using System.Text.Json;

namespace PWAPI
{
    public class ReqResAPITest  
    {
        IAPIRequestContext requestContext;
        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            requestContext=await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL="https://reqres.in/api/",
                    IgnoreHTTPSErrors=true,
                } );
        }

        [Test]
        public async Task GetAllUsers()
        {
            var getresponse = await requestContext.GetAsync(url: "users?page=2");
            await Console.Out.WriteLineAsync("Res:\n"+getresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n"+getresponse.StatusText);


            Assert.That(getresponse.Status.Equals(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody=(JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body:\n"+responsebody.ToString());

            
           
        }
    }
}