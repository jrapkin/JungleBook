using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IUserProfileRepository : IRepositoryBase<UserProfile>
	{
		void CreateUserProfile(Trip trip, Traveler traveler);
		List<Trip> GetAllTripsByTraveler(int travelerId);
		List<Traveler> GetAllTravelersByTrip(int tripId);
		UserProfile GetUserProfileByIds(int travelerId, int tripId);
		Task<UserProfile> GetUserProfileByInviteCode(string username, string tripName);
	}
}
