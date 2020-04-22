using JungleBook.Models;
using JungleBook.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
		public List<Traveler> GetAllTravelersByTrip(int tripId)
		{
			return FindByCondition(ot => ot.TripId == tripId).Select(ot => ot.Traveler).ToList();
		}
		public UserProfile GetUserProfileByIds(int travelerId, int tripId)
		{
			return FindByCondition(t => t.TravelerId == travelerId && t.TripId == tripId)
				.Include(t => t.Trip)
				.ThenInclude(d => d.Destinations)
				.ThenInclude(d => d.Days)
				.ThenInclude(da => da.DayActivities)
				.FirstOrDefault();
		}
		public async Task<UserProfile> GetUserProfileByInviteCode(string username, string tripName)
		{
			var traveler = await FindByCondition(u => u.Traveler.UserName == username).FirstOrDefaultAsync();
			var trip = await FindByCondition(t => t.Trip.Name == tripName).FirstOrDefaultAsync();
			return await FindByCondition(up => up.TravelerId == traveler.TravelerId && up.TripId == trip.TripId)
				.Include(t => t.Trip)
				.ThenInclude(d => d.Destinations)
				.ThenInclude(d => d.Days)
				.ThenInclude(da => da.DayActivities).FirstOrDefaultAsync();
		}
	}
}
