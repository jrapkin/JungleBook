using JungleBook.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IGoogleServices
	{
		Task<JObject> GetDestinationInformation(string url);
		Task<PlaceResults> PlacesSearch(string latitude, string longitude, string keyword);
	}
}
