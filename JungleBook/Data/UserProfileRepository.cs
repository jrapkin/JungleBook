using JungleBook.Models;
using JungleBook.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JungleBook.Data
{
	public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
	{
		public UserProfileRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public void CreateUserProfile(Trip trip, Traveler traveler)
		{
			UserProfile userProfile = new UserProfile()
			{ 
				TripId = trip.TripId, 
				TravelerId = traveler.TravelerId 
			};
			Create(userProfile);
		}
		public List<Trip> GetAllTripsByTraveler(int travelerId)
		{
			return FindByCondition(t => t.TravelerId == travelerId)
				.Include(t => t.Trip)
				.Select(t => t.Trip).ToList();
				
		}
	}
}
