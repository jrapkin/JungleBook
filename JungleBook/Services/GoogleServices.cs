using JungleBook.Contracts;
using JungleBook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JungleBook.Services
{
	public class GoogleServices : IGoogleServices
	{
		public async Task<JObject> GetDestinationInformation(string url)
		{
			using HttpClient client = new HttpClient();
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					string information = await response.Content.ReadAsStringAsync();
					JObject convertedInformation = JsonConvert.DeserializeObject<JObject>(information);
					return convertedInformation;
				}
				return null;
			}
		}
		public async Task<PlaceResults> PlacesSearch(string latitude, string longitude, string keyword)
		{

			string url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={latitude},{longitude}&radius=50&&keyword={keyword}{API_Keys.GoogleServicesKey}";

			using HttpClient client = new HttpClient();
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					string information = await response.Content.ReadAsStringAsync();
					PlaceResults convertedInformation = JsonConvert.DeserializeObject<PlaceResults>(information);
					return convertedInformation;
				}
				return null;
			}
		}
	}
}
