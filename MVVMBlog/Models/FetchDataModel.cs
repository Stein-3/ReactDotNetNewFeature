using MVVMBlog.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVMBlog.Models
{
    public class FetchDataModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecast[] forecasts = Array.Empty<WeatherForecast>();

        public event EventHandler<WeatherForecast[]?>? WetherForecastChanged;

        public FetchDataModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetWetherForecastAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("blog");
            var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("https://localhost:7270/weatherforecast");

            forecasts = (result is null) ? Array.Empty<WeatherForecast>() : result;

            WetherForecastChanged?.Invoke(this, forecasts);
        }
    }
}