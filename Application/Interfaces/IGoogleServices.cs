using Application.Dtos;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IGoogleServices
	{
		Task<JObject> GetDestinationInformation(string url);
		Task<PlaceResults> PlacesSearch(string latitude, string longitude, string keyword);
	}
}
