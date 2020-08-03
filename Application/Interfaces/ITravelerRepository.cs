using Domain.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface ITravelerRepository : IRepositoryBase<Traveler>
	{
		void CreateTraveler(Traveler traveler);
		Traveler GetTravelerByUserId(string userId);
		ICollection<Traveler> GetTravelBuddiesByTripId(int tripId);
	}
}
