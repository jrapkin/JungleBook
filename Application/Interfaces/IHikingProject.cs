using Application.Dtos;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IHikingProject
	{
		Task<HikingResult> SearchForHikingSpots(string latitude, string longitude);
	}
}
