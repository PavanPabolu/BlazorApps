using BlazorApp.Client.ConsumeAPI.Models;
using System.Net.Http.Json;

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
            //return await response.Content.ReadAsStringAsync();

            var res =  await _httpClient.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast");//"api/weatherforecast");
            return res;
        }

    }
}
