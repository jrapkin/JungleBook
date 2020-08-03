using Application.Dtos;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface ISearchRequest
	{
		Task<EventSearchResult> Search(string location, string keyword);
	}
}
