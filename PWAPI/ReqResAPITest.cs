using Microsoft.Playwright;
using NUnit.Framework;
using System.Net;
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
        [Test]
        public async Task GetSingleUsers()
        {
            var getresponse = await requestContext.GetAsync(url: "users/2");
            await Console.Out.WriteLineAsync("Res:\n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);


            Assert.That(getresponse.Status.Equals(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body:\n" + responsebody.ToString());



        }

        [Test]
        public async Task GetSingleUserNotFound()
        {
            var getresponse = await requestContext.GetAsync(url: "users/25");
            await Console.Out.WriteLineAsync("Res:\n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);


            Assert.That(getresponse.Status.Equals(404));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responsebody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body:\n" + responsebody.ToString());

            Assert.That(responsebody.ToString, Is.EqualTo("{}"));



        }
        [Test]
        public async Task PostUser()
        {
            var postData = new
            {
                name = "Maria",
                job = "Engineer"
            };
            var jsonData=System.Text.Json.JsonSerializer.Serialize(postData);

            var postResponse = await requestContext.PostAsync(url: "users",
                new APIRequestContextOptions()
                {
                  Data = jsonData
                });
            await Console.Out.WriteLineAsync("Res:\n" + postResponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + postResponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + postResponse.StatusText);

            Assert.That(postResponse.Status.Equals(201));
            Assert.That(postResponse, Is.Not.Null);

        }
        [Test]
        public async Task UpdateUser()
        {
            var postData = new
            {
                name = "Lizza",
                job = "Engineer"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postData);

            var postResponse = await requestContext.PutAsync(url: "users/2",
                new APIRequestContextOptions()
                {
                    Data = jsonData
                });
            await Console.Out.WriteLineAsync("Res:\n" + postResponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + postResponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + postResponse.StatusText);

            Assert.That(postResponse.Status.Equals(200));
            Assert.That(postResponse, Is.Not.Null);

        }
    }
}