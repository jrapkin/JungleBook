using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class Trip
	{
		public int TripId { get; set; }
		public double EstimatedCost { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		[NotMapped]
		public List<UserProfile> UserProfiles { get; set; }
	}
}
