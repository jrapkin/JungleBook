using JungleBook.Models;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IHikingProject
	{
		Task<HikingResult> SearchForHikingSpots(string latitude, string longitude);	}
}
