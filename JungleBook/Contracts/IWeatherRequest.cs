using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JungleBook.Models;
using Newtonsoft.Json.Linq;

namespace JungleBook.Contracts
{
	public interface IWeatherRequest
	{
		Task<JObject> GetCurrentWeather(string city, string state, string country);
		Task<JObject> GetFiveDayForecast(string city, string state, string country, string numberOfDays);
		Task<WeatherHistory> GetHistoricalWeather(string url);
	}
}
