using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JungleBook.Models
{
	public class Trip
	{
		public int TripId { get; set; }
		public double EstimatedCost { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public List<UserProfile> UserProfiles { get; set; }
	}
}
