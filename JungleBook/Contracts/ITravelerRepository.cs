using JungleBook.Models;
using System.Collections.Generic;

namespace JungleBook.Contracts
{
	public interface ITravelerRepository : IRepositoryBase<Traveler>
	{
		void CreateTraveler(Traveler traveler);
		Traveler GetTravelerByUserId(string userId);
		ICollection<Traveler> GetTravelBuddiesByTripId(int tripId);
	}
}
