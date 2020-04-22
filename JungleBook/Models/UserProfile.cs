using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class UserProfile
	{
		[ForeignKey("Traveler")]
		public int TravelerId { get; set; }
		public Traveler Traveler { get; set; }
		[ForeignKey("Trip")]
		public int? TripId { get; set; }
		public Trip Trip { get; set; }

	}
}
