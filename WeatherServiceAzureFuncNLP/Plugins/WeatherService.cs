using Microsoft.SemanticKernel;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WeatherServiceAzureFunction
{
    public class WeatherService
    {
        private static readonly string _apiKey= "e4b1d7b128047d0aee0a8303454e4e1f";
         

        [KernelFunction, Description("Get the weather details of the given city")]
        public static async Task<string> GetWeatherAsync([Description("The city for which the weather report is needed")] string city)
        {
            string baseUrl = "http://api.openweathermap.org/data/2.5/weather";
            string requestUri = $"{baseUrl}?q={city}&appid={_apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic weatherData = JsonConvert.DeserializeObject(json);
                    return $"Current weather in {city}: {weatherData.weather[0].description}";
                }
                else
                {
                    return $"Error: Unable to retrieve weather data for {city}";
                }
            }
        }
    }
}
