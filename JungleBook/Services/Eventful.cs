using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JungleBook.Models;
using JungleBook.Contracts;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JungleBook.Services
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
