using System.Text.Json;
// See https://aka.ms/new-console-template for more information
public class ApiClient
{
    public class WeatherForecastResponse
    {
        DateTime date {get;set;}
        decimal temperatureC {get;set;}
        decimal temperatureF {get;set;}
        string summary {get;set;}
    }

    private readonly Uri BaseUri;

    public ApiClient(Uri baseUri)
    {
        this.BaseUri = baseUri;
    }

    public async Task<HttpResponseMessage> GetWeatherForecast()
    {
        using (var client = new HttpClient { BaseAddress = BaseUri })
        {
            try
            {
                var response = await client.GetAsync($"/WeatherForecast");
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem connecting to WeatherForecast API.", ex);
            }
        }
    }
}
