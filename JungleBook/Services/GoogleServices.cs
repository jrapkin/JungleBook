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
	}
}
