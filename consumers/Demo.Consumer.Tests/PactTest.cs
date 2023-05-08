namespace Demo.Consumer.Tests;

using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PactNet;
using PactNet.Matchers;
using Xunit;
using Xunit.Abstractions;

public class PactTest
{
    private IPactBuilderV3 pact;
        private readonly ApiClient ApiClient;
        private readonly int port = 9001;
        private readonly List<object> products;

        public PactTest(ITestOutputHelper output)
        {
            products = new List<object>()
            {
                new   {
                    date = "2023-05-09T08:38:38.012717+07:00",
                    temperatureC = 12,
                    temperatureF = 53,
                    summary = "Hot"
                },
                new {
                    date = "2023-05-10T08:38:38.012732+07:00",
                    temperatureC = 20,
                    temperatureF = 67,
                    summary = "Sweltering"
                },
                new {
                    date = "2023-05-11T14:21:41.760305+07:00",
                    temperatureC = 43,
                    temperatureF = 109,
                    summary = "Bracing"
                },
                new {
                    date = "2023-05-12T14:21:41.760305+07:00",
                    temperatureC = 17,
                    temperatureF = 62,
                    summary = "Warm"
                },
                new {
                    date = "2023-05-13T14:21:41.760305+07:00",
                    temperatureC = 19,
                    temperatureF = 66,
                    summary = "Bracing"
                }
            };

            var Config = new PactConfig
            {
                PactDir = Path.Join("..", "..", "..", "..", "..", "pacts"),
                //LogDir = "pact_logs",
                //Outputters = new[] { new XUnitOutput(output) },
                DefaultJsonSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            pact = Pact.V3("ApiClient", "WeatherForecastService", Config).UsingNativeBackend(port);
            ApiClient = new ApiClient(new System.Uri($"http://localhost:{port}"));
        }

        [Fact]
        public async void GetWeatherForecast()
        {
            // Arange
            pact.UponReceiving("A valid request for all forecast")
                    .Given("There is data")
                    .WithRequest(HttpMethod.Get, "/WeatherForecast")
                .WillRespond()
                    .WithStatus(HttpStatusCode.OK)
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithJsonBody(new TypeMatcher(products));

            await pact.VerifyAsync(async ctx => {
                var response = await ApiClient.GetWeatherForecast();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            });
        }
}