﻿using JungleBook.Contracts;
using JungleBook.Models;
using System.Collections.Generic;
using System.Linq;

namespace JungleBook.Data
{
	public class TripRepository : RepositoryBase<Trip>, ITripRepository
	{
		public TripRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public void CreateTrip(Trip trip) => Create(trip);
		public ICollection<Trip> GetAllTrips() => FindAll().ToList();
		public Trip GetTripById(int tripId) => FindByCondition(t => t.TripId == tripId).FirstOrDefault();

	}
}
