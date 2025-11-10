using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeather.Models;

namespace OpenWeather
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<Coordinates> GetCoordinatesAsync(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<WeatherResponse>(json);
            return data?.Coord;
        }

        public async Task<ForecastResponse> Get7DayForecastAsync(double lat, double lon)
        {
            string url = $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,hourly,alerts&appid={_apiKey}&units=metric";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ForecastResponse>(json);
        }
    }
}
