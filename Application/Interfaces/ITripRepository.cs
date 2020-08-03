using Domain.Models;
using System.Collections.Generic;


namespace Application.Interfaces
{
	public interface ITripRepository : IRepositoryBase<Trip>
	{
		ICollection<Trip> GetAllTrips();
		Trip GetTripById(int tripId);

		void CreateTrip(Trip trip);
	}
}
