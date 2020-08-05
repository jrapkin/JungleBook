using System;
using System.Collections.Generic;

namespace Domain.Models
{
	public class Trip
	{
		public Trip()
		{
			TripItineraries = new HashSet<TripItinerary>();
			TravelerTrips = new HashSet<TravelerTrip>();
		}
		public int TripId { get; set; }
		public string Name { get; set; }
		public double EstimatedCost { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public virtual ICollection<TripItinerary> TripItineraries { get; set; }
		public virtual ICollection<TravelerTrip> TravelerTrips { get; set; }
	}
}
