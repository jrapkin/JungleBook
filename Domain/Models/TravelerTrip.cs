using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class TravelerTrip
	{
		public int TravelerId { get; set; }
		public int? TripId { get; set; }		
		public Traveler Traveler { get; set; }
		public Trip Trip { get; set; }

	}
}
