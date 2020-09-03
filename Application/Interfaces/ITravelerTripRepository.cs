using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface ITravelerTripRepository : IRepositoryBase<TravelerTrip>
	{
		void CreateTravelerTrip(Trip trip, Traveler traveler);
		List<Trip> GetAllTripsByTraveler(int travelerId);
		List<Traveler> GetAllTravelersByTrip(int tripId);
		//Task<List<Traveler>> GetAllTravelersByTripAsync(int tripId);
		//TravelerTrip GetTravelerTripByIds(int travelerId, int tripId);
		//Task<TravelerTrip> GetTravelerTripByIdsAsync(int travelerId, int tripId);
		//Task<TravelerTrip> GetTravelerTripByInviteCode(string username, string tripName);
		//List<Destination> GetAllDestinationsByTravelerId(int travelerId);
	}
}
