using Xunit;
using Flurl;
using Flurl.Http;
using Flurl.Http.Testing;

namespace FlurlExampleTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("server error", 500);
                var result = await Assert.ThrowsAsync<FlurlHttpException>(() => "https://testingcall.com/".AppendPathSegment("test").GetJsonAsync());
            }
        }

        [Fact]
        public async void Test2()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("Some result", 200);
                var result = await "http://phillydotnet.org".WithHeader("test", "test").GetAsync();
                Assert.Equal(200, result.StatusCode);
                Assert.Equal("Some result", await result.GetStringAsync());
            }
        }

        [Fact]
        public async void Test3()
        {
            var getResult =
                "{'id': '1',"
                + "'title': 'test title,"
                + "'userId': '1',"
                + "'completed': 'True'}";
            using var httpTest = new HttpTest();
            httpTest.ForCallsTo("http://url.com")
                .WithVerb("GET")
                .RespondWith(getResult, 200);

            httpTest.ForCallsTo("http://url.com")
                .WithVerb("PATCH")
                .RespondWithJson(new { Result = "It Works" }, 204);

            var result1 = await "http://url.com".GetAsync();
            var result2 = await "http://url.com".PatchJsonAsync(new { Anything = "stuff" });

            Assert.Contains("test title", await result1.GetStringAsync());
            Assert.Equal(204, result2.StatusCode);

        }
        [Fact]
        public async void Test4()
        {
            using var httpTest = new HttpTest();
            httpTest.ForCallsTo("https://www.meetup.com/Philly-NET/")
                .AllowRealHttp();

            var result = await "https://www.meetup.com/Philly-NET/".GetAsync();
            Assert.Contains("Bill Wolff", await result.GetStringAsync());

        }
    }
}