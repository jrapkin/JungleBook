using JungleBook.Contracts;
using JungleBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JungleBook.Services
{
	public class HikingProject : IHikingProject
	{
		public async Task<HikingResult> SearchForHikingSpots(string latitude, string longitude)
		{
			string url = $"https://www.hikingproject.com/data/get-trails?lat={latitude}&lon={longitude}&maxDistance=50&key={API_Keys.HikingAPI}";
			using HttpClient client = new HttpClient();
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					string json = await response.Content.ReadAsStringAsync();
					HikingResult events = JsonConvert.DeserializeObject<HikingResult>(json);
					return events;
				}
			}
			return null;
		}
		public async Task<CampingResult> Search(string latitude, string longitude)
		{
			string url = $"https://www.hikingproject.com/data/get-campgrounds?lat={latitude}&lon=-{longitude}&maxDistance=50&key={API_Keys.HikingAPI}";
			using HttpClient client = new HttpClient();
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					string json = await response.Content.ReadAsStringAsync();
					CampingResult events = JsonConvert.DeserializeObject<CampingResult>(json);
					return events;
				}
			}
			return null;
		}
	}
}
