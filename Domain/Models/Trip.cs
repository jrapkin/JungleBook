using System;
using System.Collections.Generic;

namespace Domain.Models
{
	public class Trip
	{
		public int TripId { get; set; }
		public string Name { get; set; }
		public double EstimatedCost { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public List<Destination> Destinations { get; set; }
		public List<UserProfile> UserProfiles { get; set; }
	}
}
