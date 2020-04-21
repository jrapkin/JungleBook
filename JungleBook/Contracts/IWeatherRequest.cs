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
		Task<JObject> GetThirtyDayForecast(string city, string state, string country, string numberOfDays);
		Task<JObject> GetHistoricalWeather(string city, string state, string country, string startDate, string endDate);
	}
}
