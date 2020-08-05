using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
	public class TripItinerary
	{
		public TripItinerary()
		{
			Destinations = new HashSet<Destination>();
			Days = new HashSet<Day>();
		}
		public int TripItineraryId { get; set; }
		public int TripId { get; set; }
		public DateTime ArrivalDate { get; set; }
		public DateTime DepartureDate { get; set; }
		public Trip Trip { get; set; }
		public virtual ICollection<Destination> Destinations { get; set; }
		public virtual ICollection<Day> Days { get; private set; }
	}
}
