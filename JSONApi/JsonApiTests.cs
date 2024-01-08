using Microsoft.Playwright;
using System.Text.Json;

namespace JSONApi
{
    public class JsonApiTests
    {
        IAPIRequestContext requestContext;
        [SetUp]
        public async Task SetUp()
        {
            var playwright = await Playwright.CreateAsync();
            requestContext = await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL = "https://jsonplaceholder.typicode.com/",
                    IgnoreHTTPSErrors = true,

                });
        }
        [Test]
        public async Task GetAllUsersAsync()
        {
            var getResponse = await requestContext.GetAsync(url: "/posts");
            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("\nCode :" + getResponse.Status);
            await Console.Out.WriteLineAsync("\nText :" + getResponse.StatusText);
            JsonElement responseBody = (JsonElement)await getResponse.JsonAsync();
            await Console.Out.WriteLineAsync("\nResponseBody :" + responseBody);
            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        public async Task GetSingleUsersAsync()
        {

            var getResponse = await requestContext.GetAsync(url: "posts/2");
            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("\nCode :" + getResponse.Status);
            await Console.Out.WriteLineAsync("\nText :" + getResponse.StatusText);
            JsonElement responseBody = (JsonElement)await getResponse.JsonAsync();
            await Console.Out.WriteLineAsync("\nResponseBody :" + responseBody);
            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        public async Task PostSingleUsersAsync()
        {
            var postdata = new
            {
                userId = 1,
                title = "qui est esse",
                body = "est rerum"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postdata);
            var getResponse = await requestContext.PostAsync(url: "posts");
            //    , 
            //    new APIRequestContextOptions
            //{
            //    Data = jsonData
            //});

            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("\nCode :" + getResponse.Status);
            await Console.Out.WriteLineAsync("\nText :" + getResponse.StatusText);
            /* JsonElement responseBody = (JsonElement)await getResponse.JsonAsync();
             await Console.Out.WriteLineAsync("\nResponseBody :" + responseBody);*/
            Assert.That(getResponse.Status, Is.EqualTo(201));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        public async Task PutSingleUsersAsync()
        {
            var postdata = new
            {
                userId = 1,
                title = "qui est esse",
                body = "est rerum"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postdata);
            var getResponse = await requestContext.PutAsync(url: "posts/2");/*, new APIRequestContextOptions
            {
                Data = jsonData
            });*/

            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("\nCode :" + getResponse.Status);
            await Console.Out.WriteLineAsync("\nText :" + getResponse.StatusText);
            /* JsonElement responseBody = (JsonElement)await getResponse.JsonAsync();
             await Console.Out.WriteLineAsync("\nResponseBody :" + responseBody);*/
            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
        [Test]
        public async Task DeleteSingleUsersAsync()
        {

            var getResponse = await requestContext.DeleteAsync(url: "posts/2");
            await Console.Out.WriteLineAsync("Res :" + getResponse.ToString());
            await Console.Out.WriteLineAsync("\nCode :" + getResponse.Status);
            await Console.Out.WriteLineAsync("\nText :" + getResponse.StatusText);
            /* JsonElement responseBody = (JsonElement)await getResponse.JsonAsync();
             await Console.Out.WriteLineAsync("\nResponseBody :" + responseBody);*/
            Assert.That(getResponse.Status, Is.EqualTo(200));
            Assert.That(getResponse, Is.Not.Null);

        }
    }
}