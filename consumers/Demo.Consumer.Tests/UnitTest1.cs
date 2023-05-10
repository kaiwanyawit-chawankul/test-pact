namespace Demo.Consumer.Tests;

using System.Net;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        string myServiceUrl = Environment.GetEnvironmentVariable("MY_SERVICE_URL") ?? "http://localhost:5206";
        var client = new ApiClient(new Uri(myServiceUrl));
        var result = await client.GetWeatherForecast();
        Assert.Equal(HttpStatusCode.OK,result.StatusCode);
    }
}
