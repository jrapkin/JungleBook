using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Data
{
	public class TravelerTripRepository : RepositoryBase<TravelerTrip>, ITravelerTripRepository
	{
		public TravelerTripRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public void CreateTravelerTrip(Trip trip, Traveler traveler)
		{
			TravelerTrip userProfile = new TravelerTrip()
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
		//public List<Destination> GetAllDestinationsByTravelerId(int travelerId)
		//{
		//	return FindByCondition(t => t.TravelerId == travelerId).Include(t => t.Trip).ThenInclude(a => a.Destinations).ThenInclude(d => d.Address).Select(d => d.Trip.Destinations).FirstOrDefault();
		//}
		public List<Traveler> GetAllTravelersByTrip(int tripId)
		{
			return FindByCondition(ot => ot.TripId == tripId).Select(ot => ot.Traveler).ToList();
		}
		public Task<List<Traveler>> GetAllTravelersByTripAsync(int tripId)
		{
			return FindByCondition(ot => ot.TripId == tripId).Select(ot => ot.Traveler).ToListAsync();
		}
		//public TravelerTrip GetTravelerTripByIds(int travelerId, int tripId)
		//{
		//	return FindByCondition(t => t.TravelerId == travelerId && t.TripId == tripId)
		//		.Include(t => t.Trip)
		//		.ThenInclude(d => d.Destinations)
		//		.ThenInclude(d => d.Days)
		//		.ThenInclude(da => da.DayActivities)
		//		.FirstOrDefault();
		//}
		//public Task<TravelerTrip> GetTravelerTripByIdsAsync(int travelerId, int tripId)
		//{
		//	return FindByCondition(t => t.TravelerId == travelerId && t.TripId == tripId)
		//		.Include(t => t.Trip)
		//		.ThenInclude(d => d.Destinations)
		//		.ThenInclude(d => d.Days)
		//		.ThenInclude(da => da.DayActivities)
		//		.FirstOrDefaultAsync();
		//}
		//public async Task<TravelerTrip> GetTravelerTripByInviteCode(string username, string tripName)
		//{
		//	var traveler = await FindByCondition(u => u.Traveler.UserName == username).FirstOrDefaultAsync();
		//	var trip = await FindByCondition(t => t.Trip.Name == tripName).FirstOrDefaultAsync();
		//	return await FindByCondition(up => up.TravelerId == traveler.TravelerId && up.TripId == trip.TripId)
		//		.Include(t => t.Trip)
		//		.ThenInclude(d => d.Destinations)
		//		.ThenInclude(d => d.Days)
		//		.ThenInclude(da => da.DayActivities).FirstOrDefaultAsync();
		//}
	}
}
