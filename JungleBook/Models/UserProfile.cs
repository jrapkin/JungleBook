using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class UserProfile
	{
		[ForeignKey("ApplicationUser")]
		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		[ForeignKey("Trip")]
		public int TripId { get; set; }
		public Trip Trip { get; set; }

	}
}
