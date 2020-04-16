using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JungleBook.Contracts
{
	public interface ITripRepository
	{
		ICollection<Trip> GetAllTrips();
		Trip GetTripById(int tripId);
		void CreateTrip(Trip trip);
	}
}
