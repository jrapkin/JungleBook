using JungleBook.Contracts;
using JungleBook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JungleBook.Services
{
    public class WeatherService : IWeatherRequest
    {
        public async Task<JObject> GetCurrentWeather(string city, string state, string country)
        {
            string url = $"https://api.worldweatheronline.com/premium/v1/weather.ashx?q={city},{state},{country}ie&date=today&key={API_Keys.WorldWeather}&format=json";
            using HttpClient client = new HttpClient();
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject currentWeather = JsonConvert.DeserializeObject<JObject>(json);
                    return currentWeather;
                }
            }
            return null;
        }
        public async Task<JObject> GetFiveDayForecast(string city, string state, string country, string numberOfDays)
        {
            string url = $"https://api.worldweatheronline.com/premium/v1/weather.ashx?q={city},{state},{country}&num_of_days={numberOfDays}&key={API_Keys.WorldWeather}&format=json";
            using HttpClient client = new HttpClient();
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject fiveDayForecast = JsonConvert.DeserializeObject<JObject>(json);
                    return fiveDayForecast;
                }
            }
            return null;
        }
        public async Task<WeatherHistory> GetHistoricalWeather(string url)
        {
            using HttpClient client = new HttpClient();
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    WeatherHistory history = JsonConvert.DeserializeObject<WeatherHistory>(json);
                    return history;
                }
            }
            return null;
        }
    }
}

