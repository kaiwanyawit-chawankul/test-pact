namespace Demo.Consumer.Tests;

using System.Net;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var client = new ApiClient(new Uri("http://localhost:5206"));
        var result = await client.GetWeatherForecast();
        Assert.Equal(HttpStatusCode.OK,result.StatusCode);
    }
}
