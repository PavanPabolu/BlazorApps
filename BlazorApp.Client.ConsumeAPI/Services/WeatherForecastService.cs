using BlazorApp.Client.ConsumeAPI.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorApp.Client.ConsumeAPI.Services
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> GetWeatherForecastsAsync()
        {
            var response = await _httpClient.GetAsync("/WeatherForecast");
            response.EnsureSuccessStatusCode();
            //var responseContent = await response.Content.ReadAsStringAsync();
            //var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var res =  await _httpClient.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast");//"api/weatherforecast");
            return res;
        }

    }
}
