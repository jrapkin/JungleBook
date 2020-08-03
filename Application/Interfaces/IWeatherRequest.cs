using Application.Dtos;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IWeatherRequest
	{
		Task<JObject> GetCurrentWeather(string city, string state, string country);
		Task<JObject> GetFiveDayForecast(string city, string state, string country, string numberOfDays);
		Task<WeatherHistory> GetHistoricalWeather(string url);
	}
}
