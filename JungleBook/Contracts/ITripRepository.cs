using JungleBook.Models;
using System.Collections.Generic;


namespace JungleBook.Contracts
{
	public interface ITripRepository : IRepositoryBase<Trip>
	{
		ICollection<Trip> GetAllTrips();
		Trip GetTripById(int tripId);

		void CreateTrip(Trip trip);
	}
}
