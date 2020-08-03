using Domain;
using Application.Dtos;
using Application.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class Eventful : ISearchRequest
	{
		public async Task<EventSearchResult> Search(string location, string eventKeyword)
		{
			string url = $"http://api.eventful.com/json/events/search?...&keywords={eventKeyword}&location={location}&date=Future&app_key={API_Keys.EventfulAppKey}";
			using HttpClient client = new HttpClient();
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					string json = await response.Content.ReadAsStringAsync();
					EventSearchResult events = JsonConvert.DeserializeObject<EventSearchResult>(json);
					return events;
				}
			}
			return null;
		}

	}
}
