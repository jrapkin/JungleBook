using JungleBook.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JungleBook.Services
{
    public class Weather : IWeatherRequest
    {
        //public string ConvertToUrl(string city, string state, string country, DateTime date)
        //{
        //    city = city.Replace(' ', '+');
        //    country = country.Replace(' ', '+');
        //    if (date == DateTime.Today)
        //    {
        //        string url = $"https://api.worldweatheronline.com/premium/v1/weather.ashx?q={city},{state},{country}ie&date=today&key={API_Keys.WorldWeather}&format=json";
        //    }
        //    string dateAsString = date.ToString()
        //}
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
        public async Task<JObject> GetHistoricalWeather(string city, string state, string country, string startDate, string endDate)
        {
            string url = $"https://api.worldweatheronline.com/premium/v1/past-weather.ashx?q={city},{state},{country}&date={startDate}&enddate={endDate}&key={API_Keys.WorldWeather}&format=json";
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
    }
}

